<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.vb" Inherits="OSC.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
     <asp:Panel ID ="row" Class="row"  backcolor="white"  runat="server">
         <asp:Panel ID ="pnlsidebar" backcolor="white"  class="col-sm-3 col-md-6 col-lg-4" runat ="server">
           <table cellspacing="0" border="0" align="center">
               <tr><td>  <h3><asp:Label ID="lblheader"  Font-Underline="true" runat="server"  Text="View Posts By Category" ForeColor="Blue"></asp:Label></h3></td></tr>
                    <asp:Repeater ID="rptViewbyCategory" runat="server" DataSourceID="">
                           <HeaderTemplate>
                               
                                      <tr>
                <th scope="col">
                    
                </th>
            </tr>
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:linkbutton ID="lblcategorydesc" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Post_Category_id") %>' Text='<%# Eval("post_category_desc") %>' />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater></table>

          
         </asp:Panel>
        <asp:Panel ID ="pnlmainpart" backcolor="white" runat ="server" class="col-sm-3 col-md-6 col-lg-4">
              <table  align="center">
                  <tr><td> <h3><asp:Label ID="LblMostRecent"  Font-Underline="true" runat="server"  Text="View Posts by Most Recent" ForeColor="Blue"></asp:Label></h3></td>

                      </tr>

                </table>
            
            <table  align="center">
                     <asp:Repeater ID="rptByNew" runat="server" DataSourceID="">
                            <HeaderTemplate>
                               
                                      <tr>
                <th scope="col">
                     <asp:Label ID="Label1"  Font-Underline="true" runat="server"  Text="Title" ForeColor="Blue"></asp:Label>
                </th>
                                            <th scope="col">   
                                  <asp:Label ID="Label2" runat="server" Font-Underline="true" ForeColor="Blue" Text="Author"></asp:Label>
                              
                     
                </th>
            </tr>
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                             <tr>
                                    <td>
                                        <asp:linkbutton ID="lblpost" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Post_id") %>' Text='<%# Eval("Post_Title") %>'/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:linkbutton ID="lblUser" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Post_id") %>' Text='<%# Eval("username") %>'  />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater>
           </table>
             </asp:Panel>
          <asp:Panel ID ="pnlside" backcolor="white" runat ="server" class="col-sm-3 col-md-6 col-lg-4">
               <table  align="center">
                  <tr><td> <h3><asp:Label ID="Label3"  Font-Underline="true" runat="server"  Text="Leading Users" ForeColor="Blue"></asp:Label></h3></td>

                      </tr>

                </table>
                  <table  align="center">
                     <asp:Repeater ID="rptHotUsers" runat="server" DataSourceID="">
                            <HeaderTemplate>
                               
                                      <tr>
                
            </tr>
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                             <tr>
                                    <td>
                                        <asp:linkbutton ID="lblpost" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("user_id") %>' Text='<%# Eval("username") %>'/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:linkbutton ID="lblUser" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("user_id") %>' Text='<%# Eval("score") %>'  />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
        
    </FooterTemplate>
</asp:Repeater>
           </table>
              </asp:Panel>
         </asp:Panel>
              <table align="center" class="">
                  <tr>
                      <td>
                          &nbsp;
                      </td>
                  </tr>
                   <tr>
                      <td>
                          &nbsp;
                      </td>
                  </tr>
            <tr>
                <td>
                     <asp:Button ID="btnNewPost" runat="server" CssClass="form-control" Text="Submit a New Post"  />
                </td>
            </tr>
                          <tr>
                      <td>
                          &nbsp;
                      </td>
                  </tr>
                   <tr>
                      <td>
                          &nbsp;
                      </td>
                  </tr>
        </table>
      </asp:Panel>
    
             </asp:Content>
