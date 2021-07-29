using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokédex_MVC
{
    public static class DropdownLists
    {
        public static List<SelectListItem> DdlGender()
        {
            return new List<SelectListItem>{
                new SelectListItem { Value ="Male", Text="Male" },
                new SelectListItem { Value ="Female", Text="Female" },
                new SelectListItem { Value ="Unknown", Text="Unknown"},
            };
        }
    }
}
