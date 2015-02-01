using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using WM_Project.control;
using iTextSharp.text.pdf;
using System.IO;




namespace WM_Project.control
{
    public class PFLabel
    {
        public PFLabel(string orderNumber, string trackNumber, string senderName, string senderCity,string receiveCountry, string senderAddress, string senderPostcode,string receiveName, float[] weight, string receiveCity, string receiveAddress1, string receiveAddress2, string receiveAddress3, string receivePostcode, string shipDate, string receivePhone,string shipType,string[] description)
        {
            try
            {
                PdfReader reader;

                if (senderAddress == null)
                {
                    senderAddress = " ";
                }
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
                if (receiveAddress1 == null)
                    receiveAddress1 = " ";
                if (receiveAddress2 == null)
                    receiveAddress2 = " ";
                if (receiveAddress3 == null)
                    receiveAddress3 = " ";

                string[] track = trackNumber.Split(',');
                for (int ij = 0; ij < track.Length; ij++)
                {
                    Code128B co128 = new Code128B();
                    co128.ValueFont = new System.Drawing.Font("Calibri", 20);

                    System.Drawing.Bitmap imgTemp = co128.GetCodeImage(track[ij], Code128B.Encode.Code128A);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);


                    Document document = new Document();

                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(AppDomain.CurrentDomain.BaseDirectory + "views\\pdf\\" + track[ij]+ "1.pdf", FileMode.Create));

                    document.Open();

                    PdfContentByte cb = writer.DirectContent;
                    if (shipType.Contains("IPE"))
                    {
                        reader = new PdfReader(AppDomain.CurrentDomain.BaseDirectory + "Module\\IPEModule.pdf");
                    }
                    else
                        reader = new PdfReader(AppDomain.CurrentDomain.BaseDirectory + "Module\\GPRModule.pdf");
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
                    cb.SetFontAndSize(baseFT1, 6);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderName, 26, 60, 90);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderCity, 26, 136, 90);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress, 31, 60, 90);

                    cb.ShowTextAligned(Element.ALIGN_LEFT, senderPostcode + " GB", 33, 136, 90);
                    cb.SetFontAndSize(baseFT1, 8);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 50, 1, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 50, 178, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", weight[ij]), 156, 179, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity, 45, 190, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 45, 198, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 45, 206, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 150, 206, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 150, 197, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receivePostcode, 150, 189, 0);
                    DateTime dt = DateTime.Parse(shipDate);
                    string[] day = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

                    cb.ShowTextAligned(Element.ALIGN_LEFT, dt.ToString("dd/MM/yyyy") + "," + day[Convert.ToInt32(dt.DayOfWeek)], 210, 330, 0);
                    cb.SetFontAndSize(baseFT1, 10);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 50, 38, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, "Telephone:" + receivePhone, 20, 237, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 20, 278, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 20, 290, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 20, 302, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 20, 314, 0);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 20, 325, 0);
                    cb.SetFontAndSize(baseFT, 10);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, description[ij].ToUpper(), 10, 220, 0);
                    cb.SetFontAndSize(baseFT, 14);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry.ToUpper(), 20, 247, 0);

                    cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity.ToUpper() + " " + receivePostcode, 20, 262, 0);

                    cb.ShowTextAligned(Element.ALIGN_LEFT,(ij+1).ToString()+ " of "+track.Length.ToString(), 140, 335, 0);

                    cb.SetFontAndSize(baseFT, 8);
                    cb.SetRGBColorFill(255, 255, 255);
                    cb.ShowTextAligned(Element.ALIGN_LEFT, String.Format("{0:F}", weight[ij]), 158, 180, 0);
                    cb.EndText();


                    img.ScaleAbsoluteWidth(170);
                    img.ScaleAbsoluteHeight(120);
                    img.SetAbsolutePosition(48, 52);
                    cb.AddImage(img);
                    img.ScaleAbsoluteWidth(170);
                    img.ScaleAbsoluteHeight(22);
                    img.SetAbsolutePosition(48, 9);
                    cb.AddImage(img);
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