namespace SqliteDB
{
    partial class dbForm
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.SelectedTextbox = new System.Windows.Forms.TextBox();
            this.AccountIDLabel = new System.Windows.Forms.Label();
            this.AccountIDTextbox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.DisplayNameLabel = new System.Windows.Forms.Label();
            this.DisplayNameTextbox = new System.Windows.Forms.TextBox();
            this.RolesLabel = new System.Windows.Forms.Label();
            this.RolesTextbox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid.Location = new System.Drawing.Point(29, 12);
            this.Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowTemplate.Height = 24;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(785, 150);
            this.Grid.TabIndex = 0;
            this.Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // SelectedTextbox
            // 
            this.SelectedTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTextbox.Location = new System.Drawing.Point(29, 171);
            this.SelectedTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectedTextbox.Multiline = true;
            this.SelectedTextbox.Name = "SelectedTextbox";
            this.SelectedTextbox.Size = new System.Drawing.Size(785, 50);
            this.SelectedTextbox.TabIndex = 1;
            // 
            // AccountIDLabel
            // 
            this.AccountIDLabel.AutoSize = true;
            this.AccountIDLabel.Location = new System.Drawing.Point(29, 258);
            this.AccountIDLabel.Name = "AccountIDLabel";
            this.AccountIDLabel.Size = new System.Drawing.Size(72, 17);
            this.AccountIDLabel.TabIndex = 2;
            this.AccountIDLabel.Text = "AccountID";
            // 
            // AccountIDTextbox
            // 
            this.AccountIDTextbox.Enabled = false;
            this.AccountIDTextbox.Location = new System.Drawing.Point(131, 255);
            this.AccountIDTextbox.Name = "AccountIDTextbox";
            this.AccountIDTextbox.Size = new System.Drawing.Size(184, 22);
            this.AccountIDTextbox.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(28, 295);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(73, 17);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(131, 293);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(184, 22);
            this.UsernameTextbox.TabIndex = 5;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(28, 329);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(69, 17);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(131, 330);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(184, 22);
            this.PasswordTextbox.TabIndex = 7;
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoSize = true;
            this.DisplayNameLabel.Location = new System.Drawing.Point(28, 370);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(91, 17);
            this.DisplayNameLabel.TabIndex = 8;
            this.DisplayNameLabel.Text = "DisplayName";
            // 
            // DisplayNameTextbox
            // 
            this.DisplayNameTextbox.Location = new System.Drawing.Point(132, 370);
            this.DisplayNameTextbox.Name = "DisplayNameTextbox";
            this.DisplayNameTextbox.Size = new System.Drawing.Size(183, 22);
            this.DisplayNameTextbox.TabIndex = 9;
            // 
            // RolesLabel
            // 
            this.RolesLabel.AutoSize = true;
            this.RolesLabel.Location = new System.Drawing.Point(30, 409);
            this.RolesLabel.Name = "RolesLabel";
            this.RolesLabel.Size = new System.Drawing.Size(44, 17);
            this.RolesLabel.TabIndex = 10;
            this.RolesLabel.Text = "Roles";
            // 
            // RolesTextbox
            // 
            this.RolesTextbox.Location = new System.Drawing.Point(132, 409);
            this.RolesTextbox.Name = "RolesTextbox";
            this.RolesTextbox.Size = new System.Drawing.Size(183, 22);
            this.RolesTextbox.TabIndex = 11;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(132, 464);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 34);
            this.UpdateButton.TabIndex = 12;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(240, 464);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 34);
            this.NewButton.TabIndex = 13;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(34, 464);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 34);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(20, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 211);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Control";
            // 
            // dbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 510);
            this.Controls.Add(this.RolesTextbox);
            this.Controls.Add(this.RolesLabel);
            this.Controls.Add(this.DisplayNameTextbox);
            this.Controls.Add(this.DisplayNameLabel);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.AccountIDTextbox);
            this.Controls.Add(this.AccountIDLabel);
            this.Controls.Add(this.SelectedTextbox);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "dbForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TextBox SelectedTextbox;
        private System.Windows.Forms.Label AccountIDLabel;
        private System.Windows.Forms.TextBox AccountIDTextbox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label DisplayNameLabel;
        private System.Windows.Forms.TextBox DisplayNameTextbox;
        private System.Windows.Forms.Label RolesLabel;
        private System.Windows.Forms.TextBox RolesTextbox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

