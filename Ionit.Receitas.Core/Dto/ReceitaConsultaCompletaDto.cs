using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Dto
{
    public class ReceitaConsultaCompletaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string TempoPreparo { get; set; }

        public class Ingrediente
        {
            public int IdReceita { get; set; }
            public string Nome { get; set; }
            public string UnidadeMedida { get; set; }
            public string Quantidade { get; set; }
        }
    }
}
