using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HelloMvc.Data;

namespace SquashNext.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160430200403_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc3-20709");

            modelBuilder.Entity("HelloMvc.Models.Issue", b =>
                {
                    b.Property<int>("GitHubIssueNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HtmlUrl");

                    b.Property<int>("Milestone");

                    b.Property<int?>("Priority");

                    b.Property<int?>("StoryPoints");

                    b.Property<int>("Theme");

                    b.Property<string>("Title");

                    b.HasKey("GitHubIssueNumber");

                    b.ToTable("Issues");
                });
        }
    }
}
