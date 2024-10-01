using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medilink.Views.assets
{
    internal class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 20; // Radio de los bordes

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            base.OnPaint(e);
        }
    }
}
