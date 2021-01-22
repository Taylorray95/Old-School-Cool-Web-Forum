<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ViewPosts.aspx.vb" Inherits="OSC.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
    <%-- <asp:Panel ID ="row" Class="row" backcolor="white"  runat="server">--%>

      <%--  <asp:Panel ID ="pnlmainpart" HorizontalAlign="center" backcolor="white" runat ="server" >--%>
           <table cellspacing="0"   align="center">
              <tr><td><h3> <asp:Label ID="lbltheheader"  Font-Underline="true" runat="server"  Text="Posts" ForeColor="Blue"></asp:Label></h3></td>
                 
                  
                     
                          <td>
                              <h3>
                                  <asp:Label ID="lbltheUser" runat="server" Font-Underline="true" ForeColor="Blue" Text="Author"></asp:Label>
                              </h3>
                          </td>
                      </tr>

                          
                  
             
                        <asp:Repeater ID="rptViewbyCategory" runat="server" DataSourceID="">
                           <%-- <HeaderTemplate>
                               
                                      <tr>
                <th>
                      
                </th>
            </tr>
                                
                            </HeaderTemplate>--%>
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

         <table align="center">
             <tr>
                 <td align="center">
                     <asp:Button ID="btnNewPost" CssClass="form-control" runat="server" Text="Create a new post" />
                 </td>
             </tr>
         </table>
          <asp:Label id="lblpostcategoryid" runat="server" Text="" visible="false" ></asp:Label>
            <asp:Label id="lblpostid" runat="server" Text="" visible="false" ></asp:Label>
         </asp:Panel>
    <%--  </asp:Panel>--%>
<%--    </asp:Panel>--%>
       </asp:Content>
