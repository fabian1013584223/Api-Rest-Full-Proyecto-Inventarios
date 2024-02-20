using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
                new Categoria
                {
                    IdCategoria = new Guid("4F9A7CDB-C6DD-4C1C-8CA2-88F34C913C54"),
                    Nombre = "Portatiles"   
                },
                new Categoria
                {
                    IdCategoria = new Guid("B130F449-A5F3-4E3E-A165-D73C3B73A241"),
                    Nombre = "Auriculares"
                },
                new Categoria
                {
                    IdCategoria = new Guid("5AF38236-256E-4DED-A81E-8010F08C51B6"),
                    Nombre = "Implementos"
                }
            );
        }
    }
}
