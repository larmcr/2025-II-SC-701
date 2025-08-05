using DI.Interfaces;

namespace DI.Services;

class FechaHoraLocal : IFechaHora
{
  public DateTime Actual => DateTime.Now;
}