using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;

namespace WebApiDAL.ServiceManager
{
    public interface IEmployer
    {
        Boolean BuildCompanyProfile(EmployerProfile CompanyProfile, out string ErMsg);
    }
}
