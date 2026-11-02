<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InversionWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1> Simulador de Inversiones   </h1>
    <p> Compara los rendimientos de diferentes opciones de inversión</p>

    <h2>Banco Provincia</h2>
    <p>Capital inicial a invertir: $850.000</p>
    <p>Primer Tasa Anual(%):</p>
    <asp:TextBox ID="txtTasa1" runat ="server" />
    <p>Segunda Tasa Anual(%):</p>
    <asp:TextBox ID="txtTasa2" runat="server" />
     <p>Tercer Tasa Anual(%):</p>
 <asp:TextBox ID="txtTasa3" runat="server" />

    <br /><br />
   <asp:Button ID="btnCalcular" runat="server"
    Text="Calcular promedio"
    OnClick="btnCalcular_Click" />
    <br /><br />
    <asp:Label ID="lblResultado" runat="server" />

    <asp:GridView ID="gvResultados" runat="server"
    AutoGenerateColumns="false"
    CssClass="table table-bordered table-striped">

    <Columns>
        <asp:BoundField DataField="Modalidad"
            HeaderText="Modalidad" />

        <asp:BoundField DataField="TasaAnualPromedio"
            HeaderText="Tasa anual promedio (%)"
            DataFormatString="{0:N2}" />

        <asp:BoundField DataField="CapitalFinal"
            HeaderText="Capital final ($)"
            DataFormatString="{0:N2}" />

        <asp:BoundField DataField="Ganancia"
            HeaderText="Ganancia ($)"
            DataFormatString="{0:N2}" />
    </Columns>

</asp:GridView>


</asp:Content>
