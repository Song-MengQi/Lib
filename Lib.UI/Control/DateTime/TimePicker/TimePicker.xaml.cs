using System;
using System.Windows;
using System.Windows.Controls;

namespace Lib.UI
{
    public partial class TimePicker : UserControl
    {
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
            "Time",
            typeof(TimeSpan),
            typeof(TimePicker),
            new FrameworkPropertyMetadata(
                TimeSpan.Zero,
                (obj, args)=>{
                    ((TimePicker)obj).TextBox.Text = ((TimeSpan)args.NewValue).ToString();
                }));
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set
            {
                if (value == Time) TextBox.Text = value.ToString();
                else SetValue(TimeProperty, value);
            }
        }

        public static readonly RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent(
            "TimeChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(TimePicker));
        public event RoutedEventHandler TimeChanged
        {
            add { AddHandler(TimeChangedEvent, value); }
            remove { RemoveHandler(TimeChangedEvent, value); }
        }

        public static readonly DependencyProperty OKTextProperty = DependencyProperty.Register(
            "OKText",
            typeof(string),
            typeof(TimePicker));
        public string OKText
        {
            get { return (string)GetValue(OKTextProperty); }
            set { SetValue(OKTextProperty, value); }
        }

        public static readonly DependencyProperty HourTextProperty = DependencyProperty.Register(
            "HourText",
            typeof(string),
            typeof(TimePicker));
        public string HourText
        {
            get { return (string)GetValue(HourTextProperty); }
            set { SetValue(HourTextProperty, value); }
        }

        public static readonly DependencyProperty MinuteTextProperty = DependencyProperty.Register(
            "MinuteText",
            typeof(string),
            typeof(TimePicker));
        public string MinuteText
        {
            get { return (string)GetValue(MinuteTextProperty); }
            set { SetValue(MinuteTextProperty, value); }
        }

        public static readonly DependencyProperty SecondTextProperty = DependencyProperty.Register(
            "SecondText",
            typeof(string),
            typeof(TimePicker));
        public string SecondText
        {
            get { return (string)GetValue(SecondTextProperty); }
            set { SetValue(SecondTextProperty, value); }
        }

        public TimePicker()
        {
            InitializeComponent();
        }
        private void OnTimeChanged(RoutedEventArgs e)
        {
            RaiseEvent(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen == true)
            {
                Popup.IsOpen = false;
                return;
            }

            TimeView view = new TimeView {
                OKText = OKText,
                HourText = HourText,
                MinuteText = MinuteText,
                SecondText = SecondText,
                Time = Time,
            };
            view.CallbackAction = ()=>{
                Time = view.Time;
                OnTimeChanged(new RoutedEventArgs(TimeChangedEvent, this));
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
    }
}
