namespace Enigma
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonTranslate;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.FlowLayoutPanel panelRotorPositions;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonTranslate = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.panelRotorPositions = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(300, 23);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonTranslate
            // 
            this.buttonTranslate.Location = new System.Drawing.Point(318, 12);
            this.buttonTranslate.Name = "buttonTranslate";
            this.buttonTranslate.Size = new System.Drawing.Size(100, 23);
            this.buttonTranslate.TabIndex = 1;
            this.buttonTranslate.Text = "Translate";
            this.buttonTranslate.UseVisualStyleBackColor = true;
            this.buttonTranslate.Click += new System.EventHandler(this.ButtonTranslate_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 41);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(406, 23);
            this.textBoxOutput.TabIndex = 2;
            // 
            // panelRotorPositions
            // 
            this.panelRotorPositions.Location = new System.Drawing.Point(12, 70);
            this.panelRotorPositions.Name = "panelRotorPositions";
            this.panelRotorPositions.Size = new System.Drawing.Size(406, 60);
            this.panelRotorPositions.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 140);
            this.Controls.Add(this.panelRotorPositions);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonTranslate);
            this.Controls.Add(this.textBoxInput);
            this.Name = "MainForm";
            this.Text = "Enigma Debug";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
