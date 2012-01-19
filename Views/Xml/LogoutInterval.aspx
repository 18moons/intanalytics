<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>

<anychart>
 	<settings>
 	<animation enabled="True" />
 	</settings>
 	<charts>
 	<chart plot_type="CategorizedVertical">
 	    <data_plot_settings default_series_type="Bar">
 	    <bar_series point_padding="0.2" group_padding="1">
 	        <tooltip_settings enabled="True" />
 	    </bar_series>
 	    </data_plot_settings>
 	    <chart_settings>
 	    <title enabled="true">
 	        <text>Average Recency</text>
 	    </title>
 	    <axes>
 	        <y_axis position="Opposite">
            <title enabled="true">
                <text>Total Profiles</text>
            </title>
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
             <point name="<%=Model.Tables[0].Rows[i]["AVG_PROFILE_RECURRENCE"] %> Days" y="<%= Model.Tables[0].Rows[i]["TOTAL_PROFILES"] %>" />
             <% } %>
 	    </series>
 	    </data>
 	</chart>
 	</charts>
</anychart>
