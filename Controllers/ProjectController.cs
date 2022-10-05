using CRMSYSTEMBACK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRMSYSTEMBACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,ProjectTitle,ProjectDescription,Projectdeadline,ProjectStatus from Project";
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
        public JsonResult Post(Project project)
        {
            string query = @"insert into Project(ProjectTitle,ProjectDescription,Projectdeadline,ProjectStatus) values (@ProjectTitle,@ProjectDescription,@Projectdeadline,@ProjectStatus);
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {

                    myComand.Parameters.AddWithValue("@ProjectTitle", project.ProjectTitle);
                    myComand.Parameters.AddWithValue("@ProjectDescription", project.ProjectDescription);
                    myComand.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus);
                    myComand.Parameters.AddWithValue("@Projectdeadline", project.Projectdeadline);
                    myreader = myComand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added succesfully");
        }
        [HttpPut]
        public JsonResult Put(Project project)
        {
            string query = @"update Project set
                            ProjectTitle = @ProjectTitle,
                            ProjectDescription= @ProjectDescription,
                            Projectdeadline=@Projectdeadline,
                            ProjectStatus=@ProjectStatus
                            where id = @projectid;
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    myComand.Parameters.AddWithValue("@projectid", project.Id);
                    myComand.Parameters.AddWithValue("@ProjectTitle", project.ProjectTitle);
                    myComand.Parameters.AddWithValue("@ProjectDescription", project.ProjectDescription);
                    myComand.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus);
                    myComand.Parameters.AddWithValue("@Projectdeadline", project.Projectdeadline);
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
            string query = @"delete from Project where id=@projectid;
";
            DataTable table = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("CRMAppCon");
            MySqlDataReader myreader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myComand = new MySqlCommand(query, mycon))
                {
                    myComand.Parameters.AddWithValue("@projectid", id);

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