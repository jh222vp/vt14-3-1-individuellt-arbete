<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WhiskyApp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WhiskyApp</title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>--%>
    
            <%--  --%>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Insert" runat="server" ShowModelStateErrors="false"/>
    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="Update" runat="server" />

    <div id = "container">
        <asp:ListView ID="WhiskyListView" runat="server"
                ItemType="WhiskyApp.Model.LabelBrands"
                SelectMethod="WhiskyListView_GetData"
                

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
                





             <%-- Nedan lista MÄRKET av whiskyn --%>
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








                <%-- Nedan lista MODELL av whiskyn --%>
             </asp:ListView>
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




        


                



            
    </div>
    </form>
</body>
</html>
