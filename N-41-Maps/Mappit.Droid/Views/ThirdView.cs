using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Exceptions;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using Java.Lang;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for ThirdViewModel")]
    public class ThirdView : MvxFragmentActivity
    {
        private ZombieMarkerSet _zombieMarkers;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ThirdView);

            var viewModel = (ThirdViewModel) ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            _zombieMarkers = new ZombieMarkerSet(mapFragment.Map);

            var set = this.CreateBindingSet<ThirdView, ThirdViewModel>();
            set.Bind(_zombieMarkers)
               .For(m => m.ItemsSource)
               .To(vm => vm.Yarp);
            set.Apply();

        }


        public class ZombieMarkerSet
        {
            private IDisposable _token;
            private readonly List<ZombieWrapper> _markerWrappers = new List<ZombieWrapper>();

            private readonly GoogleMap _map;

            private IEnumerable _itemsSource;

            public ZombieMarkerSet(GoogleMap map)
            {
                _map = map;
            }

            public IEnumerable ItemsSource
            {
                get { return _itemsSource; }
                set
                {
                    if (_itemsSource == value)
                        return;

                    if (_token != null)
                    {
                        _token.Dispose();
                        _token = null;
                    }

                    _itemsSource = value;

                    var notify = _itemsSource as INotifyCollectionChanged;
                    if (notify != null)
                        _token = notify.WeakSubscribe(HandleChangedMessage);

                    ReloadAll();
                }
            }

            private void ReloadAll()
            {
                RemoveAll();
                AddAll();
            }

            private void AddAll()
            {
                if (_itemsSource == null)
                    return;

                foreach (var item in _itemsSource)
                {
                    var zomby = (Zombie) item;
                    AddZombie(zomby);
                }
            }

            private void AddZombie(Zombie zomby)
            {
                var options = new MarkerOptions();
                options.SetPosition(new LatLng(zomby.Location.Lat, zomby.Location.Lng));
                options.SetTitle(zomby.Name);
                var marker = _map.AddMarker(options);
                var markerWrapper = new ZombieWrapper(zomby, marker);
                _markerWrappers.Add(markerWrapper);
            }

            private void RemoveAll()
            {
                foreach (var markerWrapper in _markerWrappers)
                {
                    markerWrapper.Remove();
                    markerWrapper.Dispose();
                }
                _markerWrappers.Clear();
            }

            private void HandleChangedMessage(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems)
                        {
                            var zomby = (Zombie) item;
                            AddZombie(zomby);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var item in e.OldItems)
                        {
                            var zomby = (Zombie) item;
                            RemoveZombie(zomby);
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        // ignore this - not used
                        throw new MvxException("Zombies should not be moved");
                        break;
                    case NotifyCollectionChangedAction.Move:
                        // ignore this - not used
                        throw new MvxException("Zombies should not be moved");
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        ReloadAll();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            private void RemoveZombie(Zombie zomby)
            {
                var zombieWrapper = _markerWrappers.FirstOrDefault(mw => mw.Zombie == zomby);
                if (zombieWrapper == null)
                    throw new MvxException("Zombie not found");

                _markerWrappers.Remove(zombieWrapper);
                zombieWrapper.Dispose();
            }
        }


        public sealed class ZombieWrapper
            : IDisposable
        {
            private readonly Zombie _zombie;
            private readonly Marker _marker;
            private IDisposable _token;

            public ZombieWrapper(Zombie zombie, Marker marker)
            {
                _zombie = zombie;
                _marker = marker;

                _token = _zombie.WeakSubscribe(OnLocationChanged);
            }

            private void OnLocationChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName != "Location")
                    return;

                Position = new LatLng(_zombie.Location.Lat, _zombie.Location.Lng);
            }

            public LatLng Position
            {
                get { return _marker.Position; }
                set { _marker.Position = value; }
            }

            public Zombie Zombie
            {
                get { return _zombie; }
            }

            public void Remove()
            {
                _marker.Remove();
            }

            public void Dispose()
            {
                _token.Dispose();
            }
        }
    }
}