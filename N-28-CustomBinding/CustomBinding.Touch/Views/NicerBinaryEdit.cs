using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CustomBinding.Touch.Views
{
    [Register("NicerBinaryEdit")]
    public class NicerBinaryEdit : UIView
    {
        private List<UISwitch> _boxes = new List<UISwitch>();

        public NicerBinaryEdit()
        {
            Initialize();
        }

        public NicerBinaryEdit(RectangleF bounds)
            : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.LightGray;

            for (var i = 0; i < 4; i++)
            {
                var box = new UISwitch(new RectangleF(10, 30 * i, 300, 30));
                AddSubview(box);
                _boxes.Add(box);
                box.ValueChanged += (sender, args) =>
                    {
                        UpdateCount();
                    };
            }
        }

        public int MyCount
        {
            get { return GetCount(); }
            set { SetThat(value); }
        }
        private bool _isUpdating;

        private void UpdateCount()
        {
            if (_isUpdating)
                return;

            var handler = MyCountChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler MyCountChanged;

        public int GetCount()
        {
            return _boxes.Count(b => b.On);
        }

        public void SetThat(int count)
        {
            _isUpdating = true;
            try
            {
                var currentCount = GetCount();

                if (count < 0 || count > 4)
                    return;

                while (count < currentCount)
                {
                    _boxes.First(b => b.On).On = false;
                    currentCount = GetCount();
                }
                while (count > currentCount)
                {
                    _boxes.First(b => !b.On).On = true;
                    currentCount = GetCount();
                }
            }
            finally
            {
                _isUpdating = false;
            }
        }
    }
}