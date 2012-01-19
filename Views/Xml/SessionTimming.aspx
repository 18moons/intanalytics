<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>
<anychart>
 	  <settings>
 	    <animation enabled="True" />
 	  </settings>
 	  <charts>
 	    <chart plot_type="Pie">
 	      <data_plot_settings enable_3d_mode="true">
 	        <pie_series>
            <tooltip_settings enabled="true">
 	            <format><![CDATA[{%Name}{numDecimals:0}hs: {%YPercentOfSeries}{numDecimals: 0}%]]></format>
 	          </tooltip_settings>
             
 	          <label_settings enabled="true">
 	            <background enabled="false" />
 	            <position anchor="Center" valign="Center" halign="Center" padding="20" />
 	            <font color="White">
 	              <effects>
 	                <drop_shadow enabled="true" distance="2" opacity="0.5" blur_x="2" blur_y="2" />
 	              </effects>
 	            </font>
 	            <format><![CDATA[{%Name}{numDecimals:0}hs]]></format>
 	          </label_settings>
 	        </pie_series>
 	      </data_plot_settings>
 	      <data>
 	        <series name="Series 1" type="Pie">
 	            <% for (var i = 0; i < Model.Tables[0].Rows.Count; i++) { %>
                <point name="<%= Model.Tables[0].Rows[i]["NAME"] %>" y="<%=Model.Tables[0].Rows[i]["TOTAL"] %>" />
                <% } %>
            </series>
 	      </data>
 	      <chart_settings>
 	        <title enabled="true" padding="15">
 	          <text>Session Timing</text>
 	        </title>
 	      </chart_settings>
 	    </chart>
 	  </charts>
 	</anychart>
