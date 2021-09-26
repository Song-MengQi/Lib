using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Lib.UI
{
    public class SliderIgnoreDelta : Slider
    {
        public double FinalValue
        {
            get { return (double)GetValue(FinalValueProperty); }
            set
            {
                SetValue(FinalValueProperty, value);
                if (value != Value) Value = value;
            }
        }
        public static readonly DependencyProperty FinalValueProperty =
            DependencyProperty.Register("FinalValue", typeof(double), typeof(SliderIgnoreDelta), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnFinalValueChanged));
        private static void OnFinalValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            double result;
            if (double.TryParse(e.NewValue.ToString(), out result))
            {
                SliderIgnoreDelta sliderIgnoreDelta = sender as SliderIgnoreDelta;
                if (sliderIgnoreDelta.Value != result) sliderIgnoreDelta.Value = result;
            }
        }
        public bool IsDragging { get; protected set; }
        protected override void OnThumbDragCompleted(DragCompletedEventArgs e)
        {
            IsDragging = false;
            base.OnThumbDragCompleted(e);
            OnValueChanged(Value, Value);
        }
        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            IsDragging = true;
            base.OnThumbDragStarted(e);
        }
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            if (IsDragging) return;
            base.OnValueChanged(oldValue, newValue);
            if (FinalValue != Value) FinalValue = Value;
        }
    }
}