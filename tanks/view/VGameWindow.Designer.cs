using tanks.controller;

namespace tanks.view
{
    public partial class VGameWindow
    {
        CGameWindow controller;

        private const int WINDOW_WIDTH = 1300;
        private const int WINDOW_HIGHT = 760;


        


        public void draw()
        {
        }

        public void prepareDisplay()
        {
            Show();
            SetBounds(
                10,
                10,
                WINDOW_WIDTH,
                WINDOW_HIGHT);

    //shell.addPaintListener(listener->controller.onRedraw());
    //shell.addKeyListener(new KeyAdapter()
//      {public void keyPressed(KeyEvent iEvent)
//      {
//          controller.onKeyPressed(iEvent.keyCode);
//      }
//      @Override
//public void keyReleased(KeyEvent iEvent)
//      {
//          controller.onKeyReleased(iEvent.keyCode);
//      }
//  });
        }




        public void setController(CGameWindow iController)
        {
            controller = iController;
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