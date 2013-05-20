using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CustomControls.Core.ViewModels;

namespace CustomControls.Droid.Controls
{
    public class ShapeTextView : TextView
    {
        private Shape _theShape;

        protected ShapeTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ShapeTextView(Context context) : base(context)
        {
        }

        public ShapeTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public ShapeTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public Shape TheShape
        {
            get { return _theShape; }
            set { _theShape = value;
                AdjustText();
            }
        }

        private void AdjustText()
        {
            Text = TheShape.ToString();
            switch (TheShape)
            {
                case Shape.Circle:
                    SetTextColor(Color.Aqua);
                    break;
                case Shape.Square:
                    SetTextColor(Color.Red);
                    break;
                case Shape.Triangle:
                    SetTextColor(Color.Magenta);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}