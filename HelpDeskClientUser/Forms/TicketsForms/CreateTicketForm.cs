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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HelpDeskClientUser.Forms.TicketsForms
{
    public partial class CreateTicketForm : Form
    {
        public string _tticket;
        public Users _client;
        
        public CreateTicketForm()
        {
            InitializeComponent();
            LoadResources();

            
        }

        public void LoadResources()
        {
            tb_description.Text = "Просьба указать информацию максимально подробно, если проблемма с программой то указать что за программа и на каком этапе возникла проблемма, если заказ картриджей то просьба указать модель принтера(или картриджа), а так же количество которое нужно";
            tb_description.ForeColor = Color.Gray;
        }

        

        private void tb_description_Leave(object sender, EventArgs e)
        {
            tb_description.Text = "Просьба указать информацию максимально подробно, если проблемма с программой то указать что за программа и на каком этапе возникла проблемма, если заказ картриджей то просьба указать модель принтера(или картриджа), а так же количество которое нужно";
            tb_description.ForeColor = Color.Gray;
        }

        private void tb_description_Enter(object sender, EventArgs e)
        {
            tb_description.Text = null;
            tb_description.ForeColor = Color.Black;
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            var ticket = new Tickets()
            {
                Title = tb_title.Text,
                Type = _tticket,
                ClientId = _client.Id,
                CreateDate = DateTime.Today.Date,
                Priority = cb_prioritet.Text,
                LastUpdateDate = DateTime.Now,
                Status = "Ожидание",
                Description = tb_description.Text,
                AssignedTo = 1
            };

            var responce = await AccessingToApi.CreateTicketAsync(ticket);
            this.Close();
        }
    }
}
