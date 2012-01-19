<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %><anychart>
  <settings>
    <animation enabled="True" />
  </settings>
  <charts>
    <chart plot_type="CategorizedVertical">
      <chart_settings>
        <title enabled="true">
          <text>Daily Subscriptions</text>
        </title>
        <axes>
          <x_axis tickmarks_placement="Center">
            <title enabled="true">
              <text></text>
            </title>
            <label>
                <format>{%XValue}{datetimeformat:%dd%MM%YYYY}</format>
            </label>
          </x_axis>
          <y_axis>
            <scale minimum="1" type="Logarithmic"  />
            <title enabled="true">
              <text>Total</text>
            </title>
          </y_axis>
        </axes>
      </chart_settings>
      <data_plot_settings default_series_type="Line">
        <line_series point_padding="0.2" group_padding="1">
          <label_settings enabled="true">
            <background enabled="false" />
            <font color="Rgb(45,45,45)" bold="true" size="9">
              <effects enabled="true">
                <glow enabled="true" color="White" opacity="1" blur_x="1.5" blur_y="1.5" strength="3" />
              </effects>
            </font>
            <format>{%YValue}</format>
          </label_settings>
          <tooltip_settings enabled="true">
            <format>
Cadastros: {%YValue}{numDecimals:2}
Data: {%Name}
</format>
            <background>
              <border type="Solid" color="DarkColor(%Color)" />
            </background>
            <font color="DarkColor(%Color)" />
          </tooltip_settings>
          <marker_settings enabled="true" />
          <line_style>
            <line thickness="3" />
          </line_style>
        </line_series>
      </data_plot_settings>
      <data>
        <series type="Line">
        <% for(int i=0;i<Model.Tables[0].Rows.Count;i++) { %>
          <point name="<%=Model.Tables[0].Rows[i]["DATE"] %>" y="<%=Model.Tables[0].Rows[i]["TOTAL"] %>" />
        <% } %>
        </series>
      </data>
    </chart>
  </charts>
</anychart>