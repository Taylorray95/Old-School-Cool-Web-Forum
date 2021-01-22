<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Error.aspx.vb" Inherits="OSC.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1> <asp:Label ID="lblerror" runat="server" Text="Error"></asp:Label></h1>
     <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
    <h3> <asp:linkbutton ID="btn" href="homepage.aspx" runat="server" Text="Oops..Something somewhere went wrong. Please click here to return to the home page."></asp:linkbutton></h3>
          </asp:Panel>
</asp:Content>
