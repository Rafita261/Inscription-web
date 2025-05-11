using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MySqlConnector;

namespace Inscription.Pages;

public class InscrireModel : PageModel
{
    private readonly ILogger<InscrireModel> _logger;
    public InscrireModel(ILogger<InscrireModel> logger)
    {
        _logger = logger;
    }

    public List<List<string>> GetFormulaires(string ecole, string idecole)
    {
        List<List<string>> forms = new List<List<string>>();
        List<string> attributs = new List<string>();
        List<string> types = new List<string>();

        const string connectionString = "Server=localhost;User ID=chris;Password=Chriskely@123;Database=Inscription";

        try
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ATTRIBUT_FORMULAIRE WHERE ID_ECOLE = '" + idecole + "' AND YEAR(ANNEE)=YEAR(CURDATE());", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                attributs.Add(reader.GetString("NOM_ATTRIBUT"));
                types.Add(reader.GetString("TYPE_ATTRIBUT"));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération des écoles.");
        }
        forms.Add(types);
        forms.Add(attributs);
        return forms;
    }
    public void OnGet()
    {

    }
}