using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Tasks Tasks { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Tasks.NameOfTask;
            textBox2.Text = Tasks.Explanations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tasks.NameOfTask = textBox1.Text;
            Tasks.Explanations = textBox2.Text;
        }
    }
}
