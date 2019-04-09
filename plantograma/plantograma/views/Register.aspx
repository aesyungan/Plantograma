<%@ Page Title="" Language="C#" MasterPageFile="~/Autentificacion.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="plantograma.views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_autentification" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="col-lg-6 bg-white">
        <div class="form d-flex align-items-center">
            <div class="content">
                <form id="register-form">
                    <h2 class="input-material">Nuevo Usuario</h2>
                    <br />
                    <br />
                    <div class="form-group">
                        <asp:TextBox ID="register_cedula" runat="server" CssClass="input-material" required=""></asp:TextBox>

                        <label for="register_cedula" class="label-material">Cedula</label>
                    </div>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <div class="form-group">

                                    <asp:TextBox ID="register_nombres" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                    <label for="register_nombres" class="label-material">Nombres</label>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">

                                    <asp:TextBox ID="register_apellidos" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                    <label for="register_apellidos" class="label-material">Apellidos</label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Sexo</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceSexo" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.SexoLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListSexo" runat="server" DataSourceID="ObjectDataSourceSexo" DataTextField="descrpcion" DataValueField="id_sexo">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Formación Profecional</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceFormacionProfecional" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.FormacionProfecionalLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListFormacionProfecional" runat="server" DataSourceID="ObjectDataSourceFormacionProfecional" DataTextField="descrpcion" DataValueField="id_formacionProfecional">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Especialidad</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceEspecialidad" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.EspecialidadLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListEspecialidad" runat="server" DataSourceID="ObjectDataSourceEspecialidad" DataTextField="descrpcion" DataValueField="id_especialidad">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Nacionalidad</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceNacionalidad" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.NacionalidadLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListNacionalidad" runat="server" DataSourceID="ObjectDataSourceNacionalidad" DataTextField="descrpcion" DataValueField="id_nacionalidad">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Autoidentificación</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceAutoidentificación" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.AutoidetificacionLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListAutoidentificación" runat="server" DataSourceID="ObjectDataSourceAutoidentificación" DataTextField="descrpcion" DataValueField="id_autoidetificacion">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Codigo MPS</p>
                                    <asp:ObjectDataSource ID="ObjectDataSourceCodigoMPS" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.CodigoMPSLN"></asp:ObjectDataSource>
                                    <asp:DropDownList ID="DropDownListCodigoMPS" runat="server" DataSourceID="ObjectDataSourceCodigoMPS" DataTextField="descrpcion" DataValueField="id_codigoMPS">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="register_fechaNacimiento" type="date" runat="server" CssClass="input-material" required=""></asp:TextBox>
                                    <label for="register_fechaNacimiento" class="label-material">Fecha Nacimiento</label>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="register_passowrd" runat="server" CssClass="input-material" required="" Type="password"></asp:TextBox>
                                    <label for="register_passowrd" class="label-material">Password</label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="form-group terms-conditions">
                        <asp:CheckBox ID="license" runat="server" />

                        <label for="license">Agree the terms and policy</label>
                    </div>
                    <asp:Button ID="register" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="register_Click" />
                </form>
                <small>Already have an account? </small><a href="Login" class="signup">Login</a>
            </div>
        </div>
    </div>
</asp:Content>
