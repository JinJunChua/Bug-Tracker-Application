using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerApplication.Models;

namespace BugTrackerApplication.DAL
{
    public interface IDataGateway<T> where T: class
    {
        IEnumerable<T> SelectAll();
        T SelectById(int? id);
        void Insert(T obj);
        void Update(int? id, T obj);
        T Delete(int? id);
        void Save();
        
    }
}
