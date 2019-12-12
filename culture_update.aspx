<%@ Page Title="" Language="C#" MasterPageFile="~/culture.Master" AutoEventWireup="true" CodeBehind="culture_update.aspx.cs" Inherits="HTTP_5101_FINAL_PatelKrishna.culture_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h1 id="header">Update Information</h1> 
            <div id="updateform" class="updatecultureitem" runat="server">
                
                <div>
                   <label>Title of Culture:</label>
                    <asp:TextBox runat="server" class="inputtext" ID="culture_title" placeholder="ex. Kalamkari Paintings"></asp:TextBox>
                    <div><asp:RequiredFieldValidator runat="server" EnableClientScript="true" 
                        ControlToValidate="culture_title" ErrorMessage="*Please enter required text!" ForeColor="Red"></asp:RequiredFieldValidator></div>
                    <%-- <asp:RegularExpressionValidator runat="server" EnableClientScript="true" ControlToValidate="culture_title" ValidationExpression="^[a-zA-Z'.\s]{1,50}" ErrorMessage="Please enter a valid text" ForeColor="Red"/>--%>
                </div>
                <div>
                    <label>About Culture:</label>
                    <textarea ID="culture_about" class="inputtext" placeholder="ex.Kalamkari is painting..." runat="server"></textarea>
                    <asp:RequiredFieldValidator runat="server" EnableClientScript="true" 
                        ControlToValidate="culture_about" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <label>Select Menu:</label>
                    <asp:DropDownList id="menu_list" runat="server">
                        <asp:ListItem  Value="------Select Menu------" ></asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <asp:button ID="btn_update" Text="Update" runat="server" onClick="update_culture"></asp:button>
            
            </div>
</asp:Content>
