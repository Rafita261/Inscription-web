using Microsoft.VisualBasic;
using MySqlConnector;

public class Inscription_Table
{
    public string IM, CodeNiveau;
    private string[] f;
    public string Annee;
    public Inscription_Table(string IM, string CodeNiveau)
    {
        this.IM = IM;
        this.CodeNiveau = CodeNiveau;
        this.f =  Formulaire.GetAnnee().ToString().Split("/"); 
        this.Annee = f[2] + "/" + f[1] + "/" + f[0];
    }
    public void insert_to_database()
    {
        string sql = "INSERT INTO Inscription(Annee, IM, CodeNiveau) VALUES ('"+this.Annee+"','" + this.IM + "','" + this.CodeNiveau + "')";
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