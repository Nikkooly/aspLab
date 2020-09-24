using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfClientWindowsForm.ServiceReference1;

namespace WcfClientWindowsForm
{
    public partial class Form1 : Form
    {
        private ServiceReference1.Service1Client client;
        public Form1()
        {
            InitializeComponent();
            client = new ServiceReference1.Service1Client();
            client.Open();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            foreach (Contact c in client.GetDist())
            {
                ListViewItem item = new ListViewItem(c.Id.ToString());
                item.SubItems.Add(c.Surname.ToString());
                item.SubItems.Add(c.Phone.ToString());
                //listBox1.Items.Add(c.Id.ToString() + ' ' + c.Surname + ' ' + c.Phone);
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Surname = textBox2.Text;
            contact.Phone = textBox3.Text;
            client.AddDict(contact);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Id = int.Parse(textBox1.Text);
            contact.Surname = textBox2.Text;
            contact.Phone = textBox3.Text;
            client.UpdDict(contact);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.Id = int.Parse(textBox1.Text);
            client.DelDict(contact);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
