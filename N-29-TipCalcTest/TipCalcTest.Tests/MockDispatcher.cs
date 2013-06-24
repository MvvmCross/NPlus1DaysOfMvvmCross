using System;
using System.Collections.Generic;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace TipCalcTest.Tests
{
    public class MockDispatcher
        : MvxMainThreadDispatcher 
          , IMvxViewDispatcher
    {
        public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            throw new NotImplementedException();
        }
    }
}