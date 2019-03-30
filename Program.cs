using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace Procédure_Stockées
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            string h, u, db, p;
            //Saisie des donnée de connexion par l'utilisateur
            /*Console.WriteLine("Host"); h = Console.ReadLine();
            Console.WriteLine("User"); u = Console.ReadLine();
            Console.WriteLine("Base de données"); db = Console.ReadLine();
            Console.WriteLine("Mot de Passe"); p = Console.ReadLine();*/
            //données brutes
            h=localhost;
            u=root;
            bd=gesper;
            p=siojjr;
            MySqlConnection cnx;
            cnx = new Connexion(h, u, db, p).GetCnx;

            do
            {
                do
                {
                    Console.WriteLine("1 - Création d'un nouvel employé");
                    Console.WriteLine("2 - Liste des employés ayant le bac et la licence");
                    Console.WriteLine("3 - Liste des employés ayant leur salaires compris entre borne inférieure et borne supérieure");
                    Console.WriteLine("4 - Mise à jour du budget");
                    Console.WriteLine("5 - Liste des employés qui ont plus de diplômes que la moyenne des diplômes possédés par chaque employé");
                    Console.WriteLine("6 - Liste complète des employé");
                    Console.WriteLine("7 - Liste complète des services");
                    Console.WriteLine("8 - Mise à jour du salaire d'un employé ");
                    Console.WriteLine("9 - Masse salariale mensuelle d'un service");
                    Console.WriteLine("10 - Liste des employés cadre qui gane plus de la moyenne des salaires des cadres");
                    Console.WriteLine("11 - Fin");
                    choix = Int32.Parse(Console.ReadLine());
                    Requêtes rq = new Requêtes();
                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Création de l'employé ...");
                            Console.WriteLine("Saisissez le nom"); string nom = Console.ReadLine();
                            Console.WriteLine("Saisissez le prénom"); string prenom = Console.ReadLine();
                            Console.WriteLine("Saisissez le sexe"); string sexe = Console.ReadLine();
                            Console.WriteLine("Est-il cadre ?"); byte cadre = Convert.ToByte(Console.ReadLine());
                            Console.WriteLine("Saisissez le salaire"); decimal salaire = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Saisissez le service"); int service = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(rq.nouvelemp(nom, prenom, sexe, cadre, salaire, service));
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Liste des employés des employés ayant le Bac et la Licence");
                            Console.WriteLine(rq.licence_bac());
                            break;
                        case 3:
                            Console.WriteLine("Liste des employés ayant le salaire compris entre une borne inférieur et unne borne supérieure");
                            int borninf = Convert.ToInt32(Console.ReadLine());
                            int bornsup = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(rp.salaire(borninf,bornesup));
                            break;
                        case 4:
                            Console.WriteLine("Mise à jour du budget");
                            int numservice =Convert.ToInt32(Console.ReadLine());
                            Decimal pourcentage=Convert.ToInt32(Console.Readline());
                            Console.WriteLine(rq.budget());
                            break;
                        case 5:
                            Console.WriteLine("Liste des employés qui ont plus de diplome que la moyenne des diplômes par employés");
                            Console.WriteLine(rq.diplome());
                            break;
                        case 6:
                            Console.WriteLine("Liste complète des employés");
                            Console.WriteLine(rq.ListeEmployes());
                            break;
                        case 7:
                            Console.WriteLine("Liste complète des services");
                            Console.WriteLine(rq.ListeService());
                             break;
                        case 8:
                            Console.WriteLine("Mise à jour du salaire d'un employé...");
                            Console.WriteLine(rq.MajSalaire());
                            break;
                        case 9 :
                            Console.WriteLine("Masse salariale d'un service");
                            Console.WriteLine(rq.msalariale());
                            break;
                        case 10:
                             Console.WriteLine("Liste des employés cadres gagnant plus que la moyenne des cadre");
                             Console.WriteLine(rq.salairecadre());
                             break;
                         case 11:
                            Console.WriteLine("\nFin du Traitement");
                             break;

                    }

                }
                while (choix < 0 || choix > 11);

            } while (choix != 12);
        }
    }
}
