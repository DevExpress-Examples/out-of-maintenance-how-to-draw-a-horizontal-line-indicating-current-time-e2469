# How to draw a horizontal line indicating current time


<p><strong>Starting from v15.2, </strong>our SchedulerControl can now indicate the current time by drawing a line in the view out-of-the-box. In the Day, Work-Week, and Full Week views, the horizontal line can go across the entire view, or it can be restricted to the current date. See the <a href="https://community.devexpress.com/blogs/ctodx/archive/2015/11/11/devexpress-scheduler-controls-big-changes-are-coming-in-v15-2.aspx">DevExpress Scheduler controls: big changes are coming in v15.2</a> blog for more details. To customize the default <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument114790">Time Indicator</a> painting, use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_CustomDrawTimeIndicatortopic">SchedulerControl.CustomDrawTimeIndicator</a> event.<br><br><br><strong>For versions older than 15.2</strong>, use the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_CustomDrawTimeCelltopic">CustomDrawTimeCell</a> event to draw a horizontal line across the scheduler indicating the current time in the Day and WorkWeek views.</p>

<br/>


