using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace InvoiceForm
{
    public static class FormPDF
    {

        public static void CreateFile()
        {
            Document doc = new Document();
            string filepath = Application.StartupPath + "\\FormPDF.pdf";
            PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph("Hello World!");
            doc.Add(p1);
            doc.Close();
            MessageBox.Show("PDF File Created Sucessfully");

        }
    }

    
}
