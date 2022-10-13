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
        [HttpGet("{users_id}")]
        public JsonResult Get(int users_id)
        {

            string query = @"select id,users_id,ProjectTitle,ProjectDescription,Projectdeadline,ProjectStatus from Project where users_id='" + users_id + "'";
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
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,users_id,ProjectTitle,ProjectDescription,Projectdeadline,ProjectStatus from Project";
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
        [HttpPost()]
        public JsonResult Post(Project project,int id)
        {
            string query = @"insert into Project(ProjectTitle,ProjectDescription,Projectdeadline,ProjectStatus,users_id) values (@ProjectTitle,@ProjectDescription,@Projectdeadline,@ProjectStatus,@users_id)";
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
                    myComand.Parameters.AddWithValue("@users_id", project.users_id);

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
                            users_id=@users_id,
                            projectTitle = @ProjectTitle,
                            projectDescription= @ProjectDescription,
                            projectdeadline=@Projectdeadline,
                            projectStatus=@ProjectStatus
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
                    myComand.Parameters.AddWithValue("@users_id", project.users_id);
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