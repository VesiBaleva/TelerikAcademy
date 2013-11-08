using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PrimeCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void OnFirstButtonClick(object sender, RoutedEventArgs e)
        {
            long lowerRange = long.Parse(LowerRangeFirst.Text);
            long upperRange = long.Parse(UpperRangeFirst.Text);
            bool prime = FirstToggle.IsOn;
            PrimesOperator oper1 = new PrimesOperator();
            string result = await oper1.FindPrimeOrNotInPrimesConcatenationsAsync(lowerRange, upperRange, prime);
            if (string.IsNullOrEmpty(result))
            {
                result = "No numbers found";
            }
            ResultBlockFirst.Text = result;
        }

        private async void OnSecondButtonClick(object sender, RoutedEventArgs e)
        {
            int lowerRange = int.Parse(LowerRangeSecond.Text);
            int upperRange = int.Parse(UpperRangeSecond.Text);
            bool prime = SecondToggle.IsOn;
            PrimesOperator oper2 = new PrimesOperator();
            string result = await oper2.FindPrimeOrNotInPrimesConcatenationsAsync(lowerRange, upperRange, prime);
            if (string.IsNullOrEmpty(result))
            {
                result = "No numbers found";
            }
            ResultBlockSecond.Text = result;
        }

        private async void OnThirdButtonClick(object sender, RoutedEventArgs e)
        {
            int lowerRange = int.Parse(LowerRangeThird.Text);
            int upperRange = int.Parse(UpperRangeThird.Text);
            bool prime = ThirdToggle.IsOn;
            PrimesOperator oper3 = new PrimesOperator();
            string result = await oper3.FindPrimeOrNotInPrimesConcatenationsAsync(lowerRange, upperRange, prime);
            if (string.IsNullOrEmpty(result))
            {
                result = "No numbers found";
            }
            ResultBlockThird.Text = result;
        }

        private async void OnForthButtonClick(object sender, RoutedEventArgs e)
        {
            int lowerRange = int.Parse(LowerRangeForth.Text);
            int upperRange = int.Parse(UpperRangeForth.Text);
            bool prime = ForthToggle.IsOn;
            PrimesOperator oper4 = new PrimesOperator();
            string result = await oper4.FindPrimeOrNotInPrimesConcatenationsAsync(lowerRange, upperRange, prime);
            if (string.IsNullOrEmpty(result))
            {
                result = "No numbers found";
            }
            ResultBlockForth.Text = result;
        }
    }
}
