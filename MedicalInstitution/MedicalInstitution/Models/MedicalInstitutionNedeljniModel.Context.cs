﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalInstitution.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MedicalInstitutionNedeljniEntities : DbContext
    {
        public MedicalInstitutionNedeljniEntities()
            : base("name=MedicalInstitutionNedeljniEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAdministrator> tblAdministrators { get; set; }
        public virtual DbSet<tblDailyMaintenance> tblDailyMaintenances { get; set; }
        public virtual DbSet<tblDoctor> tblDoctors { get; set; }
        public virtual DbSet<tblGender> tblGenders { get; set; }
        public virtual DbSet<tblInstitution> tblInstitutions { get; set; }
        public virtual DbSet<tblMainternace> tblMainternaces { get; set; }
        public virtual DbSet<tblManager> tblManagers { get; set; }
        public virtual DbSet<tblPatient> tblPatients { get; set; }
        public virtual DbSet<tblShiftWork> tblShiftWorks { get; set; }
        public virtual DbSet<vwAdmin> vwAdmins { get; set; }
        public virtual DbSet<vwDailyMaintenance> vwDailyMaintenances { get; set; }
        public virtual DbSet<vwDoctor> vwDoctors { get; set; }
        public virtual DbSet<vwMainternace> vwMainternaces { get; set; }
        public virtual DbSet<vwManager> vwManagers { get; set; }
        public virtual DbSet<vwPatient> vwPatients { get; set; }
    }
}