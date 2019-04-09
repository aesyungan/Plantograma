<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="plantograma.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/home.css" rel="stylesheet" />
    <link href="css/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="css/bootstrap-4.0.0-alpha.6-dist/popper.min.js"></script>
    <link href="css/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/spinner.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <!-- process analizando -->
        <asp:UpdateProgress ID="content_loading" runat="server" AssociatedUpdatePanelID="BannerPanel">
            <ProgressTemplate>
                <i class="fa fa-cog fa-5x fa-spin" aria-hidden="true" style="color: white"></i>
                <h5 style="color: white">Analizando..</h5>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <!-- process show subir -->
        <%-- <asp:UpdateProgress ID="content_upload" runat="server" AssociatedUpdatePanelID="conten_subir">
            <ProgressTemplate>
                <i class="fa fa-spinner fa-5x fa-spin" aria-hidden="true" style="color: white"></i>
                <h5 style="color: white">Subiendo Archivo..</h5>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>

        <div class="allContainer">
            <div class="header">
                <img src="graficos/logo.png" class="logo" />
                <h2>Plantograma </h2>
            </div>
            <div class="contenedor">
                <%-- <asp:UpdatePanel ID="conten_subir" runat="server" UpdateMode="Always">

                    <ContentTemplate>--%>
                <div class="subir">
                    <asp:FileUpload ID="FileUploadPlanta" runat="server" />
                    <asp:Button ID="Button1" runat="server" Text="Subir" OnClick="Button1_Click" CssClass="btn btn-primary" />

                    <asp:Label ID="Label1" runat="server" Text="No Se Ha subido Nada"></asp:Label>
                </div>
                <%--     </ContentTemplate>
                </asp:UpdatePanel>--%>


                <div class="original">
                    <h4>Original</h4>
                    <asp:RadioButtonList ID="rblistPie" runat="server">
                        <asp:ListItem Text="Derecho" Value="0" />
                        <asp:ListItem Text="Izquierdo" Value="1" />
                    </asp:RadioButtonList>



                    <asp:Image ID="imgSubida" runat="server" class="img-original" />

                </div>

                <div class="imgEdit">

                    <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Always">

                        <ContentTemplate>

                            <h4>Editado</h4>
                            <div class="editDatos">
                                <asp:Label ID="Label2" runat="server" Text="Umbral: "></asp:Label>

                                <asp:TextBox ID="TextBox2" runat="server" Text="230" CssClass="inputUmbral" Enabled="false"></asp:TextBox>
                                <asp:TextBox ID="txtUmbral" runat="server" Text="230" CssClass="inputUmbral" Enabled="false" OnTextChanged="changeUmbral"></asp:TextBox>
                                <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" TargetControlID="txtUmbral" BoundControlID="TextBox2" Minimum="100" Maximum="300"></ajaxToolkit:SliderExtender>

                                <asp:Button ID="btnConvertir" runat="server" Text="Editar" OnClick="btnConvertir_Click" CssClass="btn btn-primary btn-editar" autopostback="true" />
                                <asp:Button ID="btnaalizar" runat="server" Text="Analizar" CssClass="btn btn-success btn-editar" autopostback="true" OnClick="btnaalizar_Click" />


                            </div>



                            <asp:Panel ID="PanelResultado" runat="server" CssClass="resultado">
                                <h5>Resultado</h5>
                                <div>
                                    <table class="table table-striped">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Medida Fundamental (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbmf" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="X (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbX" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Y (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbY" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="ai (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbai" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="ta (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbta" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="logitud Pie (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblogitudPie" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="% X="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbresultadoPorcentaje" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="Tipo Tie="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="descripcion" runat="server" Text="0"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>


                            <div class="editView">

                                <asp:Image ID="imgEditada" runat="server" class="img" />
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>


            </div>
        </div>
    </form>
</body>
</html>
