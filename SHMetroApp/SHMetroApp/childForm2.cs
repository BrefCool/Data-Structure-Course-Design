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
    public partial class childForm2 : Form
    {
        public MetroLine chosenLine
        {
            get { return chooseBox.SelectedItem as MetroLine; }
        }

        public childForm2(List<MetroLine> Lines)
        {
            InitializeComponent();

            foreach (var line in Lines)
            {
                chooseBox.Items.Add(line);
            }
        }
    }
}
