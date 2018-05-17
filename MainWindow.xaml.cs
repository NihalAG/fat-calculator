    //Apoorva Solanki
    //Harkeerat Kaur
    //Kiranpreet Kaur
    //Jiwant Singh
    //Nihal Ahmed Gesudraz

using System;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace FatPercentageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FatCalc fc = new FatCalc();
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = fc;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            TxtGof.Text = "";
            TxtCalTot.Text = "";
            fc.NoOfCal = 0;
            fc.CalPct = 0;
            fc.Angle = "-120";
            fc.MeterValue = "";
            DisplayErrorMessage("");
            DisplaySecondErrorMessage("");
            ChkCalcLow.IsChecked = false;
        }

        //Calculates the percentage.
        private void Calculate(object sender, RoutedEventArgs e)
        {
            Button TxtCal = sender as Button;
            Console.WriteLine(TxtCalTot.Text);
            if (!fc.IsValidPositiveNonBlankValue(TxtGof.Text))
            {
                DisplayErrorMessage("Enter Non Zero Positive Values.");
            }

            if (!fc.IsValidPositiveNonBlankValue(TxtCalTot.Text))
            {
                DisplaySecondErrorMessage("Enter Non Zero Positive Values.");

            }
            else if (!fc.IsValueGreaterThanCalories(TxtCalTot.Text))
            {
                DisplaySecondErrorMessage("Invalid Total Fat Calories.");
            }
            else
            {
                fc.CalPct = Convert.ToDecimal(TxtCalTot.Text);
                fc.Angle = fc.CalcAngle();
                fc.MeterValue = fc.LowFatCheck();
                DisplaySecondErrorMessage("");
            }
        }

        private void IsFatNeeded(object sender, RoutedEventArgs e)
        {
            fc.CheckedStatus = true;
        }

        private void IsFatNotNeeded(object sender, RoutedEventArgs e)
        {
            fc.CheckedStatus = false;
        }

        private void CalcFatCal(object sender, RoutedEventArgs e)
        {
            TextBox TxtFat = sender as TextBox;
            if (fc.IsValidPositiveNonBlankValue(TxtFat.Text))
            {
                fc.NoOfCal = Convert.ToDecimal(TxtFat.Text);
                DisplayErrorMessage("");
            }
            else
            {
                DisplayErrorMessage("Enter Non Zero Positive Values.");
            }
        }

        private void ValidateFatCal(object sender, RoutedEventArgs e)
        {
            if (!fc.IsValidPositiveNonBlankValue(TxtCalTot.Text))
            {
                DisplaySecondErrorMessage("Enter Non Zero Positive Values.");
            }
            else if (!fc.IsValueGreaterThanCalories(TxtCalTot.Text))
            {
                DisplaySecondErrorMessage("Invalid Total Fat Calories.");
            }
            else
            {
                DisplaySecondErrorMessage("");
            }
        }

        private void DisplayErrorMessage(string Message)
        {
            fc.ErrorMessage = Message;
        }

        private void DisplaySecondErrorMessage(string Message)
        {
            fc.ErrorMessageTwo = Message;
        }
    }
}
