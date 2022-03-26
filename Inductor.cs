using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchematicDrawer {
    class Inductor {

        public int x, y;
        public Point line1s, line1e, line2s, line2e, text, textIndex;
        public Point arcStart1, size1;
        public Point arcStart2, size2;
        public Point arcStart3, size3;
        public Point arcStart4, size4;
        public int startAngle1, endAngle1;
        public int startAngle2, endAngle2;
        public int startAngle3, endAngle3;
        public int startAngle4, endAngle4;
        public static int iCount = 0;
        public int indCount;

        public Inductor() {
            x = 0;
            y = 0;
        }
        public Inductor(Point p, bool isRotated) {
            x = p.X;
            y = p.Y;
            if (!isRotated) {
                line1s = new Point(x, y - 48);
                line1e = new Point(x, y - 30);

                arcStart1 = new Point(x - 8, y - 30);
                size1 = new Point(15, 15);
                startAngle1 = -90;
                endAngle1 = 180;

                arcStart2 = new Point(x - 8, y - 15);
                size2 = new Point(15, 15);
                startAngle2 = -90;
                endAngle2 = 180;

                arcStart3 = new Point(x - 8, y);
                size3 = new Point(15, 15);
                startAngle3 = -90;
                endAngle3 = 180;

                arcStart4 = new Point(x - 8, y + 15);
                size4 = new Point(15, 15);
                startAngle4 = -90;
                endAngle4 = 180;

                line2s = new Point(x, y + 30);
                line2e = new Point(x, y + 48);

                text = new Point(x + 10, y - 35);
                textIndex = new Point(x + 25, y - 25);
            }
            else {

                text = new Point(x + 10, y - 35);
                textIndex = new Point(x + 25, y - 25);
            }
            iCount++;
            indCount = iCount;

        }
    }
}
