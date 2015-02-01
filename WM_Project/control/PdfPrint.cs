using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Reflection;

namespace WM_Project.control
{
    public class PdfPrint
    {


        string filename = null;
        Code128B co128 = new Code128B();
        public PdfPrint(string Ordernum, string Tracknum, string ReceiverName, string ReceiverPhone, string ReceiverAdress, string ReceiverPostCode, string ReceiverCity, string SenderName, string SenderPhone, string SenderAdress, string PayWay, float Weight, float GoodValue, string GoodsType, string GoodRemark, int totalParcel, int cixu)
        {
            try
            {
                Code128B co128 = new Code128B();
                Document document = new Document(PageSize.A8);
                document.SetPageSize(new iTextSharp.text.Rectangle(298, 425));

                co128.ValueFont = new System.Drawing.Font("Calibri", 20);

                System.Drawing.Bitmap imgTemp = co128.GetCodeImage(Ordernum, Code128B.Encode.Code128A);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);


                System.Drawing.Bitmap imgTemp2 = co128.GetCodeImage(Tracknum, Code128B.Encode.Code128A);
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);
                iTextSharp.text.Image img3 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);

                // Random random=new Random();
                filename = "\\views\\pdf\\" + Tracknum + ".pdf";
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
                PdfWriter.GetInstance(document, fs);
                document.SetMargins(10, 10, 2, 2);
                document.Open();
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
                BaseFont baseFT = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.NOT_EMBEDDED);
                BaseFont baseFT1 = BaseFont.CreateFont("C:/WINDOWS/Fonts/STFANGSO.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT1, 7);

                PdfPTable table = new PdfPTable(8);

                table.WidthPercentage = 100;
                table.TotalWidth = 1200;

                PdfPCell cell;
                PdfPTable table1 = new PdfPTable(1);
                PdfPCell cell1;

                iTextSharp.text.Image emslogoimg = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\image\\images\\EMSLOGO2.png");
                emslogoimg.ScaleAbsoluteWidth(100);
                emslogoimg.ScaleAbsoluteHeight(24);
                cell = new PdfPCell(emslogoimg);
                cell.MinimumHeight = 20;
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);
                cell.PaddingTop = 2;
                cell.BorderWidth = 0;
                table1.AddCell(cell);
                cell = new PdfPCell(new Phrase("标准快递", new iTextSharp.text.Font(baseFT, 20)));

                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);
                cell.PaddingTop = 0;
                cell.PaddingBottom = 0;
                cell.BorderWidth = 0;

                table1.AddCell(cell);
                cell = new PdfPCell(new Phrase("时间: " + DateTime.Now.ToString(), font));
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);

                cell.PaddingTop = 0;

                cell.BorderWidth = 0;

                table1.AddCell(cell);
                cell = new PdfPCell(table1);
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (3);

                cell.BorderWidthRight = 0;
                table.AddCell(cell);


                PdfPTable table2 = new PdfPTable(1);
                img.ScaleAbsoluteWidth(210);
                img.ScaleAbsoluteHeight(20);
                img3.ScaleAbsoluteWidth(166);
                img3.ScaleAbsoluteHeight(40);
                cell = new PdfPCell(img3);

                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);

                cell.BorderWidth = 0;
                table2.AddCell(cell);
                cell = new PdfPCell(new Phrase(Tracknum, new iTextSharp.text.Font(baseFT, 8)));
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);
                cell.BorderWidthTop = 0;
                cell.BorderWidth = 0;
                cell.Padding = 2;
                //cell.PaddingBottom = 20;
                table2.AddCell(cell);


                cell = new PdfPCell(table2);
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (5);
                cell.Padding = 5;
                cell.BorderWidthLeft = 0;
                cell.PaddingBottom = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("寄件：", font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.MinimumHeight = 40;
                cell.Colspan = (1);

                cell.Padding = 2;
                cell.BorderWidthRight = 0;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(SenderName + "  " + SenderPhone + "  " + SenderAdress, font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (3);
                cell.BorderWidthLeft = 0;
                cell.Padding = 5;
                //cell.PaddingTop = 20;
                cell.PaddingBottom = 5;
                table.AddCell(cell);

                cell.FixedHeight = 800;
                cell = new PdfPCell(new Phrase(ReceiverCity, new iTextSharp.text.Font(baseFT, 20)));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (4);

                cell.Padding = 5;
                cell.PaddingBottom = 5;
                table.AddCell(cell);
                table.HorizontalAlignment = Element.ALIGN_LEFT;


                cell = new PdfPCell(new Phrase("收件：", font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (1);
                cell.MinimumHeight = 45;
                cell.BorderWidthRight = 0;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase(ReceiverName + "   " + ReceiverPhone + "  " + ReceiverAdress, font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (7);

                cell.BorderWidthLeft = 0;
                table.AddCell(cell);




                cell = new PdfPCell(new Phrase("付款方式：  \n计费重量（KG）：" + Weight.ToString() + "\n报价金额（元）：" + GoodValue, font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (4);

                cell.Padding = 5;

                cell.PaddingBottom = 0;
                table.AddCell(cell);

                Phrase ph = new Phrase();
                ph.Add(new Chunk("收件人/代收件人：\n签收时间：       年     月    日\n", font));
                ph.Add(new Chunk("    ", new iTextSharp.text.Font(baseFT1, 10)));
                ph.Add(new Chunk("快件送达收件人地址，经收件人或收件人允许的代收件人签字，视为送达。", new iTextSharp.text.Font(baseFT1, 5)));

                cell = new PdfPCell(ph);

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (4);

                cell.PaddingBottom = 5;
                table.AddCell(cell);



                cell = new PdfPCell(new Phrase("订单号：  \n", font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.BorderWidthRight = 0;
                cell.BorderWidthBottom = 0;
                cell.Colspan = (1);
                cell.PaddingTop = 5;

                table.AddCell(cell);

                cell = new PdfPCell(img);
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                cell.Colspan = (7);
                cell.PaddingTop = 5;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(Ordernum + "         件数：" + totalParcel.ToString() + "          重量（KG）:" + Weight.ToString(), font));
                cell.BorderWidthTop = 0;
                cell.BorderWidthBottom = 0;
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                cell.Colspan = (8);

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("配货信息：  " + GoodsType, font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (8);
                cell.BorderWidthTop = 0;
                cell.MinimumHeight = 30;

                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("                ", font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (8);

                table.AddCell(cell);
                img2.ScaleAbsoluteWidth(150);
                img2.ScaleAbsoluteHeight(20);
                PdfPTable table4 = new PdfPTable(1);
                cell = new PdfPCell(img2);
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);
                cell.Padding = 2;

                cell.PaddingRight = 0;
                cell.BorderWidth = 0;
                table4.AddCell(cell);
                cell = new PdfPCell(new Phrase(Tracknum, new iTextSharp.text.Font(baseFT, 8)));
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (1);
                cell.BorderWidthTop = 0;
                cell.BorderWidth = 0;


                table4.AddCell(cell);


                cell = new PdfPCell(table4);
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (4);
                cell.Padding = 5;

                cell.BorderWidthRight = 0;

                table.AddCell(cell);

                iTextSharp.text.Image img6 = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\image\\images\\EMSLOGO2.png");
                img6.ScaleAbsoluteHeight(24);
                img6.ScaleAbsoluteWidth(100);
                cell = new PdfPCell(img6);
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (4);
                cell.Padding = 5;
                cell.PaddingBottom = 5;
                cell.PaddingLeft = 20;
                cell.BorderWidthLeft = 0;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("寄件：", font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (1);

                cell.Padding = 5;
                cell.BorderWidthRight = 0;
                cell.PaddingBottom = 5;

                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(SenderName + " " + SenderPhone + "  " + SenderAdress, font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (3);
                cell.BorderWidthLeft = 0;


                cell.PaddingBottom = 5;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("收件：", font));

                cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                cell.Colspan = (1);

                cell.Padding = 5;
                cell.BorderWidthRight = 0;
                cell.PaddingBottom = 5;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ReceiverName + "   " + ReceiverPhone + "  " + ReceiverAdress, font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (3);
                cell.Padding = 5;
                cell.BorderWidthLeft = 0;
                cell.PaddingBottom = 5;
                table.AddCell(cell);


                PdfPTable table3 = new PdfPTable(1);


                cell = new PdfPCell(new Phrase("备注：" + GoodRemark, font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (1);
                cell.Padding = 5;

                cell.BorderWidthTop = 0;
                cell.BorderWidthLeft = 0;
                cell.BorderWidthRight = 0;

                table3.AddCell(cell);
                cell = new PdfPCell(new Phrase("网址：www.ems.com.cn  电话：11183", font));
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (1);
                cell.Padding = 5;
                cell.PaddingBottom = 5;
                cell.BorderWidth = 0;


                table3.AddCell(cell);
                cell.MinimumHeight = 400;
                cell = new PdfPCell(table3);
                cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                cell.Colspan = (5);

                cell.PaddingBottom = 5;

                table.AddCell(cell);


                cell.MinimumHeight = 400;
                iTextSharp.text.Image img4 = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\image\\images\\erweima.png");
                img4.ScaleAbsoluteHeight(60);
                img4.ScaleAbsoluteWidth(60);
                cell = new PdfPCell(img4);
                cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                cell.Colspan = (3);
                cell.BorderWidthTop = 0;

                cell.Padding = 5;

                table.AddCell(cell);
                document.Add(table);


                document.Close();
                fs.Close();

            }




            catch (DocumentException de)
            {


            }
            catch (IOException ioe)
            {


            }



            //Random random = new Random();
            //filename = "\\views\\pdf\\" + Ordernum + "2.pdf";

            //try
            //{
            //    Document document = new Document(PageSize.A8);
            //    document.SetPageSize(new iTextSharp.text.Rectangle(298, 425));
            //    co128.ValueFont = new System.Drawing.Font("宋体", 20);

            //    System.Drawing.Bitmap imgTemp = co128.GetCodeImage(Ordernum, Code128B.Encode.Code128A);
            //    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);
            //    System.Drawing.Bitmap imgTemp2 = co128.GetCodeImage(Tracknum, Code128B.Encode.Code128A);
            //    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);
            //    iTextSharp.text.Image img3 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);

            //    FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
            //    PdfWriter.GetInstance(document, fs);
            //    document.SetMargins(10, 10, 2, 2);
            //    document.Open();
            //    iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
            //    iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
            //    BaseFont baseFT = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.NOT_EMBEDDED);
            //    BaseFont baseFT1 = BaseFont.CreateFont("C:/WINDOWS/Fonts/STFANGSO.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT1, 7);
            //    PdfPTable table = new PdfPTable(8);

            //        table.WidthPercentage = 100;
            //        table.TotalWidth = 1200;

            //        PdfPCell cell;

            //        PdfPTable table1 = new PdfPTable(1);
            //        iTextSharp.text.Image emslogoimg = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\EMSLOGO2.png");
            //        emslogoimg.ScaleAbsoluteWidth(100);
            //        emslogoimg.ScaleAbsoluteHeight(24);
            //        cell = new PdfPCell(emslogoimg);
            //        cell.MinimumHeight = 20;
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.PaddingTop = 2;
            //        cell.BorderWidth = 0;
            //        table1.AddCell(cell);

            //        cell = new PdfPCell(new Phrase("标准快递", new iTextSharp.text.Font(baseFT, 20)));

            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.PaddingTop = 0;
            //        cell.PaddingBottom = 0;
            //        cell.BorderWidth = 0;

            //        table1.AddCell(cell);
            //        cell = new PdfPCell(new Phrase("时间: " +DateTime.Now.ToString(), font));
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);

            //        cell.PaddingTop = 0;

            //        cell.BorderWidth = 0;

            //        table1.AddCell(cell);
            //        cell = new PdfPCell(table1);
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (3);

            //        cell.BorderWidthRight = 0;
            //        table.AddCell(cell);











            //        PdfPTable table2 = new PdfPTable(1);
            //        img.ScaleAbsoluteWidth(210);
            //        img.ScaleAbsoluteHeight(20);
            //        img3.ScaleAbsoluteWidth(166);
            //        img3.ScaleAbsoluteHeight(40);
            //        cell = new PdfPCell(img3);

            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);

            //        cell.BorderWidth = 0;
            //        table2.AddCell(cell);
            //        cell = new PdfPCell(new Phrase(Tracknum, new iTextSharp.text.Font(baseFT, 8)));
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.BorderWidthTop = 0;
            //        cell.BorderWidth = 0;
            //        cell.Padding = 2;
            //        //cell.PaddingBottom = 20;
            //        table2.AddCell(cell);


            //        cell = new PdfPCell(table2);
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (5);
            //        cell.Padding = 5;
            //        cell.BorderWidthLeft = 0;
            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);






            //        cell = new PdfPCell(new Phrase("寄件：", font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.MinimumHeight = 40;
            //        cell.Colspan = (1);

            //        cell.Padding = 2;
            //        cell.BorderWidthRight = 0;
            //        table.AddCell(cell);

            //        cell = new PdfPCell(new Phrase(SenderName+" "+SenderPhone+" "+SenderAdress, font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (3);
            //        cell.BorderWidthLeft=0;
            //        cell.Padding = 5;
            //        //cell.PaddingTop = 20;
            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);

            //        cell.FixedHeight = 800;
            //        cell = new PdfPCell(new Phrase(ReceiverCity, new iTextSharp.text.Font(baseFT, 20)));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (4);

            //        cell.Padding = 5;
            //        //cell.PaddingTop = 20;
            //        table.AddCell(cell);
            //        table.HorizontalAlignment = Element.ALIGN_LEFT;




            //        cell = new PdfPCell(new Phrase("收件：", font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (1);
            //        cell.MinimumHeight = 45;
            //        cell.BorderWidthRight = 0;
            //        table.AddCell(cell);


            //        cell = new PdfPCell(new Phrase(ReceiverName+" "+ReceiverPhone+" \n"+ReceiverAdress, font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (7);


            //    cell.BorderWidthLeft=0;
            //        table.AddCell(cell);





            //        cell = new PdfPCell(new Phrase("付款方式： "+PayWay+" \n计费重量（KG）："+Weight.ToString()+"\n报价金额（元）："+GoodValue.ToString(), font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (4);

            //        cell.Padding = 5;

            //        cell.PaddingBottom = 0;
            //        table.AddCell(cell);



            //        Phrase ph = new Phrase();
            //        ph.Add(new Chunk("收件人/代收件人：\n签收时间：       年     月    日\n", font));
            //        ph.Add(new Chunk("    ", new iTextSharp.text.Font(baseFT1, 10)));
            //        ph.Add(new Chunk("快件送达收件人地址，经收件人或收件人允许的代收件人签字，视为送达。", new iTextSharp.text.Font(baseFT1, 5)));

            //        cell = new PdfPCell(ph);

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (4);

            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);




            //        cell = new PdfPCell(new Phrase("订单号：  \n", font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.BorderWidthRight = 0;
            //        cell.BorderWidthBottom = 0;
            //        cell.Colspan = (1);
            //        cell.PaddingTop = 5;
            //        table.AddCell(cell);

            //        cell = new PdfPCell(img);
            //        cell.BorderWidthBottom = 0;
            //        cell.BorderWidthLeft = 0;
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);

            //        cell.Colspan = (7);
            //        cell.PaddingTop = 5;
            //        table.AddCell(cell);
            //        cell = new PdfPCell(new Phrase(Tracknum+"         件数："+totalParcel+"          重量（KG）:"+Weight.ToString(), font));
            //        cell.BorderWidthTop = 0;
            //        cell.BorderWidthBottom = 0;
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);

            //        cell.Colspan = (8);

            //        table.AddCell(cell);

            //        cell = new PdfPCell(new Phrase("配货信息：  \n"+GoodsType , font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (8);
            //        cell.BorderWidthTop = 0;
            //        cell.MinimumHeight = 30;

            //        table.AddCell(cell);

            //        cell = new PdfPCell(new Phrase("                ", font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (8);

            //        table.AddCell(cell);
            //        img2.ScaleAbsoluteWidth(150);
            //        img2.ScaleAbsoluteHeight(20);
            //        PdfPTable table4 = new PdfPTable(1);
            //        cell = new PdfPCell(img2);
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.Padding = 2;

            //        cell.PaddingRight = 0;
            //        cell.BorderWidth = 0;
            //        table4.AddCell(cell);
            //        cell = new PdfPCell(new Phrase(Tracknum, new iTextSharp.text.Font(baseFT, 8)));
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.BorderWidthTop = 0;
            //        cell.BorderWidth = 0;


            //        table4.AddCell(cell);


            //        cell = new PdfPCell(table4);
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (4);
            //        cell.Padding = 5;

            //        cell.BorderWidthRight = 0;

            //        table.AddCell(cell);

            //        iTextSharp.text.Image img6 = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\EMSLOGO2.png");
            //        img6.ScaleAbsoluteHeight(24);
            //        img6.ScaleAbsoluteWidth(100);

            //        cell = new PdfPCell(img6);
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (4);
            //        cell.Padding = 5;
            //        cell.PaddingBottom = 5;
            //        cell.PaddingLeft = 20;
            //        cell.BorderWidthLeft = 0;
            //        table.AddCell(cell);
            //        cell = new PdfPCell(new Phrase("寄件：", font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (1);

            //        cell.Padding = 5;
            //        cell.BorderWidthRight = 0;
            //        cell.PaddingBottom = 5;

            //        table.AddCell(cell);
            //        cell = new PdfPCell(new Phrase(SenderName+" "+SenderPhone+"\n"+SenderAdress, font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (3);
            //        cell.BorderWidthLeft = 0;

            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);
            //        cell = new PdfPCell(new Phrase("收件：", font));

            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);

            //        cell.Colspan = (1);

            //        cell.Padding = 5;
            //        cell.BorderWidthRight = 0;
            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);

            //        cell = new PdfPCell(new Phrase(ReceiverName+"   "+ReceiverPhone+  " \n"+ReceiverAdress+" "+ReceiverPostCode, font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (3);
            //        cell.Padding = 5;
            //        cell.BorderWidthLeft = 0;
            //        cell.PaddingBottom = 5;
            //        table.AddCell(cell);








            //        PdfPTable table3 = new PdfPTable(1);


            //        cell = new PdfPCell(new Phrase("备注："+GoodRemark, font));
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (1);
            //        cell.Padding = 5;

            //        cell.BorderWidthTop = 0;
            //        cell.BorderWidthLeft = 0;
            //        cell.BorderWidthRight = 0;

            //        table3.AddCell(cell);
            //        cell = new PdfPCell(new Phrase("网址：www.ems.com.cn   客服电话：11183\n", font));
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (1);
            //        cell.Padding = 5;
            //        cell.PaddingBottom = 5;
            //        cell.BorderWidth = 0;

            //        table3.AddCell(cell);
            //        cell.MinimumHeight = 400;
            //        cell = new PdfPCell(table3);
            //        cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            //        cell.Colspan = (5);

            //        cell.PaddingBottom = 5;

            //        table.AddCell(cell);


            //        cell.MinimumHeight = 400;
            //        iTextSharp.text.Image img4 = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\erweima.png");
            //        img4.ScaleAbsoluteHeight(60);
            //        img4.ScaleAbsoluteWidth(60);
            //        cell = new PdfPCell(img4);
            //        cell.HorizontalAlignment = (Element.ALIGN_CENTER);
            //        cell.Colspan = (3);
            //        cell.BorderWidthTop = 0;

            //        cell.Padding = 5;


            //        table.AddCell(cell);
            //        document.Add(table);


            //    document.Close();




            //}




            //catch (DocumentException de)
            //{
            //    Console.Error.WriteLine(de.Message);

            //}
            //catch (IOException ioe)
            //{
            //    Console.Error.WriteLine(ioe.Message);

            //}



        }

        public PdfPrint(int n, string[] Ordernum, string[] Tracknum, string[] ReceiverName, string[] ReceiverPhone, string[] ReceiverCity, string[] ReceiverAdress, string[] ReceiverPostCode, string[] SenderName, string[] SenderPhone, string[] SenderAdress,  string[] PayWay, double[] Weight, double[] GoodValue, string[] GoodsType, string[] GoodRemark, int[] totalParcel)
        {
             Random random = new Random();
             filename = "\\pdf\\Create" + DateTime.Now.Second.ToString() + random.Next(1, 1000) + ".pdf";
          
            try
            {
                Document document = new Document();

                co128.ValueFont = new System.Drawing.Font("宋体", 20);

               
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
                PdfWriter.GetInstance(document, fs);

                document.Open();
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
                BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/STFANGSO.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT, 15);

                for (int i = 0; i < n; i++)
                {
                    document.NewPage();
                    System.Drawing.Bitmap imgTemp = co128.GetCodeImage(Ordernum[i], Code128B.Encode.Code128A);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);
                    System.Drawing.Bitmap imgTemp2 = co128.GetCodeImage(Tracknum[i], Code128B.Encode.Code128A);
                    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);


                    PdfPTable table = new PdfPTable(6);

                    table.WidthPercentage = 100;
                    table.TotalWidth = 1200;

                    PdfPCell cell;

                    PdfPTable table1 = new PdfPTable(1);
                  
                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory+"\\images\\EMSLOGO2.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 0;
                    cell.BorderWidth = 0;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("标准快递", new iTextSharp.text.Font(baseFT, 30)));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingTop = 0;
                    cell.PaddingBottom = 0;
                    cell.BorderWidth = 0;

                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("时间: " + DateTime.Now.ToString(), font));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingTop = 0;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;

                    table1.AddCell(cell);
                    cell = new PdfPCell(table1);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (2);
                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    table.AddCell(cell);










                    PdfPTable table2 = new PdfPTable(1);
                    img.ScaleAbsoluteWidth(300);
                    img2.ScaleAbsoluteWidth(300);
                    cell = new PdfPCell(img);

                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 20;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;
                    table2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Ordernum[i]));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.BorderWidthTop = 0;
                    cell.BorderWidth = 0;
                    cell.Padding = 5;
                    //cell.PaddingBottom = 20;
                    table2.AddCell(cell);


                    cell = new PdfPCell(table2);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (4);
                    cell.Padding = 5;
                    cell.BorderWidthLeft = 0;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);






                    cell = new PdfPCell(new Phrase("寄件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(SenderName[i] + " " + SenderPhone[i] + " " + SenderAdress[i], font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (2);
                    cell.BorderWidthLeft = 0;
                    cell.Padding = 5;
                    //cell.PaddingTop = 20;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);

                    cell.FixedHeight = 800;
                    cell = new PdfPCell(new Phrase(ReceiverCity[i], new iTextSharp.text.Font(baseFT, 30)));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);

                    cell.Padding = 5;
                    //cell.PaddingTop = 20;
                    table.AddCell(cell);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;




                    cell = new PdfPCell(new Phrase("收件：", font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    
                    cell.BorderWidthRight = 0;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Phrase(ReceiverName[i] + " " + ReceiverPhone[i] + "\n" + ReceiverAdress[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (5);
                    cell.Padding = 5;
                   
                    cell.BorderWidthLeft = 0;
                    table.AddCell(cell);





                    cell = new PdfPCell(new Phrase("付款方式： "+PayWay[i]+" \n计费重量（KG）：" + Weight[i].ToString() + "\n报价金额（元）：" + GoodValue[i].ToString(), font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);

                    cell.Padding = 5;
                    cell.PaddingTop = 10;
                    cell.PaddingBottom = 0;
                    table.AddCell(cell);



                    cell = new PdfPCell(new Phrase("收件人/代收件人：\n签收时间：       年     月    日\n", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);
                    cell.PaddingTop = 20;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);



                    cell = new PdfPCell(new Phrase("订单号：  \n", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = (1);
                    cell.PaddingTop = 15;
                    table.AddCell(cell);

                    cell = new PdfPCell(img2);
                    cell.BorderWidthBottom = 0;
                    cell.BorderWidthLeft = 0;
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                    cell.Colspan = (5);
                    cell.PaddingTop = 15;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Tracknum[i] + "         件数：" + totalParcel[i] + "          重量（KG）:" + Weight[i].ToString(), font));
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                    cell.Colspan = (6);

                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("配货信息：  \n" + GoodsType[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (6);
                    cell.BorderWidthTop = 0;
                    cell.Padding = 5;
                 
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("                ", font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (6);

                    table.AddCell(cell);

                    PdfPTable table4 = new PdfPTable(1);
                    cell = new PdfPCell(img);
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.PaddingRight = 0;
                    cell.BorderWidth = 0;
                    table4.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Ordernum[i]));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.BorderWidthTop = 0;
                    cell.BorderWidth = 0;
                    cell.Padding = 5;

                    table4.AddCell(cell);


                    cell = new PdfPCell(table4);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (3);
                    cell.Padding = 5;
                    cell.PaddingRight = 15;
                    cell.BorderWidthRight = 0;

                    table.AddCell(cell);


                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory +"\\images\\EMSLOGO2.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (3);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.PaddingLeft = 20;
                    cell.BorderWidthLeft = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("寄件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    cell.PaddingBottom = 20;

                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(SenderName[i] + " " + SenderPhone[i] + "\n" + SenderAdress[i], font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (2);
                    cell.BorderWidthLeft = 0;
                    cell.Padding = 5;

                    cell.PaddingBottom = 10;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("收件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(ReceiverName[i] + " " + ReceiverPhone[i] + " \n" + ReceiverAdress[i] + " " + ReceiverPostCode[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (2);
                    cell.Padding = 5;
                    cell.BorderWidthLeft = 0;
                    cell.PaddingBottom = 10;
                    table.AddCell(cell);








                    PdfPTable table3 = new PdfPTable(1);


                    cell = new PdfPCell(new Phrase("备注：" + GoodRemark[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 20;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;

                    table3.AddCell(cell);
                    cell = new PdfPCell(new Phrase("网址：www.ems.com.cn   客服电话：11183\n", font));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;

                    table3.AddCell(cell);
                    cell.MinimumHeight = 400;
                    cell = new PdfPCell(table3);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (4);

                    cell.PaddingBottom = 5;

                    table.AddCell(cell);


                    cell.MinimumHeight = 400;
                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory +"\\images\\erweima.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (2);
                    cell.BorderWidthTop = 0;

                    cell.Padding = 5;

                    table.AddCell(cell);
                    document.Add(table);
                }

                document.Close();


               

            }




            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);

            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);

            }



        }








        public PdfPrint(int n, string Ordernum, string[] Tracknum, string ReceiverName, string ReceiverPhone, string ReceiverAdress, string ReceiverCity, string ReceiverPostCode, string SenderName, string SenderPhone, string SenderAdress, string PayWay, double[] Weight, double[] GoodValue, string[] GoodsType, string[] GoodRemark, int[] totalParcel)
        {
            Random random = new Random();
            filename = "\\pdf\\Create" + DateTime.Now.Second.ToString() + random.Next(1, 1000) + ".pdf";

            try
            {
                Document document = new Document();

                co128.ValueFont = new System.Drawing.Font("宋体", 20);


                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
                PdfWriter.GetInstance(document, fs);

                document.Open();
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
                iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
                BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/STFANGSO.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT, 15);
                System.Drawing.Bitmap imgTemp = co128.GetCodeImage(Ordernum, Code128B.Encode.Code128A);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);

                for (int i = 0; i < n; i++)
                {
                    document.NewPage();
                      System.Drawing.Bitmap imgTemp2 = co128.GetCodeImage(Tracknum[i], Code128B.Encode.Code128A);
                    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp2, iTextSharp.text.BaseColor.WHITE);


                    PdfPTable table = new PdfPTable(6);

                    table.WidthPercentage = 100;
                    table.TotalWidth = 1200;

                    PdfPCell cell;

                    PdfPTable table1 = new PdfPTable(1);
                    
                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\EMSLOGO2.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 0;
                    cell.BorderWidth = 0;
                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("标准快递", new iTextSharp.text.Font(baseFT, 30)));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingTop = 0;
                    cell.PaddingBottom = 0;
                    cell.BorderWidth = 0;

                    table1.AddCell(cell);
                    cell = new PdfPCell(new Phrase("时间: " + DateTime.Now.ToString(), font));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingTop = 0;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;

                    table1.AddCell(cell);
                    cell = new PdfPCell(table1);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (2);
                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    table.AddCell(cell);










                    PdfPTable table2 = new PdfPTable(1);
                    img.ScaleAbsoluteWidth(300);
                    img2.ScaleAbsoluteWidth(300);
                    cell = new PdfPCell(img);

                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 20;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;
                    table2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Ordernum));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.BorderWidthTop = 0;
                    cell.BorderWidth = 0;
                    cell.Padding = 5;
                    //cell.PaddingBottom = 20;
                    table2.AddCell(cell);


                    cell = new PdfPCell(table2);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (4);
                    cell.Padding = 5;
                    cell.BorderWidthLeft = 0;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);






                    cell = new PdfPCell(new Phrase("寄件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(SenderName + " " + SenderPhone + " " + SenderAdress, font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (2);
                    cell.BorderWidthLeft = 0;
                    cell.Padding = 5;
                    //cell.PaddingTop = 20;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);

                    cell.FixedHeight = 800;
                    cell = new PdfPCell(new Phrase(ReceiverCity, new iTextSharp.text.Font(baseFT, 30)));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);

                    cell.Padding = 5;
                    //cell.PaddingTop = 20;
                    table.AddCell(cell);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;




                    cell = new PdfPCell(new Phrase("收件：", font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    
                    cell.BorderWidthRight = 0;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Phrase(ReceiverName + " " + ReceiverPhone + "\n" + ReceiverAdress, font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (5);
                    cell.Padding = 5;
                   
                    cell.BorderWidthLeft = 0;
                    table.AddCell(cell);





                    cell = new PdfPCell(new Phrase("付款方式： " + PayWay + " \n计费重量（KG）：" + Weight[i].ToString() + "\n报价金额（元）：" + GoodValue[i].ToString(), font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);

                    cell.Padding = 5;
                    cell.PaddingTop = 10;
                    cell.PaddingBottom = 0;
                    table.AddCell(cell);



                    cell = new PdfPCell(new Phrase("收件人/代收件人：\n签收时间：       年     月    日\n", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (3);
                    cell.PaddingTop = 20;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);



                    cell = new PdfPCell(new Phrase("订单号：  \n", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.BorderWidthRight = 0;
                    cell.BorderWidthBottom = 0;
                    cell.Colspan = (1);
                    cell.PaddingTop = 15;
                    table.AddCell(cell);

                    cell = new PdfPCell(img2);
                    cell.BorderWidthBottom = 0;
                    cell.BorderWidthLeft = 0;
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                    cell.Colspan = (5);
                    cell.PaddingTop = 15;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Tracknum[i] + "         件数：" + totalParcel[i] + "          重量（KG）:" + Weight[i].ToString(), font));
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthBottom = 0;
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);

                    cell.Colspan = (6);

                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("配货信息：  \n" + GoodsType[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (6);
                    cell.BorderWidthTop = 0;
                    cell.Padding = 5;
                   
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("                ", font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (6);

                    table.AddCell(cell);

                    PdfPTable table4 = new PdfPTable(1);
                    cell = new PdfPCell(img);
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.PaddingRight = 0;
                    cell.BorderWidth = 0;
                    table4.AddCell(cell);
                    cell = new PdfPCell(new Phrase(Ordernum));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.BorderWidthTop = 0;
                    cell.BorderWidth = 0;
                    cell.Padding = 5;

                    table4.AddCell(cell);


                    cell = new PdfPCell(table4);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (3);
                    cell.Padding = 5;
                    cell.PaddingRight = 15;
                    cell.BorderWidthRight = 0;

                    table.AddCell(cell);


                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\EMSLOGO2.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (3);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.PaddingLeft = 20;
                    cell.BorderWidthLeft = 0;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("寄件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    cell.PaddingBottom = 20;

                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(SenderName + " " + SenderPhone + "\n" + SenderAdress, font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (2);
                    cell.BorderWidthLeft = 0;
                    cell.Padding = 5;

                    cell.PaddingBottom = 10;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("收件：", font));

                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);

                    cell.Colspan = (1);

                    cell.Padding = 5;
                    cell.BorderWidthRight = 0;
                    cell.PaddingBottom = 20;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(ReceiverName + " " + ReceiverPhone + " \n" + ReceiverAdress + " " + ReceiverPostCode, font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (2);
                    cell.Padding = 5;
                    cell.BorderWidthLeft = 0;
                    cell.PaddingBottom = 10;
                    table.AddCell(cell);








                    PdfPTable table3 = new PdfPTable(1);


                    cell = new PdfPCell(new Phrase("备注：" + GoodRemark[i], font));
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 20;
                    cell.BorderWidthTop = 0;
                    cell.BorderWidthLeft = 0;
                    cell.BorderWidthRight = 0;

                    table3.AddCell(cell);
                    cell = new PdfPCell(new Phrase("网址：www.ems.com.cn   客服电话：11183\n", font));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (1);
                    cell.Padding = 5;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;

                    table3.AddCell(cell);
                    cell.MinimumHeight = 400;
                    cell = new PdfPCell(table3);
                    cell.HorizontalAlignment = (Element.ALIGN_LEFT);
                    cell.Colspan = (4);

                    cell.PaddingBottom = 5;

                    table.AddCell(cell);


                    cell.MinimumHeight = 400;
                    cell = new PdfPCell(iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "\\images\\erweima.png"));
                    cell.HorizontalAlignment = (Element.ALIGN_CENTER);
                    cell.Colspan = (2);
                    cell.BorderWidthTop = 0;

                    cell.Padding = 5;

                    table.AddCell(cell);
                    document.Add(table);
                }

                document.Close();




            }




            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);

            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);

            }



        }


        public PdfPrint(string OrderNumber, int trackcount, string[] tracknumber, string[] recipientcompanyname, string[] recipientcontactname, string[] recipientphone, string[] recipientaddressline, string[] recipienttown, string[] recipientpostcode, string[] recipientcountry, string[] sendercompanyname, string[] sendercontactname, string[] senderphone, string[] senderaddressline, string[] sendertown, string[] senderpostcode, string[] sendercountry, string[] shippingdate, string[] shipmentpurpose, string[] packagedescription, string[] weight)
        {
            Random random = new Random();
            filename = "\\pdf\\Create" + DateTime.Now.Second.ToString() + random.Next(1, 1000) + ".pdf";
            Document document = new Document();
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + filename, FileMode.Create);
            PdfWriter.GetInstance(document, fs);

            document.Open();
            document.NewPage();
            iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
            iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
            BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/STFANGSO.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT, 15);
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            PdfPCell cell;
            cell = new PdfPCell(new Phrase("OrderNumber/订单号："+OrderNumber,new iTextSharp.text.Font(baseFT, 30)));
            cell.PaddingBottom = 10;
            cell.Colspan = 2;
            cell.HorizontalAlignment=Element.ALIGN_CENTER;
            table.AddCell(cell);
            
            for (int i = 0; i < trackcount; i++)
            {

                PdfPTable table1 = new PdfPTable(1);
                cell = new PdfPCell(new Phrase("TrackNumber/跟踪号：   "+tracknumber[i],font));
                cell.PaddingBottom = 5;
                cell.HorizontalAlignment=Element.ALIGN_CENTER;
                cell.Colspan = 2;
                cell.BorderWidthBottom = 0;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("From:"));
                cell.PaddingBottom = 5;
                cell.BorderWidthTop = 0;
                cell.BorderWidthBottom = 0;
                cell.BorderWidthRight = 0;
                cell.Colspan = 1;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("To:"));
                cell.PaddingBottom = 5;
                cell.BorderWidthTop = 0;
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.Colspan = 1;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(sendercompanyname[i] + "   " + sendercontactname[i] + "    " + senderphone[i] + "     " + senderaddressline[i] + "     "+sendertown[i]+"     " + senderpostcode[i] + "     " + sendercountry[i] , font));
                cell.Colspan = 1;
                table1.AddCell(cell);
                cell = new PdfPCell(table1);
                cell.PaddingLeft = 20;
                cell.PaddingBottom = 0;
                cell.PaddingRight = 20;
                cell.PaddingTop = 10;
                cell.BorderWidthTop = 0;
                cell.BorderWidthBottom = 0;
                cell.BorderWidthRight = 0;
                cell.Colspan = 1;
                table.AddCell(cell);
                 table1 = new PdfPTable(1);
                cell = new PdfPCell(new Phrase(recipientcompanyname[i] + "   " + recipientcontactname[i] + "    " + recipientphone[i] + "     " + recipientaddressline[i] + "     " +recipienttown[i]+"        "+ recipientpostcode[i] + "     " + recipientcountry[i] , font));
                cell.Colspan = 1;
                table1.AddCell(cell);
                cell = new PdfPCell(table1);
                cell.PaddingLeft = 20;
                cell.PaddingBottom = 0;
                cell.PaddingRight = 20;
                cell.PaddingTop = 10;
                cell.BorderWidthTop = 0;
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                cell.Colspan = 1;
                table.AddCell(cell);
                 table1 = new PdfPTable(1);
                cell = new PdfPCell(new Phrase("\nDate/日期:   " + shippingdate[i] + "\nPurpose/目的：  " + shipmentpurpose[i] + "\nDescription/描述：  " + packagedescription[i] + "\nWeight/重量：  " + weight[i],font));
                cell.Colspan = 2;
                cell.BorderWidthTop = 0;
                cell.PaddingTop = 0;
                cell.PaddingBottom = 5;
                table.AddCell(cell);
            }
            document.Add(table);
            document.Close();
            fs.Close();
        }



        public void DownPdf()
        {
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Create.pdf");

            HttpContext.Current.Response.WriteFile(AppDomain.CurrentDomain.BaseDirectory + filename);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
        }

        public void ShowPdf()
        {
            HttpContext.Current.Response.Clear();
           
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;FileName=out.pdf");
            HttpContext.Current.Response.WriteFile(filename);
            HttpContext.Current.Response.OutputStream.Flush();

        }
    }
}