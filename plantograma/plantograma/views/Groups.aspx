<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="plantograma.views.Groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel runat="server" ID="panelAllGroup">
        <h2 class="tituloSubPage">Todos los Grupos</h2>
        <div class="bar-menu">
            <asp:LinkButton runat="server" CssClass="btn btn-success btnLeft btn-circle" OnClick="clickShowAdd"><i class="fa fa-plus-circle "  aria-hidden="true" ></i> </asp:LinkButton>
        </div>
        <div class="allData">
            <asp:ListView runat="server" ID="lvwDatos" DataKeyNames="idGrupo" OnSelectedIndexChanging="selectedIndexChanging" EnableViewState="False">
                <ItemTemplate>


                    <span class="item-content">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                            <ContentTemplate>
                                <asp:LinkButton ID="sele" runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-square-o" aria-hidden="true"></i></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>
                        <asp:UpdatePanel style="display: initial;" runat="server" ID="UpdatePanel5" UpdateMode="Conditional">
                        <%--    <Triggers>
                                <asp:PostBackTrigger ControlID="dato2" />
                            </Triggers>--%>
                            <ContentTemplate>
                                <asp:LinkButton  ID="dato2" runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-clix|" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>
                                  <div class="statistic d-flex align-items-center bg-white has-shadow item-item" style="height: 4em;">
                                  <div class="icon bg-red"><i class="fa fa-users fa-2x " style="color: white;vertical-align: middle;" aria-hidden="true"></i></div>
                                        <div class="text">
                                                
                                                <small><%#Eval("nombreUnidad") %></small>
                                          </div>
                                 </div>
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </span>

                </ItemTemplate>
                <SelectedItemTemplate>


                    <span class="item-content">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn1" runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-check-square-o" aria-hidden="true"></i></asp:LinkButton>
                                <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">

                            <ContentTemplate>
                                <asp:LinkButton ID="btn2" runat="server" CssClass="statistic  align-items-center bg-white item-dato" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>
                            <div class="statistic d-flex align-items-center bg-white has-shadow item-item item-item-selected" style="height: 4em;">
                                <div class="icon bg-red"><i class="fa fa-users fa-2x " style="color: white; vertical-align: middle;" aria-hidden="true"></i></div>
                                <div class="text">
                                   
                                    <small><%#Eval("nombreUnidad") %></small>
                                </div>
                                
                            </div>
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="item_botonesGroup">
                            <asp:UpdatePanel style="display: inline-flex;" runat="server" ID="UpdatePanel2">
                                <ContentTemplate>
                                    <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("idGrupo") %>' runat="server" CssClass="btn btn-success btn-circle2" OnCommand="btnEdit">
                                             <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                    </asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel style="display: inline-flex;" runat="server" ID="UpdatePanel3">
                                <ContentTemplate>
                                    <asp:LinkButton ID="lnkRemove" CommandArgument='<%# Eval("idGrupo") %>' Text="Eliminar" runat="server" CssClass="btn btn-danger btn-circle2" OnCommand="btnremoveClic">
                       
                                      <i class="fa fa-trash-o" aria-hidden="true"></i>
                                    </asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </span>


                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </asp:Panel>
    <!--nuevo-->
    <asp:Panel runat="server" ID="panelAddNewGroup" Visible="false">
        <div class="addUser">
            <div class="page login-page">
                <div class="container d-flex align-items-center center-contenido">
                    <div class="form-holder has-shadow align-items-center center-contenido">
                        <div class="row" style="justify-content: space-evenly;">
                            <!-- Logo & Information Panel
                            <!-- Form Panel    -->
                            <div class="col-lg-6 bg-white">
                                <div class="form d-flex align-items-center">
                                    <div class="content" style="text-align: -webkit-center;">
                                        <h2>Nuevo Grupo</h2>
                                        <br />
                                        <div id="register-form" style="text-align: initial;">
                                            <div class="form-group">

                                                <asp:TextBox ID="nombreUnidad" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                <%--<label for="nombreUnidad" class="label-material">Nombre Unidad Operativa</label>--%>
                                                <label for="nombreUnidad" class="label-material">descripción</label>
                                            </div>

                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Lugar Atención </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourcelugarAtencion" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.LugarAtencionLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListlugarAtencion" runat="server" DataSourceID="ObjectDataSourcelugarAtencion" DataTextField="descrpcion" DataValueField="id_lugarAtencion">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Tipo Establecimiento </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourceTipoEstablecimiento" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.TipoEstableLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListTipoEstablecimiento" runat="server" DataSourceID="ObjectDataSourceTipoEstablecimiento" DataTextField="descrpcion" DataValueField="id_tipoEstable">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Institucion del Sistema </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourceInstituciondelSistema" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.InstitucionSistemaLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListInstituciondelSistema" runat="server" DataSourceID="ObjectDataSourceInstituciondelSistema" DataTextField="descrpcion" DataValueField="id_institucionSistema">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="botones" style="text-align: center">
                                                <asp:LinkButton runat="server" ID="btnNuevo1" CssClass="btn btn-primary" Text="Add" OnClick="btnNuevo_Click" />
                                                <asp:LinkButton runat="server" ID="btnCalcel" CssClass="btn btn-danger" OnClick="btnCalcel_Click"><i class="fa fa-plus-circle"  aria-hidden="true"> Cancelar</i></asp:LinkButton>

                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--panel editar-->
    <asp:Panel runat="server" ID="panelEditGroup" Visible="false">
        <div class="addUser">
            <div class="page login-page">
                <div class="container d-flex align-items-center center-contenido">
                    <div class="form-holder has-shadow align-items-center center-contenido">
                        <div class="row" style="justify-content: space-evenly;">
                            <!-- Logo & Information Panel
                            <!-- Form Panel    -->
                            <div class="col-lg-6 bg-white">
                                <div class="form d-flex align-items-center">
                                    <div class="content" style="text-align: -webkit-center;">
                                        <h2>Editar Grupo</h2>
                                        <br />
                                        <div id="register-form" style="text-align: initial;">
                                            <div class="form-group">

                                                <asp:TextBox ID="nombreUnidadEdit" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                <%-- <label for="nombreUnidadEdit" class="label-material">Nombre Unidad Operativa</label>--%>
                                                <label for="nombreUnidadEdit" class="label-material">Descripción</label>
                                            </div>

                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Lugar Atención </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourcelugarAtencionEdit" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.LugarAtencionLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListlugarAtencionEdit" runat="server" DataSourceID="ObjectDataSourcelugarAtencionEdit" DataTextField="descrpcion" DataValueField="id_lugarAtencion">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Tipo Establecimiento </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourceTipoEstablecimientoEdit" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.TipoEstableLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListTipoEstablecimientoEdit" runat="server" DataSourceID="ObjectDataSourceTipoEstablecimientoEdit" DataTextField="descrpcion" DataValueField="id_tipoEstable">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Institucion del Sistema </p>
                                                <asp:ObjectDataSource ID="ObjectDataSourceInstituciondelSistemaEdit" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.InstitucionSistemaLN"></asp:ObjectDataSource>
                                                <asp:DropDownList ID="DropDownListInstituciondelSistemaEdit" runat="server" DataSourceID="ObjectDataSourceInstituciondelSistemaEdit" DataTextField="descrpcion" DataValueField="id_institucionSistema">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="botones" style="text-align: center">
                                                <asp:LinkButton runat="server" ID="btnEditarPanel1" CssClass="btn btn-primary" Text="Editar" OnClick="btnEditarPanel_Click" />
                                                <asp:LinkButton runat="server" ID="btnCalcelEdit" CssClass="btn btn-danger" OnClick="btnCalcelEdit_Click"><i class="fa fa-plus-circle"  aria-hidden="true"> Cancelar</i></asp:LinkButton>

                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--panel editar fin-->
</asp:Content>

