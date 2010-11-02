<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BugBaseClasses.Model.BugProject>>" MasterPageFile="~/Views/Shared/BugBase.Master" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Current projects</h2>
    
            
    <% foreach (var item in Model) { %>
    
    <table>
    <tr><th>Project</th><th><%: item.ProjectName %></th></tr>
    <tr><td>Description</td><td><%: item.ProjectDescription %></td></tr>
    <tr><td>Owner</td><td><%: item.ProjectOwner.UserName %></td></tr>
    <tr><td rowspan="2"><%: Html.ActionLink("Find bugs", "Index", "Bug", new {  id=item.Id }, null)%> 
    </td></tr>
    <% } %>
    </table>
</asp:Content>