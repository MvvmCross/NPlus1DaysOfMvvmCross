using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using CustomControls.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CustomControls.Phone.Controls
{
    public partial class ShapeTextBlock : UserControl
    {

        public static readonly DependencyProperty ShapeTextDependencyProperty = DependencyProperty.Register(
            "ShapeText", typeof (Shape), typeof (ShapeTextBlock), new PropertyMetadata(Shape.Circle, OnShapeTextChanged));

        private static void OnShapeTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // nothing to do...
            (d as ShapeTextBlock).Update();
        }

        public Shape ShapeText
        {
            get { return (Shape) base.GetValue(ShapeTextDependencyProperty); }
            set { base.SetValue(ShapeTextDependencyProperty, value); }
        }

        private void Update()
        {
            MyTextBlock.Text = ShapeText.ToString();
            switch (ShapeText)
            {
                case Shape.Circle:
                    MyTextBlock.Foreground = new SolidColorBrush(Colors.Cyan);
                    break;
                case Shape.Square:
                    MyTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                    break;
                case Shape.Triangle:
                    MyTextBlock.Foreground = new SolidColorBrush(Colors.Magenta);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ShapeTextBlock()
        {
            InitializeComponent();
        }
    }
}
