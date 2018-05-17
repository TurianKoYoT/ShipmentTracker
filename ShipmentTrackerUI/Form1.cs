using ShipmentTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipmentTrackerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ShipmentInfo GetModelFromUI()
        {
            return new ShipmentInfo()
            {
                Received = dateTimePicker1.Value,
                Sent = dateTimePicker2.Value,
                Code = textBox1.Text,
                Content = listBox1.Items.OfType<Content>().ToList(),
                Fragile = checkBox1.Checked,
                Length = Convert.ToDecimal(textBox2.Text),
                Width = Convert.ToDecimal(textBox3.Text),
                Height = Convert.ToDecimal(textBox4.Text),
            };
        }

        private void SetModelToUI(ShipmentInfo shipment)
        {
            button2.Enabled = false;
            dateTimePicker1.Value = shipment.Received;
            dateTimePicker2.Value = shipment.Sent;
            textBox1.Text = shipment.Code;
            listBox1.Items.Clear();
            foreach (var e in shipment.Content)
            {
                listBox1.Items.Add(e);
            }
            checkBox1.Checked = shipment.Fragile;
            textBox2.Text = Convert.ToString(shipment.Length);
            textBox3.Text = Convert.ToString(shipment.Width);
            textBox4.Text = Convert.ToString(shipment.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ContentForm(new ShipmentTracker.Content());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                listBox1.Items.Add(form.content);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var si = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(si);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы информации о грузах|*.shipment" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var shipment = GetModelFromUI();
                ShipmentTrackerHelper.WriteToFile(sfd.FileName, shipment);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл информации о грузе|*.shipment" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var shipment = ShipmentTrackerHelper.LoadFromFile(ofd.FileName);
                SetModelToUI(shipment);
            }
        }
    }
}
