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
        var message = "";
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
            message = "Erreur : "+ E;
            Console.WriteLine("erreur : " + E);
        }

        List<Formulaire> forms = Formulaire.GetForms(ecole);
        foreach (var form in forms)
        {
            if (form.type != "checkbox" && form.type != "radio")
            {
                try
                {
                    form.insert_value_to_database(etudiant.IM, Request.Form[form.id_attribut]);
                }
                catch (Exception E)
                {
                    message = "Erreur : " + E;
                }
            }
            else if (form.type == "radio")
            {
                try
                {
                    var choix = new Valeur_Choix(Request.Form[form.id_attribut], etudiant.IM);
                    choix.insert_value_to_database();
                }
                catch (Exception E)
                {
                    message = "Erreur : " + E;
                }
            }
            else
            {
                foreach (var ch in Request.Form[form.attribut])
                {
                    var choix = new Valeur_Choix(ch, etudiant.IM);
                    try
                    {
                        choix.insert_value_to_database();
                    }
                    catch (Exception E)
                    {
                        message = "Erreur : " + E;
                    }
                }
            }
        }
        if (message == "")
        {
            message = "Success : Inscription ajouté avec succèss";
        }

        TempData["Message"] = message;
        return RedirectToPage("/Merci");
    }
}