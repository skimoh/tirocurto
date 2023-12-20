
namespace CodeBehind.TiroCurto.Voador
{
    partial class frmGameStart
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGameStart));
            this.picGrama = new System.Windows.Forms.PictureBox();
            this.picMenino = new System.Windows.Forms.PictureBox();
            this.picCoronaTopo = new System.Windows.Forms.PictureBox();
            this.picCoronaBase = new System.Windows.Forms.PictureBox();
            this.scoreText = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGrama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCoronaTopo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCoronaBase)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrama
            // 
            this.picGrama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGrama.BackgroundImage")));
            this.picGrama.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picGrama.Location = new System.Drawing.Point(0, 412);
            this.picGrama.Margin = new System.Windows.Forms.Padding(2);
            this.picGrama.Name = "picGrama";
            this.picGrama.Size = new System.Drawing.Size(622, 41);
            this.picGrama.TabIndex = 0;
            this.picGrama.TabStop = false;
            // 
            // picMenino
            // 
            this.picMenino.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMenino.BackgroundImage")));
            this.picMenino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMenino.Location = new System.Drawing.Point(26, 188);
            this.picMenino.Margin = new System.Windows.Forms.Padding(2);
            this.picMenino.Name = "picMenino";
            this.picMenino.Size = new System.Drawing.Size(63, 47);
            this.picMenino.TabIndex = 1;
            this.picMenino.TabStop = false;
            // 
            // picCoronaTopo
            // 
            this.picCoronaTopo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picCoronaTopo.BackgroundImage")));
            this.picCoronaTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picCoronaTopo.Location = new System.Drawing.Point(219, 38);
            this.picCoronaTopo.Margin = new System.Windows.Forms.Padding(2);
            this.picCoronaTopo.Name = "picCoronaTopo";
            this.picCoronaTopo.Size = new System.Drawing.Size(67, 65);
            this.picCoronaTopo.TabIndex = 2;
            this.picCoronaTopo.TabStop = false;
            // 
            // picCoronaBase
            // 
            this.picCoronaBase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picCoronaBase.BackgroundImage")));
            this.picCoronaBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picCoronaBase.Location = new System.Drawing.Point(385, 257);
            this.picCoronaBase.Margin = new System.Windows.Forms.Padding(2);
            this.picCoronaBase.Name = "picCoronaBase";
            this.picCoronaBase.Size = new System.Drawing.Size(67, 65);
            this.picCoronaBase.TabIndex = 3;
            this.picCoronaBase.TabStop = false;
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.scoreText.Location = new System.Drawing.Point(8, 8);
            this.scoreText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(76, 23);
            this.scoreText.TabIndex = 4;
            this.scoreText.Text = "Score : 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 50;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // frmGameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(622, 453);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.picCoronaBase);
            this.Controls.Add(this.picCoronaTopo);
            this.Controls.Add(this.picMenino);
            this.Controls.Add(this.picGrama);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmGameStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuga do COVID";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGameStart_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGameStart_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picGrama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCoronaTopo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCoronaBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrama;
        private System.Windows.Forms.PictureBox picMenino;
        private System.Windows.Forms.PictureBox picCoronaTopo;
        private System.Windows.Forms.PictureBox picCoronaBase;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
    }
}

