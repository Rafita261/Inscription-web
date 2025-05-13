using MySqlConnector;

public class Choix
{
    public string id_choix;
    public string valeur;
    public Choix(string id_choix, string valeur)
    {
        this.id_choix = id_choix;
        this.valeur = valeur;
    }

    public static List<Choix> GetChoix(string id_attribut)
    {
        List<Choix> choixList = new List<Choix>();
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Choix WHERE NumAttribut = '" + id_attribut + "';", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                choixList.Add(new Choix(reader.GetString("NumChoix"), reader.GetString("Valeur")));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return choixList;
    }
}