using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class InscrireModel : PageModel
{
    public void OnGet()
    {
        // Chargement effectué dans le fichier .cshtml
    }

    public JsonResult OnGetNiveaux(string idParcours)
    {
        var niveaux = Parcours.GetNiveau(idParcours);
        return new JsonResult(niveaux);
    }

    public IActionResult OnPost()
    {
        // Traitement à l'envoi du formulaire
        // Exemple : Request.Form["nom"], etc.
        var nom = Request.Form["nom"];
        var prenom = Request.Form["prenom"];
        var email = Request.Form["email"];
        var parcours = Request.Form["parcours"];
        var niveau = Request.Form["niveau"];
        Etudiant etudiant = new Etudiant(nom, prenom, email);
        string code_niveau = new Niveau(parcours, niveau).GetCodeNiveau(); 
        Inscription_Table inscription_ = new Inscription_Table(etudiant.IM, code_niveau);
        try
        {
            etudiant.insert_to_database();
            inscription_.insert_to_database();
        }
        catch (Exception E)
        {
            Console.WriteLine("erreur : " + E);
        }

        return RedirectToPage("/inscription");
    }
}
