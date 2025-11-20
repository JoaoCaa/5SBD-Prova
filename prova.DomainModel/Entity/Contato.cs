using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MedGrupo.DomainModel.Entity

{
    [JsonObject(IsReference = true)]
    public class Contato : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public int Idade
        {
            get
            {
                int idade = DateTime.Now.Year - DataNascimento.Year;

                if (DateTime.Now.DayOfWeek < DataNascimento.DayOfWeek)
                {
                    idade -= 1;
                }
                return idade;

            }
        }
        public bool Ativo { get; set; }
    }
}
