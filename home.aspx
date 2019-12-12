<%@ Page Title="" Language="C#" MasterPageFile="~/culture.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="HTTP_5101_FINAL_PatelKrishna.home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>
    <html>
        <head>
            <title>home page</title>
        </head>
        <body>
            <header></header>
            <form>
                <asp:button class="crud_button" runat="server" ID="home_btn" text="List of Cultures" OnClick="list_page">
                </asp:button>
            </form>
        </body>
    </html>

</asp:Content>

