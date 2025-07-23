namespace Takenplanner.Core.Models;

public class Taak
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Naam { get; set; } = string.Empty;
  public string Beschrijving { get; set; } = string.Empty;
  public bool IsVoltooid { get; set; } = false;
  public DateTime? Deadline { get; set; }
}