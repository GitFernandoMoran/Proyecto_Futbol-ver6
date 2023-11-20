using Base_Datos.Shared.Modelos;
using Microsoft.EntityFrameworkCore;
namespace Base_Datos.Server.Data
{
    public class DataFutbolDBContext : DbContext
    {
        public DataFutbolDBContext(DbContextOptions<DataFutbolDBContext> options) : base(options)
        {

        }
        //Tablas de mi base de datos
        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Confederacion> Confederaciones { get; set; }
    }
}
