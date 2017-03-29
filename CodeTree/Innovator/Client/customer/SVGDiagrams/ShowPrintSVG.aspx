<%@ Page  language="c#" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Precedence Diagram</title>
		<link href="../../styles/default.css" type="text/css" rel="stylesheet">
			<script language="C#" runat="server">
   void Page_Load(Object Sender, EventArgs E)   {
    string qs=Request.QueryString.ToString();
    //string qs="proc_param=innovator.selectprecdiagdot 'EF9677CD8A334768A787C28B469DEF4A'&db=IS810";
    input_qs.Value=qs;
    svgembed.Attributes["src"] = @"DrawSVGDirectedGraph.aspx?"+qs;
    input_svg.Value = @"DrawSVGDirectedGraph.aspx?"+qs;
    input_proj_num.Value=Request.QueryString.Get("proj_num");
    }
   void ButtonClicked(Object Sender, EventArgs E) {
        string qs=input_qs.Value;        
    svgembed.Attributes["src"] =  @"DrawSVGDirectedGraph.aspx?"+qs;
   }
			</script>
			<script language="javascript">var aras=opener.top.aras;</script>
			<script src="../../javascript/AddConfigurationLink.js" type="text/javascript">PrintSVG;SharpVectorObjectModel;SharpVectorRenderingEngine</script>
			<script language="jscript">
    function print_clicked()
    {
      var printsvg = document.getElementById("graphic");
      var svgembed = document.getElementById("svgembed");
      var url =document.location.href.replace("ShowPrintSVG","DrawSVGDirectedGraph");
      printsvg.SetSvgURL(url);
      printsvg.PrintJ();
    }
    function change_title(){
      document.title="Project " + document.getElementById("input_proj_num").value +" Precedence Diagram";
      }
			</script>
	</HEAD>
	<body onload="change_title()">
		<form name="theform" runat="server">
			<span style="FONT-FAMILY: arial">SVG Diagram </span><ASP:BUTTON id="button" onclick="ButtonClicked" runat="server" width="60" text="Update"></ASP:BUTTON>
			<input onclick="print_clicked()" type="button" value="   Print  " name="print_putton">
			<input id="input_qs" type="hidden" name="input_qs" runat="server">
			<input id="input_svg" type="hidden" name="input_svg" runat="server">
			<input id="input_proj_num" type="hidden" name="input_proj_num" runat="server">
		</form>
		<br>
		<comment id="svgembed_commented">
      <embed id="svgembed" pluginspage="http://www.adobe.com/svg/viewer/install/" width="100%" height="100%" type="image/svg+xml" src="starter.svg" runat="server"></embed>
		</comment>
		<script>WriteUncommentedObject("svgembed_commented");</script>
		<comment id="graphic_commented">
       <object id="graphic"
        style="visibility:hidden"
        classid="../../cbin/PrintSVG.dll#Aras.Client.Controls.Graphic" >
      </object>
		</comment>
		<script>
         WriteUncommentedObject("graphic_commented");
		</script>
	</body>
</HTML>
