namespace ProductApp
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the content of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnLoadProducts = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(800, 300);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnLoadProducts
			// 
			this.btnLoadProducts.Location = new System.Drawing.Point(12, 320);
			this.btnLoadProducts.Name = "btnLoadProducts";
			this.btnLoadProducts.Size = new System.Drawing.Size(150, 50);
			this.btnLoadProducts.TabIndex = 1;
			this.btnLoadProducts.Text = "Load Products";
			this.btnLoadProducts.UseVisualStyleBackColor = true;
			this.btnLoadProducts.Click += new System.EventHandler(this.btnLoadProducts_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnLoadProducts);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Product List";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnLoadProducts;
	}
}

