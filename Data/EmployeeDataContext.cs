using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SampleAngularAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAngularAPI.Data
{
    public class EmployeeDataContext
    {
        private readonly IConfiguration configuration;
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMapper mapper;
        public EmployeeDataContext(IConfiguration _configuration,IMapper _mapper)
        {
            this.configuration = _configuration;
            this.mapper = _mapper;
            var client = new MongoClient(this.configuration.GetSection("MongoDBConnection").Value);
            mongoDatabase=client.GetDatabase(this.configuration.GetSection("MongoDatabase").Value);
        }
        public IMongoCollection<EmployeeModel> Employees
        {
            get
            {
                IMongoCollection<EmployeeModel> mongoCollectionEmployee = mongoDatabase.GetCollection<EmployeeModel>(this.configuration.GetSection("EmployeeTable").Value);
                return mongoCollectionEmployee;
            }
        }
        public List<Employee> GetEmployees()
        {
            var employees = Employees.Find(_ => true).ToList();
            if (employees != null)
            {
                return mapper.Map<List<Employee>>(employees);
            }
            return null;
        }
        public bool AddEmployee(Employee employee)
        {
            var employeeModel = mapper.Map<EmployeeModel>(employee);
            Employees.InsertOne(employeeModel);
            if (string.IsNullOrWhiteSpace(employeeModel.Id))
            {
                return false;
            }
            employee.Id = employeeModel.Id;
            return true;
        }
    }
}
