using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DBBOFCT
{
    public partial class Usuario
    { 
        public static Usuario GetUsuarioByID(BOFCTEntities db, int usuarioID)
        {
            return (from u in db.Usuario
                    where u.UsuarioID == usuarioID
                    orderby u.UsuarioID
                    select u).FirstOrDefault();
        }

        public static List<Usuario> GetList(BOFCTEntities db)
        {
            return (from u in db.Usuario
                    orderby u.UsuarioID 
                    select u).ToList();
        }

    }
}
