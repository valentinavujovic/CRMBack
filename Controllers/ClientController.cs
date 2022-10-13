using CRMSYSTEMBACK.Entities;
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
            string query = @"select id,name,passwordHash,email,role from Users where role=1";
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
        public JsonResult Post(User client)
        {
            string query = @"insert into Users(name,email,role) values (@name,@email,@role);
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
                    myComand.Parameters.AddWithValue("@email", client.Email);
                    myComand.Parameters.AddWithValue("@role", 1) ;
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added succesfully");
        }
        [HttpPut()]
        public JsonResult Put(User client)
        {
            string query = @"update Users set 
                            name=@name,
                            email=@email,
                            passwordHash=@passwordHash,
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
                    myComand.Parameters.AddWithValue("@email", client.Email);
                    myComand.Parameters.AddWithValue("@passwordHash", client.PasswordHash);
                    myComand.Parameters.AddWithValue("@role", 1);
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Changed succesfully");
        }
        [HttpPut("users")]
        public JsonResult Put1(User client)
        {
            string query = @"update Users set 
                            name=@name,
                            email=@email,
                            passwordHash=@passwordHash,
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
                    myComand.Parameters.AddWithValue("@email", client.Email);
                    myComand.Parameters.AddWithValue("@passwordHash", client.PasswordHash);
                    myComand.Parameters.AddWithValue("@role", client.Role);
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
            string query = @"delete from Users where id=@clientid;
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
