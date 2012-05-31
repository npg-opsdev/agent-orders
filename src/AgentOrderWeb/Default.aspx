<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Import</title>
</head>
<body>
    <form id="form" runat="server">
        <div>
           <asp:FileUpload id="FileUpload"
               runat="server">
           </asp:FileUpload>
        </div>
        <div>
           <asp:Button id="UploadButton" 
               Text="Upload file"
               OnClick="UploadButton_Click"
               runat="server">
           </asp:Button>    
        </div>
        <div>
           <asp:Label id="UploadStatusLabel"
               runat="server">
           </asp:Label>        
        </div>
        <div>
            <asp:GridView ID="GridView" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
