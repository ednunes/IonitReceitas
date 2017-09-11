using System;
using System.Collections.Generic;
using System.Text;

namespace Ionit.Receitas.Core.Interfaces.Services.Domain
{
    public interface IDomainService<ENTITY> 
        where ENTITY : class
    {
        ENTITY Consultar();
        List<ENTITY> Listar();
        int Inserir(ENTITY entity);
        int Alterar(ENTITY entity);
    }
}
