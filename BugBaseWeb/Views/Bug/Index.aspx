<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BugBaseClasses.Model.Bug>>" MasterPageFile="~/Views/Shared/BugBase.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<h2><%= Html.ViewData["Name"] %></h2>

<table><tr>
<th>
                Name
            </th>
            <th>
                Description
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.BugSubmitter.UserName %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
        <!-- <td>
          
            </td> -->
    </p>

</asp:Content>
