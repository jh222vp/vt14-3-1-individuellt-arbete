<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WhiskyApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WhiskyApp</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:PlaceHolder ID="UploadSuccess" runat="server" Visible="false">
            <p>Det gick kanon att lägga till en användare</p>
        </asp:PlaceHolder>
    
            <%--  --%>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" runat="server" ShowModelStateErrors="false"/>
    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Update" runat="server" />

    <div id = "container">
        <asp:ListView ID="WhiskyListView" runat="server"
                ItemType="WhiskyApp.Model.LabelBrands"
                
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
             <asp:ListView ID="WhiskyModelListView" runat="server"
                ItemType="WhiskyApp.Model.WhiskyModel"
                SelectMethod="WhiskyModelListView_GetData">
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
                        </td>
                    </tr>
                </ItemTemplate>
        





                 </asp:ListView>






            <%-- Nedan lista MODELL av whiskyn --%>
             <asp:ListView ID="BottleListView" runat="server"
                ItemType="WhiskyApp.Model.BottleTable.Bottle"
                SelectMethod="BottleListView_GetData">
                <LayoutTemplate>
                    <table class="table1">
                        <tr>
                            <th>
                                Pris i kronor
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
                        <td class="command">
                            <%-- knappar för att ta bort och redigera kunduppgifter --%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>



        


















        </div>

    </div>
    </form>
</body>
</html>
