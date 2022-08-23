using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveriamoFrontend
{
    public partial class MainForm : Form
    {
        private readonly string _token;

        public MainForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                // generiamo il client 
                var client = new DeliveriamoClient.Client("https://localhost:7232", httpClient);

                var res = await client.GetShopKeepersAsync(new DeliveriamoClient.GetShopKeepersRequestDto());

                if (res.Success)
                {
                    dgv_shopkeeper.DataSource = res.ShopKeepers;
                }

            }
        }
    }
}
