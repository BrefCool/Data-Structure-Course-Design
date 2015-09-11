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
        private string _message = string.Empty;

        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                processDescribeLabel.Text = _message;
            }
        }

        public waitingForm(string msg)
        {
            InitializeComponent();

            message = msg;
        }

    }
}
