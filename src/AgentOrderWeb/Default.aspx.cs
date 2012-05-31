using System;
using System.Collections.Generic;
using OrderImport;


public partial class _Default : System.Web.UI.Page 
{
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        var path = @"C:\Temp\Upload";

        if (FileUpload.HasFile)
        {
            var filename = FileUpload.FileName;

            path += filename;

            FileUpload.SaveAs(path);

            UploadStatusLabel.Text = "File saved as " + filename;

            var reader = new XmlReader();
            string orderXml = reader.Read(path);
            var parser = new OrderParser();
            var orderItems = parser.Parse(orderXml);
            
            GridView.DataSource = new List<Order>(orderItems);
            GridView.DataBind();
        }
        else
        {
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }
}
