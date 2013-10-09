using System;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;
using CustomBinding.Droid.Controls;

namespace CustomBinding.Droid
{
    public class BinaryEditFooTargetBinding : MvxAndroidTargetBinding
    {
        protected  BinaryEdit BinaryEdit
        {
            get { return (BinaryEdit) Target; }
        }

        public BinaryEditFooTargetBinding(BinaryEdit target) : base(target)
        {
        }

        public override void SubscribeToEvents()
        {
            BinaryEdit.MyCountChanged += TargetOnMyCountChanged;
        }

        private void TargetOnMyCountChanged(object sender, EventArgs eventArgs)
        {
            var target = Target as BinaryEdit;

            if (target == null)
                return;

            var value = target.GetCount();
            FireValueChanged(value);
        }

        protected override void SetValueImpl(object target, object value)
        {
            var binaryEdit = (BinaryEdit)target;
            binaryEdit.SetThat((int)value);
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