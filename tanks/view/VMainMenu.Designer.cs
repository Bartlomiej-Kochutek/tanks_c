
using tanks.controller;


namespace tanks
{
    public partial class VMainMenu
    {
        private CMainMenu mController;



        public void Display()
        {
            System.Windows.Forms.Application.Run(this);
        }



        public CMainMenu Controller { get => mController; set => mController = value; }



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
            this.buttonPlayWithOtherPlayer = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonPlayWithComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlayWithOtherPlayer
            // 
            this.buttonPlayWithOtherPlayer.Location = new System.Drawing.Point(42, 12);
            this.buttonPlayWithOtherPlayer.Name = "buttonPlayWithOtherPlayer";
            this.buttonPlayWithOtherPlayer.Size = new System.Drawing.Size(152, 44);
            this.buttonPlayWithOtherPlayer.TabIndex = 0;
            this.buttonPlayWithOtherPlayer.Text = "GRAJ Z INNYM GRACZEM";
            this.buttonPlayWithOtherPlayer.UseVisualStyleBackColor = true;
            this.buttonPlayWithOtherPlayer.Click += new System.EventHandler(this.ButtonPlayWithOtherPlayerClick);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(42, 106);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(152, 44);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "WYJŚCIE";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonPlayWithComputer
            // 
            this.buttonPlayWithComputer.Location = new System.Drawing.Point(42, 59);
            this.buttonPlayWithComputer.Name = "buttonPlayWithComputer";
            this.buttonPlayWithComputer.Size = new System.Drawing.Size(152, 41);
            this.buttonPlayWithComputer.TabIndex = 1;
            this.buttonPlayWithComputer.Text = "GRAJ Z KOMPUTEREM";
            this.buttonPlayWithComputer.UseVisualStyleBackColor = true;
            this.buttonPlayWithComputer.Click += new System.EventHandler(this.ButtonPlayWithComputerClick);
            // 
            // VMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 157);
            this.Controls.Add(this.buttonPlayWithComputer);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPlayWithOtherPlayer);
            this.Name = "VMainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayWithOtherPlayer;
        private System.Windows.Forms.Button buttonPlayWithComputer;
        private System.Windows.Forms.Button buttonExit;
    }
}

