using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanks
{
    public partial class VMainMenu : Form
    {
        public VMainMenu()
        {
            InitializeComponent();
        }

        private void ButtonPlayWithOtherPlayerClick(object sender, EventArgs e)
        {
            mController.OnPlayWithOtherPlayerButtonPushed();
        }

        private void ButtonPlayWithComputerClick(object sender, EventArgs e)
        {
            mController.OnPlayWithComputerButtonPushed();
        }
    }
}
