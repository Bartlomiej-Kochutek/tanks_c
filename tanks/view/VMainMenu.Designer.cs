
using tanks.controller;


namespace tanks
{
    public partial class VMainMenu
    {
        private CMainMenu controller;



        public void display()
        {
            System.Windows.Forms.Application.Run(this);
            
            /*
            shell.setLayout(new FillLayout(1));
            shell.pack();
            shell.open();
            while (!shell.isDisposed())
            {
                if (!display.readAndDispatch())
                    display.sleep();
            }
            display.dispose();*/
        }






        public CMainMenu getController()
        {
            return controller;
        }
        public void setController(CMainMenu iController)
        {
            controller = iController;
        }






        private System.ComponentModel.IContainer components = null;

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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(42, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(152, 44);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "GRAJ";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(42, 62);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(152, 44);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "WYJŚCIE";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 157);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPlay);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonExit;
    }
}

