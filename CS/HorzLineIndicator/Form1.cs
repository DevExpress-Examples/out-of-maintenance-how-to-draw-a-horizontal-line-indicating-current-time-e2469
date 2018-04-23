using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;

namespace HorzLineIndicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            schedulerControl1.DayView.DayCount = 3;
            schedulerControl1.Services.DateTimeNavigation.GoToToday();
            schedulerControl1.DayView.TopRowTime = new TimeSpan((DateTime.Now.Hour - 1), 0,0);
        }

        private void schedulerControl1_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
        {
            SchedulerViewType viewType = ((SchedulerControl)sender).ActiveViewType;
            // Draw a line in the Day and WorkWeek views only. 
            bool drawHorzLine = viewType == SchedulerViewType.Day || viewType == SchedulerViewType.WorkWeek;
            if (!drawHorzLine)
                return;

            TimeInterval interval = ((TimeCell)e.ObjectInfo).Interval;
            DateTime now = interval.Start.Date + DateTime.Now.TimeOfDay;

            Rectangle nowRect = Rectangle.Empty;
            // For each timecell drawn check whether the current time falls in its interval.
            if (interval.Contains(now))
            {
                e.DrawDefault();
                Rectangle rect = e.Bounds;
                nowRect = rect;
                // Calculate offset from the timecell's top.
                TimeSpan nowOffset = now.TimeOfDay - interval.Start.TimeOfDay;
                float offsetRatio = nowOffset.Ticks / (float)interval.Duration.Ticks;
                nowRect.Y += (int)(rect.Height * offsetRatio);
                // Set the line thickness.
                nowRect.Height = 1;

                e.Cache.FillRectangle(Color.Red, nowRect);
                e.Handled = true;
            }
        }
    }
}