﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QuanliSVEntities : DbContext
    {
        public QuanliSVEntities()
            : base("name=QuanliSVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Function_Role> Function_Role { get; set; }
        public virtual DbSet<GradeBySemester> GradeBySemesters { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scholarship> Scholarships { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    
        public virtual ObjectResult<sp_DanhSachSinhVienDatHocBong_Result> sp_DanhSachSinhVienDatHocBong(string maKi)
        {
            var maKiParameter = maKi != null ?
                new ObjectParameter("MaKi", maKi) :
                new ObjectParameter("MaKi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DanhSachSinhVienDatHocBong_Result>("sp_DanhSachSinhVienDatHocBong", maKiParameter);
        }
    }
}
