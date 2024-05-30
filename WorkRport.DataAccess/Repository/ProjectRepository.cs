using System.Web.Mvc;
using Trac_WorkReport.Models;
using WorkReport.DataAccess.Data;
using WorkRport.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetProjectSelectListItems()
        {
            return _db.Projects.Select(p => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = p.ProjectId.ToString(), // Assuming Id is a property of Projects
                Text = p.ProjectName // Assuming ProjectName is a property of Projects
               
            }).ToList();
        }
    }
}

