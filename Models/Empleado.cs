using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizardVS.Models
{
public class Empleado
{
    [Key]
    public int id_empleado { get; set; }
 
    [Column(TypeName = "varchar(75)")]
    public string Nombres { get; set; }
 
    [Column(TypeName = "varchar(75)")]
    public string Apellidos { get; set; }
 
    [Column(TypeName = "varchar(100)")]
    public string Domicilio { get; set; }
 
    [Column(TypeName = "varchar(30)")]
    public string Departamento { get; set; }
 
    public DateTime FechaIngreso { get; set; }
 
    public int Salario { get; set; }
}
}