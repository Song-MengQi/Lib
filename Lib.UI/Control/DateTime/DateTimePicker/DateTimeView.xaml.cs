using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

namespace Lib.UI
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
    public partial class DateTimeView : UserControl
    {
        public string OKText
        {
            get { return OKButton.Content as string; }
            set { OKButton.Content = value; }
        }
        public string HourText { get; set; }
        public string MinuteText { get; set; }
        public string SecondText { get; set; }
        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                Calendar.SelectedDate = dateTime.Date;
                Calendar.DisplayDate = dateTime.Date;
                HourButton.Content = value.Hour.ToString("D2");
                MinuteButton.Content = value.Minute.ToString("D2");
                SecondButton.Content = value.Second.ToString("D2");
            }
        }
        public XmlLanguage CalendarLanguage
        {
            get { return Calendar.Language; }
            set { Calendar.Language = value; }
        }
        public Action CallbackAction { get; set; }
        public DateTimeView()
        {
            InitializeComponent();
        }
        #region private
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime = ((DateTime)Calendar.SelectedDate).AddHours(DateTime.Hour).AddMinutes(DateTime.Minute).AddSeconds(DateTime.Second);
            ActionExtends.Invoke(CallbackAction);
        }
        private void HourButton_Click(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen == true)
            {
                Popup.IsOpen = false;
                return;
            }

            GridPicker view = new GridPicker(4, 6) {
                TitleText = HourText,
                Index = DateTime.Hour
            };
            view.CallbackAction = ()=>{
                DateTime = DateTime.Date.AddHours(view.Index).AddMinutes(DateTime.Minute).AddSeconds(DateTime.Second);
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
        private void MinuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen == true)
            {
                Popup.IsOpen = false;
                return;
            }

            GridPicker view = new GridPicker(6, 10) {
                TitleText = MinuteText,
                Index = DateTime.Minute
            };
            view.CallbackAction = ()=>{
                DateTime = DateTime.Date.AddHours(DateTime.Hour).AddMinutes(view.Index).AddSeconds(DateTime.Second);
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
        private void SecondButton_Click(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen == true)
            {
                Popup.IsOpen = false;
                return;
            }

            GridPicker view = new GridPicker(6, 10) {
                TitleText = SecondText,
                Index = DateTime.Second
            };
            view.CallbackAction = ()=>{
                DateTime = DateTime.Date.AddHours(DateTime.Hour).AddMinutes(DateTime.Minute).AddSeconds(view.Index);
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
        private void Calendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);//据说解除calendar点击后 影响其他按钮首次点击无效的问题
                //这时候不一定点击日，也有可能点击年月，所以不应该在这个时候确定日期
                //DateTime = ((DateTime)Calendar.SelectedDate).AddHours(DateTime.Hour).AddMinutes(DateTime.Minute).AddSeconds(DateTime.Second);
            }
        }
        #endregion
    }
}
