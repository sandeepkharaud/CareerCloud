using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext: DbContext
    {
        public CareerCloudContext() : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {

        }
        public DbSet<ApplicantEducationPoco> ApplicantsEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(e => e.ApplicantEducations)
               .WithRequired(e => e.ApplicantProfiles)
               .HasForeignKey(e => e.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(e => e.ApplicantJobApplications)
                .WithRequired(e => e.CompanyJobs)
                .HasForeignKey(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithRequired(e => e.SecurityLogins)
                .HasForeignKey(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantProfiles)
                .WithRequired(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantResumes)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantSkills)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantWorkHistorys)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(e => e.ApplicantWorkHistorys)
                .WithRequired(e => e.SystemCountryCodes)
                .HasForeignKey(e => e.CountryCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithRequired(e => e.CompanyProfiles)
                .HasForeignKey(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(e => e.CompanyDescriptions)
                .WithRequired(e => e.SystemLanguageCode)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(e => e.CompanyJobEducations)
               .WithRequired(e => e.CompanyJobs)
               .HasForeignKey(e => e.Job)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(e => e.CompanyJobSkills)
              .WithRequired(e => e.CompanyJobs)
              .HasForeignKey(e => e.Job)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(e => e.CompanyJobs)
              .WithRequired(e => e.CompanyProfiles)
              .HasForeignKey(e => e.Company)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(e => e.CompanyJobDescriptions)
              .WithRequired(e => e.CompanyJobs)
              .HasForeignKey(e => e.Job)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
             .HasMany(e => e.CompanyLocations)
             .WithRequired(e => e.CompanyProfiles)
             .HasForeignKey(e => e.Company)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
             .HasMany(e => e.SecurityLoginsLogs)
             .WithRequired(e => e.SecurityLogins)
             .HasForeignKey(e => e.Login)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
             .HasMany(e => e.SecurityLoginsRoles)
             .WithRequired(e => e.SecurityLogins)
             .HasForeignKey(e => e.Login)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityRolePoco>()
             .HasMany(e => e.SecurityLoginsRoles)
             .WithRequired(e => e.SecurityRoles)
             .HasForeignKey(e => e.Login)
             .WillCascadeOnDelete(false);


        }
    }
}
