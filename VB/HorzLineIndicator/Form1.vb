Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing

Namespace HorzLineIndicator

    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            textBrush = Brushes.Red
            schedulerControl1.DayView.DayCount = 3
            schedulerControl1.Services.DateTimeNavigation.GoToToday()
            schedulerControl1.DayView.TopRowTime = New TimeSpan(Date.Now.Hour - 1, 0, 0)
            AddHandler schedulerControl1.CustomDrawTimeIndicator, AddressOf SchedulerControl1_CustomDrawTimeIndicator
        End Sub

        Private textBrush As Brush
        Private Sub SchedulerControl1_CustomDrawTimeIndicator(ByVal sender As Object, ByVal e As CustomDrawObjectEventArgs)
            Dim info As TimeIndicatorViewInfo = TryCast(e.ObjectInfo, TimeIndicatorViewInfo)
            Dim scheduler As SchedulerControl = TryCast(sender, SchedulerControl)
            e.DrawDefault()
            For Each item In info.Items
                Dim timeIndicatorItem As HorizontalTimeIndicatorCircleItem = TryCast(item, HorizontalTimeIndicatorCircleItem)
                If timeIndicatorItem IsNot Nothing Then
                    Dim boundsText As Rectangle = Rectangle.Empty
                    If TypeOf scheduler.ActiveView Is DayView Then
                        boundsText = Rectangle.Inflate(New Rectangle(item.Bounds.X + 5, item.Bounds.Y - 3, scheduler.ActiveView.ViewInfo.Bounds.Width - 5, 10), 0, 5)
                        boundsText.Offset((CInt(e.Graphics.ClipBounds.Width) \ 2), -10)
                    End If
                    e.Cache.DrawString(info.Interval.Start.ToString(), scheduler.Appearance.HeaderCaption.GetFont(), textBrush, boundsText, scheduler.Appearance.HeaderCaption.GetStringFormat())
                    e.Cache.FillRectangle(textBrush, New Rectangle(item.Bounds.X + 5, item.Bounds.Y, scheduler.ActiveView.ViewInfo.Bounds.Width - 5, 2))
                End If
            Next
            e.Handled = True
        End Sub
    End Class
End Namespace
