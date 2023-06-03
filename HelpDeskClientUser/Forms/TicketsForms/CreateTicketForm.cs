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
    public partial class CreateTicketForm : Form
    {
        
        
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

        private void button1_Click(object sender, EventArgs e)
        {
            var ticket = new Tickets()
            {
                Title = tb_title.Text
                //TypeTicket =  ,

            };
        }

        private void tb_description_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
