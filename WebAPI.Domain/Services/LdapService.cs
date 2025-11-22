using System.DirectoryServices.Protocols;
using System.Net;
using System.Reflection.PortableExecutable;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Services
{
    public class LdapService
    {
        private readonly string _domain = "CMH.LOCAL";
        private readonly string _ldapServer = "BDC-DOMINIO.CMH.LOCAL";

        public bool ValidateUser(string username, string password)
        {
            try
            {
                var credential = new NetworkCredential(username, password, _domain);

                using var connection = new LdapConnection(_ldapServer)
                {
                    Credential = credential,
                    AuthType = AuthType.Negotiate
                };

                connection.Bind();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioEntiy GetUserLdap(string email, string password)
        {
            try
            {
                // El usuario para autenticar puede ser el mismo correo
                // o puedes usar userPrincipalName si lo prefieres
                string usernameSam = email.Split('@')[0];
                var credential = new NetworkCredential(usernameSam, password);

                using var connection = new LdapConnection(_ldapServer)
                {
                    Credential = credential,
                    AuthType = AuthType.Negotiate
                };

                // Validar credenciales (Bind)
                connection.Bind();

                // Ahora buscamos al usuario por el correo
                var searchFilter = $"(mail={email})";

                var request = new SearchRequest(
                    "DC=CMH,DC=LOCAL",
                    searchFilter,
                    SearchScope.Subtree,
                    new[]
                    {
                        "givenName", "sn", "displayName", "mail"
                    }
                );

                //var request = new SearchRequest(
                //    "DC=CMH,DC=LOCAL",   // Base DN
                //    searchFilter,        // (sAMAccountName=usuario)
                //    SearchScope.Subtree,
                //    null                 // <--- NULL = traer TODOS los atributos
                //);

                var response = (SearchResponse)connection.SendRequest(request);

                if (response.Entries.Count == 0)
                    return null;

                var entry = response.Entries[0];

                return new UsuarioEntiy
                {
                    Nombres = entry.Attributes["givenName"]?[0]?.ToString(),
                    Apellidos = entry.Attributes["sn"]?[0]?.ToString(),
                    Correo = entry.Attributes["mail"]?[0]?.ToString(),
                    IsActiveDirectoryUser = true,
                    EstadoId = 1
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
