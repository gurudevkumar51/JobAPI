﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebphonixJobsDBEntities : DbContext
    {
        public WebphonixJobsDBEntities()
            : base("name=WebphonixJobsDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Currency> Tbl_Currency { get; set; }
        public virtual DbSet<Tbl_EducationDetails> Tbl_EducationDetails { get; set; }
        public virtual DbSet<Tbl_EmployerIndustry> Tbl_EmployerIndustry { get; set; }
        public virtual DbSet<Tbl_EmployerProfile> Tbl_EmployerProfile { get; set; }
        public virtual DbSet<Tbl_ExperienceDetails> Tbl_ExperienceDetails { get; set; }
        public virtual DbSet<Tbl_Job> Tbl_Job { get; set; }
        public virtual DbSet<Tbl_JobActivity> Tbl_JobActivity { get; set; }
        public virtual DbSet<Tbl_JobSkill> Tbl_JobSkill { get; set; }
        public virtual DbSet<Tbl_JobType> Tbl_JobType { get; set; }
        public virtual DbSet<Tbl_SeekerProfile> Tbl_SeekerProfile { get; set; }
        public virtual DbSet<Tbl_SeekerSkill> Tbl_SeekerSkill { get; set; }
        public virtual DbSet<Tbl_Skill> Tbl_Skill { get; set; }
        public virtual DbSet<Tbl_SocialMedia> Tbl_SocialMedia { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_UserLog> Tbl_UserLog { get; set; }
        public virtual DbSet<Tbl_UserRole> Tbl_UserRole { get; set; }
        public virtual DbSet<Tbl_UserSocialProfile> Tbl_UserSocialProfile { get; set; }
        public virtual DbSet<Tbl_UserJob> Tbl_UserJob { get; set; }
    }
}
