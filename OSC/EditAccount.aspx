<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditAccount.aspx.vb" Inherits="OSC.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlMaster"  runat="server" class="col-sm-12 col-md-12 col-lg-12" BackColor="White">
                    <asp:Panel ID="pnlCreateAccountValidation" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="#FF6A6A">
            <table horizontal align="center">
               
                   <tr>
                    <td>
                        <asp:Label ID="lblValUserNameAlreadyExists" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblUsernameBlank" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblValPasswordsDoNotMatch" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValEmailNotCorrectFormt" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValPasswordNotCorrectFormat" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblNoRecoveryQuestionOrAnswer" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                     </tr><tr>
                       <td>
                          <asp:Label ID="lblvalrecovery" runat="server" Visible="false" Text=""></asp:Label></td>
                </tr>

            
            </table>

        </asp:Panel>
    <table align="center">
   
        <tr>
            <td class="col-form-label" colspan="2">
                <asp:Label ID="lbluserlbl0" runat="server" ForeColor="blue" Text="Username:" />

            </td>
            <td class="col-form-label" colspan="2">
                <asp:TextBox ID="txtUsername"  runat="server" cssclass="form-control"></asp:TextBox> </td>
            </tr>
           <tr>
              <td class="col-form-label" colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="blue" Text="First Name:" />

            </td>
            <td class="col-form-label" colspan="2">
                <asp:TextBox ID="txtFirst" placeholder="First" runat="server" cssclass="form-control" ></asp:TextBox>      </td>
            
            
            </td>
        </tr>
         <tr>
              <td class="col-form-label" colspan="2">
                <asp:Label ID="lbllast" runat="server" ForeColor="blue" Text="Last Name:" />

            </td>
            <td class="col-form-label" colspan="2">
                <asp:TextBox ID="txtLastName" placeholder="Last" runat="server" cssclass="form-control" ></asp:TextBox>      </td>     
            
            
            </td>
        </tr>
         <tr>
            <td class="col-form-label" colspan="2">
                <asp:Label ID="lbluserlbl" runat="server" ForeColor="blue" Text="Email:" />
             </td>
              <td class="col-form-label" colspan="2" >
                  <asp:TextBox ID="txtEmail" placeholder="Email@gmail.com" runat="server" cssclass="form-control"></asp:TextBox></td>
              </tr>

       <tr>
            <td class="col-form-label" colspan="2">
                <asp:Label ID="lblResetRecovery" viaible ="true" runat="server" ForeColor="blue" Text="Reset Recovery Question:" />
                  </td>
                <td class="col-form-label" colspan="2">
                    <asp:DropDownList ID="cboResetRecovery" AutoPostBack="true" Visible="true" DataSourceID="" DataTextField="Recovery_Question_Desc" DataValueField="Recovery_Question_id" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                  </td>
            
         </tr>
               <tr>
           
            <td class="col-form-label">
               <%-- <asp:TextBox ID="txtNewPassword" runat="server" Text="" TextMode="password" CssClass="form-control" Visible="true"></asp:TextBox>--%>
             <asp:Label ID="lblResetRecoveryAnswer" runat="server" ForeColor="blue" Text="Recovery Answer:" visible="true" />
                   </td>
        
            
           <td class="col-form-label" colspan="2">
               <asp:TextBox ID="txtRecoveryQuestionAnswer" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>
                   </td>
      
                  
        </tr>

        <tr>
            <td>
                <%-- <asp:Label ID="lblResetPassword2" runat="server" ForeColor="blue" Text="Retype New Password:" viaible="true" />--%>
            </td>
             <td class="col-form-label" colspan="2">
              

               <%--   <asp:TextBox ID="txtNewPassword2" Text="" TextMode="password" runat="server" CssClass="form-control" Visible="true"></asp:TextBox>--%>
              

              

            </td>
        </tr>

    </table>
        <table align="center">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
               <tr>
                <td>
                                   <asp:Button ID="btnSaveChanges" runat="server" CssClass="form-control" Text="Save Changes" />  
                   
                </td>
                    <td>
                                   <asp:Button ID="btncancel" runat="server" CssClass="form-control" Text="Cancel" />
                       
                </td>
                    <td>
                                  <asp:Button ID="btnChangePassword" runat="server" CssClass="form-control" Text="Change Password" />
                   
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
      
    </asp:Panel>
   
         <asp:label ID="lblUserid"  ForeColor="Blue" runat="server" visible="false" ></asp:label>
     <asp:label ID="lblRecoveryQuestionid"  ForeColor="Blue" runat="server" visible="false" ></asp:label>
        <asp:label ID="lblNewRecovQuestionid"  ForeColor="Blue" Text="" runat="server" visible="false" ></asp:label>
    <asp:label ID="lblrecoveryanswer"  ForeColor="Blue" Text ="" runat="server" visible="false" ></asp:label>
    <asp:label ID="lblNewRecovAnswer"  ForeColor="Blue" Text="" runat="server" visible="false" ></asp:label>
           <asp:label ID="lblemail"  ForeColor="Blue" runat="server" visible="false" ></asp:label>          
     <asp:label ID="lblFirstName"  ForeColor="Blue" runat="server" visible="false" ></asp:label>   
    <asp:label ID="lblLastName"  ForeColor="Blue" runat="server" visible="false" ></asp:label> 
    <asp:label ID="lblUsername"  ForeColor="Blue" runat="server" visible="false" ></asp:label> 
      <asp:label ID="lblPassword"  ForeColor="Blue" runat="server" visible="false" ></asp:label> 

          
</asp:Content>
