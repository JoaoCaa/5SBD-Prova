using Newtonsoft.Json;

namespace Prova.DomainModel.Entity
{
    [JsonObject(IsReference = true)]
    public class Produto : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}
