﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeSpan?>" %>
<% if (Model == null){%>-<% } else { if (Model.Value.Days > 0) { %><% =Model.Value.Days%><%=Resource.Views.Common.CommonText.DayLetter %> <% =Model.Value.Hours%><%=Resource.Views.Common.CommonText.HourLetter %> <% } else { if (Model.Value.Hours > 0) { %><% =Model.Value.Hours%><%=Resource.Views.Common.CommonText.HourLetter%> <% =Model.Value.Minutes%><%=Resource.Views.Common.CommonText.MinuteLetter %> <% } else { %><% if (Model.Value.Minutes > 0) { %><% =Model.Value.Minutes%><%=Resource.Views.Common.CommonText.MinuteLetter %> <% =Model.Value.Seconds%><%=Resource.Views.Common.CommonText.SecondLetter %> <% } else { %> <%=Model.Value.Seconds%><%=Resource.Views.Common.CommonText.SecondLetter %> <% } } } } %>