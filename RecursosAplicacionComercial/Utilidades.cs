using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace WEB.Clases
{
    public class Utilidades
    {
        public static MembershipUserCollection GetAllUserWithSelectUser()
        {
            MembershipUserCollection misUsuariosConOtro = new MembershipUserCollection();
            MembershipUserCollection misUsuarios = Membership.GetAllUsers();

            if (misUsuarios == null) return null;

            MembershipUser miOtroUsuario = null;
            foreach (MembershipUser miUsuario in misUsuarios)
            {
                miOtroUsuario = new MembershipUser(
                    miUsuario.ProviderName,
                    "[Seleccione un usuario...]",
                    miUsuario.ProviderUserKey,
                    miUsuario.Email,
                    miUsuario.PasswordQuestion,
                    miUsuario.Comment,
                    miUsuario.IsApproved,
                    miUsuario.IsLockedOut,
                    miUsuario.CreationDate,
                    miUsuario.LastLoginDate,
                    miUsuario.LastActivityDate,
                    miUsuario.LastPasswordChangedDate,
                    miUsuario.LastLockoutDate);
                break;
            }

            misUsuariosConOtro.Add(miOtroUsuario);

            foreach (MembershipUser miUsuario in misUsuarios)
            {
                misUsuariosConOtro.Add(miUsuario);
            }

            return misUsuariosConOtro;
        }
    }
}
