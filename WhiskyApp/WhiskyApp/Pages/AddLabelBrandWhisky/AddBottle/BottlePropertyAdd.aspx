<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BottlePropertyAdd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddBottle.BottlePropertyAdd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowModelStateErrors="false" />

    <div id="UpploadSucess">
        <asp:PlaceHolder ID="UploadSuccessed" runat="server" Visible="false">
            <p>Uppladdningen av buteljens egenskaper lyckades! </p>
        </asp:PlaceHolder>
    </div>


    <asp:ListView ID="AddBottleWhiskyView" runat="server"
        SelectMethod="AddWhiskyBottleView_GetData"
        ItemType="WhiskyApp.Model.BottleTable.Bottle"
        InsertMethod="AddBottleWhiskyView_InsertItem"
        DataKeyNames="BottleID"
        InsertItemPosition="FirstItem">



        <ItemTemplate>
        </ItemTemplate>

        <InsertItemTemplate>
            <div id="BottleProperties">
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
                        <p>Modell</p>
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

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Bara siffror!" ControlToValidate="Year" Display="None" ValidationExpression='[0-9]+'></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Bara siffror!" ControlToValidate="Price" Display="None" ValidationExpression='[0-9]+'></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Bara siffror!" ControlToValidate="Amount" Display="None" ValidationExpression='[0-9]+'></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>