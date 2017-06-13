using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entity;
using System.Data;

namespace WebApiDAL.Mapper
{
   public class JobMapper
    {
        public List<Job> Map(IDataReader reader)
        {
            List<Job> jobs = new List<Job>();
            while (reader.Read())
            {
                Job job = new Job();
                job.ID = Convert.ToInt32(reader["Process_status"]);

                job.Employer.UserID= Convert.ToInt32(reader["File_id"]);
                job.Employer.CompanyName= reader["File_name"].ToString();

                job.CreatedDate = Convert.ToDateTime(reader["UploadDate"]);
                job.ExpireDate = Convert.ToDateTime(reader["StartDate"].ToString());
                job.MinExperienceReq = Convert.ToDecimal(reader["File_extension"].ToString());
                job.MaxExperienceReq = Convert.ToDecimal(reader["EndDate"]);
                job.JobType.Jobtype = reader["UploadDate"].ToString();
                job.JobLocation = reader["Process_status"].ToString();
                job.JobDescription = reader["Process_status"].ToString();
                job.IsActive = Convert.ToBoolean(reader["Process_status"].ToString());
                                
                jobs.Add(job);
            }
            return jobs;
        }
    }
}
