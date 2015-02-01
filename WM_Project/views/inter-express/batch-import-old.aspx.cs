using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.views.inter_express
{
    public partial class batch_import_old : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] == null)
                {
                    page_one.Visible = true;
                    alert("请先登录!");
                }
                else
                {
                    page_two.Visible = true;
                }
            }
        }


        /// <summary>
        /// 登陆按钮的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            string code = Request.Form["txt_code"].ToLower();

            string session_code = Session["code"].ToString().ToLower();

            //身份验证
            if (code.Equals(session_code))
            {
                int flag = new UserDAO().checkUser(name, password);

                //身份验证通过
                if (flag == 1)
                {
                    page_one.Visible = false;
                    Session["name"] = name;
                    page_two.Visible = true;
                    Response.Redirect("batch-import.aspx");
                }
                else if (flag == 0)
                {
                    alert("密码错误！");
                }
                else if (flag == -1)
                {
                    alert("用户名不存在！");
                }
            }
            else
            {
                alert("验证码错误！");
            }
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message">所要弹出的信息</param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }


        //上传Excel文件的实现
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string path = upload_ems_excel.FileName;

            if (path == "")
            {
                alert("请选择文件！！");
            }
            else
            {
                string file_path = saveUploadFile();

                DataSet ds = new DataSet();
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + file_path + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                OleDbCommandBuilder cb = new OleDbCommandBuilder(myCommand);
                strExcel = "select  * from [Sheet1$] ";

                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(ds, "table1");

                ArrayList order_array = new ArrayList();
                ArrayList package_array = new ArrayList();
                DateTime temp_time = DateTime.Now;

                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    string delivery_way = ds.Tables[0].Rows[i][0].ToString();
                    string delivery_time = ds.Tables[0].Rows[i][1].ToString();
                    string receive_company = ds.Tables[0].Rows[i][2].ToString();
                    string receive_name = ds.Tables[0].Rows[i][3].ToString();
                    string receive_phone = ds.Tables[0].Rows[i][4].ToString();
                    string receive_address_line = ds.Tables[0].Rows[i][5].ToString();
                    string receive_city = ds.Tables[0].Rows[i][6].ToString();
                    string receive_postcode = ds.Tables[0].Rows[i][7].ToString();
                    string receive_country = ds.Tables[0].Rows[i][8].ToString();
                    string send_company = ds.Tables[0].Rows[i][9].ToString();
                    string send_name = ds.Tables[0].Rows[i][10].ToString();
                    string send_phone = ds.Tables[0].Rows[i][11].ToString();
                    string send_addressline = ds.Tables[0].Rows[i][12].ToString();
                    string send_city = ds.Tables[0].Rows[i][13].ToString();
                    string send_postcode = ds.Tables[0].Rows[i][14].ToString();
                    string insurance = ds.Tables[0].Rows[i][15].ToString();
                    string comment = ds.Tables[0].Rows[i][16].ToString();
                    string parcel_number = ds.Tables[0].Rows[i][17].ToString();
                    string weight = ds.Tables[0].Rows[i][18].ToString();
                    string length = ds.Tables[0].Rows[i][19].ToString();
                    string width = ds.Tables[0].Rows[i][20].ToString();
                    string height = ds.Tables[0].Rows[i][21].ToString();
                    string description = ds.Tables[0].Rows[i][22].ToString();
                    string package_value = ds.Tables[0].Rows[i][23].ToString();

                    Order order = new Order();
                    Package package = new Package();

                    order.Delivery_way = delivery_way;
                    order.Delivery_date = delivery_time;
                    order.Name = Session["name"].ToString();

                    if (receive_country.ToLower().Equals("china-ems"))
                    {
                        order.Post_way="EMS";
                        package.Destination = "China";
                        package.Post_way = order.Post_way;
                    }
                    else if(receive_country.ToLower().Equals("china"))
                    {
                        order.Post_way = "Parcelforce priority auto";
                        package.Destination = "China";
                        package.Post_way = order.Post_way;
                    }
                    else if(receive_country.ToLower().Equals("china-pfe"))
                    {
                        order.Post_way = "Parcelforce economy";
                        package.Destination = "China";
                        package.Post_way = order.Post_way;
                    }

                    order.Quantity = Convert.ToInt32(parcel_number);
                    order.Order_number = "WM" + temp_time.ToString("yyyyMMddhhmmss") + new Random(i).Next(10, 100)+i%10;
                  
                    order.CollectionCompanyName = send_company;
                    order.CollectionContactName = send_name;
                    
                    
                    
             
                    order.RecipientContactName = receive_name;
                    
          
                    
                    order.Order_time = temp_time;
                    order.Is_pay = "unpay";
                    order.Is_show = "true";

                    package.Departure = "UK";
                    
                    package.Name = Session["name"].ToString();
                    package.Weight = Convert.ToSingle(weight);
                    package.Length = Convert.ToSingle(length);
                    package.Width = Convert.ToSingle(width);
                    package.Height = Convert.ToSingle(height);
                    
                    package.Pay = new Quote().getQuote("UK", package.Destination, package.Weight, package.Length, package.Width, package.Height, package.Post_way);
                    //将 package.Pay 转换为小数点后两位
                    package.Pay = ((int)(package.Pay*100))/100.0f;

                    package.Order_number = order.Order_number;
                    package.Wp_track_no = "WP"+temp_time.ToString("yyyyMMddhhmmss")+new Random(i).Next(100,1000);
                   
                    package.Package_value = Convert.ToSingle(package_value);
                    package.Description = description;
                    package.Is_pay = "unpay";

                    order.Wp_track_no = package.Wp_track_no;

                    package_array.Add(package);
                    order_array.Add(order);

                
                }


                for (int i = 0; i < package_array.Count;i++ )
                {
                    Package temp_package = (Package)package_array[i];
                    new PackageDAO().addPackage(temp_package);
                    Order temp_order = (Order)order_array[i];
                    new OrderDAO().addOrder(temp_order);
                }

            }

            Response.Redirect("../my-shopping-cart.aspx?");
        }


        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <returns>返回文件的路径</returns>
        private string saveUploadFile()
        {
            string file = Path.GetFileName(this.upload_ems_excel.PostedFile.FileName);//用于保存到数据库中的上传文件URL路径
            int ij = file.LastIndexOf("."); //取得文件扩展名
            if (ij > 0)
            {
                string newext = file.Substring(ij).ToLower();//将文件扩展名转换为小写
                if (newext != ".xls" && newext != ".xlsx")
                {
                    Response.Write("<script language='javascript'>alert('对不起,文件类型不符,不能上传!上传文件扩展必须为(.xls/.xlsx) ')</script>");
                    return "";
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,上传失败,找不到文件!')</script>");
                return "";
            }
            string fullFileName = upload_ems_excel.PostedFile.FileName;//完整文件名
            string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);//文件名
            string pathFile = Server.MapPath("~/views/excel-upload/" + fileName);

            this.upload_ems_excel.PostedFile.SaveAs(pathFile); //文件上传保存 
            return pathFile;
        }
    }
}