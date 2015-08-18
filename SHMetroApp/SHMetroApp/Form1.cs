using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHMetroApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            metroGraphView.openGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.clickNodeChanged += new MetroGraphView.valueChangedHandler(metroGraphView_clickNodeChanged);
        }

        void metroGraphView_clickNodeChanged(object sender, EventArgs e)
        {
            if (metroGraphView.clickNode != null)
            {
                nodeNameBox.Text = metroGraphView.clickNode.Name;
                X_textBox.Text = metroGraphView.clickNode.X.ToString();
                Y_textBox.Text = metroGraphView.clickNode.Y.ToString();
            }
        }

        private void ToolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            Size tmpSize = metroGraphView.Size;
            tmpSize.Height -= 50;
            metroGraphView.Size = tmpSize;
            editGroup.Visible = true;
            editMenuItem.Enabled = false;

            metroGraphView.toggleEditStatus();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Size tmpSize = metroGraphView.Size;
            tmpSize.Height += 50;
            metroGraphView.Size = tmpSize;
            editGroup.Visible = false;
            editMenuItem.Enabled = true;

            metroGraphView.toggleEditStatus();
        }
    }
}
