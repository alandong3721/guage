﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Data;
using System.ServiceModel;
using System.IO;

using WM_Project.logical.common;
using WM_Project.control;

using iTextSharp.text.pdf;
using iTextSharp.text;

namespace WM_Project.views.inter_express
{
    public partial class order_label : System.Web.UI.Page
    {
        public ArrayList pay_orders = new ArrayList();
        protected ArrayList down_orders = new ArrayList();
        public string name = "";
        public int un_download = 0;
        public string alertMsg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["name"] == null || Session["local_order"] == null)
                {
                    Response.Redirect("../user-login.aspx");
                }
                else
                {

                    name = Session["name"].ToString();

                    pay_orders = (ArrayList)Session["local_order"];

                    bar_code.DataSource = createBarCodeTable(pay_orders);
                    bar_code.DataBind();
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

                string filename = Server.MapPath("") + "\\pdf\\" + Ordernum + "2.pdf";

                HttpContext.Current.Response.Clear();

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;FileName=out.pdf");
                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.OutputStream.Flush();

            }
            else if (e.CommandName.ToString().Equals("PrintByDownload"))
            {

                string Ordernum = e.CommandArgument.ToString();

                string filename = Server.MapPath("~/views") + "\\pdf\\local\\" + Ordernum + ".pdf";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + Ordernum + ".pdf");

                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();


            }
        }

        private DataTable createBarCodeTable(ArrayList order_numbers)
        {
            DataTable table = new DataTable();
            un_download = 0;

            down_orders.Clear();
            //订单号
            DataColumn dc = new DataColumn("order_number", typeof(string));
            table.Columns.Add(dc);

            dc = new DataColumn("local_order", typeof(string));
            table.Columns.Add(dc);
            //包裹个数
            dc = new DataColumn("weight", typeof(float));
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


            for (int i = 0; i < order_numbers.Count; i++)
            {
                string order_number = order_numbers[i].ToString();

                LocalOrder localorder = new LocalOrderDAO().getLocalOrder(order_number);

                ArrayList packageArray = new LocalPackageDAO().getLocalPackageByOrderNo(order_number);

                //if (localorder.Servicecode == "UKMail")
                //{
                    for (int j = 0; j < packageArray.Count; j++)
                    {
                        LocalPackage package = (LocalPackage)packageArray[i];

                        DataRow dr = table.NewRow();
                        dr["order_number"] = package.Ea_track_no;
                        dr["local_order"] = package.Local_track;
                        dr["weight"] = package.Weight;
                        dr["sender"] = localorder.Collectioncontactname;
                        dr["receiver"] = localorder.Recipientcontactname;
                        dr["postway"] = package.Servicecode;
                        dr["pay"] = package.Pay_after_discount;
                        dr["time"] = localorder.Pay_time;

                        table.Rows.Add(dr);
                    }
                //}
                //else if (localorder.Servicecode == "CollectionPlus")
                //{
                    //for (int j = 0; j < packageArray.Count; j++)
                    //{
                    //    LocalPackage package = (LocalPackage)packageArray[i];

                    //    DataRow dr = table.NewRow();
                    //    dr["order_number"] = package.Ea_track_no;
                    //    dr["local_track"] = "localtrack";
                    //    dr["weight"] = package.Weight;
                    //    dr["sender"] = localorder.Collectioncontactname;
                    //    dr["receiver"] = localorder.Recipientcontactname;
                    //    dr["postway"] = package.Servicecode;
                    //    dr["pay"] = package.Pay_after_discount;
                    //    dr["time"] = localorder.Pay_time;

                    //    table.Rows.Add(dr);
                    //}
                //}

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
            ArrayList all_orders = (ArrayList)Session["all_orders"];

            string[] pdflist = new string[all_orders.Count];

            for (int jj = 0; jj < all_orders.Count; jj++)
            {
                pdflist[jj] = Server.MapPath("\\views\\pdf\\" + all_orders[jj] + "2.pdf");
            }

            mergePDFFiles(pdflist, Server.MapPath("\\views\\pdf\\" + all_orders[0] + "9.pdf"));
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=AllOrder.pdf");

            HttpContext.Current.Response.WriteFile(Server.MapPath("\\views\\pdf\\" + all_orders[0] + "9.pdf"));

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();

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

        //////////////////////////////////////////////////////////////////////////
        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


    }
}