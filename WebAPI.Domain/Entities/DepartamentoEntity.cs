namespace WebAPI.Domain.Entities
{
    public class DepartamentoEntity
    {
        public int Id { get; set; }
        public string Departamento { get; set; }
        public int PaisId { get; set; }

        // Navegación
        public PaisEntity Pais { get; set; }
    }
}
