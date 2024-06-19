using System.Windows.Controls;
using System.Windows;

namespace Project_1_SimpleCalculator.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NumberRow.xaml
    /// </summary>
    public partial class NumberRow : UserControl
    {
        private int _firstNumber;

        public int FirstNumber
        {
            get { return _firstNumber; }
            set { 
                _firstNumber = value;

                if (_firstNumber < 0)
                    btnFirst.Visibility = Visibility.Hidden;
                else
                // Do not do this at all
                btnFirst.Content = _firstNumber;
            }
        }

        private int _secondNumber;

        public int SecondNumber
        {
            get { return _secondNumber; }
            set
            {
                _secondNumber = value;

                if (_secondNumber < 0)
                    btnSecond.Visibility = Visibility.Hidden;
                else
                // Do not do this at all
                btnSecond.Content = SecondNumber;
            }
        }

        private int _thirdNumber;

        public int ThirdNumber
        {
            get { return _thirdNumber; }
            set
            {
                _thirdNumber = value;

                if (_thirdNumber < 0)
                    btnThird.Visibility = Visibility.Hidden;
                else
                // Do not do this at all
                btnThird.Content = _thirdNumber;
            }
            }

        public NumberRow()
        {
            InitializeComponent();
        }
    }
}
