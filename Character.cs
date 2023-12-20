using Npgsql;
namespace RPGYdiscover
{
    public class Character
    {
        private string _name = "";
        public string Name
        {
            get {return _name;}
            set {_name = value;}
        }
        private int _attack = 100;
        public int Attack
        {
            get {return _attack;}
            set {_attack = value;}
        }
        private int _defense = 100;
        public int Defense
        {
            get {return _defense;}
            set {_defense = value;}
        }
        private int _lifePoint = 100;
        public int LifePoint
        {
            get {return _lifePoint;}
            set {_lifePoint = value;}
        }

        public Character(string name)
        {
            Name = name;
            var cs = "Host=localhost;Username=postgres;Password=Lucas12112004!!;Database=RPG-Ydiscovers";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM stats WHERE name = @Name";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", Name);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Attack = rdr.GetInt32(2);
                Defense = rdr.GetInt32(3);
                LifePoint = rdr.GetInt32(4);
            }
        }
    }
}