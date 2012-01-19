<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link href="/DxAnalytics/Content/Styles/flexigrid/flexigrid.css" rel="stylesheet" type="text/css" />
<script src="/DxAnalytics/Content/Scripts/flexigrid.js" type="text/javascript"></script>

<embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/MediaPerformance"
    width="100%" height="300" wmode="transparent"></embed>

<div style="margin: 0px 20px 20px 20px">
    <table id="PlaylistPositionPerformanceAnalytic" style="display: none">
    </table>
</div>


<script type="text/javascript">
    $("#PlaylistPositionPerformanceAnalytic").flexigrid
    (
		{
		    url: '/DxAnalytics/Xml/PlaylistPositionPerformanceAnalytic',
		    dataType: 'xml',
		    sortorder: "asc",
		    sortname: "NAME",
            singleSelect: true,
		    resizable: true,
		    searchitems: [
				{ display: 'Nome', name: 'NAME', isdefault: true }
				],
		    colModel: [
				{ display: 'Index', name: 'PLAYLIST_POSITION', width: 50, sortable: true, align: 'left' },
                { display: 'Playlist Name', name: 'NAME', width: 280, sortable: true, align: 'left' },
				{ display: 'Traillers', name: 'TRAILLER', width: 50, sortable: true, align: 'center' },
				{ display: 'Media', name: 'MOVIE', width: 50, sortable: true, align: 'center' },
                { display: '% Media', name: 'PERCENT_VIDEO', width: 100, sortable: true, align: 'center' },
				{ display: 'Related', name: 'RELATED', width: 100, sortable: true, align: 'center' },
                { display: '% Related', name: 'PERCENT_RELATED', width: 100, sortable: true, align: 'center' }
				],
            sortname: "NAME",
            sortorder: "asc"
		}
    );
</script>
