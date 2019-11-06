using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Item_17
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			txtTimer.Text = DateTime.Now.ToString("HH:mm:ss:fff");
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			using (FileStream stream = new FileStream("output.txt", FileMode.Create, FileAccess.Write))
			{
				string message = "Hello Alura!";
				byte[] array = Encoding.UTF8.GetBytes(message);
				int position = 0;
				int size = message.Length;
				await stream.WriteAsync(array, position, size);
				//Thread.Sleep(2000); //síncrono
				await Task.Delay(2000);	  //assíncrono
			}

			using (FileStream stream = new FileStream("output.txt", FileMode.Open, FileAccess.Read))
			{
				byte[] array = new byte[stream.Length];
				int position = 0;
				await stream.ReadAsync(array, position, (int)stream.Length);
				string message = Encoding.UTF8.GetString(array);
				Console.WriteLine("Message: " + message);
			}
		}
	}
}
