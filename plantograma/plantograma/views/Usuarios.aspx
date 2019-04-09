<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="plantograma.views.Usuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>


            <%-- agrear usuario--%>
            <asp:Panel runat="server" ID="panelAddUser" Visible="false">
                <div class="addUser">
                    <div class="page login-page">

                        <div class="container d-flex align-items-center center-contenido ">
                            <div class="form-holder has-shadow align-items-center center-contenido">
                                <div class="row align-items-center center-contenido">

                                    <div class="col-lg-6 bg-white align-items-center center-contenido">
                                        <div class="form d-flex align-items-center center-contenido">

                                            <div id="register-form" class="content-all-user">
                                                <asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <div class="form-group">
                                                            <h3 style="color: #aaa;">Añadir Paciente</h3>
                                                        </div>
                                                        <div class="form-group" style="margin-bottom: 0">

                                                            <asp:TextBox ID="txt_searchItem" runat="server" CssClass="input-material"></asp:TextBox>
                                                            <label for="login_username" class="label-material">Ingrese el dni</label>

                                                            <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-success btn-circle" OnClick="btnSearch_Click"><i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                                                            <a class="btn btn-success btn-circle fa fa-pencil color-white" data-toggle="modal" data-target="#myModalEditDerecho"></a>
                                                        </div>
                                                        <div class="form-group list-view-item">
                                                            <asp:ListView DataKeyNames="id_Paciente" runat="server" ID="listSearchingPerson" OnSelectedIndexChanging="selectedIndexChangingListSearch">

                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" CommandName="Select" CssClass="row-list">
                                                   
                                                        <i class="fa fa-square-o" style="float:right;" aria-hidden="true"></i>
                                                        <img src="../<%# Eval("foto") %>" class="list-user" alt="User" id="imgselect" />
                                                        <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                                                        <span class="span-dato"><%# Eval("nombres")%> &nbsp;&nbsp;<%# Eval("Apellidos")%></span>
                                                        <br />
                                                        <span class="span-dato-cedula"><%# Eval("cedula")%></span>
                                                    
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <SelectedItemTemplate>
                                                                    <div id="item_todo_row" class="row-list">
                                                                        <i class="fa fa-check-square-o" style="float: right;" aria-hidden="true"></i>
                                                                        <img src="../<%# Eval("foto") %>" class="list-user" alt="User" id="imgselect" />
                                                                        <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                                                                        <span class="span-dato"><%# Eval("nombres")%> &nbsp;&nbsp;<%# Eval("Apellidos")%></span><br />
                                                                        <span class="span-dato-cedula"><%# Eval("cedula")%></span>
                                                                    </div>
                                                                </SelectedItemTemplate>
                                                            </asp:ListView>
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
            <asp:Panel runat="server" ID="panelAllUsuario">

                <h2 class="tituloSubPage">
                    <asp:Label runat="server" ID="lbnameGrupo">  </asp:Label></h2>
                <div class="bar-menu">
                    <asp:LinkButton runat="server" CssClass="btn btn-primary btnLeft btn-circle " href="GruposAll"><i class="fa fa-arrow-circle-left"  aria-hidden="true"></i> </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-success btnLeft btn-circle" OnClick="shopanelAdd"><i class="fa fa-plus-circle"  aria-hidden="true"></i> </asp:LinkButton>
                    <asp:UpdatePanel style="display: initial;" runat="server" ID="imprimir">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnImprimir1Reporte" />
                        </Triggers>
                        <ContentTemplate>

                            <asp:LinkButton Style="float: right;" ID="btnImprimir1Reporte" runat="server" CssClass="btn btn-success btnLeft btn-circle " OnClick="btnImprimir_Click"><i class="fa fa-print"  aria-hidden="true"></i> </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="allData">
                            <asp:ListView runat="server" ID="lvwDatos" DataKeyNames="id_Paciente" OnSelectedIndexChanging="selectedIndexChanging">
                                <ItemTemplate>
                                    <span class="item-content">
                                        <asp:LinkButton runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-square-o" aria-hidden="true"></i></asp:LinkButton>

                                        <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>

                                        <asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli item-max" OnCommand="btnVerClic" CommandArgument='<%# Eval("id_Paciente") %>'>
                              <div class="statistic d-flex align-items-center bg-white has-shadow item-item" style="height: 4em;">
                                    
                            
                          
                            <div id="item_todo_row">
                                <img src="../<%# Eval("foto") %>" width="50" height="50" alt="User" id="imgselect" />
                                <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                            </div>

                            <div id="item_todo_row">
                               <span class="span-name"> <%# Eval("nombres")%> &nbsp;&nbsp;<%# Eval("Apellidos")%></span>
                            </div>

                        
                                 </div>
                                        </asp:LinkButton>
                                    </span>
                                </ItemTemplate>
                                <SelectedItemTemplate>
                                    <span class="item-content">

                                        <asp:LinkButton runat="server" CommandName="Select" CssClass="select-box"><i class="fa fa-check-square-o" aria-hidden="true"></i></asp:LinkButton>
                                        <%--<asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-long-cli" OnCommand="verGroups" CommandArgument='<%# Eval("idGrupo") %>'>--%>
                                        <asp:LinkButton runat="server" CssClass="statistic  align-items-center bg-white item-dato item-max" OnCommand="btnVerClic" CommandArgument='<%# Eval("id_Paciente") %>'>
                           
                            <div class="statistic d-flex align-items-center bg-white has-shadow item-item item-item-selected" style="height: 4em;">
                              
                             
                        
                            <div id="item_todo_row">
                                <img src="../<%# Eval("foto") %>" width="50" height="50" alt="User" id="imgselect" />
                                <%--   <img src="<%# Eval("foto") %>" width="80" height="80" alt="User" id="imgselect" />--%>
                            </div>

                            <div id="item_todo_row">
                              <span class="span-name"> <%# Eval("nombres")%> &nbsp;&nbsp;<%# Eval("Apellidos")%></span>
                            </div>

                        
                                
                            </div>
                                        </asp:LinkButton>
                                        <div id="item_botonesGroup">
                                            <asp:LinkButton ID="lnkEdit" CommandArgument='<%# Eval("id_Paciente") %>' runat="server" CssClass="btn btn-success btn-circle" OnCommand="lnkEdit_Command">
                                             <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkRemove" CommandArgument='<%# Eval("id_Paciente") %>' Text="Eliminar" runat="server" CssClass="btn btn-danger btn-circle" OnCommand="btnremoveClic">
                       
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
            <!-- Modal Add Usuario-->

            <!-- Trigger the modal with a button -->
            <div id="myModalEditDerecho" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div style="width: min-content;" class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add Usaurio</h4>
                        </div>
                        <div style="text-align: -webkit-center;" class="modal-body">

                            <h2 class="input-material">Nuevo Usuario</h2>
                            <div class="avatar center-contenido">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnAdd22" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Image ID="ImgDefaulFoto" CssClass="img-fluid rounded-circle fotoEdit" runat="server" />
                                        <br />
                                        <asp:FileUpload ID="FileUploadNewUser" runat="server" ClientIDMode="Static" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cedula</p>
                                <asp:TextBox ID="register_cedula" runat="server" CssClass="input-material" required=""></asp:TextBox>
                            </div>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Nombres</p>
                                            <asp:TextBox ID="register_nombres" runat="server" CssClass="input-material" required=""></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Apellidos</p>
                                            <asp:TextBox ID="register_apellidos" runat="server" CssClass="input-material" required=""></asp:TextBox>
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
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Afiliado Paciente </p>
                                            <asp:ObjectDataSource ID="ObjectDataSourceAfiliadoPaciente" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.AfiliadoPacienteLN"></asp:ObjectDataSource>
                                            <asp:DropDownList ID="DropDownListAfiliadoPaciente" runat="server" DataSourceID="ObjectDataSourceAfiliadoPaciente" DataTextField="descrpcion" DataValueField="id_AfiliadoPaciente">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Grupo Prioritario</p>
                                            <asp:ObjectDataSource ID="ObjectDataSourceGrupoPrioritario" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.GrupoPrioritarioLN"></asp:ObjectDataSource>
                                            <asp:DropDownList ID="DropDownListGrupoPrioritario" runat="server" DataSourceID="ObjectDataSourceGrupoPrioritario" DataTextField="descrpcion" DataValueField="id_GrupoPrioritario">
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
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Dirección.</td>
                                    <td></td>
                                </tr>
                                <tr>

                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Provincia</p>
                                            <asp:ObjectDataSource ID="ObjectDataSourceProvincia" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.ProvinciaLN"></asp:ObjectDataSource>
                                            <asp:DropDownList ID="DropDownListProvincia" runat="server" DataSourceID="ObjectDataSourceProvincia" DataTextField="descrpcion" DataValueField="id_Provincia">
                                            </asp:DropDownList>
                                        </div>

                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cantón</p>
                                            <asp:ObjectDataSource ID="ObjectDataSourceCanton" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.CantonLN"></asp:ObjectDataSource>
                                            <asp:DropDownList ID="DropDownListCanton" runat="server" DataSourceID="ObjectDataSourceCanton" DataTextField="descrpcion" DataValueField="id_Canton">
                                            </asp:DropDownList>
                                        </div>

                                    </td>
                                </tr>
                                <tr>

                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Parroquia</p>
                                            <asp:ObjectDataSource ID="ObjectDataSourceParroquia" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.ParroquiaLN"></asp:ObjectDataSource>
                                            <asp:DropDownList ID="DropDownListParroquia" runat="server" DataSourceID="ObjectDataSourceParroquia" DataTextField="descrpcion" DataValueField="id_Parroquia">
                                            </asp:DropDownList>
                                        </div>

                                    </td>
                                    <td>

                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Barrio o Resinto </p>
                                            <asp:TextBox ID="register_resinto" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Otros.</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Tipo Sangre</p>
                                            <asp:DropDownList ID="DropDownLisTipoSangre" AutoPostBack="false" runat="server">
                                                <asp:ListItem Value="O-" Text="O-" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="O+" Text="O+"></asp:ListItem>
                                                <asp:ListItem Value="A−" Text="A-"></asp:ListItem>
                                                <asp:ListItem Value="A+" Text="A+"></asp:ListItem>
                                                <asp:ListItem Value="B-" Text="B-"></asp:ListItem>
                                                <asp:ListItem Value="B+" Text="B+"></asp:ListItem>
                                                <asp:ListItem Value="AB-" Text="AB+"></asp:ListItem>
                                                <asp:ListItem Value="AB+" Text="AB+"></asp:ListItem>
                                            </asp:DropDownList>


                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Telefono</p>
                                            <asp:TextBox ID="register_telefono" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Fecha Nacimiento</p>
                                            <asp:TextBox ID="register_fechaNacimiento" type="date" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cedula Representante</p>
                                            <asp:TextBox ID="register_cedula_representante" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                        </div>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnAdd22" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" />

                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>

                    </div>

                </div>
            </div>
            <!--fin  Modal Usuario-->
            <!--panel editar-->
            <asp:Panel runat="server" ID="panelEditPaciente" Visible="false">
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

                                                <h2 class="input-material">Editar Usuario</h2>
                                                <div class="avatar center-contenido">
                                                    <asp:UpdatePanel runat="server" ID="upFoto">
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnEditPacientes" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <asp:Image ID="Edit_1ImagePerfil" CssClass="img-fluid rounded-circle fotoEdit" runat="server" />
                                                            <br />
                                                            <asp:FileUpload ID="Edit_1FileUploadFotoPerfil" runat="server" ClientIDMode="Static" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>


                                                </div>

                                                <br />
                                                <br />
                                                <div class="form-group">
                                                    <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cedula</p>
                                                    <asp:TextBox ID="Edit_register_cedula" runat="server" CssClass="input-material" required=""></asp:TextBox>
                                                </div>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Nombres</p>
                                                                <asp:TextBox ID="Edit_register_nombres" runat="server" CssClass="input-material" required=""></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Apellidos</p>
                                                                <asp:TextBox ID="Edit_register_apellidos" runat="server" CssClass="input-material" required=""></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Sexo</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceSexo" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.SexoLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListSexo" runat="server" DataSourceID="Edit_ObjectDataSourceSexo" DataTextField="descrpcion" DataValueField="id_sexo">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Afiliado Paciente </p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceAfiliadoPaciente" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.AfiliadoPacienteLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListAfiliadoPaciente" runat="server" DataSourceID="Edit_ObjectDataSourceAfiliadoPaciente" DataTextField="descrpcion" DataValueField="id_AfiliadoPaciente">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Grupo Prioritario</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceGrupoPrioritario" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.GrupoPrioritarioLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListGrupoPrioritario" runat="server" DataSourceID="Edit_ObjectDataSourceGrupoPrioritario" DataTextField="descrpcion" DataValueField="id_GrupoPrioritario">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Nacionalidad</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceNacionalidad" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.NacionalidadLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListNacionalidad" runat="server" DataSourceID="Edit_ObjectDataSourceNacionalidad" DataTextField="descrpcion" DataValueField="id_nacionalidad">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Autoidentificación</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceAutoidentificación" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.AutoidetificacionLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListAutoidentificación" runat="server" DataSourceID="Edit_ObjectDataSourceAutoidentificación" DataTextField="descrpcion" DataValueField="id_autoidetificacion">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Dirección.</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>

                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Provincia</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceProvincia" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.ProvinciaLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListProvincia" runat="server" DataSourceID="Edit_ObjectDataSourceProvincia" DataTextField="descrpcion" DataValueField="id_Provincia">
                                                                </asp:DropDownList>
                                                            </div>

                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cantón</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceCanton" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.CantonLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListCanton" runat="server" DataSourceID="Edit_ObjectDataSourceCanton" DataTextField="descrpcion" DataValueField="id_Canton">
                                                                </asp:DropDownList>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Parroquia</p>
                                                                <asp:ObjectDataSource ID="Edit_ObjectDataSourceParroquia" runat="server" SelectMethod="Mostrar" TypeName="LogicaNegocio.ParroquiaLN"></asp:ObjectDataSource>
                                                                <asp:DropDownList ID="Edit_DropDownListParroquia" runat="server" DataSourceID="Edit_ObjectDataSourceParroquia" DataTextField="descrpcion" DataValueField="id_Parroquia">
                                                                </asp:DropDownList>
                                                            </div>

                                                        </td>
                                                        <td>

                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Barrio o Resinto </p>
                                                                <asp:TextBox ID="Edit_register_resinto" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Otros.</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Tipo Sangre</p>
                                                                <asp:DropDownList ID="Edit_DropDownLisTipoSangre" AutoPostBack="false" runat="server">
                                                                    <asp:ListItem Value="O-" Text="O-" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Value="O+" Text="O+"></asp:ListItem>
                                                                    <asp:ListItem Value="A−" Text="A-"></asp:ListItem>
                                                                    <asp:ListItem Value="A+" Text="A+"></asp:ListItem>
                                                                    <asp:ListItem Value="B-" Text="B-"></asp:ListItem>
                                                                    <asp:ListItem Value="B+" Text="B+"></asp:ListItem>
                                                                    <asp:ListItem Value="AB-" Text="AB+"></asp:ListItem>
                                                                    <asp:ListItem Value="AB+" Text="AB+"></asp:ListItem>
                                                                </asp:DropDownList>


                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Telefono</p>
                                                                <asp:TextBox ID="Edit_register_telefono" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Fecha Nacimiento</p>
                                                                <asp:TextBox ID="Edit_register_fechaNacimiento" type="date" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <p style="font-weight: 300; color: #aaa; font-size: 0.8em; color: #2b90d9;" class="label-material">Cedula Representante</p>
                                                                <asp:TextBox ID="Edit_register_cedula_representante" runat="server" CssClass="input-material" required=""></asp:TextBox>

                                                            </div>
                                                        </td>
                                                    </tr>

                                                </table>
                                                <div class="modal-footer">
                                                    <asp:LinkButton type="submit" ID="btnEditPacientes" runat="server" CssClass="btn btn-primary" OnClick="btnEditPaciente_Click" Text="Update" />

                                                    <asp:LinkButton ID="btnCloseEdit" runat="server" CssClass="btn btn-primary" OnClick="btnCloseEdit_Click" Text="Cancelar" />
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

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
