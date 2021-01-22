<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UserPost.aspx.vb" Inherits="OSC.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
         <asp:Panel ID="pnlvalidation" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center"  BackColor="#FF6A6A" >
             <table horizontal align="center">
                 <tr>
                     <td>
                         <asp:Label ID="lblValidationTitle" runat="server" Visible="false" Text=""></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="lblValidationCategory" runat="server" Visible="false" Text=""></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Label ID="lblValidationBody" runat="server" Visible="false" Text=""></asp:Label>
                     </td>
                 </tr>
             </table>

         </asp:Panel>
        <table align="center" colspan="5">
            <tr align="center">
                <td>
                    &nbsp;
                </td>
                <td align="center" class="auto-style1">
                   <h3><asp:Label ID="lblpostheader" runat="server" ForeColor="blue" Text="Submit a Post"></asp:Label><asp:Label ID="lblpostcategorydesc" runat="server" Visible ="false" ForeColor="blue" Text=""></asp:Label><asp:Label ID="Label1" runat="server" Visible ="false" ForeColor="blue" Text=" Category."></asp:Label></h3> 
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="auto-style1">
                    &nbsp;
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" ForeColor="blue" Text="Title:"></asp:Label>&nbsp;
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtTitle" AutoPostBack="false" CssClass="form-control" Text="" runat="server"></asp:TextBox>

                </td>
                <td>

                </td>
            </tr>
            <tr>
             <td>
                    &nbsp;
                </td>
                <td class="auto-style1">
                    &nbsp;
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                         <td>
                     <asp:Label ID="lbl" runat="server" ForeColor="blue" Text="Category:"></asp:Label>&nbsp;
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="cboCategory" CssClass="form-control" AppendDataBoundItems="true" runat="server" DataSourceID="" DataTextField="post_category_desc" DataValueField="Post_category_id">
                    </asp:DropDownList>
                 
                  
                 
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
                    <tr>     <td>
                    &nbsp;
                </td>
                <td class="auto-style1">
                    &nbsp;
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblpostbody" runat="server" ForeColor="blue" Text="Post Body:"></asp:Label>&nbsp;
                </td>
                <td class="auto-style1">
                     <asp:TextBox ID="txtPostBody" AutoPostBack="false" multiline="true" CssClass="form-control" Text="" runat="server" Rows="20" TextMode="MultiLine"></asp:TextBox>
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;
                </td>
                <td class="auto-style1">
                    &nbsp;
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSubmit" CssClass="form-control" runat="server" Text="Submit" />
                </td>
                 <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
   

       <%-- <asp:SqlDataSource ID="sqlRetrieveUserScore" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString9 %>" SelectCommand="select Users.score from Users WHERE users.User_id = @User_id">
        <selectparameters>
                          
                                         <asp:QueryStringParameter DefaultValue="34545" Name="User_id" QueryStringField="User_id" Type="Int32" />

                            </selectparameters>

    </asp:SqlDataSource>

         <asp:GridView ID="GridUserScore" Visible="false" runat="server" AutoGenerateColumns="False"
    DataSourceID="sqlRetrieveUserScore" EnableViewState="False">
    <Columns>
        <asp:BoundField DataField="score" HeaderText="score" />

    </Columns>
</asp:GridView>

          <asp:SqlDataSource ID="sqlUpdateScore" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString10 %>" UpdateCommand="Update Users SET users.Score = @score WHERE users.user_id = @User_id">
        <updateparameters>
            <asp:QueryStringParameter DefaultValue="0" Name="score" QueryStringField="Score" Type="int32" />
            <asp:QueryStringParameter DefaultValue="0" Name="user_id" QueryStringField="user_id" Type="int32" />
                            </updateparameters>

    </asp:SqlDataSource> --%>
           <asp:label ID="lblUserID" visible="false" runat="server"  />
        <asp:label ID="lblpostid" visible="false" runat="server"  />
          <asp:label ID="lblpostcategoryid" visible="false" runat="server"  />
   
</asp:Content>
