using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WM_Project.control;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace PostNL.control
{
    public class UkmailLabel
    {
        public UkmailLabel(string Ordernum, string Tracknum, string SenderAdress, double Weight, string ShippingDate, int totalParcel)
        {
            try
            {
                Code128B co128 = new Code128B();
                Document document = new Document(PageSize.A4);
                document.SetPageSize(new Rectangle(460, 320));
                co128.ValueFont = new System.Drawing.Font("Calibri", 20);
                System.Drawing.Bitmap imgTemp = co128.GetCodeImage(Tracknum, Code128B.Encode.Code128A);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);
                img.ScaleAbsoluteHeight(70);
                img.ScaleAbsoluteWidth(240);
                System.Drawing.Bitmap imgTemp1 = co128.GetCodeImage(Ordernum, Code128B.Encode.Code128A);
                iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp1, iTextSharp.text.BaseColor.WHITE);
                img1.ScaleAbsoluteWidth(163);
                
                string filename = "\\views\\pdf\\" + Ordernum + "2.pdf";
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.SetMargins(10, 10, 2, 2);
                document.Open();      
                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 100;
                table.TotalWidth = 1200;
                PdfPCell cell;
                BaseFont baseFT1 = BaseFont.CreateFont("C:/WINDOWS/Fonts/Helvetica.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/Helvetica Bold.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                for (int i = 0; i < totalParcel; i++)
                {
                    document.NewPage();
                    PdfPTable table1 = new PdfPTable(4);
                    PdfPTable table2 = new PdfPTable(1);
                    cell = new PdfPCell(new Phrase("www.ukmail.com",new Font(baseFT1,8)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    table2.AddCell(cell);
                    Phrase ph = new Phrase();
                    Chunk chunkCollection = new Chunk("Domestic Collection\r\nLIVE OPSYS\r\nLabel Produces:\r\n"+DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")+"\r\n \r\n ", new Font(baseFT, 10));
                    ph.Add(chunkCollection);
                    cell = new PdfPCell(ph);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table2.AddCell(cell);
                    cell = new PdfPCell(table2);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 1;
                    table1.AddCell(cell);
                    cell = new PdfPCell(img);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 3;
                    cell.PaddingTop = 10;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table1.AddCell(cell);
                    PdfPTable table3 = new PdfPTable(5);
                    Phrase chunkFAO = new Phrase("FAO:Customer Import\r\nETAO LTD\r\nC/O ACCESS SELF STORAGE,OFFIC\r\nHARBORNE LANE SELLY OAK\r\nBIRMINGHAM", new Font(baseFT, 10));
                    cell = new PdfPCell(chunkFAO);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Colspan = 2;
                    
                    table3.AddCell(cell);
                    Phrase chunkConsignment = new Phrase("Consignment NO:    " + Tracknum + "\r\nWeight:                      " + Weight.ToString() + " Kg\r\nParcel:                       " + (i+1).ToString() + " of " + totalParcel.ToString() + "\r\nTelephone:                0121 448 6510\r\nReference 1:\r\nnReference 2:\r\nCollection Driver:\r\nCollection Address:  " + SenderAdress,new Font(baseFT,10));
                    cell = new PdfPCell(chunkConsignment);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Colspan = 3;
                    table3.AddCell(cell);
                    //table.AddCell(table3);
                    PdfPTable table4 = new PdfPTable(5);
                    PdfPTable table5 = new PdfPTable(1);
                    Phrase phrase = new Phrase();
                    Chunk chk1 = new Chunk("B29 6SN\r\n",new Font(baseFT,14));
                    Chunk chk2 = new Chunk("Special Instructions\r\n \r\n",new Font(baseFT1,8));
                    Chunk chk3 = new Chunk(" \r\n"+Ordernum, new Font(baseFT1, 8));
                    Chunk chk4 = new Chunk("\r\nETAO LTD", new Font(baseFT, 8));
                    phrase.Add(chk1);
                    phrase.Add(chk2);
                     cell = new PdfPCell(phrase);
                     cell.BorderWidthLeft = 0;
                     cell.BorderWidthRight = 0;
                     cell.BorderWidthTop = 0;
                     cell.BorderWidthBottom = 0;
                     cell.Colspan = 1;
                     table5.AddCell(cell);
                     cell = new PdfPCell(img1);
                     cell.BorderWidthLeft = 0;
                     cell.BorderWidthRight = 0;
                     cell.BorderWidthTop = 0;
                     cell.BorderWidthBottom = 0;
                     cell.Colspan = 1;
                     table5.AddCell(cell);
                     Phrase phrase1 = new Phrase();
                     phrase1.Add(chk3);
                     phrase1.Add(chk4);
                     cell = new PdfPCell(phrase1);
                     cell.BorderWidthLeft = 0;
                     cell.BorderWidthRight = 0;
                     cell.BorderWidthTop = 0;
                     cell.BorderWidthBottom = 0;
                     cell.Colspan = 1;
                     table5.AddCell(cell);
                    cell = new PdfPCell(table5);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 2;
                    cell.PaddingTop = 5;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table4.AddCell(cell);

                    Phrase phraseHome = new Phrase("HomeService           " + DateTime.Parse(ShippingDate).ToString("dd/MM/yyyy")+"\r\nNextDay\r\n \r\n \r\nBirmingham",new Font(baseFT,17));
                    cell = new PdfPCell(phraseHome);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.PaddingTop = 5;
                    cell.Colspan = 3;
                    cell.PaddingLeft = 10;
                    table4.AddCell(cell);
                    

                    cell = new PdfPCell(table1);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 1;
                    table.AddCell(cell);
                    
                    cell = new PdfPCell(table3);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 1;
                    cell.FixedHeight = 100;
                    table.AddCell(cell);
                    cell = new PdfPCell(table4);
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = 1;
                    table.AddCell(cell);
                    document.Add(table);
                    
                }
                document.Close();
                fs.Close();
            }
            catch (DocumentException de)
            {
            }
            catch (IOException ioe)
            {
            }




        }

    }
}