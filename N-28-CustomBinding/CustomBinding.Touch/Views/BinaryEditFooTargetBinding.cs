using System;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;

namespace CustomBinding.Touch.Views
{
    public class BinaryEditFooTargetBinding : MvxTargetBinding
    {
        public BinaryEditFooTargetBinding(BinaryEdit target)
            : base(target)
        {
            target.MyCountChanged += TargetOnMyCountChanged;
        }

        private void TargetOnMyCountChanged(object sender, EventArgs eventArgs)
        {
            var target = Target as BinaryEdit;

            if (target == null)
                return;

            var value = target.GetCount();
            FireValueChanged(value);
        }

        public override void SetValue(object value)
        {
            var target = Target as BinaryEdit;

            if (target == null)
                return;

            target.SetThat((int)value);
        }

        public override Type TargetType
        {
            get { return typeof(int); }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var target = Target as BinaryEdit;
                if (target != null)
                {
                    target.MyCountChanged -= TargetOnMyCountChanged;
                }
            }
            base.Dispose(isDisposing);
        }
    }
}