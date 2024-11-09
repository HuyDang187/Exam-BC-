using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void btnLoadProducts_Click(object sender, EventArgs e)
		{
			// Đọc dữ liệu từ file JSON
			string jsonFilePath = "product.json"; // Đảm bảo rằng file JSON nằm trong thư mục dự án
			string jsonData = File.ReadAllText(jsonFilePath);

			// Chuyển đổi dữ liệu JSON thành đối tượng C#
			List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonData);

			// Gắn dữ liệu vào DataGridView
			dataGridView1.DataSource = products;
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
		public class Product
		{
			public int id { get; set; }
			public string productName { get; set; }
			public double price { get; set; }
		}
	}
}
