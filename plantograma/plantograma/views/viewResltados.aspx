<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="viewResltados.aspx.cs" Inherits="plantograma.views.viewResltados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPages" runat="server">

    <div>
    <asp:Button runat="server" ID="btnImprime" Height Width Text="Imprimir" OnClick="btnImprime_Click" />
    </div>

</asp:Content>
