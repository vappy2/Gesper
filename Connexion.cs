
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Procédure_Stockées
{
    class Connexion
    {
        static private MySqlConnection cnx;

        public Connexion(string h, string u, string db, string p)
        {   string scnx;
            scnx = String.Format("host = {0}; user = {1}; database = {2}; password = {3}\n", h,u,db,p);
            cnx = new MySqlConnection(scnx);     }


        public MySqlConnection GetCnx
        {
          get
          {
            return Connexion.cnx;
            }
           }
    }
}
