namespace Ionit.Receitas.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ionit.Receitas.Core.Entities;
    using Ionit.Receitas.Core.Interfaces.Services.Application;
    using System.Threading.Tasks;
    using System.Collections.Generic;

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
        public async Task<IActionResult> Index()
        {
            return View(await _receitaAppService.Listar());
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int idReceita)
        {
            Receita receita = new Receita();
            receita.Titulo = "Bolo de cenoura";
            receita.TempoPreparo = 30;
            receita.RendimentoPorcao = 4;

            List<ReceitaIngrediente> lst = new List<ReceitaIngrediente>();

            ReceitaIngrediente i1 = new ReceitaIngrediente { Descricao = "Ovo" };
            ReceitaIngrediente i2 = new ReceitaIngrediente { Descricao = "Farinha" };
            ReceitaIngrediente i3 = new ReceitaIngrediente { Descricao = "Açúcar" };
            ReceitaIngrediente i4 = new ReceitaIngrediente { Descricao = "Fermento" };
            ReceitaIngrediente i5 = new ReceitaIngrediente { Descricao = "Chocolate" };

            lst.Add(i1);
            lst.Add(i2);
            lst.Add(i3);
            lst.Add(i4);
            lst.Add(i5);

            receita.Ingredientes = lst;


            return View(receita);
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
