using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue dans le Jeu de Rôle en Ligne de Commande!");

        // Création de l'équipe de joueurs
        List<Joueur> joueurs = CreerEquipeDeJoueurs(2);

        while (true)
        {
            // Affichage du menu principal
            AfficherMenu();
            string choix = Console.ReadLine();

            switch (choix.ToLower())
            {
                case "1":
                    AfficherStatistiques(joueurs[0], joueurs[1]);
                    break;
                case "2":
                    CommencerCombat(joueurs);
                    break;
                case "3":
                    Console.WriteLine("Merci d'avoir joué!");
                    return;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    #region Gestion des joueurs

    static List<Joueur> CreerEquipeDeJoueurs(int numberOfPlayers)
    {
        List<Joueur> joueurs = new List<Joueur>();

        for (int i = 1; i <= numberOfPlayers; i++)
        {
            Console.WriteLine($"\nJoueur {i}");
            joueurs.Add(CreerJoueur());
        }

        return joueurs;
    }

    static Joueur CreerJoueur()
    {
        Console.Write("Entrez le nom de votre personnage : ");
        string nom = Console.ReadLine();
        Console.Write("Choisissez votre classe (Guerrier, Mage, Viking) : ");
        string classe = Console.ReadLine();

        return new Joueur(nom, classe);
    }

    #endregion

    #region Affichage et combat

    static void AfficherMenu()
    {
        Console.Clear();
        Console.WriteLine("\nMenu :");
        Console.WriteLine("1. Afficher les statistiques de l'équipe");
        Console.WriteLine("2. Combattre");
        Console.WriteLine("3. Quitter");
        Console.Write("Choisissez une option : ");
    }

    static void AfficherStatistiques(Joueur joueur1, Joueur joueur2)
    {
        Console.Clear();
        Console.WriteLine("\nStatistiques de l'équipe :");

        // Afficher les statistiques du joueur 1
        Console.WriteLine($"\n{joueur1.Nom}");
        Console.WriteLine("Classe : " + joueur1.Classe);
        Console.WriteLine("Points de Vie : " + joueur1.PointsDeVie);
        Console.WriteLine("Attaque : " + joueur1.Attaque);
        Console.WriteLine("Défense : " + joueur1.Defense);

        // Afficher les statistiques du joueur 2
        Console.WriteLine($"\n{joueur2.Nom}");
        Console.WriteLine("Classe : " + joueur2.Classe);
        Console.WriteLine("Points de Vie : " + joueur2.PointsDeVie);
        Console.WriteLine("Attaque : " + joueur2.Attaque);
        Console.WriteLine("Défense : " + joueur2.Defense);

        Console.WriteLine("\nAppuyez sur une touche pour continuer de jouer.");
        Console.ReadKey();
    }

    static void CommencerCombat(List<Joueur> joueurs)
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
                        joueurs[j].PointsDeVie -= damageAfterDefense;

                        Console.WriteLine($"\n{joueurs[j].Nom} subit {damageAfterDefense} points de dégâts!");
                        AfficherStatistiques(joueurs[i], joueurs[j]);

                        if (joueurs[j].PointsDeVie <= 0)
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

    #endregion
}

class Joueur
{
    public string Nom { get; }
    public string Classe { get; }
    public int Niveau { get; set; }
    public int PointsDeVie { get; set; }
    public int Attaque { get; set; }
    public int Defense { get; set; }

    public Joueur(string nom, string classe)
    {
        Nom = nom;
        Classe = classe;
        PointsDeVie = 100;
        Attaque = 25;
        Defense = 10;
    }
}
