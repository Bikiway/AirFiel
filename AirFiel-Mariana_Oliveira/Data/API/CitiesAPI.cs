using AirFiel_Mariana_Oliveira.Helpers;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vereyon.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AirFiel_Mariana_Oliveira.Data.API
{
    public class CitiesAPI
    {
        #region
        public Names _name { get; set; }

        private List<string> _cities;

        private string _cca3;

        private Flags _flags;

        public Names Name
        {
            get { return _name; }
            set { _name = value ?? new Names(); }
        }

        public List<string> cities
        {
            get { return _cities; }
            set { _cities = value ?? new List<string>(); }
        }

        public string CCA3
        {
            get
            {
                if (_cca3 == null || _cca3.Length == 0)
                    return "N/A";

                return _cca3;
            }
            set
            {
                _cca3 = value;
            }
        }

        public Flags Flags { get; set; }
        #endregion


        #region
        //Uri baseAddress = new Uri("https://flagcdn.com/en/codes.json");
        //private readonly HttpClient _httpClient;
        private static SqlConnection _connection;
        private static SqlCommand _command;

        private const string Path = @"Data\apiCities.sql";

        public CitiesAPI()
        {
            _name = new Names();
            _name.Name = new Dictionary<string, Names>

            {
                { "default", new Names {Official = "N/A"}}
            };

            _cities = new List<string>();
            Flags = new Flags(this);
            //_httpClient = new HttpClient();
            //_httpClient.BaseAddress = baseAddress;          

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            try
            {
                _command = new SqlCommand("Data Source = " + Path);
                _connection.Open();

                const string sqlcommand = "CREATE TABLE IF NOT EXISTS CitiesAPI_Json(CitiesAPI_cca3 varchar(10) PRIMARY KEY, json_data TEXT);";
                _command = new SqlCommand(sqlcommand, _connection);
                _command.ExecuteNonQuery();
            }
            catch (Exception e) { _ = e.Message; }

            finally
            {
                _connection.Close();
                _connection.Close();
            }
        }
        #endregion

        #region
        public static Response SaveData(ObservableCollection<CitiesAPI> apiCities)
        {
            if (apiCities == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "There's no countries list..."
                };
            }


            try
            {
                _connection = new SqlConnection("Data Source = " + Path);
                _connection.Open();

                foreach(var city in apiCities)
                {
                    const string sql = "INSERT INTO CitiesAPI_Json (CitiesAPI_cca3, json_data) VALUES (@cca3, @json)";
                    _command = new SqlCommand(sql, _connection);

                    _command.Parameters.Add("@cca3", System.Data.SqlDbType.Text, 3).Value = city.CCA3;
                    _command.Parameters.Add("@json", System.Data.SqlDbType.Text).Value = JsonConvert.SerializeObject(city);
                    _command.ExecuteNonQuery ();
                }

                return new Response
                {
                    IsSuccess = true,
                    Message = "Successfuly inserted into DataBase",
                };

            }
            catch (Exception e) 
            { _ = e.Message; }

            return new Response
            {
                IsSuccess = true,
                Message = "Successfuly inserted into DataBase",
            };

        }

        public static Response GetData()
        {
            try
            {
                _connection = new SqlConnection("Data Source =" + Path);
                _connection.Open();
                const string sql = "select json_data FROM CitiesAPI_Json";
                _command = new SqlCommand(sql, _connection);

                SqlDataReader reader = _command.ExecuteReader();

                var separar = "[";
                while (reader.Read())
                {
                    {
                        separar += new string((string)reader["json_data"] + ",");
                    }
                }
                separar += "]";

                if (separar.Length > 0)
                {
                    var countries = JsonConvert.DeserializeObject<ObservableCollection<CitiesAPI>>(separar);
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "Data read successfuly",
                        Results = countries, 
                    };
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                return null;
            }
            return new Response
            {
                IsSuccess = true,
                Message = "All data as been read."
            };
        }

        public static Response DeleteData()
        {
            try
            {
                string sql = "DELETE FROM CitiesAPI_Json";
                _command = new SqlCommand(sql, _connection);
                _command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                _ = e.Message;
            }
            return new Response
            {
                IsSuccess = true,
                Message = "Deleted."
            };
        }
        #endregion

        #region
        public async Task<Response> DownloadFlags(ObservableCollection<CitiesAPI> List, IProgress<int> progress)
        {
            string flagsFolder = @"Flags\Bandeiras.sql";

            if (!Directory.Exists(flagsFolder))
            {
                Directory.CreateDirectory(flagsFolder);
            }


            try
            {
                string[] flagsInFolder = Directory.GetFiles(flagsFolder);

                int flagsDownloaded = 0;

                var httpClient = new HttpClient();

                foreach (var lista in List)
                {
                    string flagFile = $"{lista.CCA3}.png";
                    string filePath = System.IO.Path.Combine(flagsFolder, flagFile);

                    if (!File.Exists(filePath))
                    {
                        var stream = await httpClient.GetStreamAsync(lista.Flags.Png);
                        using (var fileStream = File.Create(filePath))
                        {
                            stream.CopyTo(fileStream);
                            flagsDownloaded++;

                            int percentageComplete = flagsDownloaded * 100 / (List.Count - flagsInFolder.Length);

                            progress.Report(percentageComplete);

                        }
                    }
                    lista.Flags.LocalImage = Directory.GetCurrentDirectory() + @"/Bandeiras.sql/" + $"{lista.CCA3}.png";
                }

                if (flagsDownloaded > 0)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = $"Download concluído: {flagsDownloaded}"
                    };
                }
                else
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = "All flags are saved."
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        #endregion
    }
}
