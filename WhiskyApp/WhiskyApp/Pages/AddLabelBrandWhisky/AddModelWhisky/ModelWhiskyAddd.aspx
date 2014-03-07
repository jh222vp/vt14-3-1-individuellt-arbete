<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModelWhiskyAddd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddModelWhisky.ModelWhiskyAddd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:ListView ID="AddWhiskyModelView" runat="server"
                SelectMethod="AddWhiskyModelView_GetData"
                ItemType="WhiskyApp.Model.WhiskyModel"

                InsertMethod="AddWhiskyView_InsertModelItem"
                DataKeyNames="ModelID" 
                InsertItemPosition="FirstItem">


                <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Model %>
                        </td>
                    </tr>
                </ItemTemplate> 
                    
            <InsertItemTemplate>
                <tr>
                    <td>
                        <p>MODELL</p>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Model %>' MaxLength="50" />
                    </td>
                    <td>

                    <asp:DropDownList ID="DropDownBrand" SelectMethod="AddWhiskyView_GetData"
                        ItemType="WhiskyApp.Model.LabelBrands"
                        runat="server" DataTextField="Brand"
                        SelectedValue='<%# BindItem.BrandID %>'
                        DataValueField="BrandID"></asp:DropDownList>
                        <asp:Button ID="Add" runat="server" Text="Lägg till" CommandName="insert" />
                    </td>
                    
                </tr>
            </InsertItemTemplate>

                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                </asp:ListView>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
</asp:Content>
