namespace DeliveriamoFrontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
                using(var httpClient = new HttpClient())
                {
                //httpClient.BaseAddress = new Uri("https://localhost:7232");
                var client = new DeliveriamoClient.Client("https://localhost:7232", httpClient);
                var response = await client.LoginAsync(new DeliveriamoClient.LoginRequestDto()
                {
                    Username = txt_username.Text,
                    Password = txt_password.Text

                });

                var token = response.Token;
                if (String.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Login errato");
                }
                else
                {
                    // apri il main form
                    var mainForm = new MainForm(token);
                    mainForm.ShowDialog();
                }
            
            }
        }
    }
}