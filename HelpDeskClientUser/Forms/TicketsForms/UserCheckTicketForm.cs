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
    public partial class UserCheckTicketForm : Form
    {
        public Tickets _ticket;

        public UserCheckTicketForm(Tickets ticket)
        {
            _ticket = ticket;
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            tb_title.Text = _ticket.Title;
            tb_description.Text = _ticket.Description;
            tb_prioritet.Text = _ticket.Priority;
            tb_status.Text = _ticket.Status;

            if (_ticket.Status=="Ожидание")
            {

            }
            else
            {
                tb_firstname.Text = _ticket.Specialist.FirstName;
                tb_lastname.Text = _ticket.Specialist.LastName;
                tb_phoneNumber.Text = _ticket.Specialist.Phone;
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
