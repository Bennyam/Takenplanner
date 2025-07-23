using Takenplanner.Core.Models;

namespace Takenplanner.Core.Interfaces;

public interface ITaakService
{
  List<Taak> GetAlleTaken();
  Taak? GetTaakById(Guid id);
  Taak VoegTaakToe(Taak taak);
  bool VerwijderTaak(Guid id);
  bool MarkeerAlsVoltooid(Guid id);
}

