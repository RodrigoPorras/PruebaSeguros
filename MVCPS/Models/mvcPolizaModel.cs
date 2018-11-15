using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPS.Models
{
    public class mvcPolizaModel
    {
        public int IDPoliza { get; set; }
        [Required (ErrorMessage = "Este campo es necesario")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IDTipoCubrimiento { get; set; }
        public Nullable<double> Cobertura { get; set; }
        public Nullable<System.DateTime> InicioVigenciaPoliza { get; set; }
        public Nullable<int> PeriodoDeCobertura { get; set; }
        public Nullable<double> PrecioPoliza { get; set; }
        public Nullable<int> IDTipoRiesgo { get; set; }
        public Nullable<int> IDCliente { get; set; }
    }
}