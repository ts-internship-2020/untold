using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class untoldContext : DbContext
    {
        public untoldContext()
        {
        }

        public untoldContext(DbContextOptions<untoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendee> Attendee { get; set; }
        public virtual DbSet<Conference> Conference { get; set; }
        public virtual DbSet<ConferenceXspeaker> ConferenceXspeaker { get; set; }
        public virtual DbSet<Demo> Demo { get; set; }
        public virtual DbSet<DictionaryCity> DictionaryCity { get; set; }
        public virtual DbSet<DictionaryConferenceCategory> DictionaryConferenceCategory { get; set; }
        public virtual DbSet<DictionaryConferenceType> DictionaryConferenceType { get; set; }
        public virtual DbSet<DictionaryCountry> DictionaryCountry { get; set; }
        public virtual DbSet<DictionaryCounty> DictionaryCounty { get; set; }
        public virtual DbSet<DictionaryStatus> DictionaryStatus { get; set; }
        public virtual DbSet<Import> Import { get; set; }
        public virtual DbSet<ImportCities> ImportCities { get; set; }
        public virtual DbSet<ImportCounty> ImportCounty { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<VwConferenceDetails> VwConferenceDetails { get; set; }
        public virtual DbSet<VwConferencesForPagination> VwConferencesForPagination { get; set; }
        public virtual DbSet<VwExtendedConferenceDetails> VwExtendedConferenceDetails { get; set; }
        public virtual DbSet<VwLocationIds> VwLocationIds { get; set; }
        public virtual DbSet<VwLocationName> VwLocationName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ts-internship-2019.database.windows.net;Database=untold;User Id=usr2020;Password=n39fn0n2_j32-(#;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.HasKey(e => new { e.ConferenceId, e.AttendeeEmail })
                    .HasName("PK__Attendee__78F1509D6BA1AA0A");

                entity.HasIndex(e => e.EmailCode)
                    .HasName("UQ__Attendee__DB8F91659716D444")
                    .IsUnique();

                entity.Property(e => e.AttendeeEmail).HasMaxLength(255);

                entity.Property(e => e.EmailCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.Attendee)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendee__Confer__1A9EF37A");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Attendee)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attendee__Status__1C873BEC");
            });

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.Property(e => e.ConferenceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailOrganizer)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConferenceCategory)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.ConferenceCategoryId)
                    .HasConstraintName("FK__Conferenc__Confe__0E391C95");

                entity.HasOne(d => d.ConferenceType)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.ConferenceTypeId)
                    .HasConstraintName("FK__Conferenc__Confe__0F2D40CE");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Conferenc__Locat__10216507");

                entity.HasOne(d => d.MainSpeaker)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.MainSpeakerId)
                    .HasConstraintName("FK__Conferenc__MainS__11158940");
            });

            modelBuilder.Entity<ConferenceXspeaker>(entity =>
            {
                entity.HasKey(e => new { e.ConferenceId, e.SpeakerId })
                    .HasName("PK__Conferen__CD0B8006016EA5C2");

                entity.ToTable("ConferenceXSpeaker");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceXspeaker)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Conferenc__Confe__15DA3E5D");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.ConferenceXspeaker)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Conferenc__Speak__16CE6296");
            });

            modelBuilder.Entity<Demo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DictionaryCity>(entity =>
            {
                entity.Property(e => e.DictionaryCityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.DictionaryCity)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dictionar__Count__719CDDE7");
            });

            modelBuilder.Entity<DictionaryConferenceCategory>(entity =>
            {
                entity.HasIndex(e => e.ConferenceCategoryName)
                    .HasName("UQ__Dictiona__2507D64174E01DF7")
                    .IsUnique();

                entity.Property(e => e.DictionaryConferenceCategoryId).ValueGeneratedNever();

                entity.Property(e => e.ConferenceCategoryName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryConferenceType>(entity =>
            {
                entity.HasIndex(e => e.ConferenceTypeName)
                    .HasName("UQ__Dictiona__EAB10679D13DCBA4")
                    .IsUnique();

                entity.Property(e => e.DictionaryConferenceTypeId).ValueGeneratedNever();

                entity.Property(e => e.ConferenceTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCountry>(entity =>
            {
                entity.HasIndex(e => e.CountryCode)
                    .HasName("UQ__Dictiona__5D9B0D2C8BCBAF2F")
                    .IsUnique();

                entity.HasIndex(e => e.CountryName)
                    .HasName("UQ__Dictiona__E056F20136B4EE90")
                    .IsUnique();

                entity.Property(e => e.DictionaryCountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCounty>(entity =>
            {
                entity.Property(e => e.DictionaryCountyId).ValueGeneratedNever();

                entity.Property(e => e.CountyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.DictionaryCounty)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dictionar__Count__6EC0713C");
            });

            modelBuilder.Entity<DictionaryStatus>(entity =>
            {
                entity.HasIndex(e => e.StatusName)
                    .HasName("UQ__Dictiona__05E7698AD0A9461F")
                    .IsUnique();

                entity.Property(e => e.DictionaryStatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CityName).HasMaxLength(255);

                entity.Property(e => e.CountryCode).HasMaxLength(255);

                entity.Property(e => e.CountryName).HasMaxLength(255);
            });

            modelBuilder.Entity<ImportCities>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CityName).HasMaxLength(255);
            });

            modelBuilder.Entity<ImportCounty>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CountyName).HasMaxLength(255);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Location__CityId__7B264821");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('Not Mentioned')");
            });

            modelBuilder.Entity<VwConferenceDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwConferenceDetails");

                entity.Property(e => e.ConferenceCategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferenceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferencePeriod)
                    .IsRequired()
                    .HasMaxLength(83)
                    .IsUnicode(false);

                entity.Property(e => e.ConferenceTypeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailOrganizer)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(768);

                entity.Property(e => e.SpeakerName)
                    .IsRequired()
                    .HasMaxLength(511);
            });

            modelBuilder.Entity<VwConferencesForPagination>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwConferencesForPagination");

                entity.Property(e => e.ConferenceCategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferenceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferencePeriod)
                    .IsRequired()
                    .HasMaxLength(83)
                    .IsUnicode(false);

                entity.Property(e => e.ConferenceTypeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailOrganizer)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(768);

                entity.Property(e => e.RowNum).HasColumnName("row_num");

                entity.Property(e => e.SpeakerName)
                    .IsRequired()
                    .HasMaxLength(511);
            });

            modelBuilder.Entity<VwExtendedConferenceDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwExtendedConferenceDetails");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferenceCategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferenceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ConferenceTypeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmailOrganizer)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwLocationIds>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwLocationIds");
            });

            modelBuilder.Entity<VwLocationName>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwLocationName");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CountyName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
