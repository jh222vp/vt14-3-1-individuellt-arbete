<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhiskyApp.Pages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    
            <%--  --%>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" runat="server" ShowModelStateErrors="false"/>
    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Update" runat="server" />

    <div id = "container">
        <asp:ListView ID="WhiskyListView" runat="server"
                ItemType="WhiskyApp.Model.LabelBrands"
                UpdateMethod="WhiskyListView_UpdateItem"
                SelectMethod="WhiskyListView_GetData"
                DeleteMethod="ContactListView_DeleteItem"
                DataKeyNames="BrandID">




            <LayoutTemplate>
                    <table class="table">
                        <tr>
                            <th>
                                Märke
                            </th>
                        </tr>
                        <th>
                        </th>                   
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>


                </LayoutTemplate>
             

            <EditItemTemplate> 
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%# BindItem.Brand%>' ValidationGroup="Edit"/>
                    </td>
                    <td>
                        <%-- knappar för att spara och avbryta sina val --%>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
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
                            <th>
                                Modell
                            </th>
                        </tr>
                        <th>
                        </th> 
                                          
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
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                 <EditItemTemplate>
                     <tr>
                         <td>
                             <asp:TextBox ID="TextBox1" Text='<%# BindItem.Model%>' runat="server"></asp:TextBox>
                         </td>
                    <td>
                        <%-- knappar för att spara och avbryta sina val --%>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                    </td>
                     </tr>
                 </EditItemTemplate>
                 </asp:ListView>
            </asp:PlaceHolder>






            <%-- Nedan lista Pris i kronor av whiskyn --%>
             <asp:ListView ID="BottleListView" runat="server"
                ItemType="WhiskyApp.Model.BottleTable.Bottle"
                DataKeyNames="BottleID"
                UpdateMethod="BottleListView_UpdateItem"
                SelectMethod="BottleListView_GetData">

                <LayoutTemplate>
                    <table class="table1">
                        <tr>
                            <th>
                                Pris i kronor
                            </th>
                            <th>
                                Antal år
                            </th>
                            <th>
                                Antal mängd i cl
                            </th>
                        </tr>
                        <th>
                        </th> 
                                          
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
                             <asp:TextBox ID="TextBox1" Text='<%# BindItem.Price%>' runat="server"></asp:TextBox>
                         </td>
                        <td>
                             <asp:TextBox ID="TextBox2" Text='<%# BindItem.Year%>' runat="server"></asp:TextBox>
                         </td>
                        <td>
                             <asp:TextBox ID="TextBox3" Text='<%# BindItem.Amount%>' runat="server"></asp:TextBox>
                         </td>
                    <td>
                        <%-- knappar för att spara och avbryta sina val --%>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt"></asp:LinkButton>
                    </td>
                     </tr>
                 </EditItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
