namespace HelpDeskClientUser.Forms.TicketsForms
{
    partial class UserCheckTicketForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_status = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_prioritet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.tb_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_phoneNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_lastname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_firstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_status);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_prioritet);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_description);
            this.groupBox1.Controls.Add(this.tb_title);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заявка";
            // 
            // tb_status
            // 
            this.tb_status.Location = new System.Drawing.Point(141, 68);
            this.tb_status.Name = "tb_status";
            this.tb_status.ReadOnly = true;
            this.tb_status.Size = new System.Drawing.Size(129, 23);
            this.tb_status.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "статус";
            // 
            // tb_prioritet
            // 
            this.tb_prioritet.Location = new System.Drawing.Point(6, 68);
            this.tb_prioritet.Name = "tb_prioritet";
            this.tb_prioritet.ReadOnly = true;
            this.tb_prioritet.Size = new System.Drawing.Size(129, 23);
            this.tb_prioritet.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Приоритет заявки";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Описание заявки";
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(6, 121);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.ReadOnly = true;
            this.tb_description.Size = new System.Drawing.Size(562, 147);
            this.tb_description.TabIndex = 2;
            // 
            // tb_title
            // 
            this.tb_title.Location = new System.Drawing.Point(141, 19);
            this.tb_title.Name = "tb_title";
            this.tb_title.ReadOnly = true;
            this.tb_title.Size = new System.Drawing.Size(427, 23);
            this.tb_title.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование заявки";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_phoneNumber);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_lastname);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_firstname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(596, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 274);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ответственный сотрудник";
            // 
            // tb_phoneNumber
            // 
            this.tb_phoneNumber.Location = new System.Drawing.Point(6, 130);
            this.tb_phoneNumber.Name = "tb_phoneNumber";
            this.tb_phoneNumber.ReadOnly = true;
            this.tb_phoneNumber.Size = new System.Drawing.Size(223, 23);
            this.tb_phoneNumber.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Номер телефона";
            // 
            // tb_lastname
            // 
            this.tb_lastname.Location = new System.Drawing.Point(6, 86);
            this.tb_lastname.Name = "tb_lastname";
            this.tb_lastname.ReadOnly = true;
            this.tb_lastname.Size = new System.Drawing.Size(223, 23);
            this.tb_lastname.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Фамилия";
            // 
            // tb_firstname
            // 
            this.tb_firstname.Location = new System.Drawing.Point(6, 42);
            this.tb_firstname.Name = "tb_firstname";
            this.tb_firstname.ReadOnly = true;
            this.tb_firstname.Size = new System.Drawing.Size(223, 23);
            this.tb_firstname.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Имя";
            // 
            // UserCheckTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 295);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserCheckTicketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserCheckTicketForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        public TextBox tb_prioritet;
        private Label label3;
        private Label label2;
        public TextBox tb_description;
        public TextBox tb_title;
        private Label label1;
        private GroupBox groupBox2;
        public TextBox tb_status;
        private Label label4;
        public TextBox tb_phoneNumber;
        private Label label7;
        public TextBox tb_lastname;
        private Label label6;
        public TextBox tb_firstname;
        private Label label5;
    }
}