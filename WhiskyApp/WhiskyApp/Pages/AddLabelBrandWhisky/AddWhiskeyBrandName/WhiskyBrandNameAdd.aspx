<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WhiskyBrandNameAdd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddWhiskeyBrandName.WhiskyBrandNameAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>ADD SOME WHISKEY!</h1>
    
        <div id = "container">
            
            <asp:ListView ID="AddWhiskyView" runat="server"
                SelectMethod="AddWhiskyView_GetData"
                ItemType="WhiskyApp.Model.LabelBrands"
                InsertMethod="AddWhiskyView_InsertItem"
                DataKeyNames="BrandID" 
                InsertItemPosition="FirstItem">

            <ItemTemplate>
                    <tr>
                        <td>
                            <%#: Item.Brand %>
                        </td>
                    </tr>
                </ItemTemplate> 

                    
            <InsertItemTemplate>
                <tr>
                    <td>
                        <p>MÄRKE</p>
                        <asp:TextBox ID="Märke" runat="server" Text='<%# BindItem.Brand %>' MaxLength="50"/>
                    </td>
                    <td>
                    <asp:Button ID="Add" runat="server" Text="Lägg till" CommandName="insert" />
                    </td>


                </tr>
            </InsertItemTemplate>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                 </asp:ListView>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
            
        </div>
</asp:Content>
