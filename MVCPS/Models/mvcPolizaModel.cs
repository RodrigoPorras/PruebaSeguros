using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MVCPS.ModelsValidations;

namespace MVCPS.Models
{
    public class MvcPolizaModel
    {
        public int IDPoliza { get; set; }
        [Required (ErrorMessage = "Este campo es necesario")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        [DisplayName("Tipo De Cubrimiento")]
        public Nullable<int> IDTipoCubrimiento { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        [Range(1,100,ErrorMessage ="El valor debe estar entre 1 y 100")]
        [ValidacionCoberturaAttribute("IDTipoRiesgo",ErrorMessage ="valor menor o igual a 50")]
        public double? Cobertura { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public Nullable<System.DateTime> InicioVigenciaPoliza { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public Nullable<int> PeriodoDeCobertura { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public Nullable<double> PrecioPoliza { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        [DisplayName("Tipo De Riesgo")]
        public Nullable<int> IDTipoRiesgo { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        [DisplayName("Cedula o ID De Cliente")]
        public Nullable<int> IDCliente { get; set; }

        [NotMapped]
        public List<MvcTipoDeCubrimientoModel> TipoDeCubrimientoCollection { get; set; }
        [NotMapped]
        public List<MvcTipoDeRiesgoModel> TipoDeRiesgoCollection { get; set; }
    }
}