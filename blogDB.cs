using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP_5101_FINAL_PatelKrishna
{
    public class blogDB
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "creative_culture"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "8889"; } }

        //ConnectionString is something that we use to connect to a database
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        //they are also known as "associative arrays"
        public void update_culture(string culture_title, string culture_body, string menu_id, string culture_id)
        {
            /* string query = "insert into culture_description (culture_title, culture_body, menu_id) values('{0}','{1}','{2}') ";*/
            /* query = String.Format(query, culture_title, culture_body, menu_id);*/
            /*string query = "update culture_description (culture_title,culture_body, menu_id, culture_id) values('{0}','{1}','{2}','{3}')";*/
            /*query = String.Format(query, culture_title, culture_body, menu_id,);*/
            string query = "update culture_description set culture_title = '" + culture_title + "', culture_body = '" + culture_body + "', menu_id = '" + menu_id + "' where culture_id = '" + culture_id + "'";
            /*query = String.Format(query, culture_title, culture_body, menu_id);*/
            /*Debug.WriteLine("the query is "+ query);*/
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("@@@running db udpate function");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }


        public void add_culture(string culture_title, string culture_body, string menu_id)
        {
            string query = "insert into culture_description (culture_title, culture_body, menu_id) values('{0}','{1}','{2}') ";
            query = String.Format(query, culture_title, culture_body, menu_id);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
        public List<Dictionary<String, String>> List_Query(string query)
        {

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            // INPUT -> (string) SELECT QUERY 
            // e.g. "select * from students";
            // OUTPUT -> (List<Dictionary<String,String>>) RESULT SET 
            // e.g. 
            //[
            //  {"STUDENTFNAME":"SARAH","STUDENTLNAME":"Valdez","STUDENTNUMBER":"N1678","ENROLMENTDATE":"2018-06-18"},
            //  {"STUDENTFNAME":"Jennifer","STUDENTLNAME":"FAULKNER","STUDENTNUMBER":"N1679","ENROLMENTDATE":"2018-08-02"},
            //  {"STUDENTFNAME":"Austin","STUDENTLNAME":"Simon","STUDENTNUMBER":"N1682","ENROLMENTDATE":"2018-06-14"},
            //  ...
            //] 
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            // try{} catch{} will attempt to do everything inside try{}
            // if an error happens inside try{}, then catch{} will execute instead.
            // very useful for debugging without the whole program crashing!
            // this can be easily abused and should be used sparingly.
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();


                //for every row in the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //for every column in the row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }//end row
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

    }
}