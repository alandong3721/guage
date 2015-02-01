using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;

using iTextSharp.text.pdf;
using iTextSharp.text;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.views.user_frame
{
    public partial class check_order_by_number : System.Web.UI.Page
    {
        public static string message = "";
        public static ArrayList pay_orders = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["name"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
            }
        }

        //按订单号查找
        protected void btn_check_by_order_Click(object sender, EventArgs e)
        {
            string order_no = Request.Form["order_number"];
            if (order_no != null)
            {
                order_no = order_no.Trim();
            }
            ArrayList temp = new AutoOrderListDAO().getPayAutoOrderList(order_no);

            if (temp.Count > 0)
            {
                has_orders.Visible = true;
                no_orders.Visible = false;
                bar_code.DataSource = createBarCodeTable(temp);
                bar_code.DataBind();
            }
            else
            {
                has_orders.Visible = false;
                no_orders.Visible = true;
                message = "没有找到与该订单号对应的订单信息!!";
            }


        }


        protected void bar_code_ItemCommand(object source, DataListCommandEventArgs e)
        {


            //如果是修改地址
            if (e.CommandName.ToString().Equals("PrintInWeb"))
            {
                /************************************************************************/
                /*               弹出浮动窗口供用户修改所选中的信息                     */
                /************************************************************************/

                string Ordernum = e.CommandArgument.ToString();

                string filename = Server.MapPath("~") + "views\\pdf\\" + Ordernum + "2.pdf";

                HttpContext.Current.Response.Clear();

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;FileName=out.pdf");
                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.OutputStream.Flush();


            }
            else if (e.CommandName.ToString().Equals("PrintByDownload"))
            {


                string Ordernum = e.CommandArgument.ToString();

                string filename = Server.MapPath("~") + "views\\pdf\\" + Ordernum + "2.pdf";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Create.pdf");

                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();


            }
        }

        private DataTable createBarCodeTable(ArrayList orders)
        {
            DataTable table = new DataTable();

            //订单号
            DataColumn dc = new DataColumn("order_number", typeof(string));
            table.Columns.Add(dc);

            //包裹个数
            dc = new DataColumn("quantity", typeof(int));
            table.Columns.Add(dc);

            //发件人
            dc = new DataColumn("sender", typeof(string));
            table.Columns.Add(dc);

            //收件人
            dc = new DataColumn("receiver", typeof(string));
            table.Columns.Add(dc);

            //服务方式
            dc = new DataColumn("postway", typeof(string));
            table.Columns.Add(dc);

            //付款金额
            dc = new DataColumn("pay", typeof(string));
            table.Columns.Add(dc);

            //下单时间
            dc = new DataColumn("time", typeof(string));
            table.Columns.Add(dc);


            for (int i = 0; i < orders.Count; i++)
            {
                AutoOrderList order = (AutoOrderList)orders[i];

                DataRow dr = table.NewRow();
                dr["order_number"] = order.Order_no;
                dr["quantity"] = 1;
                dr["sender"] = order.CollectionContactName;
                dr["receiver"] = order.RecipientContactName;
                dr["postway"] = order.ServiceCode;
                dr["pay"] = order.Pay_after_discount;
                dr["time"] = order.Pay_time;

                table.Rows.Add(dr);

            }

            return table;
        }


        /// <summary>
        /// 下载所有的PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_downAll_Click(object sender, EventArgs e)
        {
            string[] pdflist = new string[pay_orders.Count];
            for (int jj = 0; jj < pay_orders.Count; jj++)
            {
                pdflist[jj] = Server.MapPath("~") + "views\\pdf\\" + ((AutoOrderList)pay_orders[jj]).Order_no + "2.pdf";
            }
            mergePDFFiles(pdflist, Server.MapPath("~") + "views\\pdf\\" + ((AutoOrderList)pay_orders[0]).Order_no + "3.pdf");
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Create.pdf");

            HttpContext.Current.Response.WriteFile(Server.MapPath("~") + "views\\pdf\\" + ((AutoOrderList)pay_orders[0]).Order_no + "2.pdf");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();

        }


        private void mergePDFFiles(string[] fileList, string outMergeFile)
        {

            // outMergeFile = Server.MapPath(outMergeFile);

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

        //////////////////////////////////////////////////////////////////////////
        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}