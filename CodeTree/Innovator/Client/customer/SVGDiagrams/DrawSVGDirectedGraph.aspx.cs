using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GraphVizJ;
using System.Xml;
using System.Configuration;


namespace SVGDiagrams
{
  /// <summary>
  /// Summary description for DrawDiagram.
  /// </summary>
  public class DrawSVGDirectedGraph : System.Web.UI.Page
  {
    GraphViz_dot gv; 
    string dot="";
    protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
    protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
    protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
    protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    string svg="";
  
    private void Page_Load(object sender, System.EventArgs e)
    {   
      string fn = System.Guid.NewGuid().ToString();
      gv= new GraphViz_dot(fn);
      DataSet dataset = new DataSet();
      string connection ="workstation id=jhodge02;packet size=4096;persist security info=True";
      string configfile =ConfigurationSettings.AppSettings["DBConnStr"];
      //connection+= ";initial catalog="+Request.QueryString.Get("db");
      string query=Request.QueryString.Get("proc_param");

      XmlDocument configFile = new XmlDocument();
      string xpath="";
      string dbid=Request.QueryString.Get("db");
      string configFileName = ConfigurationSettings.AppSettings["ConfigFile"];;
      configFile.Load(configFileName);
      xpath="//DB-Connection[@id='" + dbid +"']/@server";
      string server = configFile.SelectSingleNode(xpath).Value;
      connection+=";data source="+server;
      xpath="//DB-Connection[@id='" + dbid +"']/@database";
      string database = configFile.SelectSingleNode(xpath).Value;
      connection+=";initial catalog="+database;
      xpath="//DB-Connection[@id='" + dbid +"']/@uid";
      string uid = configFile.SelectSingleNode(xpath).Value;
      connection+=";user id="+uid;
      xpath="//DB-Connection[@id='" + dbid +"']/@pwd";
      string pwd = configFile.SelectSingleNode(xpath).Value;
      connection+=";password="+pwd;
      
      
      SqlConnection conn = new SqlConnection(connection);
      SqlDataAdapter adapter = new SqlDataAdapter();
      adapter.SelectCommand = new SqlCommand(query, conn);
      adapter.Fill(dataset);
      dot="digraph G{\n ";
      // For each table in the DataSet, print the row values.
      foreach(DataTable myTable in dataset.Tables)
      {
        foreach(DataRow myRow in myTable.Rows)
        {
          foreach (DataColumn myColumn in myTable.Columns)
          {
            dot+=(myRow[myColumn]);
          }
        }
      }
      dot+="}";
      gv.save_dot(dot);
      svg=gv.get_svg();
      Response.AddHeader("Content-Type","image/svg-xml");
      Response.Write(svg);
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
      //
      // CODEGEN: This call is required by the ASP.NET Web Form Designer.
      //
      InitializeComponent();
      base.OnInit(e);
    }
    
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {    
      this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
      this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
      this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
      this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
      this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
      // 
      // sqlDataAdapter1
      // 
      this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
      this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
      this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
      this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
      this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion
  }
}

