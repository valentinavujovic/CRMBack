using CRMSYSTEMBACK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRMSYSTEMBACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,name,password,email,role from User where role='client'";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Client client)
        {
            string query = @"insert into User(name,email,password,role) values (@name,@email,@password,@role);
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    
                    myComand.Parameters.AddWithValue("@name", client.Name);
                    myComand.Parameters.AddWithValue("@email", client.email);
                    myComand.Parameters.AddWithValue("@password", client.password);
                    myComand.Parameters.AddWithValue("@role", "client");
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added succesfully");
        }
        [HttpPut]
        public JsonResult Put(Client client)
        {
            string query = @"update User set 
                            name=@name,
                            email=@email,
                            password=@password,
                            role=@role
                            where id=@clientid;
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    myComand.Parameters.AddWithValue("@clientid", client.Id);
                    myComand.Parameters.AddWithValue("@name", client.Name);
                    myComand.Parameters.AddWithValue("@email", client.email);
                    myComand.Parameters.AddWithValue("@password", client.password);
                    myComand.Parameters.AddWithValue("@role", "client");
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Changed succesfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from User where id=@clientid;
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    myComand.Parameters.AddWithValue("@clientid", id);

                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("deleted succesfully");
        }

    }
}
