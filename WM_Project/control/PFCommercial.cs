using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using WM_Project.control;
using iTextSharp.text;
using System.IO;


namespace WM_Project.control
{
    public class PFCommercial
    {

        public PFCommercial(string orderNumber, string trackNumber, string senderName,string senderPhone, string senderCity, string receiveCountry, string senderAddress1, string senderAddress2, string senderAddress3, string senderPostcode, string receiveName, float[] weight, string receiveCity, string receiveAddress1, string receiveAddress2, string receiveAddress3, string receivePostcode, string shipDate, string receivePhone, string[] description,float[] value)
        {
            try
            {
                PdfReader reader;

            
                if (senderName == null)
                {
                    senderName = " ";
                }
                if (senderCity == null)
                {
                    senderCity = " ";
                }
             
                if (receiveCountry == null)
                {
                    receiveCountry = " ";
                }
                if (senderPostcode == null)
                {
                    senderPostcode = " ";
                }
                if (receiveName == null)
                {
                    receiveName = " ";
                }
                for (int i = 0; i < weight.Length; i++)
                {
                    if (weight[i] == null)
                    {
                        weight[i] = 0;
                    }
                }
                if (receiveCity == null)
                {
                    receiveCity = " ";
                }
                if (receivePostcode == null)
                {
                    receivePostcode = " ";
                }
                if (shipDate == null)
                {
                    shipDate = " ";
                }
                if (receivePhone == null)
                {
                    receivePhone = " ";
                }
                for (int i = 0; i < description.Length; i++)
                {
                    if (description[i] == null)
                    {
                        description[i] = " ";
                    }
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == null)
                    {
                        value[i] = 0;
                    }
                }
                if (receiveAddress1 == null)
                    receiveAddress1 = " ";
                if (receiveAddress2 == null)
                    receiveAddress2 = " ";
                if (receiveAddress3 == null)
                    receiveAddress3 = " ";
                if (senderAddress1 == null)
                    senderAddress1 = " ";
                if (senderAddress2== null)
                    senderAddress2 = " ";
                if (senderAddress3 == null)
                    senderAddress3 = " ";
                string[] track = trackNumber.Split(',');
                for (int ij = 0; ij < track.Length; ij++)
                {
                    Document document = new Document();

                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(AppDomain.CurrentDomain.BaseDirectory + "views\\pdf\\" + track[ij] + "3.pdf", FileMode.Create));

                    document.Open();

                    PdfContentByte cb = writer.DirectContent;

                    reader = new PdfReader(AppDomain.CurrentDomain.BaseDirectory + "Module\\CommercialModule.pdf");
                    PdfImportedPage newPage;
                    document.SetPageSize(reader.GetPageSize(1));
                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, 1);
                    cb.AddTemplate(newPage, 0, 0);
                    cb.BeginText();
                    BaseFont baseFT1 = BaseFont.CreateFont("C:/WINDOWS/Fonts/Helvetica.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/Helvetica Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    BaseFont baseFT2 = BaseFont.CreateFont("C:/WINDOWS/Fonts/Helvetica Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT, 8);

                    cb.SetFontAndSize(baseFT1, 9);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, description[ij], 60, 345, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 292, 345, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", weight[ij]), 390, 345, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "gbp", 443, 345, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", value[ij]), 488, 345, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", value[ij]), 530, 345, 0);




                    DateTime dt = DateTime.Parse(shipDate);

                    cb.SetFontAndSize(baseFT1, 10);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderName, 50, 743, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress1, 50, 730, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress2, 50, 717, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress3, 50, 704, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "BIRMINGHAM", 50, 691, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderPostcode, 50, 678, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 50, 665, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderPhone, 108, 645, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, dt.ToString("dd/MM/yyyy"), 419, 733, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderCity, 419, 691, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "DDU/Incoterm 20", 419, 670, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "Gift", 419, 655, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 392, 630, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, ij.ToString() + "of" + track.Length.ToString(), 392, 614, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, ij.ToString() + "of" + track.Length.ToString(), 392, 602, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 55, 532, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 55, 520, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 55, 508, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 55, 494, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity, 55, 481, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receivePostcode, 55, 468, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry, 55, 455, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receivePhone, 105, 430, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 326, 532, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 326, 520, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 326, 508, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 326, 494, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity, 326, 481, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receivePostcode, 326, 468, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry, 326, 455, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receivePhone, 379, 430, 0);

                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", weight[ij]) + "Kg", 468, 302, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "gbp " + String.Format("{0:F}", value[ij]), 468, 285, 0);
                    cb.SetFontAndSize(baseFT, 14);
                    cb.EndText();
                    document.Close();
                }

             
            }
            catch (Exception ee)
            {


            }
        }


        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {

            PdfReader reader;


            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            reader = new PdfReader(fileList[0]);
            PdfImportedPage newPage;
            document.SetPageSize(reader.GetPageSize(1));
            for (int i = 0; i < fileList.Length; i++)
            {

                reader = new PdfReader(fileList[i]);

                int iPageNum = reader.NumberOfPages;

                for (int j = 1; j <= iPageNum; j++)
                {

                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);

                }

            }

            document.Close();
        }
    }
}