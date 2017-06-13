namespace AES
{
    partial class Form1
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
            this.InputTextbox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ResultTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptCheckbox = new System.Windows.Forms.CheckBox();
            this.DecryptCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // InputTextbox
            // 
            this.InputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextbox.Location = new System.Drawing.Point(12, 12);
            this.InputTextbox.Multiline = true;
            this.InputTextbox.Name = "InputTextbox";
            this.InputTextbox.Size = new System.Drawing.Size(698, 58);
            this.InputTextbox.TabIndex = 0;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(716, 33);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(105, 37);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ResultTextbox
            // 
            this.ResultTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTextbox.Location = new System.Drawing.Point(13, 136);
            this.ResultTextbox.Multiline = true;
            this.ResultTextbox.Name = "ResultTextbox";
            this.ResultTextbox.Size = new System.Drawing.Size(697, 57);
            this.ResultTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Result";
            // 
            // EncryptCheckbox
            // 
            this.EncryptCheckbox.AutoSize = true;
            this.EncryptCheckbox.Location = new System.Drawing.Point(12, 77);
            this.EncryptCheckbox.Name = "EncryptCheckbox";
            this.EncryptCheckbox.Size = new System.Drawing.Size(78, 21);
            this.EncryptCheckbox.TabIndex = 4;
            this.EncryptCheckbox.Text = "Encrypt";
            this.EncryptCheckbox.UseVisualStyleBackColor = true;
            // 
            // DecryptCheckbox
            // 
            this.DecryptCheckbox.AutoSize = true;
            this.DecryptCheckbox.Location = new System.Drawing.Point(117, 77);
            this.DecryptCheckbox.Name = "DecryptCheckbox";
            this.DecryptCheckbox.Size = new System.Drawing.Size(79, 21);
            this.DecryptCheckbox.TabIndex = 5;
            this.DecryptCheckbox.Text = "Decrypt";
            this.DecryptCheckbox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 211);
            this.Controls.Add(this.DecryptCheckbox);
            this.Controls.Add(this.EncryptCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultTextbox);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.InputTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextbox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox ResultTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EncryptCheckbox;
        private System.Windows.Forms.CheckBox DecryptCheckbox;
    }
}

