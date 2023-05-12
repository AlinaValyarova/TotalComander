using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;



namespace TotalComander
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            panel1.Visible = false;
            ToolStripMenuItem first = new ToolStripMenuItem("Создать");
            ToolStripMenuItem second = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem third = new ToolStripMenuItem("Переименовать");
            ToolStripMenuItem fourth = new ToolStripMenuItem("Скопировать");
            ToolStripMenuItem fith = new ToolStripMenuItem("Свойства");
            // добавляем элементы в меню
            contextMenuStrip1.Items.AddRange(new[] { first, second, third, fourth, fith});
            // ассоциируем контекстное меню с текстовым полем
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            // устанавливаем обработчики событий для меню
            first.Click += first_Click;
            second.Click += second_Click;
            third.Click += third_Click;
            fourth.Click += fourth_Click;
            fith.Click += fith_Click;

            listBox1.ContextMenuStrip = contextMenuStrip1;
        }


        private void first_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;


        }
        private void second_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Удалить папку?",
    "Сообщение",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                Directory.Delete(label5.Text);
            }    
        }
        private void third_Click(object sender, EventArgs e)
        {

        }
        private void fourth_Click(object sender, EventArgs e)
        {
            //foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
            //    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            ////Скопировать все файлы. И перезаписать(если такие существуют)
            //foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            //    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }
        private void fith_Click(object sender, EventArgs e)
        {

        }
        public List<string> files = new List<string>();
        public List<string> dirs = new List<string>();
        public int i = 0;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                string path2 = listBox1.SelectedItem.ToString();
                label5.Text = path2;

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                List<string> newfiles = new List<string>();
                List<string> newdirs = new List<string>();

                try
                {
                    files.Clear();
                    files.AddRange(Directory.GetFiles(path2));
                    dirs.Clear();
                    dirs.AddRange(Directory.GetDirectories(path2));
                }
                catch (UnauthorizedAccessException a2)
                {

                }

                foreach (string dir in dirs)
                {
                    listBox1.Items.Add(dir);
                }


                foreach (string file in files)
                {

                    listBox2.Items.Add(file);
                }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
 

            var path = @"c:\";

            label6.Text = path;
            label5.Text = path;


            try
            {
                files.AddRange(Directory.GetFiles(path));
                dirs.AddRange(Directory.GetDirectories(path));
            }
            catch (UnauthorizedAccessException a)
            {
                
            }

            foreach (string dir in dirs)
            {
                listBox1.Items.Add(dir);
                listBox4.Items.Add(dir);
            }

            foreach(string file in files)
            {
                listBox2.Items.Add(file);
                listBox3.Items.Add(file);
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path2 = listBox4.SelectedItem.ToString();
            label5.Text = path2;

            listBox4.Items.Clear();
            listBox3.Items.Clear();

            List<string> newfiles = new List<string>();
            List<string> newdirs = new List<string>();

            try
            {
                files.Clear();
                files.AddRange(Directory.GetFiles(path2));
                dirs.Clear();
                dirs.AddRange(Directory.GetDirectories(path2));
            }
            catch (UnauthorizedAccessException a2)
            {

            }

            foreach (string dir in dirs)
            {
                listBox4.Items.Add(dir);
            }


            foreach (string file in files)
            {

                listBox3.Items.Add(file);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = listBox2.SelectedItem.ToString();
            Process.Start(path);

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = listBox3.SelectedItem.ToString();
            Process.Start(path);
        }

        private void listBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                i = listBox1.IndexFromPoint(e.Location);

                label5.Text = listBox1.Items[i].ToString();
                //select the item under the mouse pointer
                listBox1.SelectionMode = SelectionMode.None;

                if (i != -1)
                {
                    contextMenuStrip1.Show();
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "-")
            {
                string path = label5.Text + $"\\{textBox1.Text}\\";
                Directory.CreateDirectory(path);
                MessageBox.Show("Yes");
                panel1.Hide();
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("No");
            }
        }
    }
}
