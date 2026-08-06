using Case5_ClubSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem.AppDbContext
{
    public class ClubDbContext : DbContext
    {
        public ClubDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                .HasIndex(f => f.Name)
                .IsUnique();


            modelBuilder.Entity<Member>()
                .HasOne(m => m.Membership)
                .WithOne(ms => ms.Member)
                .HasForeignKey<Membership>(ms => ms.MemberId);


            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Facility)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FacilityId);


            modelBuilder.Entity<Membership>()
                .HasMany(ms => ms.Payments)
                .WithOne(p => p.Membership)
                .HasForeignKey(p => p.MembershipId);


            
            // Members
            

            modelBuilder.Entity<Member>().HasData(

                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@gmail.com",
                    Phone = "01012345678",
                    BirthDate = new DateTime(2000, 5, 10)
                },

                new Member
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@gmail.com",
                    Phone = "01198765432",
                    BirthDate = new DateTime(1998, 8, 22)
                },

                new Member
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@gmail.com",
                    Phone = "01234567890",
                    BirthDate = new DateTime(2002, 3, 15)
                },

                new Member
                {
                    Id = 4,
                    FullName = "Mona Adel",
                    Email = "mona@gmail.com",
                    Phone = "01511112222",
                    BirthDate = new DateTime(1999, 11, 5)
                },

                new Member
                {
                    Id = 5,
                    FullName = "Youssef Mahmoud",
                    Email = "youssef@gmail.com",
                    Phone = "01099998888",
                    BirthDate = new DateTime(1997, 7, 18)
                }
            );

            
            // Memberships
            

            modelBuilder.Entity<Membership>().HasData(

                new Membership
                {
                    Id = 1,
                    Type = "Monthly",
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = new DateTime(2026, 2, 1),
                    Price = 500,
                    Status = "Active",
                    MemberId = 1
                },

                new Membership
                {
                    Id = 2,
                    Type = "Quarterly",
                    StartDate = new DateTime(2026, 1, 15),
                    EndDate = new DateTime(2026, 4, 15),
                    Price = 1200,
                    Status = "Active",
                    MemberId = 2
                },

                new Membership
                {
                    Id = 3,
                    Type = "Yearly",
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = new DateTime(2027, 1, 1),
                    Price = 4500,
                    Status = "Active",
                    MemberId = 3
                },

                new Membership
                {
                    Id = 4,
                    Type = "Monthly",
                    StartDate = new DateTime(2026, 2, 1),
                    EndDate = new DateTime(2026, 3, 1),
                    Price = 500,
                    Status = "Expired",
                    MemberId = 4
                },

                new Membership
                {
                    Id = 5,
                    Type = "Yearly",
                    StartDate = new DateTime(2026, 3, 1),
                    EndDate = new DateTime(2027, 3, 1),
                    Price = 5000,
                    Status = "Active",
                    MemberId = 5
                }
            );

            
            // Facilities
            

            modelBuilder.Entity<Facility>().HasData(

                new Facility
                {
                    Id = 1,
                    Name = "Swimming Pool",
                    Capacity = 30,
                    HourlyPrice = 200
                },

                new Facility
                {
                    Id = 2,
                    Name = "Football Court",
                    Capacity = 22,
                    HourlyPrice = 600
                },

                new Facility
                {
                    Id = 3,
                    Name = "Basketball Court",
                    Capacity = 15,
                    HourlyPrice = 400
                },

                new Facility
                {
                    Id = 4,
                    Name = "Tennis Court",
                    Capacity = 4,
                    HourlyPrice = 300
                },

                new Facility
                {
                    Id = 5,
                    Name = "Fitness Hall",
                    Capacity = 80,
                    HourlyPrice = 150
                }
            );

            
            // Bookings
            
            modelBuilder.Entity<Booking>().HasData(

                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 8, 1),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    GroupSize = 5,
                    Status = "Confirmed",
                    MemberId = 1,
                    FacilityId = 1
                },

                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 8, 2),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 30, 0),
                    GroupSize = 10,
                    Status = "Confirmed",
                    MemberId = 2,
                    FacilityId = 2
                },

                new Booking
                {
                    Id = 3,
                    BookingDate = new DateTime(2026, 8, 3),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    GroupSize = 4,
                    Status = "Completed",
                    MemberId = 3,
                    FacilityId = 4
                },

                new Booking
                {
                    Id = 4,
                    BookingDate = new DateTime(2026, 8, 4),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(18, 30, 0),
                    GroupSize = 12,
                    Status = "Confirmed",
                    MemberId = 4,
                    FacilityId = 3
                },

                new Booking
                {
                    Id = 5,
                    BookingDate = new DateTime(2026, 8, 5),
                    StartTime = new TimeSpan(19, 0, 0),
                    EndTime = new TimeSpan(20, 0, 0),
                    GroupSize = 8,
                    Status = "Cancelled",
                    MemberId = 5,
                    FacilityId = 5
                }
            );

           
            // Payments
          

            modelBuilder.Entity<Payment>().HasData(

                new Payment
                {
                    Id = 1,
                    Amount = 500,
                    PaymentDate = new DateTime(2026, 1, 1),
                    PaymentMethod = "Cash",
                    MembershipId = 1
                },

                new Payment
                {
                    Id = 2,
                    Amount = 1200,
                    PaymentDate = new DateTime(2026, 1, 15),
                    PaymentMethod = "Credit Card",
                    MembershipId = 2
                },

                new Payment
                {
                    Id = 3,
                    Amount = 4500,
                    PaymentDate = new DateTime(2026, 1, 1),
                    PaymentMethod = "Visa",
                    MembershipId = 3
                },

                new Payment
                {
                    Id = 4,
                    Amount = 500,
                    PaymentDate = new DateTime(2026, 2, 1),
                    PaymentMethod = "Cash",
                    MembershipId = 4
                },

                new Payment
                {
                    Id = 5,
                    Amount = 5000,
                    PaymentDate = new DateTime(2026, 3, 1),
                    PaymentMethod = "Credit Card",
                    MembershipId = 5
                }
            );




        }



        public DbSet<Member> Members { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Facility> Facilities { get; set; }


        public DbSet<Payment> Payments { get; set; }
    }
}
