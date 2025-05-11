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

    public List<Ecole> GetEcoles()
    {
        return Ecole.get_all();
    }

    public void OnGet()
    {

    }
}
