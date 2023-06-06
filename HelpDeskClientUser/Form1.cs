using ClientAppHelpDesk.Models;
using ClientWebApiHelpDesk.Models;
using HelpDeskClientUser.Forms;
using System.Text;

namespace HelpDeskClientUser
{
    public partial class Form1 : Form
    {
        public static Users _LocalUser;
        
        public Form1()
        {
            InitializeComponent();
        }

        

        
        //todo: дописать авторизацию
        private async void btn_log_in_Click(object sender, EventArgs e)
        {
            if (tb_login.Text == "admin" && tb_password.Text == "admin")
            {
                this.Visible= false;
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
                this.Visible = true;
                return;
            }

            var logmod = new LoginModel()
            {
                Login = tb_login.Text,
                Password = tb_password.Text
            };

            try
            {
                _LocalUser = await AccessingToApi.UserAuthorization(logmod);
                if (_LocalUser == null)
                {
                    MessageBox.Show("Ќеверные логин и/или пароль");
                    return;
                }

                if (_LocalUser.TypeUser == 2)
                {
                    this.Visible = false;
                    SpecialistForm specialistForm = new SpecialistForm();
                    specialistForm._specialist = _LocalUser;
                    specialistForm.ShowDialog();
                    
                    this.Visible = true;
                    return;
                }

                if (_LocalUser.TypeUser == 1)
                {
                    this.Visible = false;
                    ClientForm clientForm = new ClientForm();
                    clientForm._client = _LocalUser;
                    clientForm.ShowDialog();
                    
                    this.Visible = true;
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ќеверные логин и/или пароль");
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