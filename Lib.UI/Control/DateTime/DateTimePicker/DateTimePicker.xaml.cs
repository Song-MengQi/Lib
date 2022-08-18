using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Lib.UI
{
    public partial class DateTimePicker : UserControl
    {
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(
            "DateTime",
            typeof(DateTime),
            typeof(DateTimePicker),
            new FrameworkPropertyMetadata(
                DateTime.Now,
                (obj, args)=>{
                    ((DateTimePicker)obj).TextBox.Text = ((DateTime)args.NewValue).ToString(DateTimeExtends.DateTimeFormat);
                }));
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        public static readonly RoutedEvent DateTimeChangedEvent = EventManager.RegisterRoutedEvent(
            "DateTimeChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(DateTimePicker));
        public event RoutedEventHandler DateTimeChanged
        {
            add { AddHandler(DateTimeChangedEvent, value); }
            remove { RemoveHandler(DateTimeChangedEvent, value); }
        }

        public static readonly DependencyProperty OKTextProperty = DependencyProperty.Register(
            "OKText",
            typeof(string),
            typeof(DateTimePicker));
        public string OKText
        {
            get { return (string)GetValue(OKTextProperty); }
            set { SetValue(OKTextProperty, value); }
        }

        public static readonly DependencyProperty HourTextProperty = DependencyProperty.Register(
            "HourText",
            typeof(string),
            typeof(DateTimePicker));
        public string HourText
        {
            get { return (string)GetValue(HourTextProperty); }
            set { SetValue(HourTextProperty, value); }
        }

        public static readonly DependencyProperty MinuteTextProperty = DependencyProperty.Register(
            "MinuteText",
            typeof(string),
            typeof(DateTimePicker));
        public string MinuteText
        {
            get { return (string)GetValue(MinuteTextProperty); }
            set { SetValue(MinuteTextProperty, value); }
        }

        public static readonly DependencyProperty SecondTextProperty = DependencyProperty.Register(
            "SecondText",
            typeof(string),
            typeof(DateTimePicker));
        public string SecondText
        {
            get { return (string)GetValue(SecondTextProperty); }
            set { SetValue(SecondTextProperty, value); }
        }

        public static readonly DependencyProperty CalendarLanguageProperty = DependencyProperty.Register(
            "CalendarLanguage",
            typeof(XmlLanguage),
            typeof(DateTimePicker));
        public XmlLanguage CalendarLanguage
        {
            get { return (XmlLanguage)GetValue(CalendarLanguageProperty); }
            set { SetValue(CalendarLanguageProperty, value); }
        }

        public DateTimePicker()
        {
            InitializeComponent();
        }
        private void OnDateTimeChanged(RoutedEventArgs e)
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

            DateTimeView view = new DateTimeView {
                OKText = OKText,
                HourText = HourText,
                MinuteText = MinuteText,
                SecondText = SecondText,
                DateTime = DateTime,
                CalendarLanguage = CalendarLanguage
            };
            view.CallbackAction = ()=>{
                DateTime = view.DateTime;
                OnDateTimeChanged(new RoutedEventArgs(DateTimeChangedEvent, this));
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
    }
}
