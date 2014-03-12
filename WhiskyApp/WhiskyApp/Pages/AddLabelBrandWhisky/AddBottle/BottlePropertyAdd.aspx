<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BottlePropertyAdd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddBottle.BottlePropertyAdd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowModelStateErrors="false" />


    <asp:ListView ID="AddBottleWhiskyView" runat="server"
        SelectMethod="AddWhiskyBottleView_GetData"
        ItemType="WhiskyApp.Model.BottleTable.Bottle"
        InsertMethod="AddBottleWhiskyView_InsertItem"
        DataKeyNames="BottleID"
        InsertItemPosition="FirstItem">
        <ItemTemplate>
            <tr>
                <td>
                    <%#: Item.Year %>
                </td>
                <td>
                    <%#: Item.Price %>
                </td>
                <td>
                    <%#: Item.Amount %>
                </td>
            </tr>
        </ItemTemplate>

        <InsertItemTemplate>
            <tr>
                <td>
                    <p>År</p>
                    <asp:TextBox ID="Year" runat="server" Text='<%# BindItem.Year %>' MaxLength="50" />
                </td>
                <td>
                    <p>Pris</p>
                    <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' MaxLength="50" />
                </td>
                <td>
                    <p>Mängd</p>
                    <asp:TextBox ID="Amount" runat="server" Text='<%# BindItem.Amount %>' MaxLength="50" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownModel"
                        ItemType="WhiskyApp.Model.WhiskyModel"
                        runat="server" DataTextField="Model"
                        SelectedValue='<%# BindItem.ModelID %>'
                        DataValueField="ModelID"
                        SelectMethod="WhiskyListModelView_GetData">
                    </asp:DropDownList>

                    <asp:Button ID="Button1" runat="server" Text="Lägg till" CommandName="insert" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ett år måste fyllas i!" ControlToValidate="Year" Display="None"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ett pris måste fyllas i!" ControlToValidate="Price" Display="None"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="En mängd måste fyllas i!" ControlToValidate="Amount" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
