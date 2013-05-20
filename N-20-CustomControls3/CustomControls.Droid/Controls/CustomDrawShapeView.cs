using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = Android.Graphics.Color;

namespace CustomControls.Droid.Controls
{
    public class CustomDrawShapeView : View
    {
        private Shape _theShape;

        protected CustomDrawShapeView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomDrawShapeView(Context context) : base(context)
        {
        }

        public CustomDrawShapeView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomDrawShapeView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public Shape TheShape
        {
            get { return _theShape; }
            set { _theShape = value; Invalidate(); }
        }

        public override void Draw(Android.Graphics.Canvas canvas)
        {
            base.Draw(canvas);

            var rect = new RectF(0,0,300,300);
            switch (TheShape)
            {
                case Shape.Circle:
                    canvas.DrawOval(rect, new Paint() { Color = Color.Aqua });
                    break;
                case Shape.Square:
                    canvas.DrawRect(rect, new Paint() { Color = Color.Red });
                    break;
                case Shape.Triangle:
                    var path = new Path();
                    path.MoveTo(rect.CenterX(), 0);
                    path.LineTo(0, rect.Height());
                    path.LineTo(rect.Width(), rect.Height());
                    path.Close();

                    var paint = new Paint() {Color = Color.Magenta};
                    paint.SetStyle(Paint.Style.Fill);
                    canvas.DrawPath(path, paint);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}