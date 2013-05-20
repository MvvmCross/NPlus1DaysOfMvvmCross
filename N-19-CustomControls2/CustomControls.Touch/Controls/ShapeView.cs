using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CustomControls.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CustomControls.Touch.Controls
{
    [Register("ShapeView")]
    public class ShapeView : UIView
    {
        private Shape _theShape;

        public ShapeView()
        {            
        }

        public ShapeView(IntPtr h)
            : base(h)
        {
            
        }

        public ShapeView(RectangleF frame)
            : base(frame)
        {            
        }

        public Shape TheShape
        {
            get { return _theShape; }
            set { _theShape = value; SetNeedsDisplay(); }
        }

        public override void Draw(RectangleF rect)
        {
            base.Draw(rect);

            var context = UIGraphics.GetCurrentContext();
            context.SetFillColor(UIColor.White.CGColor);
            context.FillRect(rect);

            switch (TheShape)
            {
                case Shape.Circle:
                    context.SetFillColor(UIColor.Cyan.CGColor);
                    context.FillEllipseInRect(rect);
                    break;
                case Shape.Square:
                    context.SetFillColor(UIColor.Red.CGColor);
                    context.FillRect(rect);
                    break;
                case Shape.Triangle:
                    context.SetFillColor(UIColor.Magenta.CGColor);
                    context.BeginPath();
                    context.MoveTo(rect.Width/2, 0);
                    context.AddLineToPoint(0, rect.Height);
                    context.AddLineToPoint(rect.Width, rect.Height);
                    context.ClosePath();
                    context.FillPath();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
