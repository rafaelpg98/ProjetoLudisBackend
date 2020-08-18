using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLudis.Models
{
    public class Esportista
    {
        public Esportista(){}

        public Esportista(int idEsportista, string cpf)
        {
            this.IdEsportista = idEsportista;
            this.CPF = cpf;
        }

        public int IdEsportista { get; set; }

        public string CPF { get; set; }
    }
}
