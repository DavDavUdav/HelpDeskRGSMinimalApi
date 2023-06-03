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
            UpdateDataGridView();
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
                String.IsNullOrEmpty(tb_password.Text)
                )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var spec = new Specialists
            {
                FirstName = tb_firstname.Text,
                LastName = tb_lastname.Text,
                Email = tb_mail.Text,
                Login = tb_login.Text,
                Password = tb_password.Text,
            };
            try
            {
                var auth = await AccessingToApi.AddNewSpecialistAsync(spec);
                if (auth)
                {
                    MessageBox.Show("Специалист успешно добавлен");
                }
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btn_deleteSpecialist_Click(object sender, EventArgs e)
        {
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
        }

        public async void UpdateDataGridView()
        {
            var specs = await AccessingToApi.GetAllSpecialists();
            if (specs != null)
            {
                dgv_specialists.DataSource = specs;
            }
        }

    }
}
