using DbExplorer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DatabaseTableExplorer : System.Web.UI.Page
{
    const string CONNECTION_STRING_VALUE = "Data Source={0};Initial Catalog={1};Integrated Security=true";
    private string SelectedConnectionString { get; set; }
    private void InitSelectedConnectionString(string dataSource, string initialCatalog)
    {
        SelectedConnectionString = string.Format(CONNECTION_STRING_VALUE, dataSource, initialCatalog);
    }

    #region Event Handlers
		    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ServerName.Text = ".";
        }
        InitSelectedConnectionString(ServerName.Text, DatabaseNames.SelectedValue);
        TableNameDataSource.DataBind();
    }

    protected void DataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = new Controller(SelectedConnectionString);
    }

    protected void TableNameDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
        }
    }

    protected void ShowTables_Click(object sender, EventArgs e)
    {
        InitSelectedConnectionString(ServerName.Text, DatabaseNames.SelectedValue);
        TableInfoListView.Visible = true;
        DataBind();
    }
	#endregion
}