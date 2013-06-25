using System;
using Acme.Plugin.Html;
using Cirrious.MvvmCross.ViewModels;

namespace Injection.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IScreenSize _screenSize;
        private readonly IEncode _encode;

        public FirstViewModel(IScreenSize screenSize, IEncode encode)
        {
            _screenSize = screenSize;
            Height = _screenSize.Height;
            Width = _screenSize.Width;

            _encode = encode;
            Foo = _encode.Encode(DateTime.Now.ToString());
        }

        private string _foo;
        public string Foo
        {
            get { return _foo; }
            set { _foo = value; RaisePropertyChanged(() => Foo); }
        }
        
        private double _height;
        public double Height
        {
            get { return _height; }
            set { _height = value; RaisePropertyChanged(() => Height); }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set { _width = value; RaisePropertyChanged(() => Width); }
        }
        
    }
}
