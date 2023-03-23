using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartipationController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public PartipationController(IConfiguration configuration)
        {
            _configuration = configuration;

        }



        [HttpPost]
        public JsonResult Post(Partipation partipation)
        {
            string query = @"insert into Partipation values
                            ('" + partipation.employee_id + @"','" + partipation.project_id + @"','" + partipation.salary + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);


        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"Select a.EmployeeName,a.Deparment,b.Name from Partipation inner join Employee a  on a.EmployeeId=employee_id inner join Project b on project_id=b.projectId where project_id='" + id + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }


        [HttpGet("/employee/{id2}")]
        public JsonResult GetEmployeeInfo(int id2)
        {
            string query = @"Select a.EmployeeName,a.Deparment,b.Name,salary from Partipation inner join Employee a  on a.EmployeeId=employee_id inner join Project b on project_id=b.projectId where employee_id='" + id2 + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }
    }
}

