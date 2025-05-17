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
        var photo = Request.Form["photo"];
        var parcours = Request.Form["parcours"];
        var niveau = Request.Form["niveau"];
        var ecole = Ecole.Get_Id(Request.Form["ecole"]);
        Etudiant etudiant = new Etudiant(nom, prenom, email, photo);
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

        List<Formulaire> forms = Formulaire.GetForms(ecole);
        foreach (var form in forms)
        {
            if (form.type != "checkbox" && form.type != "radio")
            {
                form.insert_value_to_database(etudiant.IM,Request.Form[form.id_attribut]);
            }
            else if (form.type == "radio")
            {
                var choix = new Valeur_Choix(Request.Form[form.id_attribut], etudiant.IM);
                choix.insert_value_to_database();
            }
            else
            {
                foreach (var ch in Request.Form[form.attribut])
                {
                    var choix = new Valeur_Choix(ch, etudiant.IM);
                    choix.insert_value_to_database();
                }
            }
        }

        return RedirectToPage("/inscription");
    }
}
