using ClientAppHelpDesk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDeskClientUser.Forms.TicketsForms
{
    public partial class CheckTicketForm : Form
    {
        Tickets _Tickets;

        public CheckTicketForm(Tickets tickets)
        {
            InitializeComponent();
            _Tickets = tickets;
             
        }

        async Task LoadData()
        {
            _Tickets = await AccessingToApi.GetUserTicketsByIdAsync(_Tickets.Id);
            
            tb_title.Text = _Tickets.Title;
            tb_description.Text = _Tickets.Description;
            tb_prioritet.Text = _Tickets.Priority;
            tb_status.Text = _Tickets.Status;

            var _client = await AccessingToApi.GetUserByIdAsync(_Tickets.ClientId);
            
                tb_firstname.Text = _client.FirstName;
                tb_lastname.Text = _client.LastName;
                tb_phoneNumber.Text = _client.Phone;
            
            //todo: дописать условия вызова метода
            if (_Tickets.Status == "В работе")
            {
                button1.Text = "Выполнено";
                button1.Click -= button1_Click;
                button1.Click -= button1_Click2;

                button1.Click += button1_Click2;
            }

            if (_Tickets.Status == "Ожидание")
            {
                button1.Text = "В работе";
               

                button1.Click -= button1_Click2;
                button1.Click -= button1_Click;

                button1.Click += button1_Click;
            }

            if (_Tickets.Status == "Выполнено")
            {
                button1.Text = "Выйти";
                button1.Click -= button1_Click;
                button1.Click -= button1_Click2;
                button1.Click += button1_Click3;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var updateTicket = _Tickets;
            updateTicket.Status = "В работе";
            await AccessingToApi.UpdateTicketAsync(updateTicket);
            await LoadData();
        }

        private async void button1_Click2(object sender, EventArgs e)
        {
            var updateTicket = _Tickets;
            updateTicket.Status = "Выполнена";
            await AccessingToApi.UpdateTicketAsync(updateTicket);
            await LoadData();
        }

        private async void button1_Click3(object sender, EventArgs e)
        {
            
            await LoadData();
            this.Close();
        }

        private async void btn_reject_Click(object sender, EventArgs e)
        {
            var updateTicket = _Tickets;
            updateTicket.Status = "Отклонена";
            await AccessingToApi.UpdateTicketAsync(updateTicket);
            await LoadData();
        }

        private async void CheckTicketForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
