<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WhiskyBrandNameAdd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddWhiskeyBrandName.WhiskyBrandNameAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowModelStateErrors="false" />


        <div id="ModelBorder">
            <asp:ListView ID="AddWhiskyView" runat="server"
                SelectMethod="AddWhiskyView_GetData"
                ItemType="WhiskyApp.Model.LabelBrands"
                InsertMethod="AddWhiskyView_InsertItem"
                DataKeyNames="BrandID"
                InsertItemPosition="FirstItem">


                <ItemTemplate>
                    <div id="BrandTemplate">
                       
                            <tr>
                                 <ul>
                                <%#: Item.Brand %>
                                </ul>
                            </tr>
                        
                    </div>
                </ItemTemplate>




                <InsertItemTemplate>
                    <div id="AddBrand">
                        <h2>Lägg till ett märke</h2>
                        <tr>
                            <td>
                                <asp:TextBox ID="Brand" runat="server" Text='<%# BindItem.Brand %>' MaxLength="50" />
                            </td>
                            <td>
                                <asp:Button ID="Add" runat="server" Text="Lägg till märke" CommandName="insert" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett märke måste fyllas!!!!!!! i" ControlToValidate="Brand" Display="None"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </div>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
</asp:Content>
