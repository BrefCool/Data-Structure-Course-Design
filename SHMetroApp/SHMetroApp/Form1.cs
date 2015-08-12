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
        }

        private void ToolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            Size tmpSize = metroGraphView.Size;
            if (editGroup.Visible)
                tmpSize.Width += 250;
            else
                tmpSize.Width -= 250;
            metroGraphView.Size = tmpSize;
            editGroup.Visible ^= true;
        }
    }
}
