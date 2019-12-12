<%@ Page Title="" Language="C#" MasterPageFile="~/culture.Master" AutoEventWireup="true" CodeBehind="culture_list.aspx.cs" Inherits="HTTP_5101_FINAL_PatelKrishna.culture_list" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        
        <div>
            <h1 id="header">List of Cultures -test123</h1>
        </div>
        <div id="crud_3btn">
            <asp:button id="add_btn" Text="Add" class="crud_button" runat="server" OnClick="add"></asp:button>
        </div>
        <div id="table_container" class="container" runat="server" style="display:flex">
            
            <div id="culture_items" class="column" runat="server">
                <div class="column_name">Culture</div>
            </div>
            <div  id="about_items" class="column" runat="server">
                <div class="column_name">About</div>
            </div>
            <div  id="menu_items" class="column" runat="server">
                <div class="column_name">menu</div>
            </div>
            <div id="list_controls" class="column" runat="server">
                <div class="column_name">Actions</div>
            </div>

            
      </div>
        
    


</asp:Content>
