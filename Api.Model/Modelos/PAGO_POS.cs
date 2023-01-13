using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class PAGO_POS
    {
        string Documento { get; set; }
        string Pago { get; set; }
        string Caja { get; set; }
        string Tipo { get; set; }
        string Condicion_Pago { get; set; }
        string Entidad_Financiera { get; set; }
        string Tipo_Tarjeta { get; set; } 
        string Forma_Pago { get; set; }
        string Numero { get; set; }
        decimal Monto_Local { get; set; }
        decimal Monto_Dolar { get; set; }
        string Autorizacion { get; set; }
        string Fecha_Expiracion { get; set; }
        int Cobro { get; set; }
        string Cliente_Liquidador { get; set; }
        string Tipo_Cobro { get; set; }
        string Referencia { get; set; }
        string Num_Seguimiento { get; set; }
        string Num_Transac_Tarjeta { get; set; }
        string Campo1 { get; set; }
        string Valor1 { get; set; }
        string Campo2 { get; set; }
        string Valor2 { get; set; }
        string Campo3 { get; set; }
        string Valor3 { get; set; }
        string Campo4 { get; set; }
        string Valor4 { get; set; }
        string Campo5 { get; set; }
        string Valor5 { get; set; }
        string Campo6 { get; set; }
        string Valor6 { get; set; }
        byte Noteexistsflag { get; set; }
        DateTime Recorddate { get; set; }
        Guid Rowpointer { get; set; }
        string Createdby { get; set; }
        string Updatedby { get; set; }
        DateTime Createdate { get; set; }
    }
}
