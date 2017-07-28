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
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid.Location = new System.Drawing.Point(22, 10);
            this.Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowTemplate.Height = 24;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(589, 122);
            this.Grid.TabIndex = 0;
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // SelectedTextbox
            // 
            this.SelectedTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTextbox.Location = new System.Drawing.Point(22, 139);
            this.SelectedTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.SelectedTextbox.Multiline = true;
            this.SelectedTextbox.Name = "SelectedTextbox";
            this.SelectedTextbox.Size = new System.Drawing.Size(590, 41);
            this.SelectedTextbox.TabIndex = 1;
            // 
            // AccountIDLabel
            // 
            this.AccountIDLabel.AutoSize = true;
            this.AccountIDLabel.Location = new System.Drawing.Point(22, 210);
            this.AccountIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountIDLabel.Name = "AccountIDLabel";
            this.AccountIDLabel.Size = new System.Drawing.Size(58, 13);
            this.AccountIDLabel.TabIndex = 2;
            this.AccountIDLabel.Text = "AccountID";
            // 
            // AccountIDTextbox
            // 
            this.AccountIDTextbox.Enabled = false;
            this.AccountIDTextbox.Location = new System.Drawing.Point(98, 207);
            this.AccountIDTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.AccountIDTextbox.Name = "AccountIDTextbox";
            this.AccountIDTextbox.Size = new System.Drawing.Size(139, 20);
            this.AccountIDTextbox.TabIndex = 3;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(21, 240);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(98, 238);
            this.UsernameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(139, 20);
            this.UsernameTextbox.TabIndex = 5;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(21, 267);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(98, 268);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(139, 20);
            this.PasswordTextbox.TabIndex = 7;
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoSize = true;
            this.DisplayNameLabel.Location = new System.Drawing.Point(21, 301);
            this.DisplayNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(69, 13);
            this.DisplayNameLabel.TabIndex = 8;
            this.DisplayNameLabel.Text = "DisplayName";
            // 
            // DisplayNameTextbox
            // 
            this.DisplayNameTextbox.Location = new System.Drawing.Point(99, 301);
            this.DisplayNameTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.DisplayNameTextbox.Name = "DisplayNameTextbox";
            this.DisplayNameTextbox.Size = new System.Drawing.Size(138, 20);
            this.DisplayNameTextbox.TabIndex = 9;
            // 
            // RolesLabel
            // 
            this.RolesLabel.AutoSize = true;
            this.RolesLabel.Location = new System.Drawing.Point(22, 332);
            this.RolesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RolesLabel.Name = "RolesLabel";
            this.RolesLabel.Size = new System.Drawing.Size(34, 13);
            this.RolesLabel.TabIndex = 10;
            this.RolesLabel.Text = "Roles";
            // 
            // RolesTextbox
            // 
            this.RolesTextbox.Location = new System.Drawing.Point(99, 332);
            this.RolesTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.RolesTextbox.Name = "RolesTextbox";
            this.RolesTextbox.Size = new System.Drawing.Size(138, 20);
            this.RolesTextbox.TabIndex = 11;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(75, 377);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(56, 28);
            this.UpdateButton.TabIndex = 12;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(135, 377);
            this.NewButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(56, 28);
            this.NewButton.TabIndex = 13;
            this.NewButton.Text = "Save";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(15, 377);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(56, 28);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "New";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 189);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(248, 171);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Control";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(196, 377);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(67, 28);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 414);
            this.Controls.Add(this.DeleteButton);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "dbForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.dbForm_Load);
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
        private System.Windows.Forms.Button DeleteButton;
    }
}

