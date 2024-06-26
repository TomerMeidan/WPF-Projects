using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_1_SimpleCalculator
{

    public partial class MainWindow : Window
    {
        private string _a = "";
        public string A
        {
            get { return _a; }
            set { _a = value; }
        }

        private string _b = "";

        public string B
        {
            get { return _b; }
            set { _b = value; }
        }

        public int C { get; set; }

        private string _action = "";

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        private bool firstNumberAndActionPressed = false;
        private bool calculationHappened = false;
        private bool firstTimeB = true;
        private bool firstTimeA = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void numberBtn_Click(object sender, RoutedEventArgs e)
        {
            Button numberButtonPressed = (Button)sender;

            if (!firstNumberAndActionPressed)
            {
                // Calculation happened
                if (calculationHappened && !firstTimeA)
                {
                    A = "";
                    firstTimeA = true;
                }
                A += numberButtonPressed.Content;

                // Update display textbox
                tbDisplay2.Text = A;
            }
            else
            {
                // Calculation happened
                if (calculationHappened && !firstTimeB)
                {
                    B = "";
                    firstTimeB = true;
                }

                B += numberButtonPressed.Content;

                // Update display textbox
                tbDisplay2.Text = B;
            }


        }

        private void actionBtn_Click(object sender, RoutedEventArgs e)
        {
            Button actionButtonPressed = (Button)sender;

            switch (actionButtonPressed.Content)
            {
                case "+":
                    chooseAction("+");
                    break;
                case "-":
                    chooseAction("-");
                    break;
                case "*":
                    chooseAction("*");
                    break;
                case "/":
                    chooseAction("/");
                    break;
                case "=":
                    if (Calculate())
                    {
                        tbDisplay1.Text = $"{A} {Action} {B} =";
                        tbDisplay2.Text = $"{C}";
                        A = $"{C}";
                        firstNumberAndActionPressed = false;
                        calculationHappened = true;
                        firstTimeB = false;
                    }
                    else
                    {
                        ResetParameters();
                    }

                    break;
                case "CLR":
                    // Clear displays and reset variables
                    ResetParameters();
                    break;
                default:
                    break;
            }

        }

        private void chooseAction(string action)
        {
            Action = action;
            firstNumberAndActionPressed = true;
            tbDisplay1.Text = $"{A} {Action}";
            firstTimeA = false;
        }

        private void ResetParameters()
        {
            firstNumberAndActionPressed = false;
            calculationHappened = false;
            firstTimeB = true;
            firstTimeA = true;
            tbDisplay1.Text = "";
            tbDisplay2.Text = "0";
            A = "";
            B = "";
            Action = "";
        }

        private bool Calculate()
        {
            switch (Action)
            {
                case "+":
                    C = Int32.Parse(A) + Int32.Parse(B);
                    break;
                case "-":
                    C = Int32.Parse(A) - Int32.Parse(B);
                    break;
                case "*":
                    C = Int32.Parse(A) * Int32.Parse(B);
                    break;
                case "/":
                    if (Int32.Parse(B) == 0)
                    {
                        MessageBox.Show("You cannot divide by zero!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    C = Int32.Parse(A) / Int32.Parse(B);
                    break;
                default:
                    C = Int32.Parse(A);
                    chooseAction("");
                    break;
            }

            return true;

        }




    }
}
