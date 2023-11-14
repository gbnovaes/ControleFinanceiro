using System.ComponentModel;

namespace SistemaFinanceiroUGB232.Models
{
    public class Instituicao
    {
        [DisplayName("Código")]
        public long? InstituicaoID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
