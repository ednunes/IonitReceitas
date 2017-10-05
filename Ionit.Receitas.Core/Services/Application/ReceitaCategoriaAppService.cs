namespace Ionit.Receitas.Core.Services.Application
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Ionit.Receitas.Core.Interfaces.Services.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define a interface de serviço pública para Receita.
    /// </summary>
    public class ReceitaCategoriaAppService : IReceitaCategoriaAppService
    {
        #region Variáveis

        /// <summary>
        /// Domínio de serviços 
        /// </summary>
        protected readonly IDomainService<ReceitaCategoria> _service;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa o construtor da classe com o serviço de domínio de Receita.
        /// </summary>
        /// <param name="service"></param>

        public ReceitaCategoriaAppService(IDomainService<ReceitaCategoria> service)
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
        public async Task<ReceitaCategoriaDto> Consultar(int id)
        {
            var result = await _service.Consultar(id);

            return new ReceitaCategoriaDto()
            {
                Id = result?.Id ?? 0,
                Nome = result.Nome
            };
        }

        /// <summary>
        /// Realizar a inserção da receita no banco de dados.
        /// </summary>
        /// <param name="dto">Receita a ser inserida.</param>
        /// <returns>Retorna quantidade de linhas fetadas pela inserção da entidade.</returns>
        public async Task<int> Inserir(ReceitaCategoriaDto dto)
        {
            var entity = new ReceitaCategoria()
            {
                Nome = dto.Nome
            };

            return await _service.Inserir(entity);
        }

        /// <summary>
        /// Lista de Receitas.
        /// </summary>
        /// <returns>Retorna uma lista de receitas.</returns>
        public async Task<IEnumerable<ReceitaCategoriaDto>> Listar()
        {
            List<ReceitaCategoriaDto> categorias = new List<ReceitaCategoriaDto>();

            foreach (var categoria in await _service.Listar())
            {
                categorias.Add(new ReceitaCategoriaDto()
                {
                    Id = categoria.Id, 
                    Nome = categoria.Nome
                });
            }

            return categorias;
        }

        #endregion
    }
}
