<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWhisky.aspx.cs" Inherits="WhiskyApp.Pages.AddWhisky.AddWhisky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD SOME WHISKEEEEY YAO!!!!!</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>ADD SOME WHISKEY!</h1>
    <div>
        <div id = "container">
        
            
            
            <asp:ListView ID="AddWhiskyView" runat="server"
                SelectMethod="AddWhiskyView_GetData"
                ItemType="WhiskyApp.Model.LabelBrands"
                InsertMethod="AddWhiskyView_InsertItem">



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
                        <asp:TextBox ID="Märke" runat="server" Text='<%# BindItem.Brand %>' MaxLength="50"/>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" ></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" CausesValidation="false" Text="Rensa" ></asp:LinkButton>
                    </td>
                </tr>
            </InsertItemTemplate>



            


            </asp:ListView>
    </div>
    </div>
    </form>
</body>
</html>
