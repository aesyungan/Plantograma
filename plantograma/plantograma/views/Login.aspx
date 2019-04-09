<%@ Page Title="" Language="C#" MasterPageFile="~/Autentificacion.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="plantograma.views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_autentification" runat="server">
    <div class="col-lg-6 bg-white">
        <div class="form d-flex align-items-center">
            <div class="content">
                <form id="login-form" method="post">
                    <div class="form-group">
                        <asp:TextBox ID="login_username"  runat="server" CssClass="input-material"  required="" ></asp:TextBox>
                       
                        <label for="login_username" class="label-material">User Name</label>
                    </div>
                    <div class="form-group">
                         <asp:TextBox type="password" ID="login_password"  runat="server" CssClass="input-material"  required=""></asp:TextBox>
                       
                        <label for="login_password" class="label-material">Password</label>
                    </div>
                    <asp:LinkButton ID="login"  CssClass="btn btn-primary" runat="server" OnClick="login_Click">Login</asp:LinkButton>
                   <br />   
                    <!-- This should be submit button but I replaced it with <a> for demo purposes-->
                </form>
                <a href="#" class="forgot-pass">Forgot Password?</a><br>
                <small>Do not have an account? </small><a href="Register" class="signup">Signup</a>
            </div>
        </div>
    </div>
</asp:Content>
