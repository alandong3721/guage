using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;

namespace WM_Project.manage_system.frame
{
    public partial class import_ems_order_number : System.Web.UI.Page
    {
        public string intablename = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_order_file_upload_Click(object sender, EventArgs e)
        {
            string path = ems_order_file.FileName;
            int success = 0;

            if (path == "")
            {
                alert("请选择文件！！");
                return;
            }
            else
            {

                string file_path = saveUploadFile();

                if (file_path == "error")
                {
                    return;
                }

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

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string order_no = ds.Tables[0].Rows[i]["ems_no"].ToString();
                    // 添加 EMS 单号
                    if (new EMSOrderNoDAO().addEMSOrderNo(order_no))
                    {
                        success++;
                    }
                }

                alert("成功导入" + success + "个单号！！");
            }

        }

        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <returns>返回文件的路径</returns>
        private string saveUploadFile()
        {
            intablename = "";

            string file = Path.GetFileName(this.ems_order_file.PostedFile.FileName);//用于保存到数据库中的上传文件URL路径
            int ij = file.LastIndexOf("."); //取得文件扩展名
            if (ij > 0)
            {
                string newext = file.Substring(ij).ToLower();//将文件扩展名转换为小写
                if (newext != ".xls")
                {
                    Response.Write("<script language='javascript'>alert('对不起,文件类型不符,不能上传!上传文件扩展必须为(.xls) ')</script>");
                    return "error";
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('对不起,上传失败,找不到文件!')</script>");

            }

            intablename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string pathFile = Server.MapPath("~/manage-system/ems-file/ems-order-no/" + intablename);

            this.ems_order_file.PostedFile.SaveAs(pathFile); //文件上传保存 
            return pathFile;

        }


        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}