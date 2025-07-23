using Takenplanner.Core.Models;
using Takenplanner.Core.Interfaces;

namespace Takenplanner.Core.Services;

public class TaakService : ITaakService
{
  private readonly List<Taak> _taken = new();

  public List<Taak> GetAlleTaken()
  {
    return _taken;
  }

  public Taak? GetTaakById(Guid id)
  {
    return _taken.FirstOrDefault(t => t.Id == id);
  }

  public Taak VoegTaakToe(Taak taak)
  {
    _taken.Add(taak);
    return taak;
  }

  public bool VerwijderTaak(Guid id)
  {
    var taak = GetTaakById(id);
    if (taak is null) return false;
    return _taken.Remove(taak);
  }

  public bool MarkeerAlsVoltooid(Guid id)
  {
    var taak = GetTaakById(id);
    if (taak is null) return false;
    taak.IsVoltooid = true;
    return true;
  }
}