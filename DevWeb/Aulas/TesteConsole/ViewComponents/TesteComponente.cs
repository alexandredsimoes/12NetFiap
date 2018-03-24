using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsole.ViewComponents
{
    public class TesteComponente : ViewComponent
    {
        public TesteComponente()
        {

        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var obj = new
            {
                Id = 10,
                Nome = "Alexandre Dias"
            };

            return Task.FromResult<IViewComponentResult>(View(viewName: "Teste", model: obj));
        }
    }
}
