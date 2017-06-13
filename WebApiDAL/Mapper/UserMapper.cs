using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using System.Data;

namespace WebApiDAL.Mapper
{
    public class AdminMapper 
    {
        public List<User> Map(IDataReader reader)
        {
            List<User> usrs = new List<User>();
            while (reader.Read())
            {
                User usr = new User();
                usr.ID = Convert.ToInt32(reader["AdminID"].ToString());
                usr.Email = reader["MailID"].ToString();
                usr.Password = reader["Password"].ToString();
                usr.PhoneNumber = reader["FirstName"].ToString();
                usr.ProfileImgPath = reader["LastName"].ToString();
                usr.SMSActive = Convert.ToBoolean(reader["Status"]);
                usr.EmailActive = Convert.ToBoolean(reader["IsDeleted"]);
                usr.Role = reader["AdminType"].ToString();
                usr.AccountActive = Convert.ToBoolean(reader["IsDeleted"]);
                usr.LastJobAppliedDate =Convert.ToDateTime( reader["AdminType"].ToString());
                usr.LastLogin = Convert.ToDateTime(reader["AdminType"].ToString());
                usr.RegistrationDate = Convert.ToDateTime(reader["AdminType"].ToString());
                usrs.Add(usr);
            }
            return usrs;
        }

        public User MapSingle(IDataReader reader)
        {
            User usr = new User();
            while (reader.Read())
            {
                usr.ID = Convert.ToInt32(reader["AdminID"].ToString());
                usr.Email = reader["MailID"].ToString();
                usr.Password = reader["Password"].ToString();
                usr.PhoneNumber = reader["FirstName"].ToString();
                usr.ProfileImgPath = reader["LastName"].ToString();
                usr.SMSActive = Convert.ToBoolean(reader["Status"]);
                usr.EmailActive = Convert.ToBoolean(reader["IsDeleted"]);
                usr.Role = reader["AdminType"].ToString();
                usr.AccountActive = Convert.ToBoolean(reader["IsDeleted"]);
                usr.LastJobAppliedDate = Convert.ToDateTime(reader["AdminType"].ToString());
                usr.LastLogin = Convert.ToDateTime(reader["AdminType"].ToString());
                usr.RegistrationDate = Convert.ToDateTime(reader["AdminType"].ToString());
            }
            return usr;
        }
    }
}
