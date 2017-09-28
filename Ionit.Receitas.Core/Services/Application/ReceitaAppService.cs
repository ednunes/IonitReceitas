namespace Ionit.Receitas.Core.Services.Application
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Define a interface de serviço pública para Receita.
    /// </summary>
    public class ReceitaAppService : IReceitaAppService
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected readonly IDomainService<Receita> _service;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o serviço de domínio de Receita.
        /// </summary>
        /// <param name="service"></param>

        public ReceitaAppService(IDomainService<ReceitaDto> service)
        {
            _service = service;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Realizar a inserção da receita no banco de dados.
        /// </summary>
        /// <param name="dto">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public int Inserir(ReceitaDto dto)
        {
            var entity = new Receita()
            {
                Titulo = dto.Titulo,
                TempoPreparo = dto.TempoPreparo,
                RendimentoPorcao = dto.RendimentoPorcao,
                Categoria = new ReceitaCategoria()
                {
                    Nome = dto.Categoria?.Nome
                },
                Ingredientes = dto.Ingredientes?.Select(ingrediente =>
                {
                    return new ReceitaIngrediente()
                    {
                        Descricao = ingrediente.Descricao
                    };
                }).ToList(),
                Curtidas = dto.Curtidas?.Select(curtida =>
                {
                    return new ReceitaCurtida()
                    {
                        Usuario = curtida.Usuario
                    };
                }),
                Tags = dto.Tags?.Select(tag =>
                {
                    return new ReceitaTag()
                    {
                        Nome = tag.Nome
                    };
                })
            };
            
            return _service.Inserir(entity);
        }

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de receitas.</returns>
        public IEnumerable<ReceitaDto> Listar()
        {
            foreach (var receita in _service.Listar())
            {
                yield return new ReceitaDto()
                {
                    Titulo = receita.Titulo,
                    TempoPreparo = receita.TempoPreparo,
                    RendimentoPorcao = receita.RendimentoPorcao,
                    Categoria = new ReceitaCategoriaDto()
                    {
                        Nome = receita.Categoria?.Nome
                    },
                    Ingredientes = receita.Ingredientes.Select(ingrediente =>
                    {
                        return new ReceitaIngredienteDto()
                        {
                            Descricao = ingrediente.Descricao
                        };
                    }).ToList(),
                    Curtidas = receita.Curtidas.Select(curtida =>
                    {
                        return new ReceitaCurtidaDto()
                        {
                            Usuario = curtida.Usuario
                        };
                    }),
                    Tags = receita.Tags.Select(tag =>
                    {
                        return new ReceitaTagDto()
                        {
                            Nome = tag.Nome
                        };
                    })
                };
            }
        }

        #endregion
    }
}
