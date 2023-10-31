using System.ComponentModel;

namespace SistemaFinanceiroUGB232.Models
{
    public class Departamento
    {
        [DisplayName("Código")]
        public long? DepartamentoID { get; set; }
        public string Nome { get; set; }
    }
}
