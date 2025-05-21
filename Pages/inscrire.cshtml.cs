using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class InscrireModel : PageModel
{
    public void OnGet()
    {
    }

    public JsonResult OnGetNiveaux(string idParcours)
    {
        var niveaux = Parcours.GetNiveau(idParcours);
        return new JsonResult(niveaux);
    }

    public IActionResult OnPost()
    {
        var message = "";
        var nom = Request.Form["nom"];
        var prenom = Request.Form["prenom"];
        var email = Request.Form["email"];
        var photo = Path.Combine("/home/randriamiarimanana/Images", Request.Form["photo"]);
        Console.WriteLine(photo);
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
            message = "Erreur lors de l' inscription, veuillez contacter l'administrateur du site web";
            Console.WriteLine("Erreur : " + E);
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
                    message = "Erreur lors de l' inscription, veuillez contacter l'administrateur du site web";
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
                        message = "Erreur Erreur lors de l' inscription, veuillez contacter l'administrateur du site web";
                    }
                }
            }
        }
        if (message == "")
        {
            message = "Success : Inscription ajouté avec succèss";
        }
        else
        {
            try
            {
                etudiant.delete_from_database();
            }
            catch (Exception E)
            {
                message = "Erreur côté serveur : Veuillez contacter l'administrateur du site";
            }
        }

        TempData["Message"] = message;
        return RedirectToPage("/Merci");
    }
}