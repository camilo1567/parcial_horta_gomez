namespace parcial_Horta_Gomez.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpleado { get; set; }
        public string IdServicio { get; set; }
        public DateTime Fecha { get; set; }

    }
}
