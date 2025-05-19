using MySqlConnector;

public class Calendrier
{
    public DateOnly date_debut, date_fin;

    public Calendrier(DateOnly date_debut, DateOnly date_fin)
    {
        this.date_debut = date_debut;
        this.date_fin = date_fin;
    }

    public Calendrier(string CodeEcole)
    {
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT Datedebut, Datefin FROM Calendrier WHERE YEAR(Annee)=YEAR(CURDATE()) AND CodeEcole='" + CodeEcole + "';", connection);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.date_debut = reader.GetDateOnly(0);
                this.date_fin = reader.GetDateOnly(1);
            }
            else
            {
                this.date_debut = DateOnly.FromDateTime(DateTime.Now);
                this.date_fin = DateOnly.FromDateTime(DateTime.Now);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
    }
    public Calendrier(Ecole ecole)
    {
        Calendrier calendrier = new Calendrier(ecole.id_ecole);
        this.date_debut = calendrier.date_debut;
        this.date_fin = calendrier.date_fin;
    }
}