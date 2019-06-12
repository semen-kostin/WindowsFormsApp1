using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Workers)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wrk = new Form2() { Workers = new Workers() };
            if (wrk.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(wrk.Workers);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Список|*.list";

            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Class1));
            var file = File.OpenRead(openFileDialog.FileName);
            var storage = (Class1)xs.Deserialize(file);
            file.Close();

            textBox1.Text = storage.NameOfCompany;
            textBox2.Text = storage.Address;
            textBox3.Text = Convert.ToString(storage.Number);
            switch (storage.Category)
            {

                case Category.Administration:
                    comboBox1.Text = "Администрация";
                    break;
                case Category.Engineering:
                    comboBox1.Text = "Инженерия";
                    break;
                case Category.Metallurgy:
                    comboBox1.Text = "Металлургия";
                    break;
                case Category.NuclearIndustry:
                    comboBox1.Text = "Ядерная область";
                    break;
                case Category.ScientificActivity:
                    comboBox1.Text = "Научная область";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var items in storage.Workers)
            {
                listBox1.Items.Add(items);
            }
            foreach (var items in storage.Tasks)
            {
                listBox2.Items.Add(items);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Список|*.list";

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            Class1 storage = new Class1()
            {
                NameOfCompany = textBox1.Text,
                Address = textBox2.Text,
                Number = Convert.ToInt32(textBox3.Text),
                Tasks = listBox2.Items.OfType<Tasks>().ToList(),
                Workers = listBox1.Items.OfType<Workers>().ToList(),
            };

            switch (comboBox1.SelectedValue?.ToString())
            {

                case "Металлургия":
                    storage.Category = Category.Metallurgy;
                    break;
                case "Администрация":
                    storage.Category = Category.Administration;
                    break;
                case "Инженерия":
                    storage.Category = Category.Engineering;
                    break;
                case "Ядерная область":
                    storage.Category = Category.NuclearIndustry;
                    break;
                case "Научная область":
                    storage.Category = Category.ScientificActivity;
                    break;
                default:
                    storage.Category = Category.Administration;
                    break;
            }
            var xs = new XmlSerializer(typeof(Class1));
            var file = File.Create(saveFileDialog.FileName);
            xs.Serialize(file, storage);
            file.Close();

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listBox1.SelectedItem is Workers;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var wr = (Workers)listBox1.Items[index];
                var ff = new Form2() { Workers = wr };
                if (ff.ShowDialog(this) == DialogResult.OK)
                {
                    listBox1.Items.Remove(wr);
                    listBox1.Items.Insert(index, wr);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tasks = new Form3 { Tasks = new Tasks() };
            if (tasks.ShowDialog(this) == DialogResult.OK)
            {
                listBox2.Items.Add(tasks.Tasks);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox2.SelectedItem is Tasks;
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var tasks = (Tasks)listBox2.Items[index];
                var ff = new Form3() { Tasks = tasks };
                if (ff.ShowDialog(this) == DialogResult.OK)
                {
                    listBox2.Items.Remove(tasks);
                    listBox2.Items.Insert(index, tasks);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is Tasks)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
