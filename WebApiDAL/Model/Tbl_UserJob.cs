
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

    public partial class Tbl_UserJob
    {

        public int ID { get; set; }

        public Nullable<int> JobId { get; set; }

        public Nullable<int> UserId { get; set; }

        public Nullable<bool> IsActive { get; set; }



        public virtual Tbl_Job Tbl_Job { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }

    }

}
