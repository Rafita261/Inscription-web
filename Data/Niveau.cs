using MySqlConnector;
public class Niveau
{
    public string CodeNiveau="", CodeParcours, niveau;
    public Niveau(string CodeNiveau, string CodeParcours, string niveau)
    {
        this.CodeNiveau = CodeNiveau;
        this.CodeParcours = CodeParcours;
        this.niveau = niveau;
    }
    public Niveau(string CodeParcours, string niveau)
    {
        this.CodeParcours = CodeParcours;
        this.niveau = niveau;
    }
    public string GetCodeNiveau()
    {
        string _niveau = "";
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT CodeNiveau FROM Niveau WHERE CodeParcours = '" + this.CodeParcours + "' AND Niveau = '"+this.niveau+"';", connection);
            using var reader = command.ExecuteReader();
            reader.Read();
            _niveau = reader.GetString(0);            
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        this.CodeNiveau = _niveau;
        return _niveau;
    }
}