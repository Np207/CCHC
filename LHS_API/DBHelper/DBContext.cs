using LHS_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LHS_API.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<PermissionCategory> PermissionCategories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Authorized> Authorized { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TestHandler> TestHandlers { get; set; }
        public DbSet<TestRecord> TestRecords { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👇 Seed ONLY this table
            modelBuilder.Entity<PermissionCategory>().HasData(
                new PermissionCategory { Id = Guid.Parse("176eb711-24b2-4003-bd05-624e5f552640"), Name = "Trang Admin" },
                new PermissionCategory { Id = Guid.Parse("176eb711-24b2-4003-bd05-624e5f552641"), Name = "Trang Profile" }
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = Guid.Parse("186eb711-24b2-4003-bd05-624e5f552640"), Name = "Xem list profiles", Code="view-profile-list", PerCatId =Guid.Parse("176eb711-24b2-4003-bd05-624e5f552641") },
                new Permission { Id = Guid.Parse("186eb711-24b2-4003-bd05-624e5f552641"), Name = "Tạo profile", Code = "create-profile", PerCatId = Guid.Parse("176eb711-24b2-4003-bd05-624e5f552641") }
            );

            modelBuilder.Entity<Authorized>().HasData(
                new Authorized { Id = Guid.Parse("196eb711-24b2-4003-bd05-624e5f552640"), RoleId = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72a"), PermissionId = Guid.Parse("186eb711-24b2-4003-bd05-624e5f552640") },
                new Authorized { Id = Guid.Parse("196eb711-24b2-4003-bd05-624e5f552641"), RoleId = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72a"), PermissionId = Guid.Parse("186eb711-24b2-4003-bd05-624e5f552641") }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department{Id = Guid.Parse("826eb711-24b2-4003-bd05-624e5f552640"),Name = "Sở Nội vụ tỉnh Cà Mau"},
                new Department{Id = Guid.Parse("826eb711-24b2-4003-bd05-624e5f552641"),Name = "Hội đồng Nhân dân tỉnh Cà Mau"}
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = Guid.Parse("74dcce23-2377-4e91-8990-a7c85ab64630"), Username = "admin", Password = "123456", IsActived = true, CreatedDate = DateTime.Now, RoleId = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72a"), ProfileId = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272640") },
                new Account { Id = Guid.Parse("74dcce23-2377-4e91-8990-a7c85ab64631"), Username = "pubu", Password = "123456", IsActived = true, CreatedDate = DateTime.Now, RoleId = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72b"), ProfileId = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272641") },
                new Account { Id = Guid.Parse("74dcce23-2377-4e91-8990-a7c85ab64632"), Username = "nghi", Password = "123456", IsActived = true, CreatedDate = DateTime.Now, RoleId = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72b"), ProfileId = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272642") }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72a"), RoleName = "Admin", RoleCode = "TNCM_ADM" },
                new Role { Id = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72b"), RoleName = "Công chức", RoleCode = "TNCM_CONGCHUC" },
                new Role { Id = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72c"), RoleName = "Viên chức", RoleCode = "TNCM_VIENCHUC" },
                new Role { Id = Guid.Parse("fb776600-cf93-4411-8c39-ddc68682b72d"), RoleName = "Khác", RoleCode = "TNCM_OTHER" }
            );


            modelBuilder.Entity<Profile>().HasData(
                new Profile { Id = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272640"), Name = "ADMINISTRATOR", PhoneNumber = "012345678", IdNumber = "000000000000" },
                new Profile { Id = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272641"), Name = "Pu Bu", PhoneNumber = "012345678", DateOfBirth = DateOnly.Parse("10/20/2001"), IdNumber = "000000000000", DepId = Guid.Parse("826eb711-24b2-4003-bd05-624e5f552640") },
                new Profile { Id = Guid.Parse("856eb7d9-24b2-4743-bd05-624e5f272642"), Name = "Nghi Nghi", PhoneNumber = "012345678", DateOfBirth = DateOnly.Parse("11/17/2002"), IdNumber = "000000000000", DepId = Guid.Parse("826eb711-24b2-4003-bd05-624e5f552641") }
            );

            // Just define the entity (EF will create the table automatically)
            modelBuilder.Entity<TestHandler>();
            modelBuilder.Entity<TestRecord>();
            modelBuilder.Entity<Question>();
            modelBuilder.Entity<QuestionBank>();
        }
    }
}
