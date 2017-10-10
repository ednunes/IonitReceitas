namespace Ionit.Receitas.Web.Controllers
{
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller of Receitas.
    /// </summary>
    public class ReceitasController : Controller
    {
        #region Propriedades

        /// <summary>
        /// Receita app service.
        /// </summary>
        private IReceitaAppService _receitaAppService;
        private IReceitaCategoriaAppService _receitaCategoriaAppService;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa a controller.
        /// </summary>
        /// <param name="receitaAppService">O serviço de receita.</param>
        public ReceitasController(IReceitaAppService appService, IReceitaCategoriaAppService appServiceCategoria)
        {
            _receitaAppService = appService;
            _receitaCategoriaAppService = appServiceCategoria;
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
            return View(await _receitaAppService.Listar());
        }

        /// <summary>
        /// Criação da receita.
        /// GET: Receitas/Create
        /// </summary>
        /// <returns>View de criação da receita.</returns>
        public IActionResult Create()
        {
            ViewBag.Receita = _receitaCategoriaAppService.Listar().Result;

            return View();
        }

        /// <summary>
        /// Detalhes da receita.
        /// GET: Receita/Details/5
        /// </summary>
        /// <param name="idReceita">Id da receita.</param>
        /// <returns>View com detalhes da receita.</returns>
        public async Task<IActionResult> Details(int idReceita)
        {
            return View(await _receitaAppService.Consultar(idReceita));
        }

        /// <summary>
        /// Inserir receita
        /// POST: Receitas/Create
        /// </summary>
        /// <param name="receita">Receita</param>
        /// <returns>View com a receita criada.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceitaDto receita)
        {
            if (ModelState.IsValid)
            {
                _receitaAppService.Inserir(receita);
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        #endregion
    }
}
