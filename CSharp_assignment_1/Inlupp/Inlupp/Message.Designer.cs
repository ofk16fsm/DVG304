namespace Inlupp
{
    partial class Message
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
            this.cmdInlupp = new System.Windows.Forms.Button();
            this.cmdRst = new System.Windows.Forms.Button();
            this.cmdClean = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdInlupp
            // 
            this.cmdInlupp.Location = new System.Drawing.Point(12, 36);
            this.cmdInlupp.Name = "cmdInlupp";
            this.cmdInlupp.Size = new System.Drawing.Size(116, 23);
            this.cmdInlupp.TabIndex = 0;
            this.cmdInlupp.Text = "Bläddra för shapefiler";
            this.cmdInlupp.UseVisualStyleBackColor = true;
            this.cmdInlupp.Click += new System.EventHandler(this.cmdInlupp_Click);
            // 
            // cmdRst
            // 
            this.cmdRst.Location = new System.Drawing.Point(12, 95);
            this.cmdRst.Name = "cmdRst";
            this.cmdRst.Size = new System.Drawing.Size(163, 23);
            this.cmdRst.TabIndex = 1;
            this.cmdRst.Text = "Klicka för att se restauranger";
            this.cmdRst.UseVisualStyleBackColor = true;
            this.cmdRst.Click += new System.EventHandler(this.cmdRst_Click);
            // 
            // cmdClean
            // 
            this.cmdClean.Location = new System.Drawing.Point(12, 216);
            this.cmdClean.Name = "cmdClean";
            this.cmdClean.Size = new System.Drawing.Size(163, 23);
            this.cmdClean.TabIndex = 2;
            this.cmdClean.Text = "Klicka för att rensa selektion";
            this.cmdClean.UseVisualStyleBackColor = true;
            this.cmdClean.Click += new System.EventHandler(this.cmdClean_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(12, 158);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(163, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Klicka för att spara shapefilen";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 276);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClean);
            this.Controls.Add(this.cmdRst);
            this.Controls.Add(this.cmdInlupp);
            this.Name = "Message";
            this.Text = "Message";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdInlupp;
        private System.Windows.Forms.Button cmdRst;
        private System.Windows.Forms.Button cmdClean;
        private System.Windows.Forms.Button cmdSave;
    }
}