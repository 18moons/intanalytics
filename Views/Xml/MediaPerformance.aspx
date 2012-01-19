<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>

<anychart>
 	  <settings>
 	    <animation enabled="True" />
 	  </settings>
 	  <charts>
 	    <chart type="CategorizedVertical">
 	      <chart_settings>
 	        <title>
 	          <text></text>
 	          <background enabled="false" />
 	        </title>
            
            <legend enabled="true" ignore_auto_item="true" position="Right">
 	          <title enabled="false" />
 	          <items>
 	            <item source="series" />
 	          </items>
 	        </legend>

 	        <axes>
 	          <x_axis tickmarks_placement="Center">
               <title enabled="true">
              <text>Days</text>
              </title>
              </x_axis>

               <y_axis tickmarks_placement="Center">
               <title enabled="true">
              <text>Views</text>
              </title>
              </y_axis>
 	        </axes>
 	      </chart_settings>
 	      <data_plot_settings default_series_type="Area">
 	        <area_series>
                <tooltip_settings enabled="true">
 	            <format><![CDATA[{%Name} - {%YValue}{numDecimals: 0} ({%YPercentOfSeries}{numDecimals: 0}%)]]></format>
 	          </tooltip_settings>

 	          <area_style>
 	            <line enabled="true" color="DarkColor(%Color)" />
 	            <fill type="Gradient" opacity="1">
 	              <gradient angle="90">
 	                <key position="0" color="%Color" opacity="1" />
 	                <key position="1" color="DarkColor(%Color)" opacity="1" />
 	              </gradient>
 	            </fill>
 	            <states>
 	              <hover color="White" />
 	            </states>
 	          </area_style>
 	          <marker_settings enabled="True">
 	            <marker type="Circle" size="6" />
 	          </marker_settings>
 	          <tooltip_settings enabled="True" />
 	        </area_series>
 	      </data_plot_settings>
 	      <data>

              <% 
                  string Traillers = "";
                  string Movies = "";
                  for (var i = 0; i < Model.Tables[0].Rows.Count; i++)
                  {
                      Traillers += "<point name=\"" + Model.Tables[0].Rows[i]["DATE"].ToString() + "\" y=\"" + Model.Tables[0].Rows[i]["TRAILERS"].ToString() + "\" />" + Environment.NewLine;
                      Movies += "<point name=\"" + Model.Tables[0].Rows[i]["DATE"].ToString() + "\" y=\"" + Model.Tables[0].Rows[i]["MOVIES"].ToString() + "\" />" + Environment.NewLine;
                  } %>
 	        <series name="Trailers">
 	            <%=Traillers%>
 	        </series>
 	        <series name="Medias" color="#EEEE25">
 	            <%=Movies%>
 	        </series>
 	      </data>
 	    </chart>
 	  </charts>
 	</anychart>
