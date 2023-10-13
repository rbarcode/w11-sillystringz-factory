using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class HomeController : Controller 
  {
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      Engineer[] engineers = _db.Engineers.ToArray();
      Machine[] machines = _db.Machines.ToArray();
      Dictionary<string, object[]> model = new();
      model.Add("engineers", engineers);
      model.Add("machines", machines);
      return View(model);
    }
  }
}