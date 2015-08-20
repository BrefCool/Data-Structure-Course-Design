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
    public partial class childForm1 : Form
    {
        private Color _lineColor = Color.Black;

        public Color lineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        public string lineName
        {
            get 
            {
                if (lineNameBox.Text == "")
                {
                    return "新的路线";
                }
                return lineNameBox.Text;
            }
        }

        public childForm1()
        {
            InitializeComponent();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int lineHeight = (int)(lineColorShowArea.Height / 2);
            int lineLength = (int)(lineColorShowArea.Width * 0.8);
            Rectangle lineBackgroundRC = new Rectangle(lineColorShowArea.Location.X, lineColorShowArea.Location.Y,
                lineColorShowArea.Width, lineColorShowArea.Height);
            Rectangle lineRC = new Rectangle((int)(lineColorShowArea.Location.X + lineColorShowArea.Width * 0.1),
                (int)(lineColorShowArea.Location.Y + lineHeight / 2), lineLength, lineHeight);

            using(Brush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(brush,lineBackgroundRC);
            }
            e.Graphics.DrawRectangle(Pens.Black, lineBackgroundRC);

            using (Brush brush = new SolidBrush(lineColor))
            {
                e.Graphics.FillRectangle(brush, lineRC);
            }
        }

        private void colorSelectBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                Invalidate();
            }
        }
    }
}
