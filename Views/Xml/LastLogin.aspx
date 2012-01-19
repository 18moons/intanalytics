<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>

<anychart>
 	<settings>
 	<animation enabled="True" />
 	</settings>
 	<charts>

        <%
        string orientation = "CategorizedHorizontal";
        if ((ViewData["orientation"] != null) && (ViewData["orientation"].ToString() == "v"))
            orientation = "CategorizedVertical"; 
        %>

 	<chart plot_type="<%=orientation %>">
 	    <data_plot_settings default_series_type="Bar">
 	    <bar_series point_padding="0.2" group_padding="1">
 	        <tooltip_settings enabled="True" />
 	    </bar_series>
 	    </data_plot_settings>
 	    <chart_settings>
 	    <title enabled="true">
 	        <text>Last Login</text>
 	    </title>
 	    <axes>
 	        <y_axis position="Opposite">
            <title enabled="false"/>

             <axis_markers>
 	            <lines>
                   <%   float max = 0;
                        for (var i = 0; i < Model.Tables[0].Rows.Count; i++)
                            max += Convert.ToInt64(Model.Tables[0].Rows[i]["TOTAL"]);
                        
                        max /=Model.Tables[0].Rows.Count; %>
                        
                    <line value="<%=max.ToString().Replace(",", ".")%>" thickness="2" color="Green" caps="Square">	                
 	                <label enabled="True" multi_line_align="Center">
 	                <font color="Green" />
 	                <format>Average</format>
 	                </label>
 	            </line>
 	            </lines>
 	        </axis_markers>
            </y_axis>
            <x_axis>
            <title enabled="true">
              <text>Days</text>
            </title>
            </x_axis>
 	    </axes>
 	    </chart_settings>
 	    <data>
 	    <series name="Series 1">
 	         <% for (var i = 0; i < Model.Tables[0].Rows.Count; i++)
              { %>
             <point name="<%= Model.Tables[0].Rows[i]["DAYS"] %> days " y="<%=Model.Tables[0].Rows[i]["TOTAL"] %>" />
             <% } %>
 	    </series>
 	    </data>
 	</chart>
 	</charts>
</anychart>
