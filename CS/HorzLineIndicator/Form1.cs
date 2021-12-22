using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraEditors;

namespace HorzLineIndicator
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            textBrush = Brushes.Red;
            schedulerControl1.DayView.DayCount = 3;
            schedulerControl1.Services.DateTimeNavigation.GoToToday();
            schedulerControl1.DayView.TopRowTime = new TimeSpan((DateTime.Now.Hour - 1), 0,0);
            schedulerControl1.CustomDrawTimeIndicator += SchedulerControl1_CustomDrawTimeIndicator;
        }
        Brush textBrush;
        private void SchedulerControl1_CustomDrawTimeIndicator(object sender, CustomDrawObjectEventArgs e) {
            TimeIndicatorViewInfo info = e.ObjectInfo as TimeIndicatorViewInfo;
            SchedulerControl scheduler = sender as SchedulerControl;
            e.DrawDefault();
            foreach(var item in info.Items) {
                TimeIndicatorBaseItem timeIndicatorItem = item as TimeIndicatorBaseItem;
                if(timeIndicatorItem != null) {
                    Rectangle boundsText = Rectangle.Empty;
                    if(scheduler.ActiveView is DayView) {
                        boundsText = Rectangle.Inflate(timeIndicatorItem.Bounds, 0, 5);
                        boundsText.Offset(((int)e.Graphics.ClipBounds.Width / 2), -10);
                    }
                    e.Cache.DrawString(info.Interval.Start.ToString(), scheduler.Appearance.HeaderCaption.GetFont(), textBrush, boundsText,
                        scheduler.Appearance.HeaderCaption.GetStringFormat());
                }
            }
            e.Handled = true;
        }
    }
}