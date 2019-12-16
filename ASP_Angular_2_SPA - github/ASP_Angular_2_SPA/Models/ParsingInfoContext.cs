using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Angular_2_SPA.Models
{
    public class ParsingInfoContext: DbContext
    {
        public DbSet<ParsingInfo> ParsingInfos { get; set; }
        public DbSet<NodeInfo> NodeInfos { set; get; }

        public ParsingInfoContext(DbContextOptions<ParsingInfoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.InternalAHREFS)
            //.HasForeignKey(p => p.ParsingInfoId);
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.ExternalAHREFS)
            //    .HasForeignKey(p => p.ParsingInfoId);
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.h1s)
            //    .HasForeignKey(p => p.ParsingInfoId);
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.images)
            //    .HasForeignKey(p => p.ParsingInfoId);
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.Titles)
            //    .HasForeignKey(p => p.ParsingInfoId);
            //modelBuilder.Entity<NodeInfo>()
            //    .HasOne(n => n.ParsingInfo)
            //    .WithMany(p => p.Descriptions)
            //    .HasForeignKey(p => p.ParsingInfoId);

            modelBuilder.Entity<NodeInfo>()
                .HasOne(n => n.ParsingInfo)
                .WithMany(p => p.NodesInfoList)
            .HasForeignKey(p => p.ParsingInfoId);
        }

    }
}
