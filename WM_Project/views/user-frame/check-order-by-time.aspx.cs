using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.IO;

using iTextSharp.text.pdf;
using iTextSharp.text;

using WM_Project.logical.common;
using WM_Project.control;

namespace WM_Project.views.user_frame
{
    public partial class check_order_by_time : System.Web.UI.Page
    {
      
        public static ArrayList pay_orders = new ArrayList();

        public static int pageSize = 20;
        public static int record_count = 0;
        public static int pageNow = 1;
        public static int page_count = 0;

        public static string start_time = "";
        public static string end_time = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                if (Session["name"] == null)
                {
                    Response.Redirect("../views/user-login.aspx");
                }
                else
                {
                    record_count = new AutoOrderListDAO().getAutoOrderListRecordCount(Session["name"].ToString(), "paied", "label");
                    page_count = new AutoOrderListDAO().getPageCount(record_count, pageSize);

                    string page_now = Request.QueryString["pageNow"];

                    if (page_now != null)
                    {
                        pageNow = Convert.ToInt32(page_now);
                        pay_orders = new AutoOrderListDAO().getAutoOrderListArray(Session["name"].ToString(), "paied", pageNow, pageSize, "haslabel");

                    }
                    else
                    {
                        pageNow = 1;
                        record_count = new AutoOrderListDAO().getAutoOrderListRecordCount(Session["name"].ToString(), "paied", "haslabel");
                        page_count = new AutoOrderListDAO().getPageCount(record_count, pageSize);
                        pay_orders = new AutoOrderListDAO().getAutoOrderListArray(Session["name"].ToString(), "paied", pageNow, pageSize, "haslabel");

                    }

                    if (pay_orders.Count > 0)
                    {
                        has_orders.Visible = true;
                        has_no_orders.Visible = false;
                        bar_code.DataSource = createBarCodeTable(pay_orders);
                        bar_code.DataBind();
                    }
                    else
                    {
                        has_orders.Visible = false;
                        has_no_orders.Visible = true;
                    }

                }

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

        //protected void btn_check_by_time_Click(object sender, EventArgs e)
        //{
        //    start_time = txt_from.Text.ToString();
        //    end_time = txt_to.Text.ToString();

        //    int i = end_time.CompareTo(start_time);

        //    if (start_time == "" || end_time == "")
        //    {
        //        alert("请选择所查询的时间段");
        //        return;
        //    }
        //    else if (end_time.CompareTo(start_time) != 1)
        //    {
        //        alert("起始时间不能大于等于终止时间!!");
        //        return;
        //    }
        //    else
        //    {
        //        pageNow = 1;
        //        DataTable temp = new AutoOrderListDAO().getInnerAutoOrderList(Session["name"].ToString(), start_time, end_time, pageNow, pageSize);

        //        if (temp.Rows.Count > 0)
        //        {
        //            has_local_order.Visible = true;
        //            no_local_order.Visible = false;
        //            local_datalist.DataSource = createTable(temp);
        //            local_datalist.DataBind();
        //        }
        //        else
        //        {
        //            has_local_order.Visible = false;
        //            no_local_order.Visible = true;
        //            message = "没有找到该时间段内的订单!!";
        //        }

        //    }
        //}
    }
}