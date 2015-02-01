using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.manage_system.super_admin_frame
{
    public partial class check_all_user_rate_type : System.Web.UI.Page
    {
        public static string username = "";
        public static ArrayList type = new ArrayList();
        public static ArrayList emsArray = new ArrayList();
        public static ArrayList postnlArray = new ArrayList();
        public static ArrayList pfgprcArray = new ArrayList();
        public static ArrayList pfgprdArray = new ArrayList();
        public static ArrayList pfipecArray = new ArrayList();
        public static ArrayList pfipedArray = new ArrayList();
        public static ArrayList pfipepArray = new ArrayList();
        public static ArrayList pfipetArray = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null&&Session["manager"]==null&&Session["staff"]==null)
                {
                    Response.Redirect("../error-page.aspx");
                }
            }
        }

        protected void check_rate_Click(object sender, EventArgs e)
        {

            initArray();

            string name = Request.Form["username"];
            username = name;
            UserRate emsRate = new SetEMSRateForUserDAO().getUserRate(name);
            if(emsRate==null){
                emsRate = new UserRate();
                emsRate.Name = name;
                emsRate.Ratetype = "rate1";
            }
            type.Add(emsRate.Ratetype);

            UserRate postnlRate = new SetPostNLRateForUserDAO().getUserRate(name);
            if (postnlRate == null)
            {
                postnlRate = new UserRate();
                postnlRate.Name = name;
                postnlRate.Ratetype = "rate22";
            }
            type.Add(postnlRate.Ratetype);

            UserRate pfgprcRate = new SetPFGPRCRateForUserDAO().getUserRate(name);
            if (pfgprcRate == null)
            {
                pfgprcRate = new UserRate();
                pfgprcRate.Name = name;
                pfgprcRate.Ratetype = "rate1";
            }
            type.Add(pfgprcRate.Ratetype);

            UserRate pfgprdRate = new SetPFGPRDRateForUserDAO().getUserRate(name);
            if (pfgprdRate == null)
            {
                pfgprdRate = new UserRate();
                pfgprdRate.Name = name;
                pfgprdRate.Ratetype = "rate1";
            }
            type.Add(pfgprdRate.Ratetype);

            UserRate pfipecRate = new SetPFIPECollectionRateForUserDAO().getUserRate(name);
            if (pfipecRate == null)
            {
                pfipecRate = new UserRate();
                pfipecRate.Name = name;
                pfipecRate.Ratetype = "rate1";
            }
            type.Add(pfipecRate.Ratetype);

            UserRate pfipedRate = new SetPFIPEDepotRateForUserDAO().getUserRate(name);
            if (pfipedRate == null)
            {
                pfipedRate = new UserRate();
                pfipedRate.Name = name;
                pfipedRate.Ratetype = "rate1";
            }
            type.Add(pfipedRate.Ratetype);

            UserRate pfipepRate = new SetPFIPEPolRateForUserDAO().getUserRate(name);
            if (pfipepRate == null)
            {
                pfipepRate = new UserRate();
                pfipepRate.Name = name;
                pfipepRate.Ratetype = "rate1";
            }
            type.Add(pfipepRate.Ratetype);

            UserRate pfipetRate = new SetPFIPETrailerRateForUserDAO().getUserRate(name);
            if (pfipetRate == null)
            {
                pfipetRate = new UserRate();
                pfipetRate.Name = name;
                pfipetRate.Ratetype = "rate1";
            }
            type.Add(pfipetRate.Ratetype);

            string sql = "select " + emsRate.Ratetype + " from tb_rate_ems";
            DataTable emstable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < emstable.Rows.Count; i++)
            {
                emsArray.Add(Math.Round(Convert.ToSingle(emstable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + postnlRate.Ratetype + " from tb_rate_postnl";
            DataTable postnltable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < postnltable.Rows.Count; i++)
            {
                postnlArray.Add(Math.Round(Convert.ToSingle(postnltable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + pfgprcRate.Ratetype + " from tb_rate_pf_gpr_collection";
            DataTable pftable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pftable.Rows.Count; i++)
            {
                pfgprcArray.Add(Math.Round(Convert.ToSingle(pftable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + pfgprdRate.Ratetype + " from tb_rate_pf_gpr_delivery";
            DataTable pfgprdtable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pfgprdtable.Rows.Count; i++)
            {
                pfgprdArray.Add(Math.Round(Convert.ToSingle(pfgprdtable.Rows[i][0].ToString()), 2));
            }


            sql = "select " + pfipecRate.Ratetype + " from tb_rate_pf_ipe_Collection";
            DataTable pfipectable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pfipectable.Rows.Count; i++)
            {
                pfipecArray.Add(Math.Round(Convert.ToSingle(pfipectable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + pfgprdRate.Ratetype + " from tb_rate_pf_ipe_depot";
            DataTable pfipedtable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pfipedtable.Rows.Count; i++)
            {
                pfipedArray.Add(Math.Round(Convert.ToSingle(pfipedtable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + pfgprdRate.Ratetype + " from tb_rate_pf_ipe_pol";
            DataTable pfipeptable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pfipeptable.Rows.Count; i++)
            {
                pfipepArray.Add(Math.Round(Convert.ToSingle(pfipeptable.Rows[i][0].ToString()), 2));
            }

            sql = "select " + pfgprdRate.Ratetype + " from tb_rate_pf_ipe_trailer";
            DataTable pfipettable = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < pfipettable.Rows.Count; i++)
            {
                pfipetArray.Add(Math.Round(Convert.ToSingle(pfipettable.Rows[i][0].ToString()), 2));
            }

            user_rate_info.Visible = true;
        }


        /// <summary>
        /// 初始化列表
        /// </summary>
        private void initArray()
        {
            type.Clear();
            emsArray.Clear();
            postnlArray.Clear();
            pfgprcArray.Clear();
            pfgprdArray.Clear();
            pfipecArray.Clear();
            pfipedArray.Clear();
            pfipepArray.Clear();
            pfipetArray.Clear();

        }
    }
}