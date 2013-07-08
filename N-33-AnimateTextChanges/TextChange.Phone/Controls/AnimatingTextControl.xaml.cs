using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TextChange.Phone.Controls
{
    public partial class AnimatingTextControl : UserControl
    {
        public AnimatingTextControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AnimatingTextProperty =
            DependencyProperty.Register("AnimatingText", typeof (string), typeof (AnimatingTextControl), new PropertyMetadata(default(string), OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AnimatingTextControl;
            var newText = e.NewValue as string;

            var animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            animation.Duration = new Duration(TimeSpan.FromMilliseconds(200));

            animation.Completed += (sender, args) =>
                {
                    control.TheTextBlock.Text = newText;
                    var fadeInAnimation = new DoubleAnimation();
                    fadeInAnimation.From = 0.0;
                    fadeInAnimation.To = 1.0;
                    fadeInAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(200));

                    Storyboard.SetTarget(fadeInAnimation, control);
                    Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity"));

                    var storyboard2 = new Storyboard();
                    storyboard2.Children.Add(fadeInAnimation);
                    storyboard2.Begin();
                };

            Storyboard.SetTarget(animation, control);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        public string AnimatingText
        {
            get { return (string) GetValue(AnimatingTextProperty); }
            set { SetValue(AnimatingTextProperty, value); }
        }   
    }
}
