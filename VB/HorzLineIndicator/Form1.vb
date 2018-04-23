Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing

Namespace HorzLineIndicator
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			schedulerControl1.DayView.DayCount = 3
			schedulerControl1.Services.DateTimeNavigation.GoToToday()
			schedulerControl1.DayView.TopRowTime = New TimeSpan((DateTime.Now.Hour - 1), 0,0)
		End Sub

		Private Sub schedulerControl1_CustomDrawTimeCell(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawTimeCell
			Dim viewType As SchedulerViewType = (CType(sender, SchedulerControl)).ActiveViewType
			' Draw a line in the Day and WorkWeek views only. 
			Dim drawHorzLine As Boolean = (viewType = SchedulerViewType.Day OrElse viewType = SchedulerViewType.WorkWeek)
			If (Not drawHorzLine) Then
				Return
			End If

			Dim interval As TimeInterval = (CType(e.ObjectInfo, TimeCell)).Interval
			Dim now As DateTime = interval.Start.Date + DateTime.Now.TimeOfDay

			Dim nowRect As Rectangle = Rectangle.Empty
			' For each timecell drawn check whether the current time falls in its interval.
			If interval.Contains(now) Then
				e.DrawDefault()
				Dim rect As Rectangle = e.Bounds
				nowRect = rect
				' Calculate offset from the timecell's top.
				Dim nowOffset As TimeSpan = now.TimeOfDay - interval.Start.TimeOfDay
				Dim offsetRatio As Single = nowOffset.Ticks / CSng(interval.Duration.Ticks)
				nowRect.Y += CInt(Fix(rect.Height * offsetRatio))
				' Set the line thickness.
				nowRect.Height = 1

				e.Cache.FillRectangle(Color.Red, nowRect)
				e.Handled = True
			End If
		End Sub
	End Class
End Namespace