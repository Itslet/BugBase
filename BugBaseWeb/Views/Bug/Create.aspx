<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<BugBaseClasses.Model.Bug>" MasterPageFile="~/Views/Shared/BugBase.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form action="/Bug/Create" method="post" id="BugSubmitform"> 
            <div class="editor-label"> 
                <label for="Name">Name</label> 
            </div> 
            <div class="editor-field"> 
                <input id="Name" name="Name" type="text" value="" /> 
            </div> 
            <div class="editor-label"> 
                <label for="Description">Description</label> 
            </div> 
            <div class="editor-field"> 
                <textarea cols="20" id="Description" name="Description" rows="2"> 
            </textarea> 
            </div> 
            <p> 
                <input type="submit" value="Create" /> 
            </p> 
    </form> 
    
    <h6>Bug Created: </h6>
           
    <div> 
        <a href="/Bug">Back to List</a> 
    </div> 
    <div>
       
    </div>
    </asp:Content>