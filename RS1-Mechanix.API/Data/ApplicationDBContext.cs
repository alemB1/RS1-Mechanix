using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RS1_Mechanix.API.Models;
using RS1_Mechanix.Models;

namespace RS1_Mechanix.API.Data
{
    public class ApplicationDBContext:IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessService> BusinessServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeServices> EmployeeServices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceReservation> ServiceReservations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RS1_Mechanix.Models.Task> Tasks { get; set; }   // change name
        public DbSet<BusinessScore> BusinessScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BusinessService>()
                .HasKey(bs => new { bs.BusinessId, bs.ServiceId });


            modelBuilder.Entity<BusinessService>()
                .HasOne(bs => bs.Business)
                .WithMany(b => b.BusinessServices)
                .HasForeignKey(bs => bs.BusinessId);

            modelBuilder.Entity<BusinessService>()
                .HasOne(bs => bs.Service)
                .WithMany(b => b.BusinessServices)
                .HasForeignKey(bs => bs.ServiceId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Schedule)
                .WithOne(s => s.Employee)
                .HasForeignKey<Schedule>(s => s.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(u => u.EmployeeId)
                .IsRequired();


            modelBuilder.Entity<EmployeeServices>()
                .HasKey(es => new { es.EmployeeId, es.ServiceId });

            modelBuilder.Entity<EmployeeServices>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeServices)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeServices>()
                .HasOne(es => es.Service)
                .WithMany(s => s.EmployeeServices)
                .HasForeignKey(es => es.ServiceId);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Tasks)
                .WithOne(s => s.Schedule)
                .HasForeignKey(s => s.ScheduleId)
                .IsRequired();

            modelBuilder.Entity<RS1_Mechanix.Models.Task>()
                .HasOne(t => t.State)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StateId)
                .IsRequired();

            modelBuilder.Entity<ServiceReservation>()
                .HasKey(sr => new { sr.ServiceId, sr.ReservationId });

            modelBuilder.Entity<ServiceReservation>()
                .HasOne(sr => sr.Service)
                .WithMany(r => r.ServiceReservations)
                .HasForeignKey(sr => sr.ServiceId);

            modelBuilder.Entity<ServiceReservation>()
                .HasOne(sr => sr.Reservation)
                .WithMany(r => r.ServiceReservations)
                .HasForeignKey(sr => sr.ReservationId);

            modelBuilder.Entity<BusinessScore>()
                .HasOne(b => b.Business)
                .WithMany(b => b.BusinessScores)
                .HasForeignKey(b => b.BusinessId)
                .IsRequired();

        }
    }
}
