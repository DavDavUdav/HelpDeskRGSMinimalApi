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
    public partial class SpecialistForm : Form
    {
        public Users _specialist;

        public SpecialistForm()
        {
            InitializeComponent();
            UpdateData();
        }

        async void UpdateData()
        {
            var tickets = await AccessingToApi.GetActualTicketsAsync();
            dataGridView1.DataSource= tickets;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btn_open_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заявку которую хотите открыть");
            }


            if (dataGridView1.SelectedRows.Count == 1)
            {
                var get_id_ticket = dataGridView1.CurrentRow.Cells["Id"].Value;
                Tickets currentTicket;

                var id = await AccessingToApi.GetUserTicketsByIdAsync((int)get_id_ticket);

                CheckTicketForm userCheckTicketForm = new CheckTicketForm(id);

                userCheckTicketForm.ShowDialog();
                this.Visible = true;
            }
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            var tickets = await AccessingToApi.GetActualTicketsAsync();
            dataGridView1.DataSource= tickets;
        }
    }
}
