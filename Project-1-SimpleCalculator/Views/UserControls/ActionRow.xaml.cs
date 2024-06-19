using System.Windows.Controls;

namespace Project_1_SimpleCalculator.Views.UserControls
{
    public partial class ActionRow : UserControl
    {

        private string _action;
        public string Action
        {
            get { return _action; }
            set
            {
                _action = value;
                // Do not do this!!!
                btnAction.Content = _action;
            }
        }

        public ActionRow()
        {
            InitializeComponent();
        }
    }
}
