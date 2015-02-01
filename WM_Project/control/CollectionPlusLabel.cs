using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WM_Project.control;

namespace CollectionPlus
{
    class CollectionPlusLabel
    {

        private string ClientBarcodeNumber;//第一项，头部二维码，应该是给出的
        private string ReturnsCentreName;
        private string ReturnsCentreAddress1;
        private string ReturnsCentreAddress2;
        private string ReturnsCentreAddress3;
        private string ReturnsCentreAddress4;
        private string ReturnsCentrePostcode;
        private string RoutDepotNumber = "25";
        private string RoutDepotName = "SAND";
        private string LabelDate;
        private string ReturnsReference;
        private string BarcodeNumber;
        private string ClientName;
        //public CollectionPlusLabel(string Clientname, string TACSequnceNumber,string ReturnsCentreName,string ReturnsCentrePostcode,string ReturnsCentreAddress1,string ReturnsCentreAddress2,string ReturnsCentreAddress3,string ReturnsCentreAddress4,string ReturnsReference,string LabelDate)
        //{
        //    this.ClientBarcodeNumber = "ClientBarcodeNumber".ToUpper();
        //    this.ClientName = Clientname;
        //    this.ReturnsCentreName = ReturnsCentreName;
        //    this.ReturnsCentrePostcode = ReturnsCentrePostcode;
        //    this.ReturnsCentreAddress1 = ReturnsCentreAddress1;
        //    this.ReturnsCentreAddress2 = ReturnsCentreAddress2;
        //    this.ReturnsCentreAddress3 = ReturnsCentreAddress3;
        //    this.ReturnsCentreAddress4 = ReturnsCentreAddress4;
        //    this.ReturnsReference = ReturnsReference;
        //    this.LabelDate = LabelDate;
        //    BarCode b = new BarCode(TACSequnceNumber);
        //    this.BarcodeNumber = b.getBarcodeString();
        //}

