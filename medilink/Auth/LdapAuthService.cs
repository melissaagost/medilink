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

        // Crear el contexto de conexión al dominio
        private PrincipalContext GetContext()
        {
            if (!string.IsNullOrWhiteSpace(_domainName))
                return new PrincipalContext(ContextType.Domain, _domainName);

            // fallback: usar IP + BaseDN
            return new PrincipalContext(ContextType.Domain, _adServer, _baseDn);
        }

        // Validar credenciales contra Active Directory
        public bool ValidateUser(string username, string password)
        {
            using (var ctx = GetContext())
            {
                return ctx.ValidateCredentials(username, password, ContextOptions.Negotiate);
            }
        }

        // Obtener el rol del usuario según los grupos de AD
        public string GetUserRole(string username)
        {
            using (var ctx = GetContext())
            using (var user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username))
            {
                if (user == null) return null;

                var groups = user.GetAuthorizationGroups().Select(g => g.SamAccountName).ToList();

                if (groups.Contains(_grpSis, StringComparer.OrdinalIgnoreCase))
                    return "Sistemas";

                if (groups.Contains(_grpGes, StringComparer.OrdinalIgnoreCase))
                    return "Gestor";

                if (groups.Contains(_grpMed, StringComparer.OrdinalIgnoreCase))
                    return "Medico";

                if (groups.Contains(_grpRec, StringComparer.OrdinalIgnoreCase))
                    return "Recepcionista";

                return null; // No tiene grupo válido de la app
            }
        }
    }
}
