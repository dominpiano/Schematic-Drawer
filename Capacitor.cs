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
    class Capacitor {

        public int x, y;
        public Point line1s, line1e, line2s, line2e, line3s, line3e, line4s, line4e, text, textIndex;
        public static int cCount = 0;
        public int capCount;

        public Capacitor() {
            x = 0;
            y = 0;
        }
        public Capacitor(Point p, bool isRotated) {
            x = p.X;
            y = p.Y;
            if (!isRotated) {
                line1s = new Point(x, y - 48);
                line1e = new Point(x, y - 5);

                line2s = new Point(x - 17, y + 5);
                line2e = new Point(x + 17, y + 5);

                line3s = new Point(x - 17, y - 5);
                line3e = new Point(x + 17, y - 5);

                line4s = new Point(x, y + 5);
                line4e = new Point(x, y + 48);

                text = new Point(x + 15, y - 35);
                textIndex = new Point(x + 30, y - 25);
            }
            else {
                line1s = new Point(x - 48, y);
                line1e = new Point(x - 5, y);

                line2s = new Point(x + 5, y - 17);
                line2e = new Point(x + 5, y + 17);

                line3s = new Point(x - 5, y - 17);
                line3e = new Point(x - 5, y + 17);

                line4s = new Point(x + 5, y);
                line4e = new Point(x + 48, y);

                text = new Point(x + 10, y - 35);
                textIndex = new Point(x + 25, y - 25);
            }
            cCount++;
            capCount = cCount;

        }
    }
}
