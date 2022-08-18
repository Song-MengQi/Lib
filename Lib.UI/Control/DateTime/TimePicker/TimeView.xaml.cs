using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

namespace Lib.UI
{
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中隐藏
    public partial class TimeView : UserControl
    {
        public string OKText
        {
            get { return OKButton.Content as string; }
            set { OKButton.Content = value; }
        }
        public string HourText { get; set; }
        public string MinuteText { get; set; }
        public string SecondText { get; set; }
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                HourButton.Content = value.Hours.ToString("D2");
                MinuteButton.Content = value.Minutes.ToString("D2");
                SecondButton.Content = value.Seconds.ToString("D2");
            }
        }
        public Action CallbackAction { get; set; }
        public TimeView()
        {
            InitializeComponent();
        }
        #region private
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Time = new TimeSpan(Time.Hours, Time.Minutes, Time.Seconds);
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
                Index = Time.Hours
            };
            view.CallbackAction = ()=>{
                Time = new TimeSpan(view.Index, Time.Minutes, Time.Seconds);
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
                Index = Time.Minutes
            };
            view.CallbackAction = ()=>{
                Time = new TimeSpan(Time.Hours, view.Index, Time.Seconds);
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
                Index = Time.Seconds
            };
            view.CallbackAction = ()=>{
                Time = new TimeSpan(Time.Hours, Time.Minutes, view.Index);
                Popup.IsOpen = false;
            };
            Popup.Child = view;
            Popup.IsOpen = true;
        }
        #endregion
    }
}
