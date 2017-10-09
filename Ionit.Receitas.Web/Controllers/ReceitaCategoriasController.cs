namespace Ionit.Receitas.Web.Controllers
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller of Categorias.
    /// </summary>
    public class ReceitaCategoriasController : Controller
    {
        #region Propriedades

        /// <summary>
        /// Categoria da receita app service.
        /// </summary>
        private readonly IReceitaCategoriaAppService _receitaCategoriaAppService;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa a controller.
        /// </summary>
        /// <param name="receitaAppService">O serviço de receita.</param>
        public ReceitaCategoriasController(IReceitaCategoriaAppService appService)
        {
            _receitaCategoriaAppService = appService;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Lista de todas receitas cadastradas
        /// GET: Receitas
        /// </summary>
        /// <returns>View com a lista de receitas.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _receitaCategoriaAppService.Listar());
        }

        /// <summary>
        /// Criação da receita.
        /// GET: Receitas/Create
        /// </summary>
        /// <returns>View de criação da receita.</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Detalhes da receita.
        /// GET: Receita/Details/5
        /// </summary>
        /// <param name="idReceita">Id da receita.</param>
        /// <returns>View com detalhes da receita.</returns>
        public async Task<IActionResult> Details(int id)
        {
            return View(await _receitaCategoriaAppService.Consultar(id));
        }

        /// <summary>
        /// Inserir receita
        /// POST: Receitas/Create
        /// </summary>
        /// <param name="receita">Receita</param>
        /// <returns>View com a receita criada.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] ReceitaCategoriaDto receita)
        {
            if (ModelState.IsValid)
            {
                _receitaCategoriaAppService.Inserir(receita);
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        #endregion
    }
}
