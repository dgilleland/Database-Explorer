<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatabaseTableExplorer.aspx.cs" Inherits="DatabaseTableExplorer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Table Explorer</title>
    <!-- Fake FavIcon -->
    <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon">

    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/css/bootstrap-theme.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <!-- Font-Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 class="page-header">Database Table Explorer</h1>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="ServerName">Database Server</asp:Label>
                    <asp:TextBox ID="ServerName" runat="server" list="commonDatabaseServers"></asp:TextBox>
                    <datalist id="commonDatabaseServers">
                        <option value="." />
                        <option value="./SQLEXPRESS" />
                    </datalist>

                    <asp:Label ID="Label2" runat="server" AssociatedControlID="DatabaseNames">Databases</asp:Label>
                    <asp:DropDownList ID="DatabaseNames" runat="server" AppendDataBoundItems="true"
                        DataSourceID="DatabaseNameDataSource" DataTextField="DATABASE_NAME" DataValueField="DATABASE_NAME">
                        <asp:ListItem Value="master">[Select a database]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="DatabaseNameDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListDatabases" TypeName="DbExplorer.BLL.Controller" OnObjectCreating="DataSource_ObjectCreating"></asp:ObjectDataSource>

                    <asp:LinkButton ID="ShowTables" runat="server" OnClick="ShowTables_Click">Show Tables</asp:LinkButton>

                    <asp:GridView ID="TableInfoListView" runat="server" Visible="false" DataSourceID="TableNameDataSource" DataKeyNames="FullyQualifiedTableName" ItemType="DbExplorer.Entities.TableInfo" AutoGenerateColumns="False" AllowSorting="true">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                            <asp:BoundField DataField="TableName" HeaderText="Table Name" SortExpression="TableName"></asp:BoundField>
                            <asp:BoundField DataField="SchemaName" HeaderText="Schema" SortExpression="SchemaName"></asp:BoundField>
                            <asp:BoundField DataField="FullyqualifiedTableName" HeaderText="Full Name"></asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="TableNameDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListTables" TypeName="DbExplorer.BLL.Controller" OnObjectCreating="DataSource_ObjectCreating" OnSelected="TableNameDataSource_Selected" SortParameterName="sortExpression"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
