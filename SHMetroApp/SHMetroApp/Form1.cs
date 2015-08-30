using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SHMetroApp
{
    public partial class Form1 : Form
    {
        public static BackgroundWorker bw = new BackgroundWorker();
        public static waitingForm wForm;

        public Form1()
        {
            InitializeComponent();

            dataPrepare();
            metroGraphView.Focus();
            metroGraphView.clickNodeChanged += new MetroGraphView.valueChangedHandler(metroGraphView_clickNodeChanged);
        }

        private void dataPrepare()
        {
            metroGraphView.openGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.initializeCollection();
            metroGraphView.prepareShortestPathsCollection(Application.StartupPath + "\\ShortestPathCollection.xml");
        }

        private void metroGraphView_clickNodeChanged(object sender, EventArgs e)
        {
            if (metroGraphView.clickNode != null)
            {
                nodeNameBox.Text = metroGraphView.clickNode.Name;
                X_textBox.Text = metroGraphView.clickNode.X.ToString();
                Y_textBox.Text = metroGraphView.clickNode.Y.ToString();
            }
        }

        private void nodeNameBox_textChanged(object sender, EventArgs e)
        {
            if (metroGraphView.clickNode != null)
            {
                metroGraphView.clickNode.Name = nodeNameBox.Text;
                metroGraphView.Invalidate();
            }
        }

        private void X_textBox_textChanged(object sender, EventArgs e)
        {
            if (metroGraphView.clickNode != null)
            {
                if(X_textBox.Text != "")
                    metroGraphView.clickNode.X = int.Parse(X_textBox.Text);
                metroGraphView.Invalidate();
            }
        }

        private void Y_textBox_textChanged(object sender, EventArgs e)
        {
            if (metroGraphView.clickNode != null)
            {
                if(Y_textBox.Text != "")
                    metroGraphView.clickNode.Y = int.Parse(Y_textBox.Text);
                metroGraphView.Invalidate();
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
            Size tmpSize = metroGraphView.Size;
            tmpSize.Height += 50;
            metroGraphView.Size = tmpSize;
            editGroup.Visible = false;
            editMenuItem.Enabled = true;
            nodeNameBox.Text = "";
            X_textBox.Text = "";
            Y_textBox.Text = "";

            bw.DoWork += bw_Dowork;
            bw.RunWorkerAsync();

            metroGraphView.toggleEditStatus();
            metroGraphView.saveGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.getShortestPath();
            metroGraphView.saveShortestPathsCollection(Application.StartupPath + "\\ShortestPathCollection.xml");

            if (wForm.InvokeRequired)
            {
                wForm.Invoke(new MethodInvoker(wForm.Close));
            }
            else
            {
                wForm.Close();
            }
            metroGraphView.Focus();
        }

        public static void bw_Dowork(object sender, DoWorkEventArgs e)
        {
            wForm = new waitingForm("正在重算两两站点间的最短路径(时间较久= =)");
            Application.Run(wForm);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Size tmpSize = metroGraphView.Size;
            tmpSize.Height += 50;
            metroGraphView.Size = tmpSize;
            editGroup.Visible = false;
            editMenuItem.Enabled = true;
            nodeNameBox.Text = "";
            X_textBox.Text = "";
            Y_textBox.Text = "";

            metroGraphView.toggleEditStatus();
            metroGraphView.openGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.Focus();
        }
    }
}
