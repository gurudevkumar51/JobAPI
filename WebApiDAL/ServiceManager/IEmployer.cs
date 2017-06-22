using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using WebApiDAL.Model;

namespace WebApiDAL.ServiceManager
{
    public interface IEmployer
    {
        Boolean AddCompanyProfile(Tbl_EmployerProfile CompanyProfile, out string ErMsg);
        Boolean UpdateCompanyProfile(Tbl_EmployerProfile CompanyProfile, out string ErMsg);
    }
}
