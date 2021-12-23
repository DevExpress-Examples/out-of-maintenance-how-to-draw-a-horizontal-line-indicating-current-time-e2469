<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128634727/21.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2469)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/HorzLineIndicator/Form1.cs) (VB: [Form1.vb](./VB/HorzLineIndicator/Form1.vb))
<!-- default file list end -->
# How to draw a horizontal line indicating current time 


<p><strong>Starting from v15.2, </strong>our SchedulerControl can now indicate the current time by drawing a line in the view out-of-the-box. In the Day, Work-Week, and Full Week views, the horizontal line can go across the entire view, or it can be restricted to the current date. See the <a href="https://community.devexpress.com/blogs/ctodx/archive/2015/11/11/devexpress-scheduler-controls-big-changes-are-coming-in-v15-2.aspx">DevExpress Scheduler controls: big changes are coming in v15.2</a> blog for more details. To customize the default <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument114790">Time Indicator</a> painting, use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_CustomDrawTimeIndicatortopic">SchedulerControl.CustomDrawTimeIndicator</a> event.<br><br><br><strong>For versions older than 15.2</strong>, use the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_CustomDrawTimeCelltopic">CustomDrawTimeCell</a> event to draw a horizontal line across the scheduler indicating the current time in the Day and WorkWeek views.</p>

<br/>


