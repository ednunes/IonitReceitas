using Ionit.Receitas.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Interfaces.Services.Application
{
    public interface IReceitaAppService
    {
        int Inserir(ReceitaDto dto);
        List<ReceitaConsultaCompletaDto> Listar();
    }
}
