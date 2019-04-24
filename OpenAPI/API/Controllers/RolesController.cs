using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using API.Models;
using System.Linq;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Role")]
    public class RolesController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationRoleManager _roleManager;

        private EntityConnection db = new EntityConnection();
        public RolesController()
        {
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return RoleManager.Roles;
        }

        public IdentityResult PostRole(string name)
        {
            var role = new IdentityRole { Name = name };
            var result = RoleManager.Create(role);
            return result;
        }
        
        public IdentityResult DeleteRole(string name)
        {
            var role = RoleManager.FindByName(name);
            if (role != null)
            {
                return RoleManager.Delete(role);
            } else
            {
                return new IdentityResult("Role not found!");
            }
        }
    }
}
