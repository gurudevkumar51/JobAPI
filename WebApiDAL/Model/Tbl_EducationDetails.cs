
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WebApiDAL.Model
{

using System;
    using System.Collections.Generic;
    
public partial class Tbl_EducationDetails
{

    public int ID { get; set; }

    public string CertificationName { get; set; }

    public string Stream { get; set; }

    public string InstituteName { get; set; }

    public string UniversityName { get; set; }

    public Nullable<System.DateTime> JoinDate { get; set; }

    public Nullable<System.DateTime> CompletionDate { get; set; }

    public Nullable<decimal> Percantage { get; set; }

    public Nullable<decimal> CGPA { get; set; }

    public Nullable<int> UserID { get; set; }



    public virtual Tbl_User Tbl_User { get; set; }

}

}
