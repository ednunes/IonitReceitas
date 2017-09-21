namespace Ionit.Receitas.Core.Services.Application
{
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Dto;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ionit.Receitas.Core.Services.Domain;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;

    /// <summary>
    /// 
    /// </summary>
    public class ReceitaAppService : IReceitaAppService
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected readonly IDomainService<Receita> _service;

        #endregion

        public ReceitaAppService(IDomainService<Receita> service)
        {
            _service = service;
        }

        public int Alterar(ReceitaDto dto)
        {
            throw new NotImplementedException();
        }

        public ReceitaConsultaCompletaDto Consultar()
        {
            throw new NotImplementedException();
        }

        public int Inserir(ReceitaDto dto)
        {
            Receita entity = new Receita()
            {
                Titulo = dto.Titulo,
                ModoPreparo = dto.ModoPreparo,
                TempoPreparo = dto.TempoPreparo
            };

            foreach (ReceitaDto.Ingrediente ing in dto.Ingredientes)
            {
                Receita.Ingrediente ingrediente = new Receita.Ingrediente()
                {
                    Nome = ing.Nome,
                    UnidadeMedida = ing.UnidadeMedida,
                    Quantidade = ing.Quantidade
                };

                entity.Ingredientes.Add(ingrediente);
            }

            return _service.Inserir(entity);
        }

        public List<ReceitaConsultaCompletaDto> Listar()
        {
            List<ReceitaConsultaCompletaDto> receitasDto = new List<ReceitaConsultaCompletaDto>();
            
            List<Receita> lst = _service.Listar();

            foreach (Receita receita in lst)
            {
                ReceitaConsultaCompletaDto r = new ReceitaConsultaCompletaDto()
                {
                    Id = receita.Id,
                    Titulo = receita.Titulo,
                    ModoPreparo = receita.ModoPreparo,
                    TempoPreparo = receita.TempoPreparo
                };

                foreach (Receita.Ingrediente ingrediente in receita.Ingredientes)
                {
                    r.Ingredientes.Add(new ReceitaConsultaCompletaDto.Ingrediente()
                    {
                        IdReceita = ingrediente.IdReceita,
                        Nome = ingrediente.Nome,
                        UnidadeMedida = ingrediente.UnidadeMedida,
                        Quantidade = ingrediente.Quantidade
                    });
                }

                receitasDto.Add(r);
            }

            return receitasDto;
        }
    }
}
