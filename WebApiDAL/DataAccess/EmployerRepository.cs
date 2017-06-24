using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;
using WebApiDAL.ServiceManager;

namespace WebApiDAL.DataAccess
{
    public class EmployerRepository : IEmployer
    {
        private WebphonixJobsDBEntities db = new WebphonixJobsDBEntities();

        public Boolean AddCompanyProfile(Tbl_EmployerProfile CompanyProfile, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Tbl_EmployerProfile.Add(CompanyProfile);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Ermsg = ex.Message;
                return false;
            }
        }

        public Boolean UpdateCompanyProfile(Tbl_EmployerProfile CompanyProfile, out string Ermsg)
        {
            Ermsg = "";
            try
            {
                db.Entry(CompanyProfile).State = EntityState.Modified;
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
