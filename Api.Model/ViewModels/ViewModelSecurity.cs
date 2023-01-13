using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelSecurity
    {
        public Funciones Funciones { get; set; } = null;

        public Roles Roles { get; set; } = null;

        public List<FuncionesRoles> FuncionesRoles { get; set; }

        public Usuarios Usuarios { get; set; } = null;

        public List<RolesUsuarios> RolesUsuarios { get; set; }
    }
}
