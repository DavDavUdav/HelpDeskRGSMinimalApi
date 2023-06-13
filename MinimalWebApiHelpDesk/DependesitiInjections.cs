using Microsoft.EntityFrameworkCore;
using MinimalWebApiHelpDesk.Interfaces;
using ServerAppHelpDesk.DataBase;

namespace MinimalWebApiHelpDesk
{
    /*
    public static class DependesitiInjections
    {
        public static DataStore AddPersistance(this IServiceCollection serviceCollection, IConfiguration sCollection)
        {
            var connectionString = sCollection.GetSection("ConnectionStrings").Value;

            serviceCollection.AddDbContext<DataStoreDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            serviceCollection.AddScoped<IDataStore>(provider =>
            {
                var option = provider.GetRequiredService<DbContextOptions<DataStoreDbContext>>();
                return new DataStore(option);
            });
            return null;
        }
    }
    */
}
