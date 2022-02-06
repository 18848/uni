using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using API.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(Roles = "Admin,User")]
    public class VisitasController : Controller
    {
        private protected static string server = "Server=.;Database=ISI;Trusted_Connection=True;";
        private protected SqlConnection con = new SqlConnection(server);

        public object Visitas()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }

            try
            {
                string q;

                q = "Select * FROM fiscalizacao";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                da.Fill(ds);

                List<string> data = new List<string>();
                List<string> result = new List<string>();


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    object[] r = row.ItemArray;

                    data.Add(r[2].ToString());
                }

                foreach (string n in data)
                {
                    if (DateTime.Compare(DateTime.Parse(n), DateTime.Now.AddDays(-30)) >= 0)
                    {
                        result.Add(n);
                    }
                }

                ds.Tables[0].Rows.Clear();
                ds.Tables[0].Columns.Remove("idfiscalizacao");
                ds.Tables[0].Columns.Remove("idutente");

                Dictionary<string, int> dic = new Dictionary<string, int>();

                foreach (string n in result)
                {
                    ds.Tables[0].Rows.Add(new object[] { n });
                    ds.AcceptChanges();

                    if (dic.ContainsKey(DateTime.Parse(n).ToString("dd-MM-yyyy")))
                    {
                        dic[DateTime.Parse(n).ToString("dd-MM-yyyy")]++;
                    }
                    else
                    {
                        dic.Add(DateTime.Parse(n).ToString("dd-MM-yyyy"), 1);
                    }
                }

                try
                {
                    con.Close();
                    var y = JsonConvert.SerializeObject(dic, Formatting.Indented);
                    return y;
                }
                catch (SqlException ex)
                {
                    return new ObjectResult(ex);
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }




            //List<ConcelhoModel> concelhos = new List<ConcelhoModel>();
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = client.GetAsync("https://covid19-api.vost.pt/Requests/get_last_update_counties").Result;
            //var res = response.Content.ReadAsStringAsync().Result;

            //concelhos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConcelhoModel>>(res);
            //return new ObjectResult(concelhos);
        }
    }
}
