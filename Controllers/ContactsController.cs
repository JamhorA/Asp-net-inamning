using Bmerketo_WebApp.Helpers.Repositories;
using Bmerketo_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bmerketo_WebApp.Controllers;

public class ContactsController : Controller
{
    private readonly ContactFormRepository _contactFormRepository;

    public ContactsController(ContactFormRepository contactFormRepository)
    {
        _contactFormRepository = contactFormRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid) 
        {
            await _contactFormRepository.AddAsync(viewModel);
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }
}
