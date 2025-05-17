using MySqlConnector;

public class Valeur_Choix
{
    public string id_choix, IM;
    public Valeur_Choix(string id_choix, string IM)
    {
        this.id_choix = id_choix;
        this.IM = IM;
    }
    public void insert_value_to_database()
    {
        string sql = "INSERT INTO Valeur_Choix(IM,NumChoix) VALUES('" + this.IM + "','" + this.id_choix + "') ;";
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
    }
}