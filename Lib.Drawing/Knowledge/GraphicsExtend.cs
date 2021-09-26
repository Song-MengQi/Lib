using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Lib.Drawing
{
    public static class GraphicsExtend
    {
        public static void Optimize(this Graphics graphics)
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
    }
}