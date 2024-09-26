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
    public partial class login : System.Web.UI.Page
    {
        Connectioncls objcls = new Connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = "select count(Id) from t where username='" + TextBox1.Text + "'and password ='" + TextBox2.Text + "'";
            string cid = objcls.Fn_Scalar(id);
            if (cid == "1")
            {
                int id1 = 0;
                string str = "select id from t where username ='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlDataReader dr = objcls.Fn_Reader(str);

                while (dr.Read())
                {
                    id1 = Convert.ToInt32(dr["id"].ToString());
                }
                Session["uid"] = id1;
                Response.Redirect("profileview.aspx");
            }
            else
            {
                Label1.Text = "invalid username and password";
            }
        }
    }
}