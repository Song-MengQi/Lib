using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lib.UI
{
    public class ClippingBorder : Border
    {
        private object oldClip;
        private readonly RectangleGeometry clipRect = new RectangleGeometry();
        protected override void OnRender(DrawingContext dc)
        {
            OnApplyChildClip();
            base.OnRender(dc);
        }
        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (Child == value) return;
                if (Child != null)
                {
                    Child.SetValue(UIElement.ClipProperty, oldClip);
                }

                oldClip = value == null
                    ? null
                    : value.ReadLocalValue(UIElement.ClipProperty);

                base.Child = value;
            }
        }
        protected virtual void OnApplyChildClip()
        {
            if (Child == null) return;
            clipRect.RadiusX = clipRect.RadiusY = Math.Max(0.0, this.CornerRadius.TopLeft - (this.BorderThickness.Left * 0.5));
            clipRect.Rect = new Rect(Child.RenderSize);
            Child.Clip = clipRect;
        }
    }
}
