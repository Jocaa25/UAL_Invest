using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UAL_Invest.Models;

#nullable disable

namespace UAL_Invest.Context
{
    public partial class UalContext : DbContext
    {
        public UalContext()
        {
        }

        public UalContext(DbContextOptions<UalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ativo> Ativos { get; set; }
        public virtual DbSet<AtivosWallet> AtivosWallets { get; set; }
        public virtual DbSet<ExtratoWallet> ExtratoWallets { get; set; }
        public virtual DbSet<TipoRendum> TipoRenda { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=UalInvest;Data Source=localhost;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Ativo>(entity =>
            {
                entity.Property(e => e.AtivoId).HasColumnName("AtivoID");

                entity.Property(e => e.NomeAtivo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoAtivo)
                    .HasColumnType("money")
                    .HasColumnName("precoAtivo");

                entity.Property(e => e.TipoRendaId).HasColumnName("TipoRendaID");

                entity.HasOne(d => d.TipoRenda)
                    .WithMany(p => p.Ativos)
                    .HasForeignKey(d => d.TipoRendaId)
                    .HasConstraintName("FK__Ativos__TipoRend__3A81B327");
            });

            modelBuilder.Entity<AtivosWallet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ativosWallet");

                entity.Property(e => e.AtivoId).HasColumnName("ativoID");

                entity.HasOne(d => d.Ativo)
                    .WithMany()
                    .HasForeignKey(d => d.AtivoId)
                    .HasConstraintName("FK_AtivoWallet_01");

                entity.HasOne(d => d.Wallet)
                    .WithMany()
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK_AtivoWallet_02");
            });

            modelBuilder.Entity<ExtratoWallet>(entity =>
            {
                entity.ToTable("ExtratoWallet");

                entity.Property(e => e.ExtratoWalletId).HasColumnName("ExtratoWalletID");

                entity.Property(e => e.AtivoId).HasColumnName("AtivoID");

                entity.Property(e => e.DataHoraInclusao).HasColumnType("datetime");

                entity.Property(e => e.TipoOperacao)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.ValorAtivo).HasColumnType("money");

                entity.HasOne(d => d.Ativo)
                    .WithMany(p => p.ExtratoWallets)
                    .HasForeignKey(d => d.AtivoId)
                    .HasConstraintName("FK_ExtratoWallet_01");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ExtratoWallets)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_ExtratoWallet_02");
            });

            modelBuilder.Entity<TipoRendum>(entity =>
            {
                entity.HasKey(e => e.TipoRendaId)
                    .HasName("PK__TipoRend__B672355F5ECC6E04");

                entity.Property(e => e.TipoRendaId).HasColumnName("TipoRendaID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.DataDeNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GerenteId).HasColumnName("GerenteID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuarioID");

                entity.Property(e => e.WalletId).HasColumnName("WalletID");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__Usuario__TipoUsu__412EB0B6");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK__Usuario__WalletI__4222D4EF");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.WalletId).HasColumnName("WalletID");

                entity.Property(e => e.Saldo).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
