using MySqlConnector;

public class Formulaire
{
    public string id_attribut, attribut, type;
    public const string connectionString = "Server=localhost;User ID=chris;Password=Chriskely@123;Database=Inscription";
    public Formulaire(string id_attribut,string attribut, string type)
    {
        this.id_attribut = id_attribut;
        this.attribut = attribut;
        this.type = type;
    }
    public static List<Formulaire> GetForms(string id_ecole)
    {
        List<Formulaire> formulaires = new List<Formulaire>();
        try
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ATTRIBUT_FORMULAIRE WHERE ID_ECOLE = '" + id_ecole + "' AND YEAR(ANNEE)=YEAR(CURDATE());", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                formulaires.Add(new Formulaire(reader.GetString("ID_ATTRIBUT"),reader.GetString("NOM_ATTRIBUT"), reader.GetString("TYPE_ATTRIBUT")));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return formulaires;
    }
}