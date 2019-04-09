<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="plantograma.views.HomeAdmin" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">
    <!-- Dashboard Counts Section-->
    <section class="dashboard-counts no-padding-bottom">
        <div class="container-fluid">
            <div class="row bg-white has-shadow">
                <!-- Item -->
                <div class="col-xl-3 col-sm-6">
                    <div class="item d-flex align-items-center">
                        <div class="icon bg-violet"><i class="fa fa-users" aria-hidden="true"></i></div>
                        <div class="title">
                            <span>Total<br>
                                Pacientes</span>
                            <div class="progress">
                                <div role="progressbar" style="width: 25%; height: 4px;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar bg-violet"></div>
                            </div>
                        </div>
                        <div class="number">
                            <strong>
                                <asp:Label ID="TextTotalPaciente" runat="server" Text="Label"></asp:Label>
                            </strong>
                        </div>
                    </div>
                </div>
                <!-- Item -->
                <div class="col-xl-3 col-sm-6">
                    <div class="item d-flex align-items-center">
                        <div class="icon bg-red"><i class="fa fa-male"></i></div>
                        <div class="title">
                            <span>Cantidad de  Hombres<br>
                            </span>
                            <div class="progress">
                                <div role="progressbar" style="width: 25%; height: 4px;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar bg-red"></div>
                            </div>
                        </div>
                        <div class="number"><strong>
                            <asp:Label ID="txtCantidadHombres" runat="server" Text="Label"></asp:Label></strong></div>
                    </div>
                </div>
                <!-- Item -->
                <div class="col-xl-3 col-sm-6">
                    <div class="item d-flex align-items-center">
                        <div class="icon bg-green"><i class="fa fa-female"></i></div>
                        <div class="title">
                            <span>Cantidad De Mujeres<br>  </span>
                            <div class="progress">
                                <div role="progressbar" style="width: 25%; height: 4px;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar bg-green"></div>
                            </div>
                        </div>
                        <div class="number"><strong> <asp:Label ID="txtCantidadMujeres" runat="server" Text="Label"></asp:Label></strong></div>
                    </div>
                </div>
                <!-- Item -->
                <div class="col-xl-3 col-sm-6">
                    <div class="item d-flex align-items-center">
                        <div class="icon bg-orange"><i class="fa fa-paw" aria-hidden="true"></i></div>
                        <div class="title">
                            <span>Total<br>
                                Plantogramas   </span>
                            <div class="progress">
                                <div role="progressbar" style="width: 25%; height: 4px;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar bg-orange"></div>
                            </div>
                        </div>
                        <div class="number"><strong> <asp:Label ID="txtCantidadPlantograma" runat="server" Text="Label"></asp:Label></strong></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Dashboard Header Section    -->
    <section class="dashboard-header">
        <div class="container-fluid">
            <div class="row">
                <!-- Statistics -->
                <div class="statistics col-lg-3 col-12">

                    <asp:ListView ID="ListViewTiposDeTie" runat="server">
                        <ItemTemplate>
                            <div class="statistic d-flex align-items-center bg-white has-shadow">
                                <div class="icon bg-red"><i class="fa fa-tasks"></i></div>
                                <div class="text">
                                    <strong><%# Eval("cantidad") %></strong><br>
                                    <small><%# Eval("resultado") %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <!--
                    <div class="statistic d-flex align-items-center bg-white has-shadow">
                        <div class="icon bg-red"><i class="fa fa-tasks"></i></div>
                        <div class="text">
                            <strong>234</strong><br>
                            <small>Applications</small>
                        </div>
                    </div>
                    <div class="statistic d-flex align-items-center bg-white has-shadow">
                        <div class="icon bg-green"><i class="fa fa-calendar-o"></i></div>
                        <div class="text">
                            <strong>152</strong><br>
                            <small>Interviews</small>
                        </div>
                    </div>
                    <div class="statistic d-flex align-items-center bg-white has-shadow">
                        <div class="icon bg-orange"><i class="fa fa-paper-plane-o"></i></div>
                        <div class="text">
                            <strong>147</strong><br>
                            <small>Forwards</small>
                        </div>
                    </div>-->

                </div>
                <!-- Line Chart            -->
                <div class="chart col-lg-6 col-12">
                    <asp:Chart CssClass="chat-app-pie" ID="ChartTipoPie" runat="server">
                        <Series>

                            <asp:Series  Name="Tipos De Pie">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Tipos De Pie"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <!--<div class="line-chart bg-white d-flex align-items-center justify-content-center has-shadow">
                        <canvas id="lineCahrt"></canvas>
                    </div>-->
                </div>
                <div class="chart col-lg-3 col-12">
                    <!-- Bar Chart   -->
                    <!--div class="bar-chart has-shadow bg-white">
                        <div class="title">
                            <strong class="text-violet">95%</strong><br>
                            <small>Current Server Uptime</small>
                        </div>
                        <canvas id="barChartHome"></canvas>
                    </div>
                    <!-- Numbers-->
                    <!--<div class="statistic d-flex align-items-center bg-white has-shadow">
                        <div class="icon bg-green"><i class="fa fa-line-chart"></i></div>
                        <div class="text">
                            <strong>99.9%</strong><br>
                            <small>Success Rate</small>
                        </div>
                    </div>-->
                    <asp:ListView ID="ListViewTipoDePieRstante" runat="server">
                        <ItemTemplate>
                            <div class="statistic d-flex align-items-center bg-white has-shadow">
                                <div class="icon bg-green"><i class="fa fa-line-chart"></i></div>
                                <div class="text">
                                    <strong><%# Eval("cantidad") %></strong><br>
                                    <small><%# Eval("resultado") %></small>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                </div>
            </div>
        </div>
    </section>
    <!-- Projects Section-->

    <!-- Client Section-->
    <!--
    <section class="client no-padding-top">
        <div class="container-fluid">
            <div class="row">
                <!-- Work Amount  -->
                <!--<div class="col-lg-4">
                    <div class="work-amount card">
                        <div class="card-close">
                            <div class="dropdown">
                                <button type="button" id="closeCard" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-toggle"><i class="fa fa-ellipsis-v"></i></button>
                                <div aria-labelledby="closeCard" class="dropdown-menu has-shadow"><a href="#" class="dropdown-item remove"><i class="fa fa-times"></i>Close</a><a href="#" class="dropdown-item edit"> <i class="fa fa-gear"></i>Edit</a></div>
                            </div>
                        </div>
                        <div class="card-body">
                            <h3>Work Hours</h3>
                            <small>Lorem ipsum dolor sit amet.</small>
                            <div class="chart text-center">
                                <div class="text">
                                    <strong>90</strong><br>
                                    <span>Hours</span>
                                </div>
                                <canvas id="pieChart"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Client Profile -->
               <!-- <div class="col-lg-4">
                    <div class="client card">
                        <div class="card-close">
                            <div class="dropdown">
                                <button type="button" id="closeCard" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-toggle"><i class="fa fa-ellipsis-v"></i></button>
                                <div aria-labelledby="closeCard" class="dropdown-menu has-shadow"><a href="#" class="dropdown-item remove"><i class="fa fa-times"></i>Close</a><a href="#" class="dropdown-item edit"> <i class="fa fa-gear"></i>Edit</a></div>
                            </div>
                        </div>
                        <div class="card-body text-center">
                            <div class="client-avatar">
                                <img src="../graficos/avatar-2.jpg" alt="..." class="img-fluid rounded-circle">
                                <div class="status bg-green"></div>
                            </div>
                            <div class="client-title">
                                <h3>Jason Doe</h3>
                                <span>Web Developer</span><a href="#">Follow</a>
                            </div>
                            <div class="client-info">
                                <div class="row">
                                    <div class="col-4">
                                        <strong>20</strong><br>
                                        <small>Photos</small>
                                    </div>
                                    <div class="col-4">
                                        <strong>54</strong><br>
                                        <small>Videos</small>
                                    </div>
                                    <div class="col-4">
                                        <strong>235</strong><br>
                                        <small>Tasks</small>
                                    </div>
                                </div>
                            </div>
                            <div class="client-social d-flex justify-content-between"><a href="#" target="_blank"><i class="fa fa-facebook"></i></a><a href="#" target="_blank"><i class="fa fa-twitter"></i></a><a href="#" target="_blank"><i class="fa fa-google-plus"></i></a><a href="#" target="_blank"><i class="fa fa-instagram"></i></a><a href="#" target="_blank"><i class="fa fa-linkedin"></i></a></div>
                        </div>
                    </div>
                </div>
                <!-- Total Overdue             -->
                <!--<div class="col-lg-4">
                    <div class="overdue card">
                        <div class="card-close">
                            <div class="dropdown">
                                <button type="button" id="closeCard" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" class="dropdown-toggle"><i class="fa fa-ellipsis-v"></i></button>
                                <div aria-labelledby="closeCard" class="dropdown-menu has-shadow"><a href="#" class="dropdown-item remove"><i class="fa fa-times"></i>Close</a><a href="#" class="dropdown-item edit"> <i class="fa fa-gear"></i>Edit</a></div>
                            </div>
                        </div>
                        <div class="card-body">
                            <h3>Total Overdue</h3>
                            <small>Lorem ipsum dolor sit amet.</small>
                            <div class="number text-center">$20,000</div>
                            <div class="chart">
                                <canvas id="lineChart1"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Feeds Section-->



</asp:Content>
