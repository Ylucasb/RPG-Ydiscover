namespace RPGYdiscover {
    public class Interaction 
    {
        public string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMenu :");
            Console.WriteLine("1. Afficher les statistiques de l'équipe");
            Console.WriteLine("2. Combattre");
            Console.WriteLine("3. Quitter");
            Console.Write("Choisissez une option : ");
            string inputChoice = Console.ReadLine();
            return inputChoice;
        }
        public void DisplayStatistiques(Character player1, Character player2)
        {
            Console.Clear();
            Console.WriteLine("\nStatistiques de l'équipe :");

            // Afficher les statistiques du player 1
            Console.WriteLine($"\n{player1.Nom}");
            Console.WriteLine("Classe : " + player1.Classe);
            Console.WriteLine("Points de Vie : " + player1.LifePoint);
            Console.WriteLine("Attaque : " + player1.Attaque);
            Console.WriteLine("Défense : " + player1.Defense);

            // Afficher les statistiques du joueur 2
            Console.WriteLine($"\n{player2.Nom}");
            Console.WriteLine("Classe : " + player2.Classe);
            Console.WriteLine("Points de Vie : " + player2.LifePoint);
            Console.WriteLine("Attaque : " + player2.Attaque);
            Console.WriteLine("Défense : " + player2.Defense);

            Console.WriteLine("\nAppuyez sur une touche pour continuer de jouer.");
            Console.ReadKey();
        }
    }
}