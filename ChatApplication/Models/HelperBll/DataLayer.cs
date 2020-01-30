using System;
using System.Collections.Generic;
using Npgsql;
using System.Configuration;
using System.Data;

namespace ChatApplication.Models.HelperBll
{
    public class DataLayer
    {
        NpgsqlConnection con = new NpgsqlConnection();
        public DataLayer()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        }
        public UserModel login(string email,string password)
        {
            UserModel user = new UserModel();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "select * from tbluser where email='" + email + "' and password='" + password + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                user.userid = Convert.ToInt32(row["userid"].ToString());
                user.email = row["email"].ToString();
                user.mobile = row["mobile"].ToString();
                user.password = row["password"].ToString();
            }
            return user;
        }
        public List<UserModel> getusers(int id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<UserModel> userlist = new List<UserModel>();
            string sql = "select * from tbluser where userid<>"+id;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                UserModel user = new UserModel();
                user.userid = Convert.ToInt32(row["userid"].ToString());
                user.email = row["email"].ToString();
                user.mobile = row["mobile"].ToString();
                user.password = row["password"].ToString();
                user.dob = row["dob"].ToString();
                userlist.Add(user);
            }
            return userlist;
        }

    }
}