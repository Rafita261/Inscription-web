using MySqlConnector;

public class Etudiant
{
    public string IM, NomEtdiant, Prenoms, Email;
    public Etudiant(string Nom, string Prenoms, string Email)
    {
        this.NomEtdiant = Nom;
        this.Prenoms = Prenoms;
        this.Email = Email;
        this.IM = Etudiant.GenerateIM();
    }
    public static string GenerateIM()
    {
        var last_number = "ETU000";
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("SELECT IM FROM Etudiant ORDER BY IM DESC LIMIT 1;", connection);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                last_number = reader.GetString("IM");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
        string num = "";
        for (int i = 3; i < 6; i++)
        {
            num = num + last_number[i];
        }
        int n = 0;
        foreach (var k in num)
        {
            n = n * 10 + (int)new StringReader(k.ToString()).Read() - 48;
        }
        n++;
        string N = n.ToString();
        string new_num = "ETU";
        int l = 3 - N.Length;
        for (int i = 0; i < l; i++)
        {
            N = "0" + N;
        }
        new_num += N;
        return new_num;
    }

    public void insert_to_database()
    {
        try
        {
            using var connection = new MySqlConnection(Connexion.connectionString);
            connection.Open();

            using var command = new MySqlCommand("INSERT INTO Etudiant(IM,NomEtudiant,Prenoms,Email) VALUES ('" + this.IM + "','" + this.NomEtdiant + "','" + this.Prenoms + "','" + this.Email + "')", connection);
            using var reader = command.ExecuteReader();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while fetching data from database: " + ex.Message);
        }
    }
}