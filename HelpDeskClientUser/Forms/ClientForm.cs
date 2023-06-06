using ClientAppHelpDesk.Models;
using HelpDeskClientUser.Forms.TicketsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDeskClientUser.Forms
{
    public partial class ClientForm : Form
    {
        public Users _client;

        public ClientForm()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            var ttype = await AccessingToApi.GetAllTicketType();
            lb_typeTicket.Items.Clear();
            foreach (var t in ttype)
            {
                lb_typeTicket.Items.Add(t.NameType);
            }
            //todo: дописать загрузку текущих заявок пользователя.

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //todo: написать открытие заявки при клике.
        }

        private async void btn_createTicket_Click(object sender, EventArgs e)
        {
            if (lb_typeTicket.SelectedItems.Count==0)
            {
                MessageBox.Show("Выберите тип заявки");
                return;
            }
            this.Visible= false;
            string tticket = lb_typeTicket.SelectedItems[0].ToString();
            CreateTicketForm createTicketForm = new CreateTicketForm();
            createTicketForm.ShowDialog();
            createTicketForm._tticket = tticket;
            createTicketForm._client = _client;
            this.Visible = true;
        }
    }
}
