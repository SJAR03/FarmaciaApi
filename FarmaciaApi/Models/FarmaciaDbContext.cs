using Microsoft.EntityFrameworkCore;

namespace FarmaciaApi.Models
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options)
        {
        }

        public DbSet<Dosificacion> Dosificaciones { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<LoteFarmaco> LoteFarmacos { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<PermisosRol> PermisosRoles { get; set; }
        public DbSet<Prescripcion> Prescripciones { get; set; }
        public DbSet<PrescripcionDetalle> PrescripcionDetalles { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Paciente)
                .WithOne(p => p.Expediente)
                .HasForeignKey<Expediente>(e => e.IdPaciente);

            modelBuilder.Entity<Expediente>()
                .HasMany(e => e.Prescripciones)
                .WithOne(p => p.Expediente)
                .HasForeignKey(p => p.IdPrescripcion);

            modelBuilder.Entity<Prescripcion>()
                .HasMany(p => p.PrescripcionDetalles)
                .WithOne(pd => pd.Prescripcion)
                .HasForeignKey(pd => pd.IdPrescripcionDetalle);

            modelBuilder.Entity<LoteFarmaco>()
                .HasMany(pd => pd.PrescripcionDetalles)
                .WithOne(p => p.LoteFarmaco)
                .HasForeignKey(pd => pd.IdPrescripcionDetalle);

            modelBuilder.Entity<Presentacion>()
                .HasMany(p => p.LoteFarmacos)
                .WithOne(l => l.Presentacion)
                .HasForeignKey(p => p.IdLoteFarmaco);

            modelBuilder.Entity<Presentacion>()
                .HasOne(p => p.Medidas)
                .WithMany(m => m.Presentaciones)
                .HasForeignKey(p => p.IdMedidas);

            modelBuilder.Entity<Presentacion>()
                .HasOne(p => p.Dosificacion)
                .WithMany(d => d.Presentaciones)
                .HasForeignKey(p => p.IdDosificacion);

            modelBuilder.Entity<Rol>()
                .HasMany(r => r.UsuarioRols)
                .WithOne(u => u.Rol)
                .HasForeignKey(u => u.IdUsuarioRol);

            modelBuilder.Entity<Rol>()
                .HasMany(r => r.permisosRols)
                .WithOne(pr => pr.Rol)
                .HasForeignKey(pr => pr.IdPermisosRol);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.UsuarioRols)
                .WithOne(ur => ur.Usuario)
                .HasForeignKey(ur => ur.IdUsuarioRol);

            modelBuilder.Entity<Permisos>()
                .HasMany(p => p.PermisosRols)
                .WithOne(pr => pr.Permisos)
                .HasForeignKey(pr => pr.IdPermisosRol);

        }

    }
}
