using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Webform.Models;
using Webform.Repository;

namespace Webform.Services
{
    public class Service : IService
    {
        private readonly IRepository _repo;
        private readonly IConfiguration _config;
        public Service(IRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        #region(CreateTask)
        public bool CreateTask(FormModel obj)
        {
            var createdDate = DateTime.Now.ToShortDateString();
            var dueDate = obj.DueDate.ToString();
            var statement = $"INSERT INTO tasks VALUES('{obj.Task}', '{obj.DueDate}')";
            return _repo.ExecuteQuery(statement);
        }
        #endregion

        public bool DeleteAllRecord()
        {
            string statement = "TRUNCATE TABLE";
            return _repo.ExecuteQuery(statement);
        }

        public bool DeleteRecordById(int id)
        {
            var statement = $"DELETE FROM tasks WHERE id={id}";
            return _repo.ExecuteQuery(statement);
        }

        #region Get Task By ID
        public FormModel GetTaskById(int id)
        {
            var statement = $"SELECT * FROM tasks WHERE Id= {id}";
            var dataValue = _repo.DataFromDB(statement);
            try
            {
                if (dataValue.HasRows)
                {
                    var result = new FormModel();
                    while (dataValue.Read())
                    {
                        result.TaskId = (int)dataValue["id"];
                        result.Task = dataValue["Tasks"].ToString();
                        result.DueDate = Convert.ToDateTime(dataValue["Due_Date"].ToString());

                    }
                    return result;
                }
                else
                {
                    return new FormModel();
                }
            }
            finally
            {

            }
        }
        #endregion


        public List<FormModel> GetTaskList(string search)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateRecord(FormModel obj)
        {
            var dueDateString = obj.DueDate.ToString();
            var statement = $"UPDATE tasks SET Tasks = '{obj.Task}', Due_Date = '{dueDateString}' WHERE id = {obj.TaskId}";
            return _repo.ExecuteQuery(statement);        
        }

        public List<FormModel> ViewAllData()
        {
            var statement = _repo.DataFromDB("SELECT * FROM tasks");
            try
            {
                if (statement.HasRows)
                {
                    var records = new List<FormModel>();
                    while (statement.Read())
                    {
                        records.Add(new FormModel()
                        {
                            TaskId = (int)statement["id"],
                            Task = statement["Tasks"].ToString(),
                            DueDate = Convert.ToDateTime(statement["Due_Date"].ToString()),
                        }) ;
                    }
                    return records;
                }
                else
                {
                    return new List<FormModel>();
                }
            }
            finally
            {

            }
        }
    }
}

