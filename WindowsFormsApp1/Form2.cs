using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Workers Workers { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Workers.Name = textBox1.Text;
            Workers.Position = textBox2.Text;
            Workers.Experience = Convert.ToInt32(textBox3.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Workers.Name;
            textBox2.Text = Workers.Position;
            textBox3.Text = Convert.ToString(Workers.Experience);
        }
        
    }
}
