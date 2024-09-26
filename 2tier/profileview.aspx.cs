using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _2tier
{

    public partial class profileview : System.Web.UI.Page
    {
        Connectioncls objcls = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select name,age,address,photo from t where id='" + Session["uid"] + "'";
            SqlDataReader dr = objcls.Fn_Reader(sel);
            while(dr.Read())
            {
                Label1.Text = dr["name"].ToString();
                 Label2.Text = dr["age"].ToString();
                Label3.Text = dr["address"].ToString();
                Image1.ImageUrl = dr["photo"].ToString();

            }
            DataSet ds = objcls.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dt = objcls.Fn_DataTable(sel);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}