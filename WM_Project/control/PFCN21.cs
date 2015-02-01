using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace WM_Project.control
{
    public class PFCN21
    {

        public PFCN21(string orderNumber, string trackNumber,string senderCompanyname, string senderName,  string senderCity,string receiveCompanyname, string receiveCountry, string senderAddress1, string senderAddress2, string senderAddress3, string senderPostcode, string receiveName, float[] weight, string receiveCity, string receiveAddress1, string receiveAddress2, string receiveAddress3, string receivePostcode, string shipDate, string receivePhone, string[] description, float[] value)
        {
            try
            {
                PdfReader reader;
                if (senderCompanyname == null)
                {
                    senderCompanyname = " ";
                }
                if (senderName == null)
                {
                    senderName = " ";
                }
                if (senderCity == null)
                {
                    senderCity = " ";
                }
                if (receiveCompanyname == null)
                {
                    receiveCompanyname = " ";
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

                      PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(AppDomain.CurrentDomain.BaseDirectory + "views\\pdf\\" + track[ij]  + "0.pdf", FileMode.Create));

                      document.Open();

                      PdfContentByte cb = writer.DirectContent;

                      reader = new PdfReader(AppDomain.CurrentDomain.BaseDirectory + "Module\\CN21Module.pdf");
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





                      DateTime dt = DateTime.Parse(shipDate);

                      cb.SetFontAndSize(baseFT1, 7);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderCompanyname, 38, 773, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderName, 38, 765, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress1, 38, 757, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress2, 38, 749, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress3, 38, 741, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderCity + senderPostcode, 38, 733, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 38, 725, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCompanyname, 305, 753, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 305, 745, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 305, 737, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 305, 729, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 305, 721, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity + " " + receivePostcode, 305, 713, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry, 305, 705, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, dt.ToString("dd/MM/yyyy"), 220, 708, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, description[ij], 38, 670, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "1", 240, 670, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, weight[ij].ToString(), 273, 670, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, value[ij].ToString(), 308, 670, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 422, 670, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "Gift", 489, 652, 0);



                      cb.ShowTextAligned(Element.ALIGN_LEFT, weight[ij].ToString(), 338, 540, 0);



                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderCompanyname, 38, 468, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderName, 38, 460, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress1, 38, 452, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress2, 38, 444, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress3, 38, 436, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "BIRMINGHAM" + senderPostcode, 38, 428, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 38, 420, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCompanyname, 305, 449, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 305, 441, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 305, 433, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 305, 427, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 305, 419, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity + " " + receivePostcode, 305, 411, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry, 305, 403, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, dt.ToString("dd/MM/yyyy"), 220, 404, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, description[ij], 38, 366, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "1", 240, 366, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, weight[ij].ToString(), 273, 366, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, value[ij].ToString(), 308, 366, 0);





                      cb.ShowTextAligned(Element.ALIGN_LEFT, weight[ij].ToString(), 338, 235, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderCompanyname, 38, 186, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderName, 38, 178, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress1, 38, 170, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress2, 38, 162, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, senderAddress3, 38, 154, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "BIRMINGHAM" + senderPostcode, 38, 146, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, "United Kingdom", 38, 138, 0);


                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCompanyname, 305, 186, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveName, 305, 178, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress1, 305, 170, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress2, 305, 162, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveAddress3, 305, 154, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCity + " " + receivePostcode, 305, 146, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, receiveCountry, 305, 138, 0);



                      cb.SetFontAndSize(baseFT, 14);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 410, 47, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 410, 487, 0);
                      cb.ShowTextAligned(Element.ALIGN_LEFT, track[ij], 410, 791, 0);
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