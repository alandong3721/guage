using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

using WM_Project.control;
using WM_Project.logical.common;



namespace WM_Project.manage_system
{
    public partial class order_detail_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string order_number = Request.QueryString["order_number"];
            string info = Request.QueryString["type"];
            if (order_number != null)
            {

                AutoOrder autoorder = new AutoOrderDAO().getAutoOrder(order_number);
                ArrayList auto_orderlist_array = new AutoOrderListDAO().getAutoOrderListArray(autoorder.Auto_no);
                int ordercount = autoorder.Order_count;
                string[] pdflist = new string[ordercount];
                for (int ii = 0; ii < ordercount; ii++)
                {
                    AutoOrderList autoorderlist = (AutoOrderList)auto_orderlist_array[ii];
                    string tracknumber = autoorderlist.Order_no;
                    pdflist[ii] = Server.MapPath("\\views\\pdf\\" + tracknumber  + "2.pdf");
                }
                mergePDFFiles(pdflist, Server.MapPath("\\views\\pdf\\" + order_number + "2.pdf"));
                string filename = Server.MapPath("\\views\\pdf\\" + order_number + "2.pdf");
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + order_number + ".pdf");

                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();

                
            }
            if (info != null)
            {
                if (order_number != null)
                {
                    Order order = new OrderDAO().getOrder(order_number);

                    string parentPath = Server.MapPath("");
                    string filename = order.Order_number + ".pdf";
                    string path = parentPath + "/pdf/" + filename;

                    generatePDF(order, path);

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    //如果是在网页中显示
                    if (info == "detail")
                    {
                        //在网页中显示
                        HttpContext.Current.Response.ContentType = "application/PDF";
                        HttpContext.Current.Response.AddHeader("content-disposition", "filename=" + filename);
                    }
                    else
                    {
                        //以下载的形式展现
                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                    }

                    HttpContext.Current.Response.WriteFile(path);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();

                }

            }
            else
            {
                if (Session["orders"] != null)
                {
                    ArrayList orders = (ArrayList)Session["orders"];

                    string parentPath = Server.MapPath("");
                    string filename = "all_orders.pdf";
                    string path = parentPath + "/pdf/" + filename;

                    generatePDF(orders, path);

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    //如果是在网页中显示


                    //以下载的形式展现
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename);

                    HttpContext.Current.Response.WriteFile(path);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();
                }
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
            // document.SetPageSize(new Rectangle(595, 421));
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

        protected void generatePDF(Order order, string path)
        {
            try
            {
                Document document = new Document();

                PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font fontChinese = new Font(bfChinese, 12, Font.NORMAL, new BaseColor(0, 0, 0));

                string content = "";

                content = "订单号：" + order.Order_number + "\n商品类型：未知" + "\n发件地址：" + order.CollectionAddressLine + "\n收件地址：" + order.RecipientAddressLine;
                //按设置的字体输出文本
                document.Add(new Paragraph(content, fontChinese));
               

                document.Close();
                
            }
            catch (DocumentException de)
            {
                Response.Write(de.ToString());
            }
        }


        protected void generatePDF(ArrayList orders, string path)
        {
            try
            {
                Document document = new Document();

                PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font fontChinese = new Font(bfChinese, 12, Font.NORMAL, new BaseColor(0, 0, 0));

                string content = "";

                //content = "订单号：" + order.Order_number + "\n商品类型：" + order.Good_name + "\n发件地址：" + order.Send_address + "\n收件地址：" + order.Receive_address;
                //按设置的字体输出文本
                //document.Add(new Paragraph(content, fontChinese));
                for (int i = 0; i < orders.Count; i++)
                {

                    Order order = (Order)orders[i];
                    content += "\n订单号：" + order.Order_number + "\n商品类型：未知" + "\n发件地址：" + order.CollectionAddressLine + "\n收件地址：" + order.RecipientAddressLine + "\r\n";

                }

                //按设置的字体输出文本
                document.Add(new Paragraph(content, fontChinese));
                document.Close();

            }
            catch (DocumentException de)
            {
                Response.Write(de.ToString());
            }
        }
    }
}