using Above_All_Beauty_Pageant.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class AboveAllContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventCategory> Categories { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public AboveAllContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static AboveAllContext Create()
    {
        return new AboveAllContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Particapants)
            .WithRequired(p => p.User)
            .WillCascadeOnDelete(false);


        base.OnModelCreating(modelBuilder);
    }
}