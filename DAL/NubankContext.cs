namespace ArmazemModel.DAL
{
    using Model;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class NubankContext : DbContext
    {
        public NubankContext()
            : base("name=NubankContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<Fatura> Produto { get; set; }
        public virtual DbSet<Lancamento> Composicao { get; set; }
    }
}