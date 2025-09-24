using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Gadget> Gadgets => Set<Gadget>();
    public DbSet<RoomGadget> RoomGadgets => Set<RoomGadget>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Mom> Moms => Set<Mom>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

       
        b.Entity<RoomGadget>()
            .HasOne(rg => rg.Room)
            .WithMany(r => r.RoomGadgets)
            .HasForeignKey(rg => rg.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<RoomGadget>()
            .HasOne(rg => rg.Gadget)
            .WithMany(g => g.RoomGadgets)
            .HasForeignKey(rg => rg.GadgetId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Booking>()
            .HasOne(bk => bk.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(bk => bk.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Booking>()
            .HasOne(bk => bk.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(bk => bk.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Mom>()
            .HasOne(m => m.Booking)
            .WithOne(bk => bk.Mom)
            .HasForeignKey<Mom>(m => m.BookingId)
            .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Room>().Property(x => x.Name).HasMaxLength(100);
        b.Entity<Gadget>().Property(x => x.Name).HasMaxLength(100);
        b.Entity<User>().Property(x => x.Email).HasMaxLength(200);
    }
}
