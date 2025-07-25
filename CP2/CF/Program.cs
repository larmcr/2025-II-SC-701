
void CargarDatos()
{
  using var db = new Tiempos();
  if (!db.Horarios.Any())
  {
    Console.Write("\nCargando datos...");
    var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "data", "tiempos.csv")).Skip(1).ToList();
    var horarios = new HashSet<string>();
    lines.ForEach((line) =>
    {
      var parts = line.Split(',');
      horarios.Add(parts[0]);
    });
    var horariosIds = new Dictionary<string, int>();
    var horarioId = 1;
    horarios.ToList().ForEach((descripcion) =>
    {
      horariosIds.Add(descripcion, horarioId);
      var horario = new Horario
      {
        HorarioId = horarioId,
        Descripcion = descripcion,
      };
      db.Horarios.Add(horario);
      horarioId++;
    });
    lines.ForEach((line) =>
    {
      var parts = line.Split(',');
      var sorteo = new Sorteo
      {
        SorteoId = int.Parse(parts[2]),
        FechaHora = DateTime.Parse(parts[1]),
        Numero = int.Parse(parts[3]),
        HorarioId = horariosIds[parts[0]],
      };
      db.Sorteos.Add(sorteo);
    });
    db.SaveChanges();
    Console.Write(" Listo.\n");
  }
  else
  {
    Console.WriteLine("\nDatos ya fueron cargados");
  }
}

void GuardarDatos()
{
  Console.Write("\nGuardando datos...");
  using var db = new Tiempos();
  var query = from sorteo in db.Sorteos
              join horario in db.Horarios
              on sorteo.HorarioId equals horario.HorarioId
              orderby sorteo.FechaHora ascending
              select new QueryItem
              {
                FechaHora = sorteo.FechaHora,
                Horario = $"{horario.Descripcion}",
                Sorteo = $"{sorteo.SorteoId}",
                Numero = $"{sorteo.Numero}",
              };
  var dictionary = new Dictionary<int, List<QueryItem>>();
  query.ToList().ForEach((item) =>
  {
    var key = item.FechaHora.Year;
    if (!dictionary.ContainsKey(key))
    {
      dictionary.Add(key, []);
    }
    dictionary[key].Add(item);
  });
  dictionary.Keys.ToList().ForEach((key) =>
  {
    var list = dictionary[key];
    var lines = new List<string>() { "Fecha,Horario,Sorteo,Numero" };
    list.ForEach((item) =>
    {
      lines.Add($"{item.FechaHora.ToString("yyyy-MM-dd")},{item.Horario},{item.Sorteo},{item.Numero}");
    });
    File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, "data", $"{key}.csv"), lines);
  });
  Console.Write(" Listo.\n");
}

internal record QueryItem
{
  public DateTime FechaHora;
  public string Horario;
  public string Sorteo;
  public string Numero;
}