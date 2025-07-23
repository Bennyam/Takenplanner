using Takenplanner.Core.Models;
using Takenplanner.Core.Services;

namespace Takenplanner.Tests.Services;

public class TaakServiceTests
{
    [Fact]
    public void VoegTaakToe_VoegtTaakCorrectToe()
    {
        var service = new TaakService();
        var taak = new Taak { Naam = "Test", Beschrijving = "Test taak" };

        var resultaat = service.VoegTaakToe(taak);

        Assert.Single(service.GetAlleTaken());
        Assert.Equal("Test", resultaat.Naam);
        Assert.False(resultaat.IsVoltooid);
    }

    [Fact]
    public void GetAlleTaken_GeeftAlleTakenTerug()
    {
        var service = new TaakService();
        service.VoegTaakToe(new Taak { Naam = "1" });
        service.VoegTaakToe(new Taak { Naam = "2" });

        var taken = service.GetAlleTaken();

        Assert.Equal(2, taken.Count);
    }

    [Fact]
    public void GetTaakById_GeeftCorrecteTaak()
    {
        var service = new TaakService();
        var taak = new Taak { Naam = "Zoek mij" };
        service.VoegTaakToe(taak);

        var gevonden = service.GetTaakById(taak.Id);

        Assert.NotNull(gevonden);
        Assert.Equal("Zoek mij", gevonden?.Naam);
    }

    [Fact]
    public void VewijderTaak_VerwijdertCorrect()
    {
        var service = new TaakService();
        var taak = new Taak { Naam = "Verwijder mij" };
        service.VoegTaakToe(taak);

        var succes = service.VerwijderTaak(taak.Id);

        Assert.True(succes);
        Assert.Empty(service.GetAlleTaken());
    }

    [Fact]
    public void MarkeerAlsVoltooid_WerktCorrect()
    {
        var service = new TaakService();
        var taak = new Taak { Naam = "Voltooi mij" };
        service.VoegTaakToe(taak);

        var succes = service.MarkeerAlsVoltooid(taak.Id);
        var resultaat = service.GetTaakById(taak.Id);

        Assert.True(succes);
        Assert.True(resultaat?.IsVoltooid);
    }
}