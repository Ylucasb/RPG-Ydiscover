using Npgsql;
namespace RPGYdiscover
{
    public class InitialDB
    {
        private static string cs = "Host=localhost;Username=postgres;Password=Lucas12112004!!;Database=RPG-Ydiscovers";
        public InitialDB()
        {
            using var con = new NpgsqlConnection(cs); // making connection
            con.Open(); // open connection

            // table creation
            string sql =@"
            CREATE TABLE IF NOT EXISTS Stats(
                id SERIAL PRIMARY KEY, 
                name VARCHAR ( 50 ) UNIQUE NOT NULL, 
                attack INT NOT NULL, 
                defense INT NOT NULL, 
                lifePoint INT NOT NULL)";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            // First insertion
            string sql1 = "INSERT INTO stats (name, attack, defense, lifePoint) VALUES('Guerrier',25,10,100)";
            using var cmd1 = new NpgsqlCommand(sql1, con);
            cmd1.ExecuteNonQuery();

            // Second insertion
            string sql2 = "INSERT INTO stats (name, attack, defense, lifePoint) VALUES('Mage',30,5,45)";
            using var cmd2 = new NpgsqlCommand(sql2, con);
            cmd2.ExecuteNonQuery();

            // Third insertion
            string sql3 = "INSERT INTO stats (name, attack, defense, lifePoint) VALUES('Viking',20,15,125)";
            using var cmd3 = new NpgsqlCommand(sql3, con);
            cmd3.ExecuteNonQuery();
        }

        public static bool IsValid()
        {
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string tableName = "stats";
            string sql = $@"
                SELECT EXISTS (
                    SELECT 1
                    FROM information_schema.tables
                    WHERE table_name = '{tableName}'
                ) AS table_exists;
            ";
            using var cmd = new NpgsqlCommand(sql, con);
            // using NpgsqlDataReader rdr = cmd.ExecuteReader();
            #pragma warning disable CS8605
            if ((bool)cmd.ExecuteScalar()){
                return true;
            }
            #pragma warning restore CS8605
            return false;
        }
    }
}