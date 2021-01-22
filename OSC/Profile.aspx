<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.vb" Inherits="OSC.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
         
         
   
         <table align="center">
        <tr colspan="10" align="center" align="center">
        
            <td class="col-form-label" colspan="2">
                
            </td>
                  
             <td class="col-form-label" colspan="2">

            </td>
            <td class="col-form-label" colspan="2">
                &nbsp;</td>
          <td class="col-form-label" colspan="2">

            </td>
           <td class="col-form-label" colspan="2">

            </td>
        </tr>
        <tr colspan="10">
            <td class="col-form-label" colspan="2">
                <asp:Label ID="lbluserlbl" runat="server" ForeColor="blue" Text="Username:" />

            </td>
            <td class="col-form-label">
                <asp:Label ID="lblUsername" runat="server" ForeColor="red" text="Anonymous" />
            </td>
            <td>

            </td>
              <td class="col-form-label" colspan="2">
                  </td>
              <td class="col-form-label" colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="blue" Text="Name:" />

            </td>
            <td class="col-form-label">
                <asp:Label ID="lblname" runat="server" ForeColor="red" text="Anon User" />
            </td>
        </tr>
         <tr colspan="10">
            <td class="col-form-label" colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="blue" Text="Score:" />

            </td>
              <td class="col-form-label" >
                <asp:Label ID="lblscore" runat="server" ForeColor="red" text="0" />
            </td>
               <td>

             </td>
              <td class="col-form-label" colspan="2">
               

            </td>
            <td class="col-form-label" colspan="2">
               <asp:Label ID="Label4" runat="server" ForeColor="blue" Text="User Rank:" />
            </td>
               <td class="col-form-label">
                 <asp:Label ID="lblUserRank" runat="server" ForeColor="red" text="Noob" />
            </td>
         </tr>
               <tr colspan="10">
            <td class="col-form-label" colspan="2">
                <asp:Label ID="Label3" runat="server" ForeColor="blue" Text="Total Posts" />

            </td>
            <td class="col-form-label">
                <asp:Label ID="lblTotalPosts" runat="server" ForeColor="red" text="0" />
            </td>
                <td>

                   </td>
              <td class="col-form-label" colspan="2">
              

            </td>
           <td class="col-form-label" colspan="2">
               <asp:Label ID="Label9" runat="server" ForeColor="blue" Text="Total Comments" />
            </td>
                     <td class="col-form-label" colspan="2">
                           <asp:Label ID="lblTotalComments" runat="server" ForeColor="red" text="0" />
                         </td>
        </tr>

    </table>

         <table align="center">
             <tr>
                 <td>
                     <h3>
                         <asp:Label ID ="lblMyActivityHeader" runat="server" Text="Activity:" ForeColor ="blue" ></asp:Label>
                     </h3>
                 </td>
             </tr>
             </table>
         <table align ="center">
              <asp:Repeater ID="rptRecentPosts" runat="server" DataSourceID="">
                            <HeaderTemplate>
                               
                                      <tr>
                <th>
                                              <asp:Label runat="server" Text="Recent Posts" ForeColor ="blue" ></asp:Label>

                </th>
                                           <th>
                          <asp:Label runat="server" Text="    " ForeColor ="blue" ></asp:Label>
                </th>
                                           <th>
                          <asp:Label runat="server" Text="Post Date" ForeColor ="blue" ></asp:Label>
                </th>
            </tr>
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:linkbutton ID="lblPostTitle" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Post_id") %>' Text='<%# Eval("Post_Title") %>'/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:linkbutton ID="lblPostDate" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("Post_id") %>' Text='<%# Eval("sys_date") %>'  />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
      
    </FooterTemplate>
</asp:Repeater></table><table align="center">
               <asp:Repeater ID="rptCommentActivity" runat="server" DataSourceID="">
                            <HeaderTemplate>
                               
                                      <tr>
                <th>
                                              <asp:Label runat="server" Text="Recent Comments" ForeColor ="blue" ></asp:Label>

                </th>
                                            <th>
                          <asp:Label runat="server" Text="    " ForeColor ="blue" ></asp:Label>
                </th>
                                           <th>
                          <asp:Label runat="server" Text="Comment Date" ForeColor ="blue" ></asp:Label>
                </th>
            </tr>
                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:linkbutton ID="lblComment" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%#Eval("post_id") %>' Text='<%#Eval(CheckLength("Comment_Desc"))%>'/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:linkbutton ID="lblCommentDate" CommandName="view" class="hoverable" ForeColor="Blue" runat="server" CommandArgument='<%# Eval("post_id") %>' Text='<%# Eval("sys_date") %>'  />
                                    </td>
                                </tr>
                                
                            </ItemTemplate>
                          <FooterTemplate>
      
    </FooterTemplate>
</asp:Repeater>
         </table>
         <table align ="center">
             <tr>
                 <td>
                     <asp:Button ID="btnLogout" cssclass="form-control" runat="server" Text="Logout" />
                 </td>
                  <td>
                     <asp:Button ID="btnEditaccount" cssclass="form-control" runat="server" Text="Edit Account" />
                 </td>
             </tr>
         </table>
      

         <asp:label ID="lblUserid"  ForeColor="Blue" runat="server" visible="false" ></asp:label>
                                   
   
         </asp:Panel>
   


</asp:Content>
