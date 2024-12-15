using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCGtask4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Randoms.Rows.Clear();
			if (textBox1.Text.Equals(String.Empty) || textBox2.Text.Equals(String.Empty) || textBox3.Equals(String.Empty) || textBox4.Equals(String.Empty) || textBox5.Equals(String.Empty))
			{
				MessageBox.Show("Please Enter All Inputs");
			}
			else
			{
				List<double> ResultRandoms = new List<double>();
				double The_Seed = double.Parse(textBox1.Text);
				double The_Multiplier = double.Parse(textBox2.Text);
				double The_Increment = double.Parse(textBox3.Text);
				double The_Modulus = double.Parse(textBox4.Text);
				double The_Iteration = double.Parse(textBox5.Text);
				
				ResultRandoms = HelperMethod.GenerateRandoms(The_Seed,The_Multiplier, The_Increment, The_Modulus, The_Iteration);
				
				for (int i = 0; i < ResultRandoms.Count; i++)
				{
					Randoms.Rows.Add(ResultRandoms[i]);
				}
				textBox7.Text = HelperMethod.CalcCycleLength(The_Seed, The_Multiplier, The_Increment, The_Modulus).ToString();

			}
		}
	}
}
