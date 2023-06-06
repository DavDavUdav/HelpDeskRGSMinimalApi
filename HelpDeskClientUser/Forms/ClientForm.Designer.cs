namespace HelpDeskClientUser.Forms
{
    partial class ClientForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_createTicket = new System.Windows.Forms.Button();
            this.lb_typeTicket = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 426);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Мои заявки";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 22);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(614, 398);
            this.dataGridView2.TabIndex = 2;
            // 
            // btn_createTicket
            // 
            this.btn_createTicket.Location = new System.Drawing.Point(6, 353);
            this.btn_createTicket.Name = "btn_createTicket";
            this.btn_createTicket.Size = new System.Drawing.Size(242, 67);
            this.btn_createTicket.TabIndex = 8;
            this.btn_createTicket.Text = "создать заявку";
            this.btn_createTicket.UseVisualStyleBackColor = true;
            this.btn_createTicket.Click += new System.EventHandler(this.btn_createTicket_Click);
            // 
            // lb_typeTicket
            // 
            this.lb_typeTicket.FormattingEnabled = true;
            this.lb_typeTicket.ItemHeight = 15;
            this.lb_typeTicket.Location = new System.Drawing.Point(6, 22);
            this.lb_typeTicket.Name = "lb_typeTicket";
            this.lb_typeTicket.Size = new System.Drawing.Size(242, 319);
            this.lb_typeTicket.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lb_typeTicket);
            this.groupBox3.Controls.Add(this.btn_createTicket);
            this.groupBox3.Location = new System.Drawing.Point(643, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 426);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "выбор типа заявки";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 444);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "ClientForm";
            this.Text = "Подача заявки";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dataGridView2;
        private Button btn_createTicket;
        private ListBox lb_typeTicket;
        private GroupBox groupBox3;
    }
}