﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ServerDB : DbContext
    {
        public ServerDB()
            : base("name=ServerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentGroup> StudentGroup { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}