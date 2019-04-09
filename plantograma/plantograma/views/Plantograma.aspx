<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Plantograma.aspx.cs" Inherits="plantograma.views.Plantograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%-- agrear usuario--%>
    <asp:Panel CssClass="pannel-center" runat="server" ID="panelAddPlantograma" Visible="false">
        <div class="addUser">
            <div class="page login-page">

                <div class="container d-flex align-items-center center-contenido">
                    <div class="form-holder has-shadow align-items-center center-contenido">
                        <div class="row align-items-center center-contenido">

                            <div class="col-lg-6 bg-white align-items-center center-contenido">
                                <div class="form d-flex align-items-center center-contenido">

                                    <div id="register-form" class="content-all-user">
                                        <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <h3 style="color: #aaa;">Añadir Plantograma</h3>
                                                </div>
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <div class="subir">
                                                        <label for="FileUploadPlantaDerecho" class="label-material">Derecho</label>
                                                        <asp:FileUpload ID="FileUploadPlantaDerecho" runat="server" />

                                                    </div>
                                                    <div class="subir">
                                                        <label for="FileUploadPlantaIzquierdo" class="label-material">Izquierdo</label>
                                                        <asp:FileUpload ID="FileUploadPlantaIzquierdo" runat="server" />

                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="botones">
                                            <asp:LinkButton runat="server" ID="btnCalcel" CssClass="btn btn-danger" OnClick="btnCalcel_Click"><i class="fa fa-plus-circle"  aria-hidden="true"> Cancelar</i></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnNuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click"><i class="fa fa-plus-circle"  aria-hidden="true"> Add</i></asp:LinkButton>


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
    <!--agregar usuario fin -->
    <asp:Panel runat="server" ID="panelAllPlantograma">
        <h2 class="tituloSubPage">
            <asp:Image ID="imagenUsuario" runat="server" class="img-usuario" />
            <asp:Label CssClass="label-nombre" runat="server" ID="labelNombreUsuario"></asp:Label>
            <asp:Label CssClass="label-fecha" runat="server" ID="labelFecha"></asp:Label>

        </h2>

        <div class="bar-menu">
            <asp:UpdatePanel style="display: initial;" runat="server" ID="upPegresar">
                <ContentTemplate>
                    <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-primary btnLeft btn-circle " OnClick="regresar"><i class="fa fa-arrow-circle-left"  aria-hidden="true"></i> </asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" CssClass="btn btn-success btnLeft btn-circle" OnClick="shopanelAdd"><i class="fa fa-plus-circle"  aria-hidden="true"></i> </asp:LinkButton>
            <asp:LinkButton Style="float: right;" ID="btnImprimir" runat="server" CssClass="btn btn-success btnLeft btn-circle " OnClick="btnImprimir_Click"><i class="fa fa-print"  aria-hidden="true"></i> </asp:LinkButton>

        </div>
        <asp:UpdatePanel runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="allData">
                    <asp:ListView runat="server" ID="lvwDatos" DataKeyNames="idPlantograma" OnSelectedIndexChanging="selectedIndexChanging">
                        <ItemTemplate>
                            <span class="item-content">
                                <asp:LinkButton runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-square-o" aria-hidden="true"></i></asp:LinkButton>

                                <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>

                                <asp:LinkButton OnCommand="btnVerClic" runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli item-max" CommandArgument='<%# Eval("idPlantograma") %>'>
                              <div class="statistic d-flex align-items-center bg-white has-shadow item-item" style="height: 4em;">
                                    
                            
                          
                            <div id="item_todo_row">
                                <img src="../graficos/huellapie.jpg" width="50" height="50" alt="User" id="imgselect" />
                                <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                            </div>

                            <div id="item_todo_row">
                               <span class="span-name"> <%# Eval("fechaCreacion")%></span>
                            </div>

                        
                                 </div>
                                </asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <SelectedItemTemplate>
                            <span class="item-content">

                                <asp:LinkButton runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-check-square-o" aria-hidden="true"></i></asp:LinkButton>
                                <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>
                                <asp:LinkButton OnCommand="btnVerClic" runat="server" CssClass="statistic  align-items-center bg-white item-dato item-max" CommandArgument='<%# Eval("idPlantograma") %>'>
                           
                            <div class="statistic d-flex align-items-center bg-white has-shadow item-item item-item-selected" style="height: 4em;">
                              
                             
                        
                            <div id="item_todo_row">
                                <img src="../graficos/huellapie.jpg" width="50" height="50" alt="User" id="imgselect" />
                                <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                            </div>

                            <div id="item_todo_row">
                              <span class="span-name"> <%# Eval("fechaCreacion")%></span>
                            </div>

                        
                                
                            </div>
                                </asp:LinkButton>
                                <div id="item_botonesGroup">
                                    <!-- <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("idPlantograma") %>' runat="server" CssClass="btn btn-success btn-circle">
                                             <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                    </asp:LinkButton>-->
                                    <asp:LinkButton ID="lnkRemove" CommandArgument='<%# Eval("idPlantograma") %>' Text="Eliminar" runat="server" OnCommand="lnkRemove_Click" CssClass="btn btn-danger btn-circle">
                       
                                      <i class="fa fa-trash-o" aria-hidden="true"></i>
                                    </asp:LinkButton>
                                </div>
                            </span>
                        </SelectedItemTemplate>

                    </asp:ListView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
