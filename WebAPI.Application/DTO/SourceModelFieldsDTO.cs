using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.DTO
{
    public class SourceModelFieldsDTO
    {
        public int Id { get; set; }
        public int SourceModelId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsActive { get; set; }
    }

    public class SourceModelFieldsCreateDTO
    {
        public int SourceModelId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsActive { get; set; }
    }

    public class SourceModelFieldsUpdateDTO
    {
        public int Id { get; set; }
        public int SourceModelId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsActive { get; set; }
    }
}
