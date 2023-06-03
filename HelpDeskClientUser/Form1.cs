using HelpDeskClientUser.Forms;
using System.Text;

namespace HelpDeskClientUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        

        private void btn_log_in_Click(object sender, EventArgs e)
        {
            

            switch (cb_typeUser.SelectedIndex)
            {
                case 0:
                    if (tb_login.Text == "admin" && tb_password.Text == "admin")
                    {
                        this.Visible= false;
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Неверные логин и/или пароль");
                        return;
                    }
                    break;

                case 1:


                    
                    break; 

                case 2:

                    break;

                default:
                    break;

            }
        }
    }





    public class HttpClientMain
    {
        static HttpClient httpClient = new HttpClient();
       
        public static async Task Main()
        {
            var client = new HttpClient();
            var data = new StringContent("{\"name\":\"John\", \"age\":30}", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7242/api/users", data);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
            client.Dispose();
            
        }
       
    }
}