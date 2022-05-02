using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CovoitAdmin2.Model
{
    public partial class covoitContext : DbContext
    {
        public covoitContext()
        {
        }

        public covoitContext(DbContextOptions<covoitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<EndPoint> EndPoints { get; set; }
        public virtual DbSet<Motorization> Motorizations { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Path> Paths { get; set; }
        public virtual DbSet<StartingPoint> StartingPoints { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VillesFranceFree> VillesFranceFrees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                /*optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=covoit");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver)
                    .HasName("PRIMARY");

                entity.ToTable("driver");

                entity.HasIndex(e => e.IdVehicles, "constraint_id_vehicles");

                entity.HasIndex(e => e.IdTrip, "constraint_trip2");

                entity.HasIndex(e => e.IdUser, "constraint_user2");

                entity.Property(e => e.IdDriver)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_driver");

                entity.Property(e => e.IdTrip)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_trip");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.IdVehicles)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vehicles");
            });

            modelBuilder.Entity<EndPoint>(entity =>
            {
                entity.HasKey(e => e.IdEndPoint)
                    .HasName("PRIMARY");

                entity.ToTable("end_point");

                entity.HasIndex(e => e.IdCity, "constraint_id_city_end_point2");

                entity.HasIndex(e => e.IdPath, "constraint_path_id2");

                entity.Property(e => e.IdEndPoint)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_end_point");

                entity.Property(e => e.IdCity)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_city");

                entity.Property(e => e.IdPath)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_path");
            });

            modelBuilder.Entity<Motorization>(entity =>
            {
                entity.HasKey(e => e.IdMotorization)
                    .HasName("PRIMARY");

                entity.ToTable("motorization");

                entity.Property(e => e.IdMotorization)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_motorization");

                entity.Property(e => e.Libellet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("libellet");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPassenger)
                    .HasName("PRIMARY");

                entity.ToTable("passenger");

                entity.HasIndex(e => e.IdPath, "constraint_path");

                entity.HasIndex(e => e.IdUser, "constraint_user");

                entity.Property(e => e.IdPassenger)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_passenger");

                entity.Property(e => e.IdPath)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_path");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");
            });

            modelBuilder.Entity<Path>(entity =>
            {
                entity.HasKey(e => e.IdPath)
                    .HasName("PRIMARY");

                entity.ToTable("paths");

                entity.HasIndex(e => e.IdTrip, "constraint_trip");

                entity.Property(e => e.IdPath)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_path");

                entity.Property(e => e.DepartureTime).HasColumnName("departure_time");

                entity.Property(e => e.IdTrip)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_trip");
            });

            modelBuilder.Entity<StartingPoint>(entity =>
            {
                entity.HasKey(e => e.IdStartingPoint)
                    .HasName("PRIMARY");

                entity.ToTable("starting_point");

                entity.HasIndex(e => e.IdCity, "constraint_id_city_starting_point");

                entity.HasIndex(e => e.IdPath, "constraint_path_id");

                entity.Property(e => e.IdStartingPoint)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_starting_point");

                entity.Property(e => e.IdCity)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_city");

                entity.Property(e => e.IdPath)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_path");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.IdTrip)
                    .HasName("PRIMARY");

                entity.ToTable("trips");

                entity.Property(e => e.IdTrip)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_trip");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("date")
                    .HasColumnName("starting_date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.Administrator).HasColumnName("administrator");

                entity.Property(e => e.Contacts).HasColumnName("contacts");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("f_name");

                entity.Property(e => e.ImgProfil)
                    .HasMaxLength(500)
                    .HasColumnName("img_profil");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("l_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.Tel)
                    .HasColumnType("int(10)")
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.IdVehicles)
                    .HasName("PRIMARY");

                entity.ToTable("vehicles");

                entity.HasIndex(e => e.IdMotorization, "constraint_id_motorization");

                entity.HasIndex(e => e.IdUser, "constraint_id_user");

                entity.Property(e => e.IdVehicles)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_vehicles");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("color");

                entity.Property(e => e.DateCreate).HasColumnName("date_create");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.IdMotorization)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_motorization");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.NbPlaces)
                    .HasColumnType("int(5)")
                    .HasColumnName("nb_places");

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vehicle_name");
            });

            modelBuilder.Entity<VillesFranceFree>(entity =>
            {
                entity.HasKey(e => e.VilleId)
                    .HasName("PRIMARY");

                entity.ToTable("villes_france_free");

                entity.HasIndex(e => e.VilleCodeCommune, "ville_code_commune");

                entity.HasIndex(e => e.VilleCodeCommune, "ville_code_commune_2")
                    .IsUnique();

                entity.HasIndex(e => e.VilleCodePostal, "ville_code_postal");

                entity.HasIndex(e => e.VilleDepartement, "ville_departement");

                entity.HasIndex(e => new { e.VilleLongitudeDeg, e.VilleLatitudeDeg }, "ville_longitude_latitude_deg");

                entity.HasIndex(e => e.VilleNom, "ville_nom");

                entity.HasIndex(e => e.VilleNomMetaphone, "ville_nom_metaphone");

                entity.HasIndex(e => e.VilleNomReel, "ville_nom_reel");

                entity.HasIndex(e => e.VilleNomSimple, "ville_nom_simple");

                entity.HasIndex(e => e.VilleNomSoundex, "ville_nom_soundex");

                entity.HasIndex(e => e.VillePopulation2010, "ville_population_2010");

                entity.HasIndex(e => e.VilleSlug, "ville_slug")
                    .IsUnique();

                entity.Property(e => e.VilleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ville_id");

                entity.Property(e => e.VilleAmdi)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("ville_amdi");

                entity.Property(e => e.VilleArrondissement)
                    .HasColumnType("smallint(3) unsigned")
                    .HasColumnName("ville_arrondissement");

                entity.Property(e => e.VilleCanton)
                    .HasMaxLength(4)
                    .HasColumnName("ville_canton");

                entity.Property(e => e.VilleCodeCommune)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("ville_code_commune");

                entity.Property(e => e.VilleCodePostal)
                    .HasMaxLength(255)
                    .HasColumnName("ville_code_postal");

                entity.Property(e => e.VilleCommune)
                    .HasMaxLength(3)
                    .HasColumnName("ville_commune");

                entity.Property(e => e.VilleDensite2010)
                    .HasColumnType("int(11)")
                    .HasColumnName("ville_densite_2010");

                entity.Property(e => e.VilleDepartement)
                    .HasMaxLength(3)
                    .HasColumnName("ville_departement");

                entity.Property(e => e.VilleLatitudeDeg).HasColumnName("ville_latitude_deg");

                entity.Property(e => e.VilleLatitudeDms)
                    .HasMaxLength(8)
                    .HasColumnName("ville_latitude_dms");

                entity.Property(e => e.VilleLatitudeGrd)
                    .HasMaxLength(8)
                    .HasColumnName("ville_latitude_grd");

                entity.Property(e => e.VilleLongitudeDeg).HasColumnName("ville_longitude_deg");

                entity.Property(e => e.VilleLongitudeDms)
                    .HasMaxLength(9)
                    .HasColumnName("ville_longitude_dms");

                entity.Property(e => e.VilleLongitudeGrd)
                    .HasMaxLength(9)
                    .HasColumnName("ville_longitude_grd");

                entity.Property(e => e.VilleNom)
                    .HasMaxLength(45)
                    .HasColumnName("ville_nom");

                entity.Property(e => e.VilleNomMetaphone)
                    .HasMaxLength(22)
                    .HasColumnName("ville_nom_metaphone");

                entity.Property(e => e.VilleNomReel)
                    .HasMaxLength(45)
                    .HasColumnName("ville_nom_reel");

                entity.Property(e => e.VilleNomSimple)
                    .HasMaxLength(45)
                    .HasColumnName("ville_nom_simple");

                entity.Property(e => e.VilleNomSoundex)
                    .HasMaxLength(20)
                    .HasColumnName("ville_nom_soundex");

                entity.Property(e => e.VillePopulation1999)
                    .HasColumnType("mediumint(11) unsigned")
                    .HasColumnName("ville_population_1999");

                entity.Property(e => e.VillePopulation2010)
                    .HasColumnType("mediumint(11) unsigned")
                    .HasColumnName("ville_population_2010");

                entity.Property(e => e.VillePopulation2012)
                    .HasColumnType("mediumint(10) unsigned")
                    .HasColumnName("ville_population_2012")
                    .HasComment("approximatif");

                entity.Property(e => e.VilleSlug)
                    .HasMaxLength(255)
                    .HasColumnName("ville_slug");

                entity.Property(e => e.VilleSurface).HasColumnName("ville_surface");

                entity.Property(e => e.VilleZmax)
                    .HasColumnType("mediumint(4)")
                    .HasColumnName("ville_zmax");

                entity.Property(e => e.VilleZmin)
                    .HasColumnType("mediumint(4)")
                    .HasColumnName("ville_zmin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
