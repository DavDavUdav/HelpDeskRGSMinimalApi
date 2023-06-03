namespace HelpDeskClientUser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btn_log_in = new System.Windows.Forms.Button();
            this.cb_typeUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_log_in
            // 
            this.btn_log_in.Location = new System.Drawing.Point(12, 148);
            this.btn_log_in.Name = "btn_log_in";
            this.btn_log_in.Size = new System.Drawing.Size(160, 30);
            this.btn_log_in.TabIndex = 1;
            this.btn_log_in.Text = "Вход";
            this.btn_log_in.UseVisualStyleBackColor = true;
            this.btn_log_in.Click += new System.EventHandler(this.btn_log_in_Click);
            // 
            // cb_typeUser
            // 
            this.cb_typeUser.FormattingEnabled = true;
            this.cb_typeUser.Items.AddRange(new object[] {
            "Администратор",
            "Сотрудник",
            "Клиент"});
            this.cb_typeUser.Location = new System.Drawing.Point(12, 29);
            this.cb_typeUser.Name = "cb_typeUser";
            this.cb_typeUser.Size = new System.Drawing.Size(160, 23);
            this.cb_typeUser.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "выберите тип пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логин";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(12, 73);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(160, 23);
            this.tb_login.TabIndex = 5;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(12, 119);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(160, 23);
            this.tb_password.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 193);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_typeUser);
            this.Controls.Add(this.btn_log_in);
            this.Name = "Form1";
            this.Text = "авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btn_log_in;
        private ComboBox cb_typeUser;
        private Label label1;
        private Label label2;
        private TextBox tb_login;
        private TextBox tb_password;
        private Label label3;
    }
}