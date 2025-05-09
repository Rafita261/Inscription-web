using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inscription.Pages;

public class InscriptionModel : PageModel
{
    private readonly ILogger<InscriptionModel> _logger;

    public InscriptionModel(ILogger<InscriptionModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
