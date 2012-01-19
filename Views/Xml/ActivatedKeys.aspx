<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %><?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="true" />
  </settings>
  <gauges>
    <gauge>
      <chart_settings>
        <title>
          <text>Activated Codes / Total Codes</text>
        </title>
      </chart_settings>
      <linear orientation="Vertical" x="0" y="0" height="100" width="100">
        <axis end_margin="10">
          <scale minimum="0" maximum="<%=Convert.ToInt32(Model.Tables[0].Rows[0]["TOTAL"]) %>" major_interval="<%=Convert.ToInt32(Model.Tables[0].Rows[0]["TOTAL"]) %>" />
          <scale_bar enabled="true">
            <fill enabled="true" type="Gradient">
              <gradient angle="0">
                <key color="Rgb(220,220,220)" />
                <key color="Rgb(245,245,245)" />
                <key color="Rgb(220,220,220)" />
              </gradient>
            </fill>
            <border enabled="true" color="Rgb(190,190,190)" />
            <effects enabled="true">
              <drop_shadow enabled="true" color="Black" distance="1" blur_x="2" blur_y="2" opacity="0.3" />
            </effects>
          </scale_bar>
          <scale_line enabled="false" />
          <major_tickmark enabled="true" shape="Line" align="Inside" length="3">
            <border enabled="true" color="#494949" />
          </major_tickmark>
          <minor_tickmark enabled="true" shape="Line" align="Inside" length="1.5">
            <border enabled="true" color="#494949" />
          </minor_tickmark>
          <labels enabled="true" align="Inside" padding="5">
            <format><![CDATA[{%Value}{numDecimals:0}]]></format>
            <font family="Arial" size="11" bold="true" color="#494949" />
          </labels>
        </axis>
        <frame enabled="true" type="Rectangular">
          <corners type="Rounded" all="5" />
          <outer_stroke enabled="true" thickness="3">
            <fill type="Gradient">
              <gradient>
                <key color="#FEFEFE" />
                <key color="#CECECE" />
              </gradient>
            </fill>
            <border enabled="true" color="Black" opacity="0.1" />
          </outer_stroke>
          <inner_stroke enabled="false" />
          <background>
            <fill type="Solid" color="White">
              <gradient>
                <key position="0" color="#FFFFFF" />
                <key position="0.3" color="#EEEEEE" />
                <key position="1" color="#FEFEFE" />
              </gradient>
            </fill>
            <border enabled="false" type="Gradient" thickness="6" />
            <effects enabled="true">
              <inner_shadow enabled="true" distance="3" opacity="0.2" />
            </effects>
          </background>
          <effects enabled="true">
            <drop_shadow enabled="true" distance="1" opacity="0.3" />
          </effects>
        </frame>
        <pointers>
          <label enabled="true" />
          <pointer type="Thermometer" value="<%=Model.Tables[0].Rows[0]["ACTIVATED"] %>" color="#F0673B" />
          <animation enabled="true" start_time="0" duration="0.7" interpolation_type="Back" />
        </pointers>
        <labels>
          <label>
            <position placement_mode="ByPoint" halign="Center" valign="Center" x="25" y="95" />
            <format>Used Codes</format>
            <font family="Arial" size="12" bold="true" color="Rgb(0,0,99)" />
            <background enabled="false" />
          </label>
        </labels>
      </linear>
    </gauge>
  </gauges>
</anychart>