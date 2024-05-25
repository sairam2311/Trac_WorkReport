using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkRport.DataAccess.Repository.IRepository;

namespace WorkRport.DataAccess.Repository
{
    public class ProjectRepository : Repository<Projects>, IProjectRepository
    {
        private ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void update(Projects obj)
        {
            _db.Projects.Update(obj);
        }
    }
}

