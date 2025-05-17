using Microsoft.VisualBasic;
using MySqlConnector;

public class Formulaire
{
    public string id_attribut, attribut, type;
    public bool obligatoire;
    public Formulaire(string id_attribut, string attribut, string type, bool obligatoire = true)
    {
        this.id_attribut = id_attribut;
        this.attribut = attribut;
        this.type = type;
        this.obligatoire = obligatoire;
    }
    public static List<Formulaire> GetForms(string id_ecole)
    {
        List<Formulaire> formulaires = new List<Formulaire>();
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Attribut_Formulaire WHERE CodeEcole = '" + id_ecole + "' AND YEAR(Annee)=YEAR(CURDATE());", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                formulaires.Add(new Formulaire(reader.GetString("NumAttribut"), reader.GetString("NomAttribut"), reader.GetString("TypeAttribut"), reader.GetBoolean("Obligatoire")));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return formulaires;
    }
    public static DateOnly GetAnnee()
    {
        DateOnly annee;
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT Annee FROM Annee_Univ WHERE YEAR(CURDATE()) = YEAR(Annee);", connection);
            using var reader = command.ExecuteReader();
            reader.Read();
            annee = reader.GetDateOnly(0);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return annee;
    }
}