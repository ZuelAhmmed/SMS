using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Models;

namespace SMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string NidOrBirthRegNo { get; set; }
        [Required]
        public string SecurityRole { get; set; }
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("InstituteDbConnection", throwIfV1Schema: false)
        {
        }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
     

        // Personal Detail Pre-Required Models
        //public DbSet<Gender> Genders { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<Religion> Religions { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        //public DbSet<MaritarialStatus> MaritarialStatuses { get; set; }

        // Employee Pre-Required Models
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Designation> Designations { get; set; }

        // Start's DbSet<Models> For User's
        public DbSet<StudentApplication> StudentApplications { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }

        public DbSet<EmployeeApplication> EmployeeApplications { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }

        public DbSet<GuardianAccount> GurdianAccounts { get; set; }
        // Start's DbSet<Models> For User'S

        // Start's DbSet<Models> For Address
        public DbSet<AddressCatagory> AddressCatagories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Rmo> Rmos { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<UnionOrWord> UnionOrWords { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<VillageRoad> VillageRoads { get; set; }
        // End's DbSet<Models> For Address

        //Qualification Models Starts
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<ExamOrDegree> ExamOrDegrees { get; set; }
        public DbSet<MajorSubjectOrGroup> MajorSubjectOrGroups { get; set; }
        public DbSet<EmployeeEducationalQualification> EmployeeEducationalQualifications { get; set; }
        public DbSet<StudentEducationalQualification> StudentEducationalQualifications { get; set; }
        public DbSet<TrainingQualification> TrainingQualifications { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        // Starts's DbSet<Models> For Catagory
        public DbSet<ConfirmationCatagory> ConfirmationCatagories { get; set; }


        // Start Data Set For Committee
        public DbSet<CommitteeCatagory> CommitteeCatagories { get; set; }
        public DbSet<CommitteeDesignation> CommitteeDesignations { get; set; }
        public DbSet<CommitteeMembers> CommitteeMemberses { get; set; }
        // End's Data Set For Committee


        // Start Course Management Models
        public DbSet<EducationBoard> EducationBoards { get; set; }
        public DbSet<ClassOrYear> ClassOrYears { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ExamYear> ExamYears { get; set; }
        public DbSet<SubjectCatagory> SubjectCatagories { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<CourseTeacherAssign> CourseTeacherAssigns { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }


        // Start Attendence Models
        public DbSet<StudentAttendence> StudentAttendences { get; set; }
        public DbSet<TeacherAttendence> TeacherAttendences { get; set; }

        // Start Result Management Models
        public DbSet<PublicExamResult> PublicExamResults { get; set; }
        public DbSet<AcademicExamResult> AcademicResults { get; set; }



        //Security Models
        //public DbSet<UserSecurityRole> UserSecurityRoles { get; set; } //Change here
        //public DbSet<SecurityRole> SecurityRoles { get; set; }




        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }






}