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
        private delegate void dataPrepareDelegate();
        //private waitingForm wForm = new waitingForm();

        public Form1()
        {
            InitializeComponent();

            //dataPrepareDelegate dp = dataPrepare;
            //IAsyncResult ar = dp.BeginInvoke(null, null);
            //string s = "正在导入数据文件";
            //int i = 0;
            //while (!ar.IsCompleted)
            //{
            //    string tmp = "";
            //    if (i == 4)
            //    {
            //        tmp = s;
            //        i = 0;
            //    }
            //    else
            //    {
            //        tmp = wForm.message;
            //        tmp = tmp + ".";
            //    }
            //    i++;
            //    wForm.message = tmp;
            //}

            //wForm.closeOrNot = true;
            //metroGraphView.Focus();
            //metroGraphView.openGraph(Application.StartupPath + "\\MetroGraph.xml");
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

        //private void closeWaitingForm()
        //{
        //    this.wForm.closeOrNot = true;
        //}

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

            metroGraphView.toggleEditStatus();
            metroGraphView.saveGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.initializeCollection();
            metroGraphView.getShortestPath();
            metroGraphView.saveShortestPathsCollection(Application.StartupPath + "\\ShortestPathCollection.xml");
            metroGraphView.Focus();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
