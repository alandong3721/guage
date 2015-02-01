using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text.pdf;
using iTextSharp.text;


using WM_Project.control;
using WM_Project.logical.common;

using System.Data.SqlClient;
using System.Threading;
using CollectionPlus;

namespace WM_Project.views
{
    public partial class pay_success : System.Web.UI.Page
    {
        public static int LocalTrackNumber = 9999999;
        public string trackNumber = "";
        protected   ArrayList order_number_array = new ArrayList();
        public  string name = "";
        public  int total_count = 0;
        public string alertMsg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                name = Request.QueryString["username"];
                string code = Request.QueryString["code"];
                string pay_way = Request.QueryString["paymethod"];

                if (Session["name"].ToString() != null && code != null)
                {
                    if (new UserDAO().isCodeRight(Session["name"].ToString(), code))
                    {
                        //生成支付成功码
                        string success_code1 = (new Random().Next(100000000, 1000000000)).ToString();
                        string success_code2 = (new Random().Next(1000000, 10000000)).ToString();
                        string success_code3 = (new Random().Next(10000000, 100000000)).ToString();
                        string success_code = success_code1 + success_code2 + success_code3;
                        //将成功码插入到用户表中，支付成功是进行验证
                        new UserDAO().updateSuccessCode(Session["name"].ToString(), success_code);
                        //确实付款成功
                        //更新数据库信息
                        order_number_array.Clear();
                        ArrayList excel_payorders = new AutoOrderListDAO().getAutoOrderListArray(Session["name"].ToString(), "unpay");
                        ArrayList interface_payorders = new OrderDAO().getOrders(Session["name"].ToString(), "unpay");

                        for (int i = 0; i < excel_payorders.Count; i++)
                        {
                            AutoOrderList aulist = (AutoOrderList)excel_payorders[i];
                            new AutoOrderListDAO().updatePayStatus(aulist.Order_no);
                            order_number_array.Add(aulist.Order_no);
                        }
                        new AutoOrderDAO().updateAutoOrderPayStatus(Session["name"].ToString(), pay_way);

                        for (int i = 0; i < interface_payorders.Count; i++)
                        {
                            Order interface_order = (Order)interface_payorders[i];
                            //跟新付款状态
                            new OrderDAO().updatePayStatue(interface_order.Order_number,pay_way);

                            order_number_array.Add(interface_order.Order_number);
                            
                        }

                        Session["AllOrderMsg"] = order_number_array;
                        for (int i = 0; i < order_number_array.Count; i++)
                        {
                            Order order = new OrderDAO().getOrder(order_number_array[i].ToString());
                            if (order.Delivery_way.ToLower() == "collectionplus")
                            {
                                ArrayList package_array=new PackageDAO().getPackage(order_number_array[i].ToString());
                                for(int j=0;j<package_array.Count;j++){
                                    Package package = (Package)package_array[j];
                                    LocalTrackNumber++;
                                    CollectionPlusLabel collectionplus = new CollectionPlusLabel(order.CollectionContactName, LocalTrackNumber.ToString(), "", DateTime.Parse(order.Delivery_date).ToString("dd/MM/yyyy"));
                                    trackNumber = "8M6W" + LocalTrackNumber + "A025";
                                    collectionplus.makeCollectionPlusLabel(Server.MapPath("~\\views\\pdf\\local\\" + trackNumber + ".pdf"));
                                    package.Local_track_no = trackNumber;

                                    new PackageDAO().updateLocalTrackNo(package);
                                }
                               
                            }
                        }

                            total_count = order_number_array.Count;
                    }
                    else
                    {
                        Response.Redirect("error-page.aspx");
                    }
                }
                else
                {
                    Response.Redirect("error-page.aspx");
                }
            }
        }


      

        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


        private void mergePDFFiles(string[] fileList, string outMergeFile, bool bol)
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
                    if (i == 1 && bol)
                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 2, 0, 0, 2, 0, 0);
                    }
                    else
                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }

            }

            document.Close();
        }

    }
}