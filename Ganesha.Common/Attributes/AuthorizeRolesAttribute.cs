using System.Web.Mvc;

namespace Ganesha.Common.Attributes {
    public class AuthorizeRolesAttribute : AuthorizeAttribute {
        public AuthorizeRolesAttribute(params string[] roles) {
            Roles = string.Join(",", roles);
        }
    }
}
