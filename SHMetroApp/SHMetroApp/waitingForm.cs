using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SHMetroApp
{
    public partial class waitingForm : Form
    {
        //private bool _closeOrNot = false;
        private string _message = string.Empty;

        //public bool closeOrNot
        //{
        //    get { return _closeOrNot; }
        //    set
        //    {
        //        _closeOrNot = value;
        //        if (_closeOrNot)
        //            this.Close();
        //    }
        //}

        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                changeText();
            }
        }

        public void changeText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.changeText));
                    Trace.WriteLine(_message + "?");
                    return;
                }
                Trace.WriteLine(_message + "!");
                processDescribeLabel.Text = _message;
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        public waitingForm()
        {
            InitializeComponent();
        }

    }
}
