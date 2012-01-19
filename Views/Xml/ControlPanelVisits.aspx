<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %>
<?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="True" />
  </settings>
  <charts>
    <chart plot_type="CategorizedVertical">
      <chart_settings>
        <title>
          <text>Access - Daily</text>
        </title>
        <axes>
          <x_axis tickmarks_placement="Center">
            <title enabled="true">
              <text>Access Date</text>
            </title>
            <label>
                <format>{%XValue}{datetimeformat:%dd%MM%YYYY}</format>
            </label>
          </x_axis>
          <y_axis>
            <scale type="Logarithmic"  />
            <title enabled="true">
              <text>Access Count</text>
            </title>
          </y_axis>
        </axes>
      </chart_settings>
      <data_plot_settings>
        <line_series>
          <tooltip_settings enabled="True">
            <format>
                Access: {%YValue}
                Date: {%Name}{datetimeformat:%dd%MM%YYYY}
            </format>
          </tooltip_settings>
        </line_series>
      </data_plot_settings>
      <data>
        <series type="Line">
          <% for (var i = 0; i < Model.Tables[0].Rows.Count; i++)
             { %>
             <point name="<%= Model.Tables[0].Rows[i]["DATE"] %>" y="<%=Model.Tables[0].Rows[i]["TOTAL"] %>" />
          <% } %>
        </series>
      </data>
    </chart>
  </charts>
</anychart>