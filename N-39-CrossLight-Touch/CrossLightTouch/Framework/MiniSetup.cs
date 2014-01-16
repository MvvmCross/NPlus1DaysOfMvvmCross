using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Binding.Touch;

namespace CrossLightTouch.Framework
{
    public class MiniSetup
    {
        public static readonly MiniSetup Instance = new MiniSetup();

        public void EnsureInit()
        {
            if (MvxSimpleIoCContainer.Instance != null)
                return;

            var ioc = MvxSimpleIoCContainer.Initialize();

            var builder = new MvxTouchBindingBuilder();
            builder.DoRegistration();
        }
    }
}
