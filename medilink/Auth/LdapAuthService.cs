using System;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace medilink.Auth
{
    public class LdapAuthService
    {
        private readonly string _domainName = ConfigurationManager.AppSettings["AdDomainName"];
        private readonly string _adServer = ConfigurationManager.AppSettings["AdServer"];
        private readonly string _baseDn = ConfigurationManager.AppSettings["AdBaseDn"];
        private readonly string _grpSis = ConfigurationManager.AppSettings["GrpSistemas"];
        private readonly string _grpGes = ConfigurationManager.AppSettings["GrpGestor"];
        private readonly string _grpMed = ConfigurationManager.AppSettings["GrpMedico"];
        private readonly string _grpRec = ConfigurationManager.AppSettings["GrpRecepcionista"];
        private PrincipalContext _principalContext;

        // Crear el contexto de conexión al dominio
        private PrincipalContext GetContext()
        {
            //if (!string.IsNullOrWhiteSpace(_domainName))
            //{
            //    //_principalContext = new PrincipalContext(ContextType.Domain, _domainName);
            //    //return _principalContext;
            //}
            //return new PrincipalContext(ContextType.Domain, _domainName);


            // fallback: usar IP + BaseDN

            //return new PrincipalContext(ContextType.Domain, _adServer, _baseDn);

            if (_principalContext == null)
            {
                _principalContext = new PrincipalContext(ContextType.Domain, _adServer, _baseDn);
            }
            
            return _principalContext;

        }

        // Validar credenciales contra Active Directory
        //public bool ValidateUser(string username, string password)
        //{
        //    using (var ctx = GetContext())
        //    {
        //        return ctx.ValidateCredentials(username, password, ContextOptions.Negotiate);
        //    }
        //}

        public bool ValidateUser(string username, string password)
        {
            var ctx = GetContext();
            //{
                // intentos con distintos formatos + 2 modos de bind
                string[] users = {
                    username,                            // "user-s"
                    $"LU60591\\{username}",              // "LU60591\user-s"
                    $"{username}@LU60591.LOCAL"          // "user-s@LU60591.LOCAL"
                };

                foreach (var u in users)
                {
                    if (ctx.ValidateCredentials(u, password, ContextOptions.Negotiate)) return true;
                    if (ctx.ValidateCredentials(u, password, ContextOptions.SimpleBind)) return true;
                }
                return false;
            //}
        }


        // Obtener el rol del usuario según los grupos de AD
        //public string GetUserRole(string username)
        //{
        //    using (var ctx = GetContext())
        //    using (var user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username))
        //    {
        //        if (user == null) return null;

        //        var groups = user.GetAuthorizationGroups().Select(g => g.SamAccountName).ToList();

        //        if (groups.Contains(_grpSis, StringComparer.OrdinalIgnoreCase))
        //            return "Sistemas";

        //        if (groups.Contains(_grpGes, StringComparer.OrdinalIgnoreCase))
        //            return "Gestor";

        //        if (groups.Contains(_grpMed, StringComparer.OrdinalIgnoreCase))
        //            return "Medico";

        //        if (groups.Contains(_grpRec, StringComparer.OrdinalIgnoreCase))
        //            return "Recepcionista";

        //        return null; // No tiene grupo válido de la app
        //    }
        //}

        public string GetUserRole(string username, string password)
        {
            using (var ctx = new PrincipalContext(
            ContextType.Domain,
            "192.168.0.50",
            "DC=lu60591,DC=local",
            username,
            password))
                {
                    var up = UserPrincipal.FindByIdentity(ctx, username);
                    var groups = up.GetAuthorizationGroups().Select(g => g.SamAccountName).ToList();
                    if (groups.Any(n => n.Equals(_grpSis, StringComparison.OrdinalIgnoreCase))) return "Sistemas";
                    if (groups.Any(n => n.Equals(_grpGes, StringComparison.OrdinalIgnoreCase))) return "Gestor";
                    if (groups.Any(n => n.Equals(_grpMed, StringComparison.OrdinalIgnoreCase))) return "Medico";
                    if (groups.Any(n => n.Equals(_grpRec, StringComparison.OrdinalIgnoreCase))) return "Recepcionista";
                    return null; // only works if username/password were valid
                }
            
            //var ctx = GetContext();

            ////{
            //    //var up =
            //    //    UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username)
            //    // ?? UserPrincipal.FindByIdentity(ctx, IdentityType.UserPrincipalName, $"{username}@LU60591");

            //    var up = UserPrincipal.FindByIdentity(ctx, username);
            //    if (up == null) return null;

                //var groups = up.GetAuthorizationGroups().Select(g => g.SamAccountName).ToList();
                //if (groups.Any(n => n.Equals(_grpSis, StringComparison.OrdinalIgnoreCase))) return "Sistemas";
                //if (groups.Any(n => n.Equals(_grpGes, StringComparison.OrdinalIgnoreCase))) return "Gestor";
                //if (groups.Any(n => n.Equals(_grpMed, StringComparison.OrdinalIgnoreCase))) return "Medico";
                //if (groups.Any(n => n.Equals(_grpRec, StringComparison.OrdinalIgnoreCase))) return "Recepcionista";
                //return null;
            //}
        }

    }
}
