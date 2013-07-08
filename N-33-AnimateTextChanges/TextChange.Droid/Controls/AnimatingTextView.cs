using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace TextChange.Droid.Controls
{
    public class AnimatingTextView : TextView
    {
        protected AnimatingTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public AnimatingTextView(Context context) : base(context)
        {
        }

        public AnimatingTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public AnimatingTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
        }

        public string AnimatingText
        {
            get { return base.Text; }
            set
            {

                var animationFadeOut = new AlphaAnimation(1.0f, 0.0f);
                animationFadeOut.Duration = 200;
                animationFadeOut.AnimationEnd += (sender, args) =>
                    {
                        base.Text = value;
                        var animationFadeIn = new AlphaAnimation(0.0f, 1.0f);
                        animationFadeIn.Duration = 200;

                        this.Animation = animationFadeIn;
                    };
                this.Animation = animationFadeOut;
            }
        }
    }
}