using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shape = CustomControls.Core.ViewModels.Shape;

namespace CustomControls.Phone.Controls
{
    public partial class ShapeControl : UserControl
    {
        public static readonly DependencyProperty TheShapeDependencyProperty = DependencyProperty.Register(
            "TheShape", typeof(Shape), typeof(ShapeControl), new PropertyMetadata(Shape.Circle, OnTheShapeChanged));

        private static void OnTheShapeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // nothing to do...
            (d as ShapeControl).Update();
        }

        public Shape TheShape
        {
            get { return (Shape)base.GetValue(TheShapeDependencyProperty); }
            set { base.SetValue(TheShapeDependencyProperty, value); }
        }

        public ShapeControl()
        {
            InitializeComponent();
        }

        private void Update()
        {
            TheCanvas.Children.Clear();

            switch (TheShape)
            {
                case Shape.Circle:
                    TheCanvas.Children.Add(new Ellipse() { Fill = new SolidColorBrush(Colors.Cyan), Width = 200, Height = 200});
                    break;
                case Shape.Square:
                    TheCanvas.Children.Add(new Rectangle() { Fill = new SolidColorBrush(Colors.Red), Width = 200, Height = 200});
                    break;
                case Shape.Triangle:
                    var poly = new Polygon();
                    poly.Points = new PointCollection() {new Point(100, 0), new Point(0, 200), new Point(200, 200)};
                    poly.Fill = new SolidColorBrush(Colors.Magenta);
                    TheCanvas.Children.Add(poly);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
