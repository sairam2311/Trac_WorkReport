using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Trac_WorkReport.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorkRport.DataAccess.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Projects>
    {
        void update(Projects obj);
        void save();

        IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetProjectSelectListItems();
    }
}
