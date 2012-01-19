<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %><?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="True" />
  </settings>
  <charts>
    <chart plot_type="doughnut">
      <data_plot_settings enable_3d_mode="true">
        <pie_series>
          <tooltip_settings enabled="true">
            <format><![CDATA[{%Name}
Perfis: {%Value}{numDecimals:0}
Porcentagem: {%YPercentOfSeries}{numDecimals: 2}%]]></format>
            <background>
              <corners type="Rounded" all="3" />
            </background>
          </tooltip_settings>
          <label_settings enabled="true" mode="Outside" multi_line_align="Center">
            <background enabled="false" />
            <position anchor="Center" valign="Center" halign="Center" padding="20" />
            <format><![CDATA[{%Name}
{%Value}{numDecimals:0} ({%YPercentOfSeries}{numDecimals:1}%)]]></format>
            <font bold="False" />
            <states>
              <hover>
                <font underline="true" />
              </hover>
            </states>
          </label_settings>
          <connector color="Black" opacity="0.4" />
        </pie_series>
      </data_plot_settings>
      <data>
        <series name="Series 1">
         <% for(int i=0;i<Model.Tables[0].Rows.Count;i++) { %>
          <point name="<%= Model.Tables[0].Rows[i]["GENDER"] %>" y="<%= Model.Tables[0].Rows[i]["TOTAL"] %>" />
          <% } %>
        </series>
      </data>
      <chart_settings>
        <title enabled="true" padding="15">
          <text>Profiles / Gender</text>
        </title>
      </chart_settings>
    </chart>
  </charts>
</anychart>