using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Procédure_Stockées
{
    class Requêtes
    {
        MySqlConnection cnx;
        MySqlCommand cmd;

        public Requêtes()
        {
            string h, u, db, p;
            h = "localhost";
            u = "root";
            db = "gesper";
            p = "siojjr";
            Connexion cn = new Connexion(h, u, db, p);
            cnx = cn.GetCnx;
        }

        public string nouvelemp(string nom, string prenom, string sexe, byte cadre, decimal salaire, int service)
        {
            this.cnx.Open();
            string result = "Ajouté avec succès";
            cmd.Connection = Cnx;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "créer";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("nom", MySqlDbType.String);
            cmd.Parameters.Add("prenom", MySqlDbType.String);
            cmd.Parameters.Add("sexe", MySqlDbType.String);
            cmd.Parameters.Add("cadre", MySqlDbType.Byte);
            cmd.Parameters.Add("salaire", MySqlDbType.Decimal);
            cmd.Parameters.Add("service", MySqlDbType.Int32);
            cmd.Parameters["nom"].Direction = ParameterDirection.Input;
            cmd.Parameters["prenom"].Direction = ParameterDirection.Input;
            cmd.Parameters["sexe"].Direction = ParameterDirection.Input;
            cmd.Parameters["cadre"].Direction = ParameterDirection.Input;
            cmd.Parameters["salaire"].Direction = ParameterDirection.Input;
            cmd.Parameters["service"].Direction = ParameterDirection.Input;
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return result = e.Message;
            }
            cnx.Close();
            return result;
        }

        public string licence_bac()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "licence_bac";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Prepare();
            MySqlDataReader Rdr = cmd.ExecuteReader();
            try
            {
                while (Rdr.Read())
                {
                    result += String.Format("Nom:{0}, Prenom:{1}, Sexe:{2}, Cadre:{3}, Salaire:{4}, Service:{5}", Rdr[0], Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public string salaire(int borneinf, int bornesup)
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "salaire";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("borneinf", MySqlDbType.Int32);
            cmd.Parameters.Add("bornesup", MySqlDbType.Int32);
            cmd.Parameters["borneinf"].Direction = ParameterDirection.Input;
            cmd.Parameters["bornsup"].Direction = ParameterDirection.Input;
            cmd.Prepare();
            MySqlDataReader Rdr = cmd.ExecuteReader();
            try
            {
                while (Rdr.Read())
                {
                    result += String.Format("Nom:{0}, Prenom:{1}, Sexe:{2}, Cadre:{3}, Salaire:{4}, Service:{5}", Rdr[0], Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public string budget(int numservice, decimal pourcentage)
        {
            string result = "Mise à jour réussi";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "budget";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("numservice", MySqlDbType.Int32);
            cmd.Parameters.Add("pourcentage", MySqlDbType.Decimal);
            cmd.Parameters["numservice"].Direction = ParameterDirection.Input;
            cmd.Parameters["pourcentage"].Direction = ParameterDirection.Input;
            cmd.Prepare();
            try
            {
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public string diplome()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "diplome";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Prepare();
            MySqlDataReader Rdr = cmd.ExecuteReader();
            try
            {
                while (Rdr.Read())
                {
                    result += String.Format("Nom:{0}, Prenom:{1}, Sexe:{2}, Cadre:{3}, Salaire:{4}, Service:{5}", Rdr[0], Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public string ListeEmployes()
        {
          string result= "";
          cnx.Open();
          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = cnx;
          cmd.CommandText = "Select * from employe";
          cmd.CommandType = CommandType.Text;
          MySqlDataReader Rdr = cmd.ExecuteReader();
          while (Rdr.Read())
          {
            result += ("{0}, {1}, {2}, {3}, {4}, {5}\n", Rdr[0],Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
          }
          cnx.Close();
          return result;
        }
      public string ListeService()
       {
        string result "";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = cnx;
        cnx.Open();
        cmd.CommandType = "service";
        cmd.CommandType= CommandType.TableDirect;
        MySqlDataReader Rdr = cmd.ExecuteReader();
        while (Rdr.Read())
        {
          result += ("{0}, {1}, {2}, {3}, {4}, {5}\n", Rdr[0],Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
        }
        cnx.Close();
        return result;List
      }

      public string MajSalaire(string nom, decimal pourcentage)
      {
          string result = "Mise à jour réussi";
          cnx.Open();
          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = cnx;
          cmd.CommandText = "MajSalaire";
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("nom", MySqlDbType.String);
          cmd.Parameters.Add("pourcentage", MySqlDbType.Decimal);
          cmd.Parameters["nom"].Direction = ParameterDirection.Input;
          cmd.Parameters["pourcentage"].Direction = ParameterDirection.Input;
          cmd.Prepare();
          try
          {
              {
                  cmd.ExecuteNonQuery();
              }
          }
          catch (Exception e)
          {
              result = e.Message;
          }
          return result;
      }

      public string msalariale(string nomservice)
      {
          string result = "";
          cnx.Open();
          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = cnx;
          cmd.CommandText = "msalariale";
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("nomservice", MySqlDbType.string);
          cmd.Parameters["nomservice"].Direction = ParameterDirection.Input;
          cmd.Prepare();
          MySqlDataReader Rdr = cmd.ExecuteReader();
          try
          {
              while (Rdr.Read())
              {
                  result += String.Format("Nom:{0}, Prenom:{1}, Sexe:{2}, Cadre:{3}, Salaire:{4}, Service:{5}", Rdr[0], Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
              }
          }
          catch (Exception e)
          {
              result = e.Message;
          }
          return result;
      }

      public string salairecadre()
      {
          string result = "";
          cnx.Open();
          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = cnx;
          cmd.CommandText = "Select * from cadres where emp_salaire > avg(emp_salaire)";
          cmd.CommandType = CommandType.Text;
          cmd.Prepare();
          MySqlDataReader Rdr = cmd.ExecuteReader();
          try
          {
              while (Rdr.Read())
              {
                  result += String.Format("Nom:{0}, Prenom:{1}, Sexe:{2}, Cadre:{3}, Salaire:{4}, Service:{5}", Rdr[0], Rdr[1], Rdr[2], Rdr[3], Rdr[4], Rdr[5]);
              }
          }
          catch (Exception e)
          {
              result = e.Message;
          }
          return result;
      }


    }

}
