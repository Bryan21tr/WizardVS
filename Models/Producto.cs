namespace WizardVS.Models
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}