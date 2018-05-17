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
    public partial class ContentForm : Form
    {
        public ShipmentTracker.Content content { get; set; }
        public ContentForm(ShipmentTracker.Content content)
        {
            this.content = content;
            InitializeComponent();
        }

        private void ContentForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = content.Title;
            numericUpDown1.Value = content.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDown1.Value);
            content.Title = textBox1.Text;
            content.Count = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
