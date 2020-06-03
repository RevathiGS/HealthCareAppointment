namespace HealthCareAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingTable_D : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");



            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);



            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                    IsActive = c.Boolean(),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");



            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);



            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);




            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    RoleId = c.Int(nullable: false, identity: true),
                    RoleName = c.String(),
                })
                .PrimaryKey(t => t.RoleId);



            CreateTable(
                "dbo.UserRegisters",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false),
                    FullName = c.String(nullable: false, maxLength: 100),
                    Password = c.String(nullable: false, maxLength: 100),
                    PhoneNumber = c.String(nullable: false, maxLength: 10),
                    RoleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.RoleId)
                .Index(t => t.RoleId);



            CreateTable(
                "dbo.States",
                c => new
                {
                    StateId = c.Int(nullable: false, identity: true),
                    StateName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.StateId);



            CreateTable(
                "dbo.Locations",
                c => new
                {
                    LocationId = c.Int(nullable: false, identity: true),
                    LocationName = c.String(nullable: false),
                    StateId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);

            CreateTable(
                "dbo.Specializations",
                c => new
                {
                    SpecializationId = c.Int(nullable: false, identity: true),
                    SpecializationName = c.String(),
                })
                .PrimaryKey(t => t.SpecializationId);



            CreateTable(
                "dbo.TimeSlots",
                c => new
                {
                    TimeSlotId = c.Int(nullable: false, identity: true),
                    SlotTime = c.String(nullable: false),
                })
                .PrimaryKey(t => t.TimeSlotId);



            CreateTable(
               "dbo.Doctors",
               c => new
               {
                   DoctorId = c.Int(nullable: false, identity: true),
                   DoctorName = c.String(),
                   StateId = c.Int(nullable: false),
                   LocationId = c.Int(nullable: false),
                   SpecializationId = c.Int(nullable: false),
                   Gender = c.Int(nullable: false),
                   Experience = c.Int(nullable: false),
                   PhoneNumber = c.String(),
                   Email = c.String(),
                   IsAvailable = c.Boolean(nullable: false),
                   Address = c.String(),
               })
               .PrimaryKey(t => t.DoctorId)
               .ForeignKey("dbo.Locations", t => t.LocationId)
               .ForeignKey("dbo.Specializations", t => t.SpecializationId)
               .ForeignKey("dbo.States", t => t.StateId)
               .Index(t => t.StateId)
               .Index(t => t.LocationId)
               .Index(t => t.SpecializationId);



            CreateTable(
                "dbo.Patients",
                c => new
                {
                    PatientId = c.Int(nullable: false, identity: true),
                    PatientName = c.String(),
                    Sex = c.Int(nullable: false),
                    BirthDate = c.DateTime(nullable: false),
                    Phone = c.String(),
                    StateId = c.Int(nullable: false),
                    LocationId = c.Int(nullable: false),
                    Address = c.String(),
                    DateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId)
                .Index(t => t.LocationId);



            CreateTable(
                "dbo.Appointments",
                c => new
                {
                    AppointmentId = c.Int(nullable: false, identity: true),
                    AppointmentDate = c.DateTime(nullable: false),
                    Status = c.Int(nullable: false),
                    StateId = c.Int(nullable: false),
                    LocationId = c.Int(nullable: false),
                    DoctorId = c.Int(nullable: false),
                    PatientId = c.Int(nullable: false),
                    TimeSlotId = c.Int(nullable: false),
                    SpecializationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlotId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.LocationId)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.TimeSlotId)
                .Index(t => t.SpecializationId);


        }

        public override void Down()
        {
        }
    }
}
