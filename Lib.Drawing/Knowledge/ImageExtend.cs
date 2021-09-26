using System.Drawing;

namespace Lib.Drawing
{
    public static class ImageExtend
    {
        //自带的GetThumbnailImage不能参数调优，质量差
        public static Image GetThumbnailImage(this Image image, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Optimize();
            graphics.DrawImage(image, 0, 0, width, height);
            return bitmap;
        }
    }
}