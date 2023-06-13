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
        public List<Tickets> _usertickets;

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

            var tickets = await AccessingToApi.GetUserTicketsAsync(_client);
            dgv_my_tickets.DataSource = tickets;
            _usertickets = tickets;
           
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
            createTicketForm._tticket = tticket;
            createTicketForm._client = _client;
            createTicketForm.ShowDialog();
            this.Visible = true;
            LoadData();
        }

        //todo: дописать просмотр заявки.

        private async void btn_open_ticket_Click(object sender, EventArgs e)
        {
            if (dgv_my_tickets.SelectedRows.Count == 1)
            {
                var get_id_ticket = dgv_my_tickets.CurrentRow.Cells["Id"].Value;
                Tickets currentTicket;





                foreach (var t in _usertickets)
                {
                    if (t.Id == (int)get_id_ticket)
                    {
                        currentTicket= t;

                        

                        var id = await AccessingToApi.GetUserTicketsByIdAsync((int)get_id_ticket);

                        UserCheckTicketForm userCheckTicketForm = new UserCheckTicketForm(id);
                        
                        userCheckTicketForm.ShowDialog();
                        this.Visible = true;
                        break;
                    }
                }

                

            }
        }
    }
}
