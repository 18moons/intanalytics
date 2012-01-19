<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %>
<?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="True" />
  </settings>
  <charts>
    <chart plot_type="doughnut">
      <data_plot_settings enable_3d_mode="true">
        <pie_series>
          <tooltip_settings enabled="true">
            <format><![CDATA[{%Name} Profiles: {%Value}{numDecimals:0} Percent: {%YPercentOfSeries}{numDecimals: 2}%]]></format>
            <background>
              <corners type="Rounded" all="3" />
            </background>
          </tooltip_settings>
          <label_settings enabled="true" mode="Inside" multi_line_align="Center">
            <background enabled="false" />
            <position anchor="Center" valign="Center" halign="Center" padding="20" />
            <format><![CDATA[{%YPercentOfSeries}{numDecimals:1}%]]></format>
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
          <point name="<%= Model.Tables[0].Rows[i]["NAME"] %>" y="<%= Model.Tables[0].Rows[i]["QTDE"] %>" />
          <% } %>
        </series>
      </data>
      <chart_settings>
        <title enabled="true" padding="15">
          <text>Watching Preferences (Audio)</text>
        </title>

        <legend enabled="true" position="Bottom" align="Spread" ignore_auto_item="true" padding="15">
          <format>{%Icon} {%Name} ({%YValue}{numDecimals:0})</format>
          <template>
          </template>
          <title enabled="true">
            <text>Activity</text>
          </title>
          <columns_separator enabled="false" />
          <background>
            <inside_margin left="10" right="10" />
          </background>
          <items>
            <item source="Points" />
          </items>
        </legend>

      </chart_settings>
    </chart>
  </charts>
</anychart>