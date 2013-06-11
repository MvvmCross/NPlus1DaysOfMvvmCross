// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cirrious.CrossCore.Converters;

namespace Awesome.Core.ViewModels
{
    using System.Windows.Input;

    using Cirrious.MvvmCross.ViewModels;


    public class LengthValueConverter
        : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Length;
        }
    }

    /// <summary>
    /// Define the FirstViewModel type.
    /// </summary>
    public class FirstViewModel : BaseViewModel
    {
        /// <summary>
        /// Backing field for my property.
        /// </summary>
        private string myProperty = "Mvx Ninja Coder!";

        /// <summary>
        ///  Backing field for my command.
        /// </summary>
        private MvxCommand myCommand;

        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        public string MyProperty
        {
            get
            {
                return this.myProperty;
            }

            set
            {
                this.myProperty = value;
                this.RaisePropertyChanged(() => this.MyProperty);
            }
        }

        /// <summary>
        /// Gets My Command.
        /// <para>
        /// An example of a command and how to navigate to another view model
        /// Note the ViewModel inside of ShowViewModel needs to change!
        /// </para>
        /// </summary>
        public ICommand MyCommand
        {
            get
            {
                this.myCommand = this.myCommand ?? new MvxCommand(() => MyProperty = "Pwned");
                return this.myCommand;
            }
        }
    }
}
