using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Watches
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public CreateModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.ManufacturerContext, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Watch Watch { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ManufacturerId"] = new SelectList(_context.ManufacturerContext, "Id", "Name");
                return Page();
            }

            _context.WatchContext.Add(Watch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}