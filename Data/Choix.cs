using MySqlConnector;

public class Choix
{
    public int id_choix;
    public string valeur;
    public Choix(int id_choix, string valeur)
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

            using var command = new MySqlCommand("SELECT * FROM CHOIX WHERE ID_ATTRIBUT = " + id_attribut + ";", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                choixList.Add(new Choix(reader.GetInt16("ID_CHOIX"), reader.GetString("VALEUR")));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return choixList;
    }
}