using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MySqlConnector;

namespace Inscription.Pages;

public class InscriptionModel : PageModel
{
    private readonly ILogger<InscriptionModel> _logger;

    public InscriptionModel(ILogger<InscriptionModel> logger)
    {
        _logger = logger;
    }

    public List<string> GetEcoles()
    {
        List<string> ecoles = new List<string>();
        const string connectionString = "Server=localhost;User ID=chris;Password=Chriskely@123;Database=Inscription";

        try
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ECOLE;", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                ecoles.Add(reader.GetString(1));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la récupération des écoles.");
        }
        return ecoles;
    }

    public void OnGet()
    {

    }
}
