using Microsoft.AspNetCore.Mvc;
using prueba_tec.NovaSys.DAL.Interfaces;

namespace prueba_tec.Controllers
{
    public class ProductController: Controller
    {
        readonly IProductDAL _productDAL;

        public ProductController( IProductDAL productDAL ){
            _productDAL = productDAL;
        }

        public async Task<IActionResult> Index(){
            
        }        

    }
}