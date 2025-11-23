using Newtonsoft.Json;
using System;

namespace Prova.DomainModel.Entity
{
    [JsonObject(IsReference = true)]
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
