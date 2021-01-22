<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="login.aspx.vb" Inherits="OSC.WebForm3" %>

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
                        <asp:Label ID="lblnoRecoveryQuestionOrAnswer" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
            
            </table>

        </asp:Panel>
        <asp:Panel ID="pnlvalidation" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="#FF6A6A">
            <table horizontal align="center">
                <tr>
                    <td>
                        <asp:Label ID="lblValidationUsernameLogin" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationPasswordLogin" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationLoginFail" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationNoRecoveryQuestion" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationRecoveryAnswerWrong" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValidationResetPassword" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
                   <tr>
                    <td>
                        <asp:Label ID="lblValidationResetPasswordLength" runat="server" Visible="false" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

        </asp:Panel>
           <asp:Panel ID="pnlmakeacc" Visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="#FF6A6A">
               <table visible ="true" runat="server" id ="tblnoacc" align="center">
        <tr>
            <td>
                <asp:Label ID="lblvalmakeacc" Visible =" false" runat="server"  Text="Please make an account to view your profile. To view other user's profiles click on a post, comment, or on the leading users score board."></asp:Label>
            </td>
        </tr>
       </table>
               </asp:Panel>
         <asp:Panel ID="pnlCreateAccount" class="col-md-12" runat="server" Visible ="false" HorizontalAlign="center" BackColor="White">
            <table align="center">
                <tr>
                    <td>
                        <h3>
                            <asp:Label id="Label6" runat="server" Text="Create an Account" forecolor="blue"></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;

                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <asp:Label id="Label7" runat="server" Text="Username:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtBoxCreateUername" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label id="Label10" runat="server" Text="Email:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtCreateEmail" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label id="Label13" runat="server" Text="First Name:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtFirstName" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td>
                        <asp:Label id="Label14" runat="server" Text="Last Name:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtLastName" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                        <asp:Label id="Label11" runat="server" Text="Recovery Question:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:DropDownList ID="cboResetRecovery" Visible="true" DataSourceID="" DataTextField="Recovery_Questions_Desc" DataValueField="Recovery_Question_id" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label id="Label12" runat="server" Text="Recovery Question Answer:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                      <asp:TextBox id="txtRecoveryQuestionAnswer" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label8" runat="server" Text="Password:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtboXCreatePassword" TextMode="Password" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td>
                        <asp:Label id="Label9" runat="server" Text="Retype Password:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtboXCreatePassword2" TextMode="Password" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>&nbsp;

                    </td>
               <td>&nbsp;

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="BtnCreateAccount" runat="server" cssclass="form-control" Text="Create Account" />
                    </td>
                    <td>
                        <asp:Button id="btnCancelcreateaccount" runat="server" cssclass="form-control" Text="Cancel" />
                    </td>
              
                </tr>

            </table>
        </asp:Panel>
        <asp:Panel ID="PnlLogin" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="White">
            <table align="center">
                <tr>
                    <td>
                        <h3>
                            <asp:Label id="lblLogin" runat="server" Text="Login To Your Account" forecolor="blue"></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;

                    </td>
                </tr>
            </table>
            <table id ="tblUsernameAndPassword" runat="server" align="center">
                <tr>
                    <td>
                        <asp:Label id="lblusername" runat="server" Text="Username:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtUsername" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label2" runat="server" Text="Password:" forecolor="blue"></asp:Label>
                        &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtPassword" TextMode="Password" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>&nbsp;

                    </td>
                    <td>
                        &nbsp;  
                    </td>
                <td>
                        &nbsp;  
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="btnLogin" runat="server" cssclass="form-control" Text="Login" />
                    </td>
              <td>
                        <asp:Button id="btnForgotPassword" runat="server" cssclass="form-control" Text="Forgot Password" />
                    </td>   <td>
                        <asp:Button id="btnCreateAccountLoginpage" runat="server" cssclass="form-control" Text="Create Account" />
                    </td>
                     <td>
                        <asp:Button id="btneditAccount" runat="server" Visible="false" cssclass="form-control" Text="Edit Account" />
                    </td>
                </tr>

            </table>
        </asp:Panel>
        <asp:Panel ID="pnlforgotpassword" visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="White">
            <h3>
                <asp:Label id="lblRecoverAccount" align="center" forecolor="blue" runat="server" text="Recover Your Account"></asp:Label>
            </h3>
            <table align="center">
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" forecolor="blue" Text="Username:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtForgotUsername" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" forecolor="blue" Text="Email:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtEmail" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trRecovery" runat="server" visible="false">
                    <td>
                        <asp:Label id="lblRecoveryQuestion" forecolor="blue" runat="server"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtRecoverAnswer" cssclass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <asp:Button id="btnRecoverPassword" runat="server" cssclass="form-control" Text="Submit" />
                    </td>
                     <td>
                        <asp:Button id="btnCancelAccountRecover" runat="server" cssclass="form-control" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlresetPassword" visible="false" class="col-md-12" runat="server" HorizontalAlign="center" BackColor="White">
            <h3>
                <asp:Label id="Label3" align="center" forecolor="blue" runat="server" text="Reset Your Password"></asp:Label>
            </h3>
            <table align="center">
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label4" forecolor="blue" runat="server" Text="New Password:"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtResetPassword1"  cssclass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label id="Label5" forecolor="blue" runat="server" Text="Retype New Password"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox id="txtResetPassword2" TextMode="Password" cssclass="form-control" runat="server"></asp:TextBox>

                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button id="btnSubmitPasswordReset" runat="server" cssclass="form-control" Text="Submit" />
                    </td>
                     <td>
                        <asp:Button id="btnCancelPasswordReset" runat="server" cssclass="form-control" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>

    </asp:Panel>
    
    <asp:Label id="lblUserID" forecolor="blue" visible="false" runat="server" Text=""></asp:Label>
      <asp:Label id="lblPassword" forecolor="blue" visible="false" runat="server" Text=""></asp:Label>
</asp:Content>
