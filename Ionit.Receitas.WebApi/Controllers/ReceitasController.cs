namespace Ionit.Receitas.WebApi.Controllers
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Receitas")]
    public class ReceitasController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IReceitaAppService _receitaAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receitaAppService"></param>
        public ReceitasController(IReceitaAppService receitaAppService)
        {
            _receitaAppService = receitaAppService;
        }

        /// <summary>
        /// GET: api/Receitas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ReceitaDto>> GetReceitas()
        {
            return _receitaAppService.Listar();
        }

        /// <summary>
        /// POST: api/Receitas
        /// </summary>
        /// <param name="receita"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostReceita([FromBody] ReceitaDto receita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _receitaAppService.Inserir(receita);

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }
    }
}