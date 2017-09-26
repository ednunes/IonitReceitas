namespace Ionit.Receitas.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;

    public class ReceitasController : Controller
    {
        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        private readonly IReceitaAppService _receitaAppService; 

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="receitaAppService"></param>
        public ReceitasController(IReceitaAppService receitaAppService)
        {
            _receitaAppService = receitaAppService;
        }

        /// <summary>
        /// Lista de todas receitas cadastradas
        /// GET: Receitas
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_receitaAppService.Listar());
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Inserir receita
        /// POST: Receitas/Create
        /// </summary>
        /// <param name="receita">instancia de receita</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,TempoPreparo,RendimentoPorcao")] ReceitaDto receita)
        {
            if (ModelState.IsValid)
            {
                _receitaAppService.Inserir(receita);
                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }
    }
}
