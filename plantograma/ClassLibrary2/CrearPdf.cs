using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Entidades
{
    public class CrearPdf
    {
        public void crear(String cadenaFinal)
        {

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

                //Open PDF Document to write data 
                pdfDoc.Open();


                //Assign Html content in a string to write in PDF 
                string strContent = cadenaFinal;
                





                //Read string contents using stream reader and convert html to parsed conent 
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document 
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF 
                pdfDoc.Close();

                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";

                //Set default file Name as current datetime 
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=Platograma.pdf");

                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();

            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.ToString());
            }


        }

    }
}
