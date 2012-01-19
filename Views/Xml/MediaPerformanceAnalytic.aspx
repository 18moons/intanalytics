<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataSet>" ContentType="text/xml" %>
<rows>
<page>1</page>
<total>1</total>

 <%  
     System.Data.DataTable dt = new System.Data.DataTable("data");
     
     dt.Columns.Add("NAME",Type.GetType("System.String"));
     dt.Columns.Add("TRAILLER", Type.GetType("System.Int64"));
     dt.Columns.Add("MOVIE", Type.GetType("System.Int64"));
     dt.Columns.Add("PERCENT_VIDEO", Type.GetType("System.Single"));
     dt.Columns.Add("RELATED", Type.GetType("System.Int64"));
     dt.Columns.Add("PERCENT_RELATED", Type.GetType("System.Single"));
     int totalTrailer=0;
     int totalMovie = 0;
     int totalRelated = 0;
     for (int i = 0; i < Model.Tables[0].Rows.Count; i++)
     {
         System.Data.DataRow row = dt.NewRow(); 
         float  Traillers       = Convert.ToSingle(Model.Tables[0].Rows[i]["TRAILLER"]);
         float  Movies          = Convert.ToSingle(Model.Tables[0].Rows[i]["MOVIE"]);
         float  Relateds        = Convert.ToSingle(Model.Tables[0].Rows[i]["RELATED"]);
         float  percentMovie    = 0;
         float  percentRelated  = 0;
         float LabelpercentMovie   = 0;
         float LabelpercentRelated = 0;

         if ((Traillers != 0) || (Movies != 0))
         {
             if (Traillers != 0) percentMovie = (Movies / Traillers) * 100;
             else percentMovie = 100;
             LabelpercentMovie = percentMovie;
         }
         else LabelpercentMovie = -1;

         if ((Movies != 0) || (Relateds != 0))
         {
             if (Movies != 0) percentRelated = ((Relateds / Movies) * 100) + percentMovie;
             else percentRelated = 100;
             LabelpercentRelated = percentRelated;
         }
         else LabelpercentRelated = -1;

         totalMovie += Convert.ToInt32(Movies);
         totalTrailer += Convert.ToInt32(Traillers);
         totalRelated += Convert.ToInt32(Relateds);
         
         row["NAME"]            = Model.Tables[0].Rows[i]["NAME"];
         row["TRAILLER"]        = Traillers;
         row["MOVIE"]           = Movies;
         row["PERCENT_VIDEO"]   = LabelpercentMovie;
         row["RELATED"]         = Relateds;
         row["PERCENT_RELATED"] = LabelpercentRelated;
         dt.Rows.Add(row); 
     }

     int iIndex = 0;
     foreach (System.Data.DataRow item in dt.Select(null, "[" + Request.Form["sortname"].ToUpper() + "] " + Request.Form["sortorder"].ToUpper()))
     {
         
         string Percent_Video   = "";
         string Percent_Related = "";
         
         float fPercent_Video   = Convert.ToSingle(item["PERCENT_VIDEO"]); 
         float fPercent_Related = Convert.ToSingle(item["PERCENT_RELATED"]); 
         
         if (fPercent_Video <= 0) Percent_Video = "-";
         else Percent_Video = fPercent_Video.ToString("#0").Replace(",", ".") + "%";

         if (fPercent_Related <= 0) Percent_Related = "-";
         else Percent_Related = fPercent_Related.ToString("#0").Replace(",", ".") + "%"; 

         %>
        <row id='<%=iIndex%>'>
        <cell><![CDATA[<a href="/DxAnalytics/Home/MediaEngagement"><%= item["NAME"]%></a>]]></cell>
        <cell><![CDATA[<%= item["TRAILLER"] %>]]></cell>
        <cell><![CDATA[<%= item["MOVIE"]    %>]]></cell>
        <cell><![CDATA[<%= Percent_Video    %>]]></cell>
        <cell><![CDATA[<%= item["RELATED"]  %>]]></cell>
        <cell><![CDATA[<%= Percent_Related  %>]]></cell>
        </row>
    <% 
        iIndex++;
     } %>
        <row id='<%= iIndex %>'>
        <cell><![CDATA[Total]]></cell>
        <cell><![CDATA[<%= totalTrailer %>]]></cell>
        <cell><![CDATA[<%= totalMovie %>]]></cell>
        <cell><![CDATA[<%= ((double)totalMovie/(double)totalTrailer*100).ToString("#0.00") %>%]]></cell>
        <cell><![CDATA[<%= totalRelated  %>]]></cell>
        <cell><![CDATA[<%= ((double)(totalMovie+totalRelated)/(double)totalTrailer*100).ToString("#0.00") %>%]]></cell>
        </row>
</rows>