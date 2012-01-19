<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %><?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="True" />
  </settings>
  <charts>
    <chart plot_type="CategorizedHorizontal">
      <data_plot_settings default_series_type="Bar">
        <bar_series group_padding="0.3">
          <marker_settings enabled="true" color="Gold">
            <marker type="None" size="10" />
            <states>
              <hover>
                <marker type="Circle" />
                <border thickness="2" />
              </hover>
              <pushed>
                <marker type="Circle" size="6" />
                <border thickness="2" />
              </pushed>
              <selected_normal>
                <marker type="Star5" size="16" />
                <border thickness="1" />
              </selected_normal>
              <selected_hover>
                <marker type="Star5" size="12" />
                <border thickness="1" />
              </selected_hover>
            </states>
          </marker_settings>
          <tooltip_settings enabled="true">
            <position anchor="RightTop" padding="10" />
            <background>
              <border color="DarkColor(Gold)" thickness="1" />
            </background>
          </tooltip_settings>
        </bar_series>
      </data_plot_settings>
      <chart_settings>
        <title enabled="true">
          <text>Profiles/Age</text>
        </title>
        <axes>
          <y_axis position="Opposite">
            <title>
              <text>Profile Count</text>
            </title>
          </y_axis>
          <x_axis>
            <title>
              <text>Age</text>
            </title>
          </x_axis>
        </axes>
      </chart_settings>
      <data>
        <series name="Series 1">
         <% for(int i=0;i<Model.Tables[0].Rows.Count;i++) { %>
          <point name="<%= Model.Tables[0].Rows[i]["AGE"] %>" y="<%= Model.Tables[0].Rows[i]["TOTAL"] %>" />
          <% } %>
        </series>
      </data>
    </chart>
  </charts>
</anychart>
