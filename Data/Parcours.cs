using MySqlConnector;
public class Parcours
{
    public string id_parcours, nom_parcours;

    public Parcours(string id, string nom)
    {
        this.id_parcours = id;
        this.nom_parcours = nom;
    }
    public static List<string> GetNiveau(string idParcours)
    {
        List<string> niveau = new List<string>();
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Niveau WHERE CodeParcours = '" + idParcours + "';", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string niv = reader.GetString("Niveau");
                niveau.Add(niv);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        return niveau;
    }
}