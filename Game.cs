namespace RPGYdiscover
{
    public class Game
    {
        private List<string> listValidClass = new("Mage, Viking, Guerrier")
        private string _team = List<Joueur>;
        private Interaction intercat = new();
        public string Team
        {
            get {return _team;}
            set {_team = value;}
        }
        public void Game(){
            true playerWantToContinue = true;
            Console.WriteLine("Bienvenue dans le Jeu de Rôle en Ligne de Commande!");
            Team = CreerEquipeDeJoueurs(2);
            while (playerWantToContinue){
                string inputChoice = intercat.DisplayMenu();
                switch (inputChoice)
                {
                    case "1":
                        intercat.DisplayStatistiques(Team[0], Team[1]);
                        break;
                    case "2":
                        StartGame(Team);
                        break;
                    case "3":
                        Console.WriteLine("Merci d'avoir joué!");
                        playerWantToContinue = false;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }
        private List<Joueur> CreerEquipeDeJoueurs(int numberOfPlayers)
        {
            List<Joueur> joueurs = new List<Joueur>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.WriteLine($"\nJoueur {i}");
                joueurs.Add(CreerJoueur());
            }
            return joueurs;
        }
        private Character CreerJoueur()
        {
            Console.Write("Entrez le nom de votre personnage : ");
            string nom = Console.ReadLine();
            Console.Write("Choisissez votre classe (Guerrier, Mage, Viking) : ");
            string classe = Console.ReadLine();
            while (!listValidClass.Contains(classe)){
                Console.Write("Cette classe n'existe pas !");
                Console.Write("Choisissez votre classe (Guerrier, Mage, Viking) : ");
            }
            return new Character(nom, classe);
        }
        private void StartGame(List<Joueur> joueurs)
        {
            Console.Clear();
            Console.WriteLine("Le combat commence!\n");

            while (joueurs.Count > 1)
            {
                for (int i = 0; i < joueurs.Count; i++)
                {
                    for (int j = 0; j < joueurs.Count; j++)
                    {
                        if (i != j)
                        {
                            Console.WriteLine($"{joueurs[i].Nom} attaque {joueurs[j].Nom}!");

                            // Simulation de l'attaque avec des points
                            for (int k = 0; k < 5; k++)
                            {
                                Console.Write(".");
                                Thread.Sleep(300);
                            }

                            int damage = new Random().Next(15, 25);
                            int damageAfterDefense = Math.Max(0, damage - joueurs[j].Defense);
                            joueurs[j].LifePoint -= damageAfterDefense;

                            Console.WriteLine($"\n{joueurs[j].Nom} subit {damageAfterDefense} points de dégâts!");
                            AfficherStatistiques(joueurs[i], joueurs[j]);

                            if (joueurs[j].LifePoint <= 0)
                            {
                                Console.WriteLine($"\n{joueurs[j].Nom} à perdu le combat!");
                                joueurs.RemoveAt(j);
                                if (joueurs.Count == 1)
                                {
                                    Console.WriteLine($"\n{joueurs[0].Nom} remporte la victoire!");
                                    Console.WriteLine("\nAppuyez sur une touche pour revenir au menu.");
                                    Console.ReadKey();
                                    return;
                                }
                            }

                            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
            }
        }
    }
}