using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkRport.DataAccess.Repository.IRepository;

namespace WorkRport.DataAccess.Repository
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {

        private ApplicationDbContext _db;

        public DesignationRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

        public void save()
        {
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void update(Designation obj)
        {
            _db.Designations.Update(obj);   
        }
    }
}
