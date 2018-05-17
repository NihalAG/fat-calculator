//Apoorva Solanki
//    Harkeerat Kaur
//    Kiranpreet Kaur
//    Jiwant Singh
//    Nihal Ahmed Gesudraz

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace FatPercentageCalculator
{
    class FatCalc : INotifyPropertyChanged
    {
        string ErrMsg, ErrMsgTwo;
        Decimal noOfCal;
        Decimal CalPctage; // for the calculating percentage 
        Decimal calPct; // to calculate angle
        Decimal calFromFat;
        String meterValue;
        String angle = "-120";
        bool checkedStatus;

        public Decimal NoOfCal
        {
            get
            {
                return noOfCal;
            }
            set
            {
                noOfCal = GetNumberOfCalories(value);
                propertyChanged();
            }
        }

        public Decimal CalPct
        {
            get
            {
                return calPct;
            }
            set
            {
                calPct = GetPercentageOfCaloriesFromFat(value);
                propertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return ErrMsg;
            }
            set
            {
                ErrMsg = value;
                propertyChanged();
            }
        }

        public string ErrorMessageTwo
        {
            get
            {
                return ErrMsgTwo;
            }
            set
            {
                ErrMsgTwo = value;
                propertyChanged();
            }
        }

        public String Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = CalcAngle().ToString();
                propertyChanged();
            }
        }

        public String MeterValue
        {
            get
            {
                return meterValue;
            }
            set
            {
                meterValue = this.LowFatCheck();
                propertyChanged();
            }
        }

        public bool CheckedStatus
        {
            get
            {
                return checkedStatus;
            }
            set
            {
                checkedStatus = value;
            }
        }

        private Decimal GetNumberOfCalories(Decimal gramsFat)
        {
            calFromFat = gramsFat * 9;
            return calFromFat;
        }

        private Decimal GetPercentageOfCaloriesFromFat(Decimal TotCals)
        {
            //GramsOfFat Gives Zero On Start. 
            //This just sets the value to 1. So we do not get a divide by zero error.
            if (TotCals == 0)
                TotCals = 1;
            CalPctage = Math.Round((calFromFat / TotCals), 2) * 100;
            return CalPctage;
        }

        public String LowFatCheck()
        {
            if (CalPctage <= 30)
            {
                return CalPctage.ToString() + "%"+(CheckedStatus == true? " Low Fat":"");
            }
            return CalPctage.ToString() + "%";
        }

        public String CalcAngle()
        {
            Decimal angle = ((CalPctage / 100) * 240) - 120;
            return angle.ToString();
        }

        //Checks If It Is a Number Or A Decimal Using Regular Expressions
        public Boolean IsValidPositiveNonBlankValue(string Val)
        {
            return Regex.IsMatch(Val, @"^[0-9,\.]+$");
        }

        public Boolean IsValueGreaterThanCalories(string Val)
        {
            Decimal TotCalories;
            Decimal.TryParse(Val, out TotCalories);
            return (TotCalories >= calFromFat) ? true : false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
