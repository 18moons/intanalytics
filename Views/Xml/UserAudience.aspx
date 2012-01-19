<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>

<anychart>
 	<settings>
 	<animation enabled="True" />
 	</settings>
 	<charts>
 	<chart plot_type="CategorizedHorizontal">
 	    <data_plot_settings default_series_type="Bar">
 	    <bar_series point_padding="0.2" group_padding="1">
 	        <tooltip_settings enabled="True" />
 	    </bar_series>
 	    </data_plot_settings>
 	    <chart_settings>
 	    <title enabled="true">
 	        <text>Audience</text>
 	    </title>
 	    <axes>
 	        <y_axis position="Opposite">
            <title enabled="false"/>

             <axis_markers>
 	            <lines>
                    <%  float max = 0;
                        for (var i = 0; i < Model.Tables[0].Rows.Count; i++)
                            max += Convert.ToInt64(Model.Tables[0].Rows[i]["TOTAL"]);
                        
                        max /=Model.Tables[0].Rows.Count; %>
              
                    <line value="<%=max.ToString().Replace(",", ".")%>" thickness="2" color="Green" caps="Square">	                
 	                <label enabled="True" multi_line_align="Center">
 	                <font color="Green" />
 	                <format>Average Audience</format>
 	                </label>
 	            </line>
 	            </lines>
 	        </axis_markers>
            </y_axis>
            <x_axis>
            <title enabled="true">
              <text>Time</text>
            </title>
            </x_axis>
 	    </axes>
 	    </chart_settings>
 	    <data>
 	    <series name="Series 1">
 	         <% for (var i = 0; i < Model.Tables[0].Rows.Count; i++){ %>
             <point name="<%= Model.Tables[0].Rows[i]["AUDIENCE_HOUR"] %>" y="<%=Model.Tables[0].Rows[i]["TOTAL"] %>" />
             <% } %>
 	    </series>
 	    </data>
 	</chart>
 	</charts>
</anychart>
