using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TTStatsAPI
{
    public partial class TTStatsContext : DbContext
    {
        public TTStatsContext()
        {
        }

        public TTStatsContext(DbContextOptions<TTStatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Division> Divisions { get; set; } = null!;
        public virtual DbSet<IndividualMatch> IndividualMatches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Season> Seasons { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<TeamDivision> TeamDivisions { get; set; } = null!;
        public virtual DbSet<TeamMatch> TeamMatches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TTStats;TrustServerCertificate=True;Encrypt=false;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClubName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(e => e.DivisionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SeasonNavigation)
                    .WithMany(p => p.Divisions)
                    .HasForeignKey(d => d.Season)
                    .HasConstraintName("Division_Season_FK");
            });

            modelBuilder.Entity<IndividualMatch>(entity =>
            {
                entity.HasOne(d => d.Player1Navigation)
                    .WithMany(p => p.IndividualMatchPlayer1Navigations)
                    .HasForeignKey(d => d.Player1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player1_FK");

                entity.HasOne(d => d.Player2Navigation)
                    .WithMany(p => p.IndividualMatchPlayer2Navigations)
                    .HasForeignKey(d => d.Player2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player2_FK");

                entity.HasOne(d => d.WinnerNavigation)
                    .WithMany(p => p.IndividualMatchWinnerNavigations)
                    .HasForeignKey(d => d.Winner)
                    .HasConstraintName("Winner_FK");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.Property(e => e.Years)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClubNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.Club)
                    .HasConstraintName("Club_FK");
            });

            modelBuilder.Entity<TeamDivision>(entity =>
            {
                entity.HasOne(d => d.DivisionNavigation)
                    .WithMany(p => p.TeamDivisions)
                    .HasForeignKey(d => d.Division)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Division_Team_FK");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.TeamDivisions)
                    .HasForeignKey(d => d.Team)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Team_Division_FK");
            });

            modelBuilder.Entity<TeamMatch>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatePlayed).HasColumnType("date");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AwayTeamNavigation)
                    .WithMany(p => p.TeamMatchAwayTeamNavigations)
                    .HasForeignKey(d => d.AwayTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AwayTeam_FK");

                entity.HasOne(d => d.HomeTeamNavigation)
                    .WithMany(p => p.TeamMatchHomeTeamNavigations)
                    .HasForeignKey(d => d.HomeTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HomeTeam_FK");

                entity.HasOne(d => d.SeasonNavigation)
                    .WithMany(p => p.TeamMatchSeasonNavigations)
                    .HasForeignKey(d => d.Season)
                    .HasConstraintName("Season_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
