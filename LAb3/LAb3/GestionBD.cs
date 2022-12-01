using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LAb3
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Employe> liste;
        ObservableCollection<Projet> liste2;
        static GestionBD gestionBD = null;
    }

     public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=1939786-mohamed-amine-ben-daya;Uid=1939786;Pwd=1939786;");
            liste = new ObservableCollection<Employe>();
            liste2 = new ObservableCollection<Projet>();
        }


        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }


        public void ajouter_employe(Employe e)
        {
            String matricule = e.Matricule;
            String nom = e.Nom;
            String prenom = e.Prenom;

            try
            {
                MySqlCommand commande = new MySqlCommand("ajouter_employe");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

         public void ajouter_projet(Projet p)
        {
            string numero = p.Numero;
            DateTime debut = p.Debut;
            int budget = p.Budget;
            string description = p.Description;
            string employe = p.Employe;
            string empMat=p.Employe;
            


            try
            {
                MySqlCommand commande = new MySqlCommand("ajouter_projet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@debut", debut);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@employe", empMat);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }

            catch
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    public ObservableCollection<Employe> getEmployes()
    {
        try
        {
            liste.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                liste.Add(new Employe()
                {
                    Matricule = r.GetString(0),
                    Nom = r.GetString(1),
                    Prenom = r.GetString(2)

                });

            }

            r.Close(); con.Close();
            return liste;

        }
        catch (MySqlException ex)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return null;
        }

    }
    public ObservableCollection<Employe> rechercher_employeN(string name)
    {
        try
        {
            liste.Clear();



            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe where nom = '" + name + "'";



            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Employe()
                {
                    Matricule = r.GetString(0),
                    Nom = r.GetString(1),
                    Prenom = r.GetString(2)

                });

            }

            r.Close();
            con.Close();
            return liste;

        }
        catch (MySqlException ex)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return null;
        }

    }
    public ObservableCollection<Employe> rechercher_employeP(string prename)
    {
        try
        {
            liste.Clear();

            MySqlCommand commande = new MySqlCommand(); commande.Connection = con; commande.CommandText = "Select * from employe where prenom = '" + prename + "'";

            con.Open(); MySqlDataReader r = commande.ExecuteReader(); while (r.Read())
            {

                liste.Add(new Employe()
                {
                    Matricule = r.GetString(0),
                    Nom = r.GetString(1),
                    Prenom = r.GetString(2)

                });

            }

            r.Close(); con.Close(); return liste;

        }
        catch (MySqlException ex) { if (con.State == System.Data.ConnectionState.Open) { con.Close(); } return null; }

    }

    public ObservableCollection<Employe> GetEmploye()
    {
        liste.Clear();
        MySqlCommand commande = new MySqlCommand();
        commande.Connection = con;
        commande.CommandText = "Select * from employe ";
        con.Open();
        MySqlDataReader r = commande.ExecuteReader();
        try
        {

            while (r.Read())
            {
                Employe c = new Employe()
                {
                    Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom")

                };
                liste.Add(c);

            }
            r.Close();
            con.Close();
            return liste;
        }
        catch (MySqlException ex)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return null;
        }

    }

    public ObservableCollection<Projet> rechercher_Projet(DateTime date)
    {
        try
        {
            liste2.Clear();



            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet where debut = '" + date + "'";



            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste2.Add(new Projet()
                {
                    Numero = r.GetString("numero"),
                    Debut = Convert.ToDateTime(r.GetString("debut")),
                    Budget = r.GetInt32("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetString("employe")
                });




            }

            r.Close();
            con.Close();
            return liste2;

        }
        catch (MySqlException ex)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return null;
        }

    }

    public ObservableCollection<Projet> GetProjets()
    {
        liste2.Clear();
        MySqlCommand commande = new MySqlCommand();
        commande.Connection = con;
        commande.CommandText = "Select * from projet ";
        con.Open();
        MySqlDataReader r = commande.ExecuteReader();
        try
        {
            while (r.Read())
            {
                Projet c = new Projet()
                {
                    Numero = r.GetString("numero"),
                    Debut = Convert.ToDateTime(r.GetString("debut")),
                    Description = r.GetString("description"),
                    Budget = r.GetInt32("budget"),
                    Employe = r.GetString("employe"),

                };
                liste2.Add(c);

            }
            r.Close();
            con.Close();
            return liste2;
        }
        catch (MySqlException ex)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return null;
        }

    }
}
