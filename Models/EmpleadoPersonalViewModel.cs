using System.ComponentModel.DataAnnotations;
namespace WizardVS.Models
{
public class EmpleadoPersonalViewModel
{
    [Required (ErrorMessage = "El campo nombres es obligatorio")]
    public string Nombres { get; set; }
 
    [Required(ErrorMessage = "El campo apellidos es obligatorio")]
    public string Apellidos { get; set; }
 
    [Required(ErrorMessage = "El campo domicilio es obligatorio")]
    public string Domicilio { get; set; }
}
}