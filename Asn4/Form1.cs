using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asn4 {
    public partial class Form1 : Form {

        private static Point one;
        private static Point two;
        private static List<Point> pool;

        public Form1() {
            InitializeComponent();

            pool = new List<Point>();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {

            if (one.X == 0 && one.Y == 0)
                return;

            Graphics g = e.Graphics;

            using (Pen myPen = new Pen(Color.MediumPurple)) {
                foreach (Point i in pool) {
                    g.DrawCircle(myPen, i.X, i.Y, 125);
                }
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e) {
            one = e.Location;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e) {
            two = e.Location;
            pool.Add(new Point(e.X, e.Y));
            Canvas.Refresh();
        }

    }

    public static class GraphicsExtensions {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius) {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius) {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
