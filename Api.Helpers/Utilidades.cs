using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class Utilidades
    {
        public Guid GenerarGuid()
        { 
            Guid miGUID = Guid.NewGuid();
            //String sGUID = miGUID.ToString();
            return miGUID;            
        }

        public string ConvertirEnCadenatring(object obj, string nombreObjeto, string campo)
        {
            string nuevaCadena = "";

            if (nombreObjeto == "FuncionesRoles")
            {
                List<FuncionesRoles> funcionesRoles = (List<FuncionesRoles>)obj;
                foreach (var item in funcionesRoles)
                {
                    if (campo == "RolID")
                    {
                        nuevaCadena = nuevaCadena + item.RolID.ToString() + "*";
                    }
                    else if (campo == "FuncionID")
                    {
                        nuevaCadena = nuevaCadena + item.FuncionID.ToString() + "*";
                    }
                }
            }
            else if (nombreObjeto == "RolesUsuarios")
            {
                List<RolesUsuarios> rolesUsuario = (List<RolesUsuarios>)obj;
                foreach (var item in rolesUsuario)
                {

                    nuevaCadena = nuevaCadena + item.RolID.ToString() + "*";

                }
            }

            //si la cadena no esta vacia entonces quita el ultimo caracter (*) para enviarlo al servidor de sql server.
            if (nuevaCadena.Length > 0) nuevaCadena = nuevaCadena.Substring(0, nuevaCadena.Length - 1);

            return nuevaCadena;
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj is Persona)
        //    {
        //        Persona otro = (Persona)obj;
        //        return otro.Edad == Edad &&
        //               otro.Nombre == Nombre;
        //    }
        //    return false;


        public string ConvertirEnCadenatring2(List<FuncionesRoles> funcionesRoles, string Campo)
        {

            var cadena = "";
            foreach (var item in funcionesRoles)
            {
                if (Campo == "RolID")
                {
                    cadena = cadena + item.RolID.ToString() + "*";
                }
                else if (Campo == "FuncionID")
                {
                    cadena = cadena + item.FuncionID.ToString() + "*";
                }

            }

            //si la cadena no esta vacia entonces quita el ultimo caracter (*) para enviarlo al servidor de sql server.
            if (cadena.Length > 0) cadena = cadena.Substring(0, cadena.Length - 1);
            return cadena;
        }

        /// <summary>
        /// Método que devuelve el Domingo de Pascua dado un año a consultar.
        /// </summary>
        /// <param name="anyo">Año a consultar.</param>
        /// <returns>Día del año que es Domingo de Pascua.</returns> 
        private DateTime GetFechaPascua(int anyo)
        {
            int M = 25;
            int N = 5;

            if (anyo >= 1583 && anyo <= 1699) { M = 22; N = 2; }
            else if (anyo >= 1700 && anyo <= 1799) { M = 23; N = 3; }
            else if (anyo >= 1800 && anyo <= 1899) { M = 23; N = 4; }
            else if (anyo >= 1900 && anyo <= 2099) { M = 24; N = 5; }
            else if (anyo >= 2100 && anyo <= 2199) { M = 24; N = 6; }
            else if (anyo >= 2200 && anyo <= 2299) { M = 25; N = 0; }

            int a, b, c, d, e, dia, mes;

            //Cálculo de residuos
            a = anyo % 19;
            b = anyo % 4;
            c = anyo % 7;
            d = (19 * a + M) % 30;
            e = (2 * b + 4 * c + 6 * d + N) % 7;

            // Decidir entre los 2 casos:
            if (d + e < 10) { dia = d + e + 22; mes = 3; }
            else { dia = d + e - 9; mes = 4; }

            // Excepciones especiales
            if (dia == 26 && mes == 4) dia = 19;
            if (dia == 25 && mes == 4 && d == 28 && e == 6 && a > 10) dia = 18;

            return new DateTime(anyo, mes, dia);
        }

        public bool FechaEsSemanaSanta(DateTime fecha)
        {
            bool esSemanaSanta = false;

            DateTime domingoSanto = GetFechaPascua(fecha.Year);
            DateTime juevesSanto = domingoSanto.AddDays(-3);
            DateTime viernesSanto = domingoSanto.AddDays(-2);
            DateTime sabadoSanto = domingoSanto.AddDays(-1);

            if (fecha.Date == juevesSanto)
            {
                esSemanaSanta = true;
            }
            else if (fecha.Date == viernesSanto)
            {
                esSemanaSanta = true;
            }
            else if (fecha.Date == sabadoSanto)
            {
                esSemanaSanta = true;
            }

            return esSemanaSanta;
        }


    }
}

