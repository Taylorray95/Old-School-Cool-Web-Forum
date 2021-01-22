<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="View.aspx.vb" Inherits="OSC.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
    <%-- <asp:Panel ID ="row" Class="row" HorizontalAlign="center"  backcolor="white"  runat="server">

        <asp:Panel ID ="pnlmainpart" HorizontalAlign="center" backcolor="white" runat ="server" >--%>
           <table cellspacing="0" border="0" align="center" >
                        <asp:Repeater ID="rptViewbyCategory" runat="server" DataSourceID="">
                            <HeaderTemplate>
                                      <tr>
                <th>
                      
                </th>
            </tr>    
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                     <h3>  <asp:label ID="lblpost"  ForeColor="Blue" runat="server" Text='<%# Eval("Post_Title") %>'  /></h3>
                                    </td>
                                    <td>
                                       <asp:label ID="lblGoToUserProfile"  ForeColor="blue" runat="server"  Text="Posted by: "></asp:label> <asp:linkbutton ID="lblusername"  ForeColor="red" runat="server" commandname="view"  class="hoverable" text='<%# Eval("username") %>' CommandArgument='<%# Eval("user_id") %>' />
                                    </td>
                               </tr>
                                 <tr>   
                                     <td>
                                        <asp:label ID="lblUser"   ForeColor="Blue" runat="server" Text='<%# Eval("Post_Desc") %>'  />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater>
               </table>
          <asp:Panel ID="pnlval" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="#FF6A6A">
            <table horizontal align="center">
               
                   <tr>
                    <td>
                        <asp:Label ID="lblValCommentEmpty" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblValCommentShort" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                 
            </table>

        </asp:Panel>
                       <table cellspacing="0" border="0" align="center" >
                               
                 <tr><td>&nbsp;</td></tr>       
      
                <tr><td>
                    <asp:TextBox ID="txtComment" placeholder="Type your Comment here.." runat="server"></asp:TextBox>
                    </td></tr> 
               <tr>
                   <td>
                       <asp:Button ID="btnSaveComment" runat="server" CssClass="form-control" Text="Submit" />
                   </td>
               </tr>
               <tr>
                   <td>
                        &nbsp;
                   </td>
               </tr>
          
               <tr><td>

                                          <asp:Label ID="Label1" ForeColor="Blue" runat="server" text="Comments:"></asp:Label>
                                
                   </td></tr></table>
           <table cellspacing="0" border="0" align="center" >
                        <asp:Repeater ID="rptComments" runat="server" DataSourceID="" >
                           <%-- <HeaderTemplate>
                               
                                      <tr>
                <th>
                      
                </th>
            </tr>
                                
                            </HeaderTemplate>--%>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:linkbutton ID="lblusercomment" Font-Underline="true" CommandName="view" class="hoverable" ForeColor="red" runat="server" CommandArgument='<%# Eval("user_id") %>' Text='<%# Eval("username") %>'  />
                                    </td>
                               </tr>
                                 <tr>   
                                     <td>
                                        <asp:label ID="lblcomment" CommandName="view"  ForeColor="Blue" runat="server" Text='<%# Eval("comment_desc") %>'  />
                                    </td>
                                </tr>
                                <tr><td>
                                    &nbsp;
                                    </td></tr>
                            </ItemTemplate>
                          <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater>

                        

                </table>
         </asp:Panel>
       <asp:label ID="lblUserID" visible="false" runat="server"  />
     <asp:label ID="lblPostId" visible="false" runat="server"  />
                             
<%--      </asp:Panel>
    </asp:Panel>--%>
      

    </asp:Content>
