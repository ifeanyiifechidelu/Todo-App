using System.Collections.Generic;
using Webform.Models;

namespace Webform.Services
{
    public interface IService
    {
        public List<FormModel> ViewAllData();
        public FormModel GetTaskById(int id);
        public bool UpdateRecord (FormModel obj);
        public bool DeleteRecordById (int id);
        public bool DeleteAllRecord();
        public bool CreateTask(FormModel formModel);
        public List<FormModel> GetTaskList(string search);
    }
}
