public class Tiempos : DbContext
{
  public DbSet<Horario> Horarios { get; set; }
  public DbSet<Sorteo> Sorteos { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite($"Data Source={Path.Combine(Environment.CurrentDirectory, "data", "tiempos.db")}");
  }
}

public class Horario
{
  public int HorarioId { get; set; }
  public string? Descripcion { get; set; }
}

public class Sorteo
{
  public int SorteoId { get; set; }
  public DateTime FechaHora { get; set; }
  public int Numero { get; set; }
  public int HorarioId { get; set; }
  public Horario? Horario { get; set; }
}

