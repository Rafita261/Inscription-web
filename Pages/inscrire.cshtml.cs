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
    public void OnGet()
    {

    }
    public void OnPost()
    {
        
    }
}