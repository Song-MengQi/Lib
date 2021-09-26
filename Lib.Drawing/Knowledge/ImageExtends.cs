using System.Drawing;

namespace Lib.Drawing
{
    public class StringToImageParameter
    {
        public string String { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Font Font { get; set; }
        public Brush Foreground { get; set; }
        public Brush Background { get; set; }
    }
    public static class ImageExtends
    {
        public static Image StringToImage(StringToImageParameter parameter)
        {
            Bitmap bitmap = new Bitmap(parameter.Width, parameter.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Optimize();

            if (default(Brush) != parameter.Background && Brushes.Transparent != parameter.Background)//不画就是透明
            {
                if (parameter.Background is SolidBrush) graphics.Clear((parameter.Background as SolidBrush).Color);
                else graphics.FillRectangle(parameter.Background, 0, 0, parameter.Width, parameter.Height);
            }
            graphics.DrawString(parameter.String, parameter.Font, parameter.Foreground, parameter.Width / 2, parameter.Height / 2, new StringFormat {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            return bitmap;
        }
    }
}