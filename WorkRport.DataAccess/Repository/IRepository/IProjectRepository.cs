using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;

namespace WorkRport.DataAccess.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Projects>
    {
        void update(Projects obj);
        void save();
    }
}
