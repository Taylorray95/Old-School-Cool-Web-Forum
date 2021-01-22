<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="About.aspx.vb" Inherits="OSC.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
               <asp:Panel ID="pnlvalidation" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center"  BackColor="#FF6A6A" >
             <table horizontal align="center">
                 <tr>
                     <td>
                         <asp:Label ID="lblValidationMessage" runat="server" Visible="true" Text=""></asp:Label>
                     </td>
                 </tr>
               
             </table>

         </asp:Panel>
<tABLE align="center">
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
  
    <tr>
        <td>
            <asp:Label ID="lblAbout" runat="server" ForeColor="blue" Text="Welcome to the Web Forum. Here you can create an account or remain anonymous. You can post in different categories, comment on posts,
                as well as view other user's profiles. You gain points to your profile's score by making posts, and making comments on them. As you score grows, so will your rank. Enjoy your stay!" />
        </td>
    </tr>
    <tr>
        <td>
             <asp:Label ID="lblsucc" runat="server" ForeColor="red" Visible =" false" Text="Your report has been sent. Thankyou." />
        </td>
        </tr>
    <tr>
        <td>&nbsp; </td>
    </tr>
    <tr>
        <td>&nbsp; </td>
    </tr>
   
</tABLE>
            <asp:Panel ID="pnlReportBug" Visible="true" runat="server">
            <table align="center">
                <tr>
                    <td>
                        <asp:Button ID="btnReportabug" runat="server" CssClass="form-control" Text="Report a Bug" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
            
    <asp:Panel ID="pnlReportForm" Visible="false" runat="server">
            <table align="center">
                <tr>
                    <td>
                        <asp:TextBox ID="txtboxBug" CssClass="form-control" TextMode="MultiLine" rows="6" placeholder="Bug Report goes here..." runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
             <table align="center">
                <tr>
                    <td>
                         <asp:Button ID="btnSubmitBug" runat="server" CssClass="form-control" Text="Submit" /> 
                    </td>
                     <td>
                          <asp:Button ID="btnCancel" runat="server" CssClass="form-control" Text="Cancel" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
            </asp:Panel>
         <asp:label ID="lblUserID" visible="false" runat="server"  />


</asp:Content>
