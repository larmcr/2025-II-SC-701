using DI.Interfaces;

namespace DI.Services;

class Aleatorio : IAleatorio
{
  private readonly Random _random;

  public Aleatorio(IFechaHora fechaHora)
  {
    _random = new Random(fechaHora.Actual.Millisecond);
  }

  public int Entero => _random.Next();

  public double Flotante => _random.NextDouble();
}