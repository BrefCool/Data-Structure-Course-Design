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

        //数据准备
        private void dataPrepare()
        {
            metroGraphView.openGraph(Application.StartupPath + "\\MetroGraph.xml");
            metroGraphView.initializeCollection();
            metroGraphView.prepareShortestPathsCollection(Application.StartupPath + "\\ShortestPathCollection.xml");
        }

        //metroGraphView中的clickNode发生改变时的事件处理函数
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
            if (metroGraphView.nodeHasSameName())
            {
                MessageBox.Show("图中存在具有相同名称的多个站点！");
                return;
            }

            bw.DoWork += bw_Dowork;
            //在后台执行等待窗口的运行
            bw.RunWorkerAsync();

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

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + "\\help.chm");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "ControlKey")
                metroGraphView.keyCode = "ControlKey";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            metroGraphView.keyCode = "";
        }


    }
}
