using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGDIplus
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private Rectangle rectangle;
        private double ratioX = 2;
        private double ratioY = 2;
        public Form1()
        {
            InitializeComponent();
            // this.Show();
            // var g = this.CreateGraphics();
            // g.DrawBezier(new Pen(Color.DarkOrange, 5f), new Point(100, 100), new Point(120, 50), new Point(190, 60), new Point(200, 110));
            // this.Invalidate();
            rectangle = new Rectangle(
                (int) (this.Width / ratioX + this.Width / 4),
                (int) (this.Height / ratioY + this.Height / 4),
                (int) (this.Width / 4 * Math.Sin(ratioX)),
                (int)(this.Height / 4 * Math.Sin(ratioY))
            );
            timer.Tick += (sender, ev) => {
                rectangle = new Rectangle(
                    (int)(this.Width / 4 * Math.Sin(ratioX) + this.Width / 4),
                    (int)(this.Height / 4 * Math.Sin(ratioY) + this.Height / 4),
                    (int)(this.Width / 4 * Math.Sin(ratioX)),
                    (int)(this.Height / 4 * Math.Sin(ratioY))
                );
                this.Refresh();
                ratioX += 0.005;
                ratioY += 0.005;
            };
            timer.Interval = 2;
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Form1_Paint");
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawLine(
                new Pen(Color.BurlyWood, 5f),
                new Point(0, 0),
                new Point(this.Width / 2, this.Height / 2)
            );
            g.DrawRectangle(
                new Pen(Color.DarkRed, 5f),
                new Rectangle(this.Width / 2, this.Height / 2, this.Width / 4, this.Height / 4)
            );
            g.FillEllipse(
                new SolidBrush(Color.DarkGreen),
                rectangle
            );
            g.DrawString(
                "Hello GDI+ .NET!",
                new Font("Times New Roman", 524),
                new SolidBrush(Color.DarkBlue),
                new PointF(
                    this.Width / 2,
                    this.Height / 2
                )
            );
            // g.DrawBezier(new Pen(Color.DarkOrange, 5f), new Point(100, 100), new Point(120, 50), new Point(190, 60), new Point(200, 110));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
