using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderViewer.Core.Contexts;

namespace OrderViewer.Core.Factories
{
    public class OrderViewerContextFactory : IDesignTimeDbContextFactory<OrderViewerContext>
    {
        public OrderViewerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderViewerContext>();
            
            //TODO Строку подключения брать из appsettings
            optionsBuilder.UseSqlite("Filename=OrderViewer.db");
            
            return new OrderViewerContext(optionsBuilder.Options);
        }
    }
}