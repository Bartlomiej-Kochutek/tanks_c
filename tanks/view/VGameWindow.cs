using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanks.view
{
    public partial class VGameWindow : Form
    {
        public VGameWindow()
        {
            InitializeComponent();

            KeyDown += new KeyEventHandler(ThisKeyDown);
            KeyUp += new KeyEventHandler(ThisKeyUp);

            Application.Idle += HandleApplicationIdle;
        }
        private void ThisKeyDown(object iSender, System.Windows.Forms.KeyEventArgs iKeyEventArgs)
        {
            mController.OnKeyPressed(iKeyEventArgs.KeyCode);
        }
        private void ThisKeyUp(object iSender, System.Windows.Forms.KeyEventArgs iKeyEventArgs)
        {
            mController.OnKeyReleased(iKeyEventArgs.KeyCode);
        }
        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Update();

                mController.DoNextGameLoopIteration();
            }
        }
        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, 0, 0, 0) == 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        private static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
    }
}
