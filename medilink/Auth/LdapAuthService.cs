using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
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



            if (_principalContext == null)
            {
                _principalContext = new PrincipalContext(ContextType.Domain, _adServer, _baseDn);
            }
            
            return _principalContext;

        }

    

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
                var de = up.GetUnderlyingObject() as DirectoryEntry;
                var groups = de.Properties["memberOf"];

                var targetGroups = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {

                    _grpSis, _grpGes, _grpMed, _grpRec
                };

                var groupRoleMap = new Dictionary<string, string>
                {
                    { _grpSis,"Sistemas" },
                    { _grpGes, "Gestor" },
                    { _grpMed, "Medico" },
                    { _grpRec, "Recepcionista"}
                };

                foreach (var group in groups)
                {
                    foreach (var mygroup in targetGroups)
                    {
                        if (group.ToString().ToLower().Contains(mygroup.ToString().ToLower()))
                        {
                            return groupRoleMap[mygroup.ToString()];
                        }
                    }
                }
                return null; 
                }
        }

    }
}
