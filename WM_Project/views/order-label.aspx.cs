using System;
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

namespace WM_Project.views
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

                if (Session["name"] == null || Session["AllOrderMsg"] == null)
                {
                    Response.Redirect("../views/user-login.aspx");
                }
                else
                {
                    if (Session["alertMsg"] != null)
                    {
                        alertMsg = Session["alertMsg"].ToString();
                        alert(alertMsg);
                        Session["alertMsg"] = null;
                    }
                    name = Session["name"].ToString();

                    pay_orders = (ArrayList)Session["AllOrderMsg"];


                    bar_code.DataSource = createBarCodeTable(pay_orders);
                    bar_code.DataBind();

                    //初始化DataList中的按钮事件
                    initButtonClick(bar_code);

                    if (un_download != 0 && un_download != pay_orders.Count)
                    {
                        notice_undownload.Visible = true;
                    }
                    else if (un_download == pay_orders.Count)
                    {
                        has_no_label.Visible = true;
                        has_label.Visible = false;
                        notice_undownload.Visible = false;
                    }
                }


            }
        }


        protected void bar_code_ItemCommand(object source, DataListCommandEventArgs e)
        {

            //如果是修改地址
            if (e.CommandName.ToString().Equals("downloadlocal"))
            {
                /************************************************************************/
                /*               弹出浮动窗口供用户修改所选中的信息                     */
                /************************************************************************/

                string Ordernum = e.CommandArgument.ToString();

                string filename = Server.MapPath("~\\views\\pdf\\local\\" + Ordernum + ".pdf");

                HttpContext.Current.Response.Clear();

                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;FileName=out.pdf");
                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.OutputStream.Flush();

            }
            else if (e.CommandName.ToString().Equals("downloadinter"))
            {

                string Ordernum = e.CommandArgument.ToString();

                string filename = Server.MapPath("~\\views\\pdf\\" + Ordernum + ".pdf");
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


            dc = new DataColumn("order_track", typeof(string));
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

            //收件人
            dc = new DataColumn("phone", typeof(string));
            table.Columns.Add(dc);

            //服务方式
            dc = new DataColumn("postway", typeof(string));
            table.Columns.Add(dc);

            //付款金额
            dc = new DataColumn("pay", typeof(string));
            table.Columns.Add(dc);


            for (int i = 0; i < order_numbers.Count; i++)
            {
                string order_number = order_numbers[i].ToString();
                AutoOrderList order = new AutoOrderList();

                if (order_number.Contains("WA"))
                {
                    order = new AutoOrderListDAO().getAutoOrderList(order_number);
                    if (order.Ea_track_no == "")
                    {
                        un_download++;
                    }
                    else
                    {
                        DataRow dr = table.NewRow();

                        down_orders.Add(order.Ea_track_no);

                        dr["order_number"] = order.Order_no;
                        dr["order_track"] = order.Ea_track_no;
                        dr["local_order"] = "无";
                        dr["weight"] = order.Weight;
                        dr["sender"] = order.CollectionContactName;
                        dr["receiver"] = order.RecipientContactName;
                        dr["phone"] = order.RecipientPhone;
                        dr["postway"] = order.ServiceCode;
                        dr["pay"] = order.Pay_after_discount;
                        

                        table.Rows.Add(dr);
                    }
                }
                else if (order_number.Contains("WM"))
                {
                    Order temporder = new OrderDAO().getOrder(order_number);
                    ArrayList packageArray = new PackageDAO().getPackage(temporder.Order_number);

                    for (int j = 0; j < packageArray.Count; j++) 
                    {
                        Package temp_package = (Package)packageArray[j];

                        DataRow dr = table.NewRow();

                        down_orders.Add(temp_package.Ea_track_no);

                        dr["order_number"] = temp_package.Order_number;
                        dr["order_track"] = temp_package.Ea_track_no;

                        if (temp_package.Local_track_no == "")
                        {
                            dr["local_order"] = "无";
                        }
                        else 
                        {
                            dr["local_order"] = temp_package.Local_track_no;
                        }

                        dr["weight"] = temp_package.Weight;
                        dr["sender"] = temporder.CollectionContactName;
                        dr["receiver"] = temporder.RecipientContactName;
                        dr["phone"] = temporder.RecipientPhone;

                        if (temporder.Delivery_way == "CollectionPlus")
                        {
                            dr["postway"] = getPostWay(temporder.Post_way) + "—Collection +";
                        }
                        else if (temporder.Delivery_way == "UKMail")
                        {
                            dr["postway"] = getPostWay(temporder.Post_way) + "—UKMail";
                        }
                        else 
                        {
                            dr["postway"] = getPostWay(temporder.Post_way);
                        }
                        dr["pay"] = temp_package.Pay;
 
                        table.Rows.Add(dr);
                    }

                }

                Session["all_orders"] = down_orders;
            }

            return table;
        }


        /// <summary>
        /// 下载全部国际PDF的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_downAll_Click(object sender, EventArgs e)
        {
            ArrayList all_orders = (ArrayList)Session["all_orders"];

            string[] pdflist = new string[all_orders.Count];

            for (int jj = 0; jj < all_orders.Count; jj++)
            {
               
                pdflist[jj] = Server.MapPath("~\\views\\pdf\\" + all_orders[jj] + ".pdf");
            }

            mergePDFFiles(pdflist, Server.MapPath("~\\views\\pdf\\" + all_orders[0] + "9.pdf"));
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=AllOrder.pdf");

            HttpContext.Current.Response.WriteFile(Server.MapPath("~\\views\\pdf\\" + all_orders[0] + "9.pdf"));

            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();

        }


        /// <summary>
        /// 下载全部本地PDF的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_downall_local_Click(object sender, EventArgs e)
        {

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


        private void initButtonClick(DataList datalist)
        {
            for (int i = 0; i < datalist.Items.Count;i++ )
            {
                Label label = (Label)datalist.Items[i].FindControl("local_label");
                if (label.Text == "无")
                {
                    ((Button)datalist.Items[i].FindControl("local_download")).Enabled=false;
                }

            }
        }



        private string getPostWay(string postway)
        {
            string way = "";

            if (postway == "PF-IPE-Collection")
            {
                way = "皇家邮政经济包（上门取件）";
            }
            else if (postway == "PF-IPE-Depot")
            {
                way = "皇家邮政经济包（自行送投至Depot）";
            }
            else if (postway == "PF-IPE-Pol")
            {
                way = "皇家邮政经济包（自行送投至邮局）";
            }
            else if (postway == "PF-GPR-Collection")
            {
                way = "皇家邮政优先包(上门取件)";
            }
            else if (postway == "PF-GPR-Delivery")
            {
                way = "皇家邮政优先包(自行送投至邮局或Depot)";
            }
            else if (postway == "EMS")
            {
                way = "华盟EMS专线";
            }
            else if (postway == "PostNL")
            {
                way = "荷兰邮政优先包";
            }


            return way;
        }

        //////////////////////////////////////////////////////////////////////////
        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


        


    }
}