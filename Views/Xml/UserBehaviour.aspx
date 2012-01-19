<%@ Page Language="C#" Inherits="MibClient2.Web.Mvc.MibView<System.Data.DataSet>" ContentType="text/xml" %><?xml version="1.0" encoding="UTF-8"?>
<anychart>
  <settings>
    <animation enabled="false" />
    <locale>
      <date_time_format>
        <format>%dd/%MM/%yyyy %hh:%mm:%ss</format>
      </date_time_format>
    </locale>
  </settings>
  <charts>
    <chart plot_type="CategorizedBySeriesHorizontal">
      <chart_settings>
        <title>
          <text>Comportamento do usuário X</text>
        </title>
        <axes>
          <y_axis position="Opposite">
            <scale mode="Overlay" type="DateTime" minimum_offset="0" maximum_offset="0" major_interval="1" major_interval_unit="Minute" />
            <labels>
              <format><![CDATA[{%Value}{dateTimeFormat:%hh}:{%Value}{dateTimeFormat:%mm}]]></format>
            </labels>
            <zoom enabled="true" />
            <title>
              <text>Date</text>
            </title>
            <line enabled="false" />
          </y_axis>
          <x_axis>
            <major_tickmark enabled="false" />
            <minor_tickmark enabled="false" />
            <major_grid enabled="false" />
            <title enabled="false" />
          </x_axis>
        </axes>
        <legend enabled="true" ignore_auto_item="True">
          <title enabled="false" />
          <items>
            <item source="Thresholds" />
          </items>
        </legend>
      </chart_settings>
      <thresholds>
        <threshold name="StatusThr">
          <condition name="Início da Aplicação" type="equalTo" value_1="{%Status}" value_2="22" color="#F4FFE8" />
          <condition name="Exibição de Trailer" type="equalTo" value_1="{%Status}" value_2="27" color="#20FF58" />
          <condition name="Exibição de Conteúdo" type="equalTo" value_1="{%Status}" value_2="26" color="#2058FF" />
          <condition name="Compartilhamento" type="equalTo" value_1="{%Status}" value_2="28" color="#FF60D7" />
          <condition name="Favoritos" type="equalTo" value_1="{%Status}" value_2="36" color="#FF8E8E" />
          <condition name="Final da Aplicação" type="equalTo" value_1="{%Status}" value_2="23" color="#F4FFE8" />
        </threshold>
      </thresholds>
      <data_plot_settings>
        <range_bar_series group_padding="0.2">
          <bar_style>
            <fill type="Gradient" opacity="0.8">
              <gradient angle="0">
                <key color="%Color" />
                <key color="DarkColor(%Color)" />
              </gradient>
            </fill>
            <effects enabled="false" />
            <border type="Solid" color="Rgb(120,120,120)" />
            <states>
              <hover>
                <hatch_fill enabled="true" type="Percent50" color="White" opacity="0.5" />
                <border thickness="1" />
              </hover>
            </states>
          </bar_style>
          <start_point>
            <marker_settings enabled="true" color="DarkRed">
              <marker type="None" anchor="Center" v_align="Center" h_align="Center" />
              <states>
                <hover>
                  <marker type="Star5" />
                </hover>
              </states>
            </marker_settings>
            <tooltip_settings enabled="true">
              <position anchor="Float" valign="Top" halign="Right" />
              <format><![CDATA[{%SeriesName} ({%Status})]]></format>
              <background>
                <corners type="Rounded" all="3" />
              </background>
            </tooltip_settings>
          </start_point>
          <interactivity allow_select="false" use_hand_cursor="false" />
        </range_bar_series>
      </data_plot_settings>
      <data>
        <series name="Interação" type="RangeBar" threshold="StatusThr">
        <% for(int i=0;i<Model.Tables[0].Rows.Count;i++) { %>
        <% int actionId=(int)Model.Tables[0].Rows[i]["ACTION_ID"]; %>
        <% if (actionId == 22 || actionId == 23 || actionId == 28 || actionId == 36)
           { %>
        <% if (Convert.ToDateTime(Model.Tables[0].Rows[i]["FROM"]) > Convert.ToDateTime(Model.Tables[0].Rows[i]["TO"]))
           {
            Model.Tables[0].Rows[i]["TO"]=Model.Tables[0].Rows[i]["FROM"];
           }%>
          <point start="<%= Model.Tables[0].Rows[i]["FROM"] %>" end="<%= Model.Tables[0].Rows[i]["TO"] %>">
            <attributes>
              <attribute name="Status"><%=  Model.Tables[0].Rows[i]["ACTION_ID"]%></attribute>
            </attributes>
          </point>
        <% } %>
        <% } %>
        </series>
        <series name="Mídia" type="RangeBar" threshold="StatusThr">
        <% for(int i=0;i<Model.Tables[0].Rows.Count;i++) { %>
        <% int actionId=(int)Model.Tables[0].Rows[i]["ACTION_ID"]; %>
        <% if(actionId==26 || actionId==27) { %>
        <% if (Convert.ToDateTime(Model.Tables[0].Rows[i]["FROM"]) > Convert.ToDateTime(Model.Tables[0].Rows[i]["TO"]))
           {
            Model.Tables[0].Rows[i]["TO"]=Model.Tables[0].Rows[i]["FROM"];
           }%>
          <point start="<%= Model.Tables[0].Rows[i]["FROM"] %>" end="<%= Model.Tables[0].Rows[i]["TO"] %>">
            <attributes>
              <attribute name="Status"><%=  Model.Tables[0].Rows[i]["ACTION_ID"]%></attribute>
            </attributes>
          </point>
        <% } %>
        <% } %>
        </series>
      </data>
    </chart>
  </charts>
</anychart>
