<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BugBaseClasses.Model.User>" MasterPageFile="~/Views/Shared/BugBase.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %><br />
      <% using (Html.BeginForm()) { %>
    <label for="email">email</label>
    <%= Html.TextBoxFor(model => model.Email) %><br />
    <label for="password">password</label>
    <%= Html.PasswordFor(model => model.Password) %><br />
   
    <input type="submit" value="Log in"/>


   
<% } %>
    </div>
    </asp:Content>
