using Android.App;
using Android.Content;

namespace Waiting.Droid.Views
{
    public class BindableProgress
    {
        private readonly Context _context;

        public BindableProgress(Context context)
        {
            _context = context;
        }

        private ProgressDialog _dialog;

        public bool Visible
        {
            get { return _dialog != null; }
            set
            {
                if (value == Visible)
                    return;

                if (value)
                {
                    _dialog = new ProgressDialog(_context);
                    _dialog.SetTitle("Working...");
                    _dialog.Show();
                }
                else
                {
                    _dialog.Hide();
                    _dialog = null;
                }
            }
        }
    }
}