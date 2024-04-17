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
            modelBuilder.Entity<Expediente>().HasKey(e => new { e.IdExpediente, e.IdPaciente });
            //modelBuilder.Entity<Expediente>().HasOne(e => e.Paciente).WithMany(p => p.Expedientes).HasForeignKey(e => e.IdPaciente);
            //modelBuilder.Entity<Expediente>().HasOne(e => e.Usuario).WithMany(u => u.Expedientes).HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<LoteFarmaco>().HasKey(lf => new { lf.IdLoteFarmaco, lf.IdPresentacion, lf.IdMedidas, lf.IdDosificacion });

            modelBuilder.Entity<PermisosRol>().HasKey(pr => new { pr.IdPermisos, pr.IdRol });
            //modelBuilder.Entity<PermisosRol>().HasOne(pr => pr.Permisos).WithMany(p => p.PermisosRoles).HasForeignKey(pr => pr.IdPermisos);
            //modelBuilder.Entity<PermisosRol>().HasOne(pr => pr.Rol).WithMany(r => r.PermisosRoles).HasForeignKey(pr => pr.IdRol);

            modelBuilder.Entity<Prescripcion>().HasKey(p => new { p.IdPrescripcion, p.IdExpediente, p.IdPaciente });
            //modelBuilder.Entity<Prescripcion>().HasOne(p => p.Expediente).WithMany(e => e.Prescripciones).HasForeignKey(p => new { p.IdExpediente, p.IdPaciente });

            modelBuilder.Entity<PrescripcionDetalle>().HasKey(pd => new { pd.IdPrescripcionDetalle, pd.IdLoteFarmaco, pd.IdPresentacion, pd.IdMedidas, pd.IdDosificacion, pd.IdPrescripcion, pd.IdExpediente, pd.IdPaciente });
            //modelBuilder.Entity<PrescripcionDetalle>().HasOne(pd => pd.LoteFarmaco).WithMany(lf => lf.PrescripcionDetalles).HasForeignKey(pd => new { pd.IdLoteFarmaco, pd.IdPresentacion, pd.IdMedidas, pd.IdDosificacion });
            //modelBuilder.Entity<PrescripcionDetalle>().HasOne(pd => pd.Prescripcion).WithMany(p => p.PrescripcionDetalles).HasForeignKey(pd => new { pd.IdPrescripcion, pd.IdExpediente, pd.IdPaciente });

            modelBuilder.Entity<Presentacion>().HasKey(p => new { p.IdPresentacion, p.IdMedidas, p.IdDosificacion });
            //modelBuilder.Entity<Presentacion>().HasOne(p => p.Medidas).WithMany(m => m.Presentaciones).HasForeignKey(p => p.IdMedidas);
            //modelBuilder.Entity<Presentacion>().HasOne(p => p.Dosificacion).WithMany(d => d.Presentaciones).HasForeignKey(p => p.IdDosificacion);

            modelBuilder.Entity<UsuarioRol>().HasKey(ur => new { ur.IdUsuario, ur.IdRol });
            //modelBuilder.Entity<UsuarioRol>().HasOne(ur => ur.Usuario).WithMany(u => u.UsuarioRoles).HasForeignKey(ur => ur.IdUsuario);
            //modelBuilder.Entity<UsuarioRol>().HasOne(ur => ur.Rol).WithMany(r => r.UsuarioRoles).HasForeignKey(ur => ur.IdRol);
        }

    }
}
