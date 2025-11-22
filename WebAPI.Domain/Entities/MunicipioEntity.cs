namespace WebAPI.Domain.Entities
{
    public class MunicipioEntity
    {
        public int Id { get; set; }
        public string Municipio { get; set; }
        public int DepartamentoId { get; set; }

        // Navegación
        public DepartamentoEntity Departamento { get; set; }
    }
}
