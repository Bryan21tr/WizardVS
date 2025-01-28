using System.ComponentModel.DataAnnotations;
namespace WizardVS.Models
{
public class EmpleadoLaboralViewModel
{
    [Required(ErrorMessage = "El departamento es obligatorio")]
    public string Departamento { get; set; }
 
    [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
    public DateTime FechaIngreso { get; set; }
 
    [Required(ErrorMessage = "El salario es obligatorio")]
    public int Salario { get; set; }
}
}