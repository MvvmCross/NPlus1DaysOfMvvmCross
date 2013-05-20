using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace CustomControls.Core.ViewModels
{
    public enum Shape
    {
        Circle,
        Square,
        Triangle
    }

    public class FirstViewModel 
		: MvxViewModel
    {
        private Shape _shape;
        public Shape Shape
        {
            get { return _shape; }
            set { _shape = value; RaisePropertyChanged(() => Shape); }
        }

        private List<Shape> _list = new List<Shape>()
            {
                Shape.Circle, Shape.Square, Shape.Triangle
            };

        public List<Shape> List
        {
            get { return _list; }
            set { _list = value; RaisePropertyChanged(() => List); }
        }        
    }
}
