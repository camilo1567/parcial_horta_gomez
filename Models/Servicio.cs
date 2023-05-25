namespace parcial_Horta_Gomez.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Empleado>? Empleados { get; set; } = default!;
    }
}
