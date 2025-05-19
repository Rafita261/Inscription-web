using MySqlConnector;

public class Ecole
{
    public string id_ecole, nom_ecole, photo = "";

    public Ecole(string id, string nom)
    {
        id_ecole = id;
        nom_ecole = nom;
        photo = Ecole.GetPhotoLink(id);
    }

public static string GetPhotoLink(string id_ecole){
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT Logo FROM Ecole WHERE CodeEcole = '" + id_ecole + "';", connection);
            using var reader = command.ExecuteReader();

            reader.Read();
            return reader.GetString(0);
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur lors de la récupération de l'ID de l'école : " + ex);
        }
    }
    public static string Get_Id(string NomEcole)
    {

        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT CodeEcole FROM Ecole WHERE NomEcole = '" + NomEcole + "';", connection);
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

            using var command = new MySqlCommand("SELECT CodeParcours, NomParcours FROM Parcours WHERE CodeEcole = '" + id_ecole + "';", connection);
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

            using var command = new MySqlCommand("SELECT * FROM Ecole;", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Ecole ecole = new Ecole(reader.GetString("CodeEcole"), reader.GetString("NomEcole"));
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