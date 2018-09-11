using tanks.controller;

namespace tanks.view
{
    public partial class VGameWindow
    {
        CGameWindow mController;

        private const int WINDOW_WIDTH = 1600;
        private const int WINDOW_HIGHT = 900;


        
        

        public void PrepareDisplay()
        {
            Show();
            SetBounds(
                10,
                10,
                WINDOW_WIDTH,
                WINDOW_HIGHT);
        }




        public void SetController(CGameWindow iController)
        {
            mController = iController;
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "VGameWindow";
        }

        #endregion
    }
}