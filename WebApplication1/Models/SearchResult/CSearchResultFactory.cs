using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.ViewModels.Home;

namespace WebApplication1.Models.SearchResult
{
    public class CSearchResultFactory
    {
        public List<SearchProduct> GetCSearchResultsByCondition(string 風格, string 地區, string 服務種類, string 日期, string 時段)
        {
            string sSQL = "select p.fCID, p.f項目照片,p.f項目名稱, p.[f項目評級 ], p.f價格,u.f姓名 " +
                "from (((((t販售項目 p inner join t私廚 c on p.fCID=c.fCID)" +
                "inner join t會員 u on u.fUID = c.fUID) " +
                "inner join t私廚可預訂時間 as t on t.fCID = p.fCID) " +
                "inner join t風格 as s on s.fSID = p.fSID)" +
                "inner join t服務種類 as k on k.fKID = p.fKID)" +
                "where s.f風格 = @風格 and k.f服務種類 = @服務種類 and c.f服務地區 = @地區 " +
                "and t.f日期 = @日期 and t.f時段 = @時段; ";
            DateTime D日期 = Convert.ToDateTime(日期);
            List<SqlParameter> paraList = new List<SqlParameter>();
            if (風格 != null && 地區 != null && 服務種類 != null && 日期 != null && 時段 != null)
            {
                paraList.Add(new SqlParameter("@風格", 風格));
                paraList.Add(new SqlParameter("@地區", 地區));
                paraList.Add(new SqlParameter("@服務種類", 服務種類));
                paraList.Add(new SqlParameter("@日期", D日期));
                paraList.Add(new SqlParameter("@時段", 時段));

            }

            List<SearchProduct> list = new List<SearchProduct>();
            Common.DBClass.SQLReader(sSQL, paraList.ToArray(), (reader) =>
            {
                while (reader.Read())
                {
                    SearchProduct R = new SearchProduct();
                    R.fCID = (int)reader["fCID"];
                    R.f私廚姓名 = (string)reader["f姓名"];
                    R.f項目名稱 = (string)reader["f項目名稱"];
                    R.f項目照片 = (string)reader["f項目照片"];
                    R.f項目評級 = (int)reader["f項目評級 "];
                    R.f價格 = (int)reader["f價格"];
                    list.Add(R);
                }
            });

            return list;
        }
        public List<SearchProduct> GetCSearchResultsByKeyWord(string keyWord)
        {
            string sSQL = "select p.fCID, p.f項目照片,p.f項目名稱, p.[f項目評級 ], p.f價格,u.f姓名 " +
                "from t販售項目 p inner join t私廚 c on p.fCID=c.fCID " +
                "inner join t會員 as u on u.fUID = c.fUID " +
                "inner join t私廚可預訂時間 as t on t.fCID = p.fCID " +
                "inner join t風格 as s on s.fSID = p.fSID " +
                "inner join t服務種類 as k on k.fKID = p.fKID " +
                "where u.f姓名 like @姓名 or p.f項目名稱 like @項目名稱";
            List<SqlParameter> paraList = new List<SqlParameter>();
            if(keyWord != null)
            {
                paraList.Add(new SqlParameter("@姓名", "%" + keyWord + "%"));
                paraList.Add(new SqlParameter("@項目名稱", "%" + keyWord + "%"));
            }

            List<SearchProduct> list = new List<SearchProduct>();
            Common.DBClass.SQLReader(sSQL, paraList.ToArray(), (reader) => {
                while (reader.Read())
                {
                    SearchProduct R = new SearchProduct();
                    R.fCID = (int)reader["fCID"];
                    R.f私廚姓名 = (string)reader["f姓名"];
                    R.f項目名稱 = (string)reader["f項目名稱"];
                    R.f項目照片 = (string)reader["f項目照片"];
                    R.f項目評級 = (int)reader["f項目評級 "];
                    R.f價格 = (int)reader["f價格"];
                    list.Add(R);
                }
            });
            return list;
        }
    }
}