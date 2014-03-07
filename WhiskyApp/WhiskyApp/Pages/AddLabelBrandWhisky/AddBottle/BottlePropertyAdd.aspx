<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BottlePropertyAdd.aspx.cs" Inherits="WhiskyApp.Pages.AddLabelBrandWhisky.AddBottle.BottlePropertyAdd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.Year %>' MaxLength="50" />
                    </td>
                    <td>
                        <p>Pris</p>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.Price %>' MaxLength="50" />
                    </td>
                    <td>
                        <p>Mängd</p>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.Amount %>' MaxLength="50" />
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" ></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" CausesValidation="false" Text="Rensa" ></asp:LinkButton>
                    </td>
                </tr>
            </InsertItemTemplate>

                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                </asp:ListView>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>
                <%-- HÄR SLUTAR LISTVIEW!!!!!!! --%>


</asp:Content>