        public CollectionPlusLabel(string Clientname,string TACSequnceNumber,string ReturnsReference, string LabelDate)
        {
            this.ClientName = Clientname;
            this.ReturnsReference = ReturnsReference;
            this.LabelDate = LabelDate;
            BarCode b = new BarCode(TACSequnceNumber);
            this.BarcodeNumber = b.getBarcodeString();            
        }
        public void makeCollectionPlusLabel(string filepath)
        {
           
            Document document = new Document();
            FileStream fs = new FileStream(filepath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.SetPageSize(new Rectangle(358, 418));//1/0.9  288, 437
            document.Open();
            document.NewPage();
            iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsian"));
            iTextSharp.text.io.StreamUtil.AddToResourceSearch(Assembly.Load("iTextAsianCmaps"));
            BaseFont baseFT = BaseFont.CreateFont("C:/WINDOWS/Fonts/Arial.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            Font arial = FontFactory.GetFont("Arial");

           //BaseFont baseFT = BaseFont.CreateFont(BaseFont.TIMES_ROMAN,BaseFont.CP1252, false);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFT, 15);
            
            //大的table
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            table.TotalWidth = 286; //101mm 

            //code128 client
            //Code128B co128 = new Code128B();
            ////co128.ValueFont = new System.Drawing.Font("宋体", 20);
            //System.Drawing.Bitmap imgTemp = co128.GetCodeImage(this.ClientBarcodeNumber, Code128B.Encode.Code128A);//Code128S传入,不能有“|”???
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)imgTemp, iTextSharp.text.BaseColor.WHITE);

            PdfPCell cell;
            //PdfPTable code128Table = new PdfPTable(1);
            ////code128Table.TotalWidth = 286;
            //////img.ScalePercent(70f);
            //img.ScaleAbsoluteHeight(28f);//10mm
            //img.ScaleAbsoluteWidth(193);//68mm
            //cell = new PdfPCell(img);
            //cell.BorderWidthBottom = 0;
            //cell.BorderWidthTop = 0;
            //cell.BorderWidthRight = 0;
            //cell.BorderWidthLeft = 0;
            //cell.Colspan = 1;
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //code128Table.AddCell(cell);



            //cell = new PdfPCell(new Phrase(this.ClientBarcodeNumber.ToUpper(), new Font(baseFT, 10)));
            //cell.BorderWidthTop = 0;
            //cell.BorderWidthBottom = 0;
            //cell.BorderWidthLeft = 0;
            //cell.BorderWidthRight = 0;
            //cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell.PaddingTop = 2f;
            //cell.FixedHeight = 21f;//总高度8mm            
            //code128Table.AddCell(cell);

            //cell = new PdfPCell(code128Table);
            ////cell.BorderWidthLeft = 0;
            ////cell.BorderWidthTop = 0;
            ////cell.BorderWidthBottom = 0;
            ////cell.BorderWidthRight = 0;
            //cell.PaddingTop = 15;
            //cell.FixedHeight = 70f;//总的高度为 mm

            //table.AddCell(cell);
            ////128 client二维码部分完成
            //Console.WriteLine("128二维码部分完成");

            //第二部分 clientName那一行
            PdfPTable table2 = new PdfPTable(2);
            table2.SetWidths(new int[] { 70, 30 });   
            Phrase phrase = new Phrase(this.ClientName, new Font(baseFT, 15, Font.BOLD));
            cell = new PdfPCell(phrase);
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthRight = 0;
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.PaddingTop = 8;
            cell.PaddingLeft = 5;
            table2.AddCell(cell);

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\image\\images\\collect_plus_logo.png";
            //Console.WriteLine(path);
            Image collect_plus_logo = Image.GetInstance(path);
            collect_plus_logo.ScaleAbsoluteHeight(30f);
            collect_plus_logo.ScaleAbsoluteWidth(75f);
            cell = new PdfPCell(collect_plus_logo);
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthRight = 0;
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.PaddingTop = 0;
            cell.PaddingBottom = 3;
            table2.AddCell(cell);
            table.AddCell(table2);

            PdfPTable table3 = new PdfPTable(2);
            table3.SetWidths(new int[] { 40, 60 });    // 设置各列宽度，单位是百分比
            PdfPTable tableLeft = new PdfPTable(1);
            PdfPTable tableRight = new PdfPTable(1);
            
            Chunk chunk1 = new Chunk("Depot\n", new Font(baseFT, 10));
            Chunk chunk2 = new Chunk(this.RoutDepotNumber+" "+this.RoutDepotName, new Font(baseFT, 15, Font.BOLD));
            Chunk chunk3;
            Chunk chunk4;
            Chunk chunk5;
            Chunk chunk6;

            phrase = new Phrase();
            phrase.Add(chunk1);           
            phrase.Add(chunk2);
            cell = new PdfPCell(phrase);
            cell.PaddingBottom = 10;
            tableLeft.AddCell(cell);

            chunk1 = new Chunk("Label Date\n", new Font(baseFT, 10));           
            chunk2 = new Chunk(this.LabelDate, new Font(baseFT, 15, Font.BOLD));
            phrase = new Phrase();
            phrase.Add(chunk1);          
            phrase.Add(chunk2);
            cell = new PdfPCell(phrase);
            cell.PaddingBottom = 5;
            tableLeft.AddCell(cell);

            chunk1 = new Chunk("Returns Reference\n", new Font(baseFT, 10));           
            chunk2 = new Chunk(this.ReturnsReference, new Font(baseFT, 15, Font.BOLD));
            phrase = new Phrase();
            phrase.Add(chunk1);          
            phrase.Add(chunk2);
            cell = new PdfPCell(phrase);
            cell.PaddingBottom = 5;
            tableLeft.AddCell(cell);
           

            chunk1 = new Chunk("Lydia\n".ToUpper(), new Font(baseFT, 10));           
            chunk2 = new Chunk("The Old Bus Garage\n".ToUpper(), new Font(baseFT, 10));
            chunk3 = new Chunk("Harborne Lane\n".ToUpper(), new Font(baseFT, 10));
            chunk4 = new Chunk("Selly Oak\n".ToUpper(), new Font(baseFT, 10));
            chunk5 = new Chunk("Birmingham\n".ToUpper(), new Font(baseFT, 10));
            chunk6 = new Chunk("B29 6SN", new Font(baseFT, 20, Font.BOLD));
            phrase = new Phrase();
            phrase.Add(chunk1);
            phrase.Add(Chunk.NEWLINE.setLineHeight(3));
            phrase.Add(chunk2);
            phrase.Add(Chunk.NEWLINE.setLineHeight(3));
            phrase.Add(chunk3);
            phrase.Add(Chunk.NEWLINE.setLineHeight(3));
            phrase.Add(chunk4);
            phrase.Add(Chunk.NEWLINE.setLineHeight(3));
            phrase.Add(chunk5);         
            phrase.Add(chunk6);
            cell = new PdfPCell(phrase);
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            tableRight.AddCell(cell);


            //去除边框
            cell = new PdfPCell(tableLeft);
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            table3.AddCell(cell);

            cell = new PdfPCell(tableRight);
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            table3.AddCell(cell);

            cell = new PdfPCell(table3);
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            //第三大行完成
            table.AddCell(cell);

            //第四行 Storekeeper Instruction
            PdfPTable table4 = new PdfPTable(1);
            chunk1 = new Chunk("Storekeeper Instruction\n", new Font(baseFT, 8, Font.BOLD));           
            chunk2 = new Chunk("GIVE TO THE DRIVER", new Font(baseFT, 15, Font.BOLD));
            phrase = new Phrase();
            phrase.Add(chunk1);
            phrase.Add(Chunk.NEWLINE.setLineHeight(5));
            phrase.Add(chunk2);
            cell = new PdfPCell(phrase);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            cell.PaddingTop = 3;
            cell.PaddingBottom = 10;
            table4.AddCell(cell);
            table.AddCell(table4);

            //第五行，二维码部分
            //第五行，头一行文字
            PdfPTable table5 = new PdfPTable(1);
            phrase = new Phrase("COLLECTION+ BARCODE BELOW", new Font(baseFT, 12, Font.BOLD));
            cell = new PdfPCell(phrase);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 15;
            table5.AddCell(cell);

             //第五部分collectBarcode
            Code128B collectBarcode = new Code128B();
            //co128.ValueFont = new System.Drawing.Font("宋体", 20);
            System.Drawing.Bitmap imgCollectBarcode = collectBarcode.GetCodeImage(this.BarcodeNumber, Code128B.Encode.Code128A);//Code128S传入,不能有“|”???
            
            iTextSharp.text.Image imgcollectBarcode = iTextSharp.text.Image.GetInstance(imgCollectBarcode, iTextSharp.text.BaseColor.WHITE);
            imgcollectBarcode.ScaleAbsoluteHeight(77f);//27mm
            imgcollectBarcode.ScaleAbsoluteWidth(199f);//70.2mm
            cell = new PdfPCell(imgcollectBarcode);
            cell.BorderWidthBottom = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthRight = 0;
            cell.BorderWidthLeft = 0;
            cell.Colspan = 1;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table5.AddCell(cell);

            //第五部分CodeString
            this.BarcodeNumber = this.BarcodeNumber.Replace("0", "Ø");
            phrase = new Phrase(this.BarcodeNumber, new Font(baseFT, 15, Font.BOLD));//"883KØØØØ7116AØ51"
            cell = new PdfPCell(phrase);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BorderWidthLeft = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthRight = 0;
            cell.PaddingTop = 10;
            cell.PaddingBottom = 10;
            table5.AddCell(cell);

            table.AddCell(table5);

            document.Add(table);
            document.Close();
            Console.WriteLine("全部完成");
        }
        static void Main(string[] args)
        {
            //需要传入的参数有
            //ClientName:如：SanFeng Zhang，后面无-WM，SanFeng Zhang-WM是错误的
            //SequenceNumber：范围10000000 到89999999，递增
            //Labeldate：格式严格为dd/mm/yyyy
            CollectionPlusLabel collectionplus = new CollectionPlusLabel("SanFeng Zhang", "10000001", "", "06/01/2015");
            collectionplus.makeCollectionPlusLabel("D:\\CollectionPlus.pdf");
            Console.ReadLine();
        }
    }
}
