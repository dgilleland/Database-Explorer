<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatabaseTableExplorer.aspx.cs" Inherits="DatabaseTableExplorer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Table Explorer</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
    </form>
</body>
</html>
