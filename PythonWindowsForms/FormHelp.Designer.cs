namespace PythonWindowsForms
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.textBoxStepsOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxStepsOutput
            // 
            this.textBoxStepsOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStepsOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStepsOutput.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxStepsOutput.Location = new System.Drawing.Point(0, 0);
            this.textBoxStepsOutput.Margin = new System.Windows.Forms.Padding(15);
            this.textBoxStepsOutput.MaxLength = 100000;
            this.textBoxStepsOutput.Multiline = true;
            this.textBoxStepsOutput.Name = "textBoxStepsOutput";
            this.textBoxStepsOutput.ReadOnly = true;
            this.textBoxStepsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStepsOutput.Size = new System.Drawing.Size(520, 253);
            this.textBoxStepsOutput.TabIndex = 0;
            this.textBoxStepsOutput.TabStop = false;
            this.textBoxStepsOutput.Text = resources.GetString("textBoxStepsOutput.Text");
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 253);
            this.Controls.Add(this.textBoxStepsOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHelp";
            this.ShowIcon = false;
            this.Text = "Помощь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxStepsOutput;
    }
}