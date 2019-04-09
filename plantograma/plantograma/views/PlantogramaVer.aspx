<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="PlantogramaVer.aspx.cs" Inherits="plantograma.views.PlantogramaVer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdateProgress ID="content_loading" runat="server" AssociatedUpdatePanelID="BannerPanel">
        <ProgressTemplate>
            <div class="progres-bar">
                <div class="bar">
                    <div class="bar-data">
                        <i class="fa fa-cog fa-5x fa-spin" aria-hidden="true" style="color: white"></i>
                        <h5 style="color: white; font-size: 1.2em">Analizando..</h5>
                    </div>

                </div>

            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
    <!--header-->
    <h2 class="tituloSubPage">
        <asp:Image ID="imagenUsuario" runat="server" class="img-usuario" />
        <asp:Label CssClass="label-nombre" runat="server" ID="labelnombre"></asp:Label>
        <asp:Label CssClass="label-fecha" runat="server" ID="labelFecha"></asp:Label>

    </h2>

    <div class="bar-menu">
        <asp:UpdatePanel style="display: initial;" runat="server" ID="upPegresar">
            <ContentTemplate>
                <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-primary btnLeft btn-circle " OnClick="regresar"><i class="fa fa-arrow-circle-left"  aria-hidden="true"></i> </asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:LinkButton Style="float: right;" ID="btnImprimir" runat="server" CssClass="btn btn-success btnLeft btn-circle " OnClick="btnImprimir_Click"><i class="fa fa-print"  aria-hidden="true"></i> </asp:LinkButton>
        <!-- 
        <a style="float: right" class="btn btn-default fa fa-download btn-download"  onclick="genPDF()"></a>  -->

    </div>
    <!--fin header-->
    <!--update panel-->
    <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(LoadScriptIzquierdo);
                  Sys.Application.add_load(LoadScriptDerecho);
            </script>
            <div class="row m-2 bg-white">
                <div class="col-md-12 d-flex justify-content-center">
                    <asp:ObjectDataSource ID="ObjectDataSourcetipoAnalisis" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.TipoAnalisisLN"></asp:ObjectDataSource>
                    <asp:DropDownList ID="DropDownListTipoAnalisis" runat="server" DataSourceID="ObjectDataSourcetipoAnalisis" DataTextField="descrpcion" DataValueField="id_tipo_analisis"></asp:DropDownList>
                </div>
                <nav class="col-md-12 m-2">
                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-resultado-tab" data-toggle="tab" href="#nav-resultado" role="tab" aria-controls="nav-resultado" aria-selected="true">Resultados</a>
                        <a class="nav-item nav-link" id="nav-izquierdo-tab" data-toggle="tab" href="#nav-izquierdo" role="tab" aria-controls="nav-izquierdo" aria-selected="false">Izquierdo</a>
                        <a class="nav-item nav-link" id="nav-derecho-tab" data-toggle="tab" href="#nav-derecho" role="tab" aria-controls="nav-derecho" aria-selected="false">Derecho</a>
                    </div>
                </nav>
                <div class="col-md-12 tab-content m-2" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="nav-resultado" role="tabpanel" aria-labelledby="nav-home-tab">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <span>Derecho</span>
                                    </div>
                                    <% if (metodoDerecho == 0)
                                        {
                                    %>
                                    <table class=" col-md-12 table table-striped">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label29" runat="server" Text="Método="></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="Label30" runat="server" Text="Hernández Corvo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Medida Fundamental (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbmfDerecho" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="X (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbXDerecho" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Y (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbYDerecho" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="ai (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbaiDerecho" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="ta (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbtaDerecho" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" Text="logitud Pie (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblogitudPieDerecho" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="% X="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbresultadoPorcentajeDerecho" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="Tipo Tie="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="descripcionDerecho" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                    </table>
                                    <%}
                                        else
                                        { %>
                                    <table class=" col-md-12 table table-striped">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text="Método="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label26" runat="server" Text="Cavanagh y Rodgers"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="IA="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbIADerechoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="logitud Pie (Cm)="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblogitudPieDerechoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text="Tipo Tie="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="descripcionDerechoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <%} %>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <span>Izquierdo</span>
                                    </div>
                                    <% if (metodoIzquierda == 0)
                                        {
                                    %>
                                    <table class="col-md-12 table table-striped">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" Text="Método="></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="Label28" runat="server" Text="Hernández Corvo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Medida Fundamental (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbmfIzquierdo" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="X (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbXIzquierdo" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="Y (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbYIzquierdo" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="ai (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbaiIzquierdo" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="ta (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbtaIzquierdo" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="logitud Pie (Cm)="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblogitudPieIzquierdo" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text="% X="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbresultadoPorcentajeIzquierdo" runat="server" Text="0"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="Tipo Tie="></asp:Label></td>
                                            <td>
                                                <asp:Label ID="descripcionIzquierdo" runat="server" Text="0"></asp:Label></td>
                                        </tr>

                                    </table>
                                    <%}
                                        else
                                        { %>
                                    <table class=" col-md-12 table table-striped">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text="Método="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text="Cavanagh y Rodgers"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="IA="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbIAIzquierdoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text="logitud Pie (Cm)="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblogitudPieIzquierdoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label24" runat="server" Text="Tipo Tie="></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="descripcionIzquierdoM2" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="nav-izquierdo" role="tabpanel" aria-labelledby="nav-profile-tab">
                        <div class="row">
                            <div class="col-md-2 text-center border border-success">
                                <span>Izquierdo</span>
                                <a class="fa fa-pencil btn-edit" data-toggle="modal" data-target="#myModalEdit"></a>
                                <div class="humbral-huella">
                                    <asp:TextBox ID="TextBox2" runat="server" Text="230" CssClass="inputUmbral2" Enabled="false"></asp:TextBox>
                                    <asp:TextBox ID="txtUmbralIzquierdo" runat="server" Text="230" CssClass="inputUmbral2" Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" TargetControlID="txtUmbralIzquierdo" BoundControlID="TextBox2" Minimum="100" Maximum="300"></ajaxToolkit:SliderExtender>
                                    <div class="botones">
                                        <asp:LinkButton OnClick="btnAnalizarIzquierdo_Click" ID="btnAnalizarIzquierdo" runat="server" CssClass="btn btn-success btn-analizar">
                                       <i class="fa fa-stethoscope" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="img-huella">
                                    <asp:Image ID="imageIzquierdo" runat="server" class="img-izquierdo" />
                                </div>
                            </div>
                            <div class="col-md-10">
                                <div class="row">
                                    <div class="col-md-12 text-center border border-success">
                                        <asp:LinkButton Visible="false" OnClick="LinkButtonAnalizarIzquierdo_Click" ID="LinkButtonAnalizarIzquierdo" runat="server" CssClass="btn btn-primary">
                                       <i class="fa fa-bolt" aria-hidden="true"></i> Analizar
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-md-12 border border-success text-center">
                                        <asp:Image ID="imageIzquierdoAnalizado" runat="server" class="" />
                                    </div>
                                    <% if (Convert.ToInt32(DropDownListTipoAnalisis.SelectedValue) != 0 && LinkButtonAnalizarIzquierdo.Visible == true)
                                        { %>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-12 text-center">
                                                <button type="button" class="btn btn-success" id="btnIniciarIzquierdo">Iniciar corte</button>
                                                <button type="button" class="btn btn-primary" id="btnCortarIzquierdo">Finalizar corte</button>
                                            </div>
                                            <div class="col-md-12 text-center">
                                                <canvas id="myCanvasIzquierdo" class="my-canvas border border-success border-analisis"></canvas>
                                            </div>
                                        </div>
                                    </div>
                                    <% } %>
                                    <div class="col-md-12">
                                        <asp:TextBox CssClass="none-display" ID="txtDataIzquierda" Text="" runat="server"></asp:TextBox>
                                        <!--  <asp:TextBox CssClass="none-display" ID="txtIzquierdoTotalX" type="number" Text="0" runat="server"></asp:TextBox>
                                        <asp:TextBox CssClass="none-display" ID="txtIzquierdoTotalY" type="number" Text="0" runat="server"></asp:TextBox>
                                        <asp:TextBox CssClass="none-display" ID="txtIzquierdoSelectX" type="number" Text="0" runat="server"></asp:TextBox>
                                        <asp:TextBox CssClass="none-display" ID="txtIzquierdoSelectY" type="number" Text="0" runat="server"></asp:TextBox>-->
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="nav-derecho" role="tabpanel" aria-labelledby="nav-contact-tab">
                        <div class="row">
                            <div class="col-md-2 text-center border border-success">
                                <span>Derecho</span>
                                <a class="fa fa-pencil btn-edit" data-toggle="modal" data-target="#myModalEditDerecho"></a>
                                <div class="humbral-huella">
                                    <asp:TextBox ID="TextBox3" runat="server" Text="230" CssClass="inputUmbral2" Enabled="false"></asp:TextBox>
                                    <asp:TextBox ID="txtUmbralDerecho" runat="server" Text="230" CssClass="inputUmbral2" Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:SliderExtender ID="SliderExtender2" runat="server" TargetControlID="txtUmbralDerecho" BoundControlID="TextBox3" Minimum="100" Maximum="300"></ajaxToolkit:SliderExtender>
                                    <div class="botones">
                                        <asp:LinkButton ID="btnAnalizarDerecho" OnClick="btnAnalizarDerecho_Click" runat="server" CssClass="btn btn-success btn-analizar">
                                       <i class="fa fa-stethoscope" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="img-huella">
                                    <asp:Image ID="imageDerecho" runat="server" class="img-derecho" />
                                </div>
                            </div>
                            <div class="col-md-10">
                                <div class="row">
                                    <div class="col-md-12 text-center border border-success">
                                        <asp:LinkButton Visible="false" OnClick="LinkButtonAnalizarDerecho_Click" ID="LinkButtonAnalizarDerecho" runat="server" CssClass="btn btn-primary">
                                       <i class="fa fa-bolt" aria-hidden="true"></i>Analizar
                                        </asp:LinkButton>
                                    </div>
                                    <div class="col-md-12 text-center border border-success">
                                        <asp:Image ID="imageDerechoAnalizado" runat="server" class="" />
                                    </div>
                                    <% if (Convert.ToInt32(DropDownListTipoAnalisis.SelectedValue) != 0 && LinkButtonAnalizarDerecho.Visible == true)
                                        { %>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-12 text-center">
                                                <button type="button" class="btn btn-success" id="btnIniciarDerecho">Iniciar corte</button>
                                                <button type="button" class="btn btn-primary" id="btnCortarDerecho">Finalizar corte</button>
                                            </div>
                                            <div class="col-md-12 text-center">
                                                <canvas id="myCanvasDerecho" class="my-canvas border border-success border-analisis"></canvas>
                                            </div>
                                        </div>
                                    </div>
                                    <% } %>
                                    <div class="col-md-12">
                                        <asp:TextBox CssClass="none-display" ID="txtDataDerecho" type="text" Text="0" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--fin update panel-->

    <!-- Modal Edit pie Izquierdo-->

    <!-- Trigger the modal with a button -->


    <div id="myModalEdit" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Editar Izquierdo</h4>
                </div>
                <div class="modal-body">

                    <div class="subir">
                        <label for="FileUploadPlantaIzquierdo" class="label-material">IZquierdo</label>
                        <asp:FileUpload ID="FileUploadPlantaIzquierdo" runat="server" />

                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton OnClick="btnEditIzquierdo_Click" runat="server" ID="btnEditIzquierdo" CssClass="btn btn-primary"><i class="fa fa-plus-circle"  aria-hidden="true"> Editar</i></asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    <!--fin  Modal Edit pie Izquierdo-->

    <!-- Modal Edit pie derecho-->

    <!-- Trigger the modal with a button -->


    <div id="myModalEditDerecho" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Editar  Derecho</h4>
                </div>
                <div class="modal-body">
                    <div class="subir">
                        <label for="FileUploadPlantaDerecho" class="label-material">Derecho</label>
                        <asp:FileUpload ID="FileUploadPlantaDerecho" runat="server" />

                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton OnClick="btnEditDerecho_Click" runat="server" ID="btnEditDerecho" CssClass="btn btn-primary"><i class="fa fa-plus-circle"  aria-hidden="true"> Editar</i></asp:LinkButton>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    <!--fin  Modal Edit pie Derecho-->
</asp:Content>
