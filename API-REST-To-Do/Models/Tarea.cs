namespace API_REST_To_Do.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool isCompleted { get; set; }

    }
}
