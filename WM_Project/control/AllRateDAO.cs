using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.control
{
    public class AllRateDAO
    {
        public ArrayList getAllRate()
        {
            ArrayList allrate_array = new ArrayList();

            string sql = "select * from tb_rate_postnl";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                AllPostNLRate allrate = new AllPostNLRate();
                allrate.Kg = table.Rows[i][1].ToString();
                allrate.Rate1 = table.Rows[i][2].ToString(); ;
                allrate.Rate2 = table.Rows[i][3].ToString(); ;
                allrate.Rate3 = table.Rows[i][4].ToString();
                allrate.Rate4 = table.Rows[i][5].ToString(); ;
                allrate.Rate5 = table.Rows[i][6].ToString(); ;
                allrate.Rate6 = table.Rows[i][7].ToString(); ;
                allrate.Rate7 = table.Rows[i][8].ToString(); ;
                allrate.Rate8 = table.Rows[i][9].ToString();
                allrate.Rate9 = table.Rows[i][10].ToString(); ;
                allrate.Rate10 = table.Rows[i][11].ToString(); ;
                allrate.Rate11 = table.Rows[i][12].ToString(); ;
                allrate.Rate12 = table.Rows[i][13].ToString(); ;
                allrate.Rate13 = table.Rows[i][14].ToString();
                allrate.Rate14 = table.Rows[i][15].ToString(); ;
                allrate.Rate15 = table.Rows[i][16].ToString(); ;
                allrate.Rate16 = table.Rows[i][17].ToString(); ;
                allrate.Rate17 = table.Rows[i][18].ToString(); ;
                allrate.Rate18 = table.Rows[i][19].ToString();
                allrate.Rate19 = table.Rows[i][20].ToString(); ;
                allrate.Rate20 = table.Rows[i][21].ToString(); ;
                allrate.Rate21 = table.Rows[i][22].ToString(); ;
                allrate.Rate22 = table.Rows[i][23].ToString(); ;

                allrate_array.Add(allrate);

            }



            return allrate_array;

        }
    }
}