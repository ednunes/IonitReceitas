namespace Ionit.Receitas.Core.Services.Application
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Define a interface de serviço pública para Receita.
    /// </summary>
    public class ReceitaAppService : IReceitaAppService
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected IDomainService<Receita> _service;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o serviço de domínio de Receita.
        /// </summary>
        /// <param name="service"></param>

        public ReceitaAppService(IDomainService<Receita> service)
        {
            _service = service;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Consultar Receita pelo id.
        /// </summary>
        /// <param name="id">Id da Receita para consultar.</param>
        /// <returns>Retorna uma Receita com o id passado ou null.</returns>
        public async Task<ReceitaDto> Consultar(int id)
        {
            var result = await _service.Consultar(id);

            return new ReceitaDto()
            {
                Id = result?.Id ?? 0,
                Titulo = result?.Titulo,
                TempoPreparo = result?.TempoPreparo ?? 0,
                RendimentoPorcao = result?.RendimentoPorcao ?? 0,
                Categoria = new ReceitaCategoriaDto()
                {
                    Nome = result?.Categoria?.Nome
                },
                Ingredientes = result?.Ingredientes?.Select(ingrediente =>
                {
                    return new ReceitaIngredienteDto()
                    {
                        Descricao = ingrediente?.Descricao
                    };
                }) ?? new List<ReceitaIngredienteDto>(),
                Curtidas = result?.Curtidas?.Select(curtida =>
                {
                    return new ReceitaCurtidaDto()
                    {
                        Usuario = curtida?.Usuario
                    };
                }) ?? new List<ReceitaCurtidaDto>(),
                Tags = result?.Tags?.Select(tag =>
                {
                    return new ReceitaTagDto()
                    {
                        Nome = tag?.Nome
                    };
                }) ?? new List<ReceitaTagDto>()
            };
        }

        /// <summary>
        /// Realizar a inserção da receita no banco de dados.
        /// </summary>
        /// <param name="dto">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public async Task<int> Inserir(ReceitaDto dto)
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
            
            return await _service.Inserir(entity);
        }

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de receitas.</returns>
        public async Task<IEnumerable<ReceitaDto>> Listar()
        {
            List<ReceitaDto> receitas = new List<ReceitaDto>();

            foreach (var receita in await _service.Listar())
            {
                receitas.Add(new ReceitaDto()
                {
                    Id = receita.Id,
                    Titulo = receita.Titulo,
                    TempoPreparo = receita.TempoPreparo,
                    RendimentoPorcao = receita.RendimentoPorcao,
                    Categoria = new ReceitaCategoriaDto()
                    {
                        Nome = receita.Categoria?.Nome
                    },
                    Ingredientes = receita.Ingredientes?.Select(ingrediente =>
                    {
                        return new ReceitaIngredienteDto()
                        {
                            Descricao = ingrediente.Descricao
                        };
                    }).ToList(),
                    Curtidas = receita.Curtidas?.Select(curtida =>
                    {
                        return new ReceitaCurtidaDto()
                        {
                            Usuario = curtida.Usuario
                        };
                    }),
                    Tags = receita.Tags?.Select(tag =>
                    {
                        return new ReceitaTagDto()
                        {
                            Nome = tag.Nome
                        };
                    })
                });
            }

            return receitas;
        }

        #endregion
    }
}
