using System.Text;

namespace HelpDeskClientUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await HttpClientMain.Main();
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