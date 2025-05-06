
using Microsoft.AspNetCore.Mvc;
using prueba_tec.NovaSys.BL.Interface;
using prueba_tec.NovaSys.DTOs;

namespace prueba_tec.Controllers
{
    public class StateController : Controller
    {
        readonly IStateBL _stateBL;

        public StateController( IStateBL stateBL){
            _stateBL = stateBL;
        }
     

        public async Task<IActionResult> Index()
        {
            List<FindStatesOutputDTOs> states = await _stateBL.findAll();

            return View( states );
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateStateDTOs data ){

            if(!ModelState.IsValid) return View(data);
            else {
                try
                {
                   bool newState = await _stateBL.create( data );

                   if( newState == false ){

                    ViewBag.ErrorMessage = "No se pudo agregar el estado";
                    return View();

                   } 
                   else {
                    return RedirectToAction( nameof(Index));
                   }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View();
                }
            }

        }

        [HttpGet("/update/{id}")]
        public async Task<IActionResult> Update( int id ){

            FindStatesOutputDTOs state = await _stateBL.findById( id );
            return View( state );
        }

        [HttpPut]
        public async Task<IActionResult> Update( UpdateStateDTOs data){
      
            bool updated = await _stateBL.update( data );

            if( updated == false ){
                ViewBag.ErrorMessage = "No se pudo actualizar";
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}