<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhiskyApp.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- ValidationSummary nedan för Redigering och sparandet av redigerandet --%>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" runat="server" ShowModelStateErrors="false" />
    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Update" runat="server" />

    <div id="container">
        <div id="bigtable">
            <asp:ListView ID="WhiskyListView" runat="server"
                ItemType="WhiskyApp.Model.LabelBrands"
                UpdateMethod="WhiskyListView_UpdateItem"
                SelectMethod="WhiskyListView_GetData"
                DeleteMethod="ContactListView_DeleteItem"
                DataKeyNames="BrandID">

                <LayoutTemplate>
                    <table class="table">
                        <tr>
                            <th>Märkee
                            </th>
                        </tr>
                        <th></th>
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>

                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Brand" runat="server" Text='<%# BindItem.Brand%>' />
                        </td>
                        <td>
                            <%-- knappar för att spara och avbryta sina val --%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" ValidationGroup="Update" Text="Spara"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett märke måste fyllas i!" ControlToValidate="Brand" Display="None" ValidationGroup="Update"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </EditItemTemplate>

                <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Brand %>
                        </td>
                        <td class="command">
                            <%-- knappar för att ta bort och redigera kunduppgifter --%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm ('Är du säker på att du vill ta bort användaren?')" />
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div id="ModelTable">
                <%-- Nedan lista MODELL av whiskyn --%>
                <asp:PlaceHolder ID="ModelPlaceHolder" runat="server">
                    <asp:ListView ID="WhiskyModelListView" runat="server"
                        ItemType="WhiskyApp.Model.WhiskyModel"
                        SelectMethod="WhiskyModelListView_GetData"
                        UpdateMethod="WhiskyModelListView_UpdateItem"
                        DeleteMethod="WhiskyModelListView_DeleteItem"
                        DataKeyNames="ModelID">

                        <LayoutTemplate>
                            <table class="table1">
                                <tr>
                                    <th>Modell
                                    </th>
                                </tr>
                                <th></th>

                                <%-- Platshållare för nya rader --%>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#: Item.Model %>
                                </td>
                                <td class="command">
                                    <%-- knappar för att ta bort och redigera kunduppgifter --%>
                                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm ('Är du säker på att du vill ta bort användaren?')" />--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm ('Är du säker på att du vill ta bort användaren?')" />
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Model" Text='<%# BindItem.Model%>' runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <%-- knappar för att spara och avbryta sina val --%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" ValidationGroup="Update" Text="Spara"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="En modell måste fyllas i!" ControlToValidate="Model" Display="None" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </EditItemTemplate>
                    </asp:ListView>
                </asp:PlaceHolder>
            </div>

            <div id="BottleTable">
                <%-- Nedan lista Pris i kronor av whiskyn --%>
                <asp:ListView ID="BottleListView" runat="server"
                    ItemType="WhiskyApp.Model.BottleTable.Bottle"
                    DataKeyNames="BottleID"
                    UpdateMethod="BottleListView_UpdateItem"
                    SelectMethod="BottleListView_GetData">

                    <LayoutTemplate>
                        <table class="table1">
                            <tr>
                                <th>Pris i kronor, 
                                </th>
                                <th>Antal år, 
                                </th>
                                <th>Antal mängd i cl
                                </th>
                            </tr>
                            <th></th>
                            <%-- Platshållare för nya rader --%>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#: Item.Price %>
                            </td>
                            <td>
                                <%#: Item.Year %>
                            </td>
                            <td>
                                <%#: Item.Amount %>
                            </td>
                            <td class="command">
                                <%-- knappar för att ta bort och redigera kunduppgifter --%>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox ID="Price" Text='<%# BindItem.Price%>' runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="Year" Text='<%# BindItem.Year%>' runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="Amount" Text='<%# BindItem.Amount%>' runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%-- knappar för att spara och avbryta sina val --%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ErrorMessage="En egenskap av typen PRIS måste fyllas i och får inte vara tomt!!" ControlToValidate="Price" Display="None" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="En egenskap av typen ÅR måste fyllas i och får inte vara tomt!!" ControlToValidate="Year" Display="None" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="En egenskap av typen MÄNGD måste fyllas i och får inte vara tomt!!" ControlToValidate="Amount" Display="None" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="Update" CommandName="Update" Text="Spara"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                            </td>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
