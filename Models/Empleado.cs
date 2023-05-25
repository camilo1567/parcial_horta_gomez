namespace parcial_Horta_Gomez.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NumeroDocumento { get; set; }

        public ICollection<Factura>? Facturas { get; set; } = default!;
    }
}
