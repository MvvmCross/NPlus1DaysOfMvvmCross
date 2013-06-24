using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Test.Core;
using Cirrious.MvvmCross.Views;
using Moq;
using NUnit.Framework;
using TipCalcTest.Core.Services;
using TipCalcTest.Core.ViewModels;

namespace TipCalcTest.Tests
{
    [TestFixture]
    public class FirstViewModelTests
        : MvxIoCSupportingTest
    {
        [Test]
        public void TestThatWhenSubTotalChangesThenTipIsRecalculated()
        {
            // Arrange
            base.ClearAll();

            var mockTipService = new Mock<ITipService>();
            mockTipService.Setup(t => t.Calc(It.IsAny<double>(), It.IsAny<int>()))
                          .Returns(42.0);

            var firstViewModel = new FirstViewModel(mockTipService.Object);

            // Act
            firstViewModel.SubTotal = 12;

            // Assert
            Assert.AreEqual(42.0, firstViewModel.Tip);
        }

        [Test]
        public void TestThatWhenGenerosityChangesThenTipIsRecalculated()
        {
            // Arrange
            base.ClearAll();

            var mockTipService = new Mock<ITipService>();
            mockTipService.Setup(t => t.Calc(It.IsAny<double>(), It.IsAny<int>()))
                          .Returns(37.0);

            var firstViewModel = new FirstViewModel(mockTipService.Object);

            // Act
            firstViewModel.Generosity = 12;

            // Assert
            Assert.AreEqual(37.0, firstViewModel.Tip);
        }

        [Test]
        public void TestThatWhenTipIsRecalculatedThenTipNotificationIsSent()
        {
            // Arrange
            base.ClearAll();

            var mockTipService = new Mock<ITipService>();
            mockTipService.Setup(t => t.Calc(It.IsAny<double>(), It.IsAny<int>()))
                          .Returns(19.0);

            var mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);

            var tipChangeCount = 0;
            var generosityChangeCount = 0;
            var subTotalChangeCount = 0;
            var firstViewModel = new FirstViewModel(mockTipService.Object);
            firstViewModel.PropertyChanged += (sender, args) =>
                {
                    switch (args.PropertyName)
                    {
                        case "Tip":
                            tipChangeCount++;
                            break;
                        case "SubTotal":
                            subTotalChangeCount++;
                            break;
                        case "Generosity":
                            generosityChangeCount++;
                            break;
                    }
                };

            // Act
            firstViewModel.Generosity = 12;

            // Assert
            Assert.AreEqual(1, tipChangeCount);
            Assert.AreEqual(0, subTotalChangeCount);
            Assert.AreEqual(1, generosityChangeCount);
        }

        [Test]
        public void TestThatPayCommandShowsPayViewModelWithCorrectTotal()
        {
            // Arrange
            base.ClearAll();

            var mockTipService = new Mock<ITipService>();
            mockTipService.Setup(t => t.Calc(It.IsAny<double>(), It.IsAny<int>()))
                          .Returns(19.0);

            var mockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);

            var firstViewModel = new FirstViewModel(mockTipService.Object);
            firstViewModel.SubTotal = 10;
            firstViewModel.Generosity = 12;

            // Act
            firstViewModel.PayCommand.Execute(null);

            // Assert
            Assert.AreEqual(1, mockDispatcher.Requests.Count);
            var request = mockDispatcher.Requests[0];
            Assert.AreEqual(typeof(PayViewModel), request.ViewModelType);
            Assert.AreEqual("29", request.ParameterValues["total"]);
        }
    }
}