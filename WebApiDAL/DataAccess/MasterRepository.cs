using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApiDAL.DataAccess
{
    public class MasterRepository : IMaster
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        public Boolean AddRole(Tbl_JobType jobtype, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_JobType.Add(jobtype);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }
    }
}
