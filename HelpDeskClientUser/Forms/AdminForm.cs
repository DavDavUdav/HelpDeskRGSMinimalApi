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
using HelpDeskClientUser;

namespace HelpDeskClientUser.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            UpdateData();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void btn_addSpecialist_Click(object sender, EventArgs e)
        {
            
            if (
                String.IsNullOrEmpty(tb_firstname.Text) ||
                String.IsNullOrEmpty(tb_lastname.Text) ||
                String.IsNullOrEmpty(tb_mail.Text) ||
                String.IsNullOrEmpty(tb_login.Text) ||
                String.IsNullOrEmpty(tb_password.Text)||
                String.IsNullOrEmpty(tb_phoneNumber_spec.Text)
                )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var spec = new Users
            {
                FirstName = tb_firstname.Text,
                LastName = tb_lastname.Text,
                Email = tb_mail.Text,
                Login = tb_login.Text,
                Password = tb_password.Text,
                TypeUser = 2,
                Phone = tb_phoneNumber_spec.Text
            };
            try
            {
                var auth = await AccessingToApi.AddNewSpecialistAsync(spec);
                if (auth)
                {
                    MessageBox.Show("Специалист успешно добавлен");
                }
                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private async void btn_deleteSpecialist_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                int selectedIndex = dgv_specialists.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dgv_specialists.Rows[selectedIndex];
                if (selectedRow != null)
                {
                    
                    var responce = await AccessingToApi.DeleteSpecialistAsync(Convert.ToInt32(selectedRow.Cells["Id"].Value));
                    if (responce)
                    {
                        MessageBox.Show("Специалист удален");
                    }
                    else
                    {
                        MessageBox.Show("Специалиста не получилось удалить");
                    }
                    UpdateDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            */
        }

        /// <summary>
        /// Обновляем данные datagridview
        /// </summary>
        public async void UpdateData()
        {
            try
            {
                tb_server_address.Text = AccessingToApi.address;

                var specs = await AccessingToApi.GetAllSpecialists();
                if (specs != null)
                {
                    dgv_specialists.DataSource = specs;
                }
            
                var clients = await AccessingToApi.GetAllClients();
                if (clients != null)
                {
                    dgv_clients.DataSource = clients;
                }

                lb_allTipeTicket.Items.Clear();
                var ttype = await AccessingToApi.GetAllTicketType();
                foreach(var t in ttype)
                {
                    lb_allTipeTicket.Items.Add(t.NameType);
                }
                
                //lb_allTipeTicket.Items.AddRange = ttype;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private async void tb_add_client_Click(object sender, EventArgs e)
        {
            if (
                String.IsNullOrEmpty(tb_firstname_client.Text) ||
                String.IsNullOrEmpty(tb_lastname_client.Text) ||
                String.IsNullOrEmpty(tb_mail_client.Text) ||
                String.IsNullOrEmpty(tb_login_client.Text) ||
                String.IsNullOrEmpty(tb_pass_client.Text) ||
                String.IsNullOrEmpty(tb_phoneNumber_client.Text)
                )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var client = new Users
            {
                FirstName = tb_firstname_client.Text,
                LastName = tb_lastname_client.Text,
                Email = tb_mail_client.Text,
                Login = tb_login_client.Text,
                Password = tb_pass_client.Text,
                TypeUser = 1,
                Phone = tb_phoneNumber_client.Text
            };
            try
            {
                var auth = await AccessingToApi.AddNewClientAsync(client);
                if (auth)
                {
                    MessageBox.Show("Клиент успешно добавлен");
                }
                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btn_addNewTypeTicket_Click(object sender, EventArgs e)
        {
            var ttype = new TypeTicket
            {
                NameType = tb_nameTypeTicket.Text
            };

            await AccessingToApi.AddNewTipeTicketAsync(ttype);
            UpdateData();
        }

        private void btn_save_address_Click(object sender, EventArgs e)
        {
            AccessingToApi.address = tb_server_address.Text;
        }
    }
}
