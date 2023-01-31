using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        IEnumerable<Category> categories = _db.Categories;
        
        return View(categories);
    }
    //GET
    public IActionResult Create()
    {
        return View();
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (_db.Categories.Any(x => x.Name == category.Name))
        {
            ModelState.AddModelError("5EE647E7", "The category already exists!");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(category);
    }
    
}