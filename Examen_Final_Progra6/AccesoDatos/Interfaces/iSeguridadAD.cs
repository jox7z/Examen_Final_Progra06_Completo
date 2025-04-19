using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.EntidadesSeguridad;
using Entidades.EntidadesSeguridad;

namespace AccesoDatos.Interfaces
{
    public interface iSeguridadAD
    {
        TusrUsuario obtenerUsuario(string pLogin);
        List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin);

    }
}
