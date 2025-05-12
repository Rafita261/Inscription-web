using MySqlConnector;

public class Ecole
{
    public string id_ecole, nom_ecole;

    public Ecole(string id, string nom)
    {
        id_ecole = id;
        nom_ecole = nom;
    }

    public static string Get_Id(string NomEcole)
    {

        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT ID_ECOLE FROM ECOLE WHERE NOM_ECOLE = '" + NomEcole + "';", connection);
            using var reader = command.ExecuteReader();

            reader.Read();
            return reader.GetString(0);
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur lors de la récupération de l'ID de l'école : " + ex);
        }
    }

    public List<Parcours> GetParcours()
    {
        List<Parcours> parcours = new List<Parcours>();
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT CODE_PARCOURS, NOM_PARCOURS FROM PARCOURS WHERE ID_ECOLE = '" + id_ecole + "';", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                parcours.Add(new Parcours(reader.GetString(0), reader.GetString(1)));
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Erreur lors de la récupération de l'ID de l'école : " + ex);
        }
        return parcours;
    }
    public static List<Ecole> get_all()
    {
        List<Ecole> ecoles = new List<Ecole>();

        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM ECOLE;", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ecole ecole = new Ecole(reader.GetString("ID_ECOLE"), reader.GetString("NOM_ECOLE"));
                ecoles.Add(ecole);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur lors de la récupération des écoles : " + ex);
        }
        return ecoles;
    }
}