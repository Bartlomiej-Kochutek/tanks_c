using System;
using System.Windows.Forms;

namespace tanks
{
    public partial class VMainMenu : Form
    {
        public VMainMenu()
        {
            InitializeComponent();
        }



        private void ButtonPlayWithOtherPlayerClick(
            object iSender,
            EventArgs e)
        {
            mController.OnPlayWithOtherPlayerButtonPushed();
        }

        private void ButtonPlayWithComputerClick(
            object iSender,
            EventArgs iEventArgs)
        {
            mController.OnPlayWithComputerButtonPushed();
        }
    }
}
