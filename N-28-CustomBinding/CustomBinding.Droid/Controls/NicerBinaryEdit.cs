using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Util;
using Android.Widget;

namespace CustomBinding.Droid.Controls
{
    public class NicerBinaryEdit : LinearLayout
    {
        private List<CheckBox> _boxes = new List<CheckBox>();

        public NicerBinaryEdit(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            for (var i = 0; i < 4; i++)
            {
                var box = new CheckBox(context);
                AddView(box);
                _boxes.Add(box);
                box.CheckedChange += (sender, args) =>
                    {
                        UpdateCount();
                    };
            }
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

        public int MyCount
        {
            get
            {
                return _boxes.Count(b => b.Checked);
            }
            set
            {
                var count = value;
                _isUpdating = true;
                try
                {
                    var currentCount = MyCount;

                    if (count < 0 || count > 4)
                        return;

                    while (count < currentCount)
                    {
                        _boxes.First(b => b.Checked).Checked = false;
                        currentCount = MyCount;
                    }
                    while (count > currentCount)
                    {
                        _boxes.First(b => !b.Checked).Checked = true;
                        currentCount = MyCount;
                    }
                }
                finally
                {
                    _isUpdating = false;
                }
            }
        }
    }
}