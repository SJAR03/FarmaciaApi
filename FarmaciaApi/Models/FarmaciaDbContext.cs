using FarmaciaApi.Models.Security;
using FarmaciaApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace FarmaciaApi.Models
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options) : base(options)
        {
            var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if(dbCreater != null)
            {
                // Create the database if it doesn't exist
                if(!dbCreater.CanConnect())
                {
                    dbCreater.Create();
                }

                // Create the tables if they don't exist
                if(!dbCreater.HasTables())
                {
                    dbCreater.CreateTables();
                }
            }
        }

        //Security
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRoles> UsuarioRoles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<RolesPermisos> PermisosRoles { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

        //Pharmacy
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Prescripcion> Prescripciones { get; set; }
        public DbSet<PrescripcionDetalle> PrescripcionDetalles { get; set; }
        public DbSet<LoteFarmaco> LoteFarmacos { get; set; }
        public DbSet<FarmacoPresentacion> LoteFarmacoDetalles { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<Dosificacion> Dosificaciones { get; set; }

        //Views
        //public DbSet<PresentacionView> PresentacionView { get; set; }
        //public DbSet<LoteFarmacosView> LoteFarmacosView { get; set; }
        //public DbSet<ExpedienteView> ExpedienteView { get; set; }
        //public DbSet<PrescripcionView> PrescripcionView { get; set; }
        //public DbSet<PrescripcionDetalleView> PrescripcionDetalleView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships between tables

            // Security

            // Auditoria
            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // UsuarioRoles
            modelBuilder.Entity<UsuarioRoles>()
                .HasOne(ur => ur.Usuario)
                .WithMany()
                .HasForeignKey(ur => ur.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRoles>()
                .HasOne(ur => ur.Rol)
                .WithMany()
                .HasForeignKey(ur => ur.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // RolesPermisos
            modelBuilder.Entity<RolesPermisos>()
                .HasOne(rp => rp.Permisos)
                .WithMany()
                .HasForeignKey(rp => rp.IdPermisos)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolesPermisos>()
                .HasOne(rp => rp.Rol)
                .WithMany()
                .HasForeignKey(rp => rp.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // Pharmacy

            // Paciente
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(p => p.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(p => p.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Expediente
            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Prescripcion
            modelBuilder.Entity<Prescripcion>()
                .HasOne(e => e.Expediente)
                .WithMany()
                .HasForeignKey(e => e.IdExpediente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescripcion>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescripcion>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // PrescripcionDetalle
            modelBuilder.Entity<PrescripcionDetalle>()
                .HasOne(e => e.Prescripcion)
                .WithMany()
                .HasForeignKey(e => e.IdPrescripcion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrescripcionDetalle>()
                .HasOne(e => e.FarmacoPresentacion)
                .WithMany()
                .HasForeignKey(e => e.IdFarmacoPresentacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrescripcionDetalle>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrescripcionDetalle>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // LoteFarmaco
            modelBuilder.Entity<LoteFarmaco>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LoteFarmaco>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // LoteFarmacoDetalles
            modelBuilder.Entity<FarmacoPresentacion>()
                .HasOne(e => e.LoteFarmaco)
                .WithMany()
                .HasForeignKey(e => e.IdLoteFarmaco)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FarmacoPresentacion>()
                .HasOne(e => e.Presentacion)
                .WithMany()
                .HasForeignKey(e => e.IdPresentacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FarmacoPresentacion>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FarmacoPresentacion>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Presentacion
            modelBuilder.Entity<Presentacion>()
                .HasOne(m => m.Medidas)
                .WithMany()
                .HasForeignKey(m => m.IdMedidas)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presentacion>()
                .HasOne(d => d.Dosificacion)
                .WithMany()
                .HasForeignKey(d => d.IdDosificacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presentacion>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presentacion>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Medidas
            modelBuilder.Entity<Medidas>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Medidas>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Dosificacion
            modelBuilder.Entity<Dosificacion>()
                .HasOne(e => e.UsuarioCreacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dosificacion>()
                .HasOne(e => e.UsuarioModificacion)
                .WithMany()
                .HasForeignKey(e => e.IdUsuarioModificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Views
            //modelBuilder.Entity<PresentacionView>().HasNoKey();
            //modelBuilder.Entity<LoteFarmacosView>().HasNoKey();
            //modelBuilder.Entity<ExpedienteView>().HasNoKey();
            //modelBuilder.Entity<PrescripcionView>().HasNoKey();
            //modelBuilder.Entity<PrescripcionDetalleView>().HasNoKey();
        }

    }
}
