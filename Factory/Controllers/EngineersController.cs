using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;
using System;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                .Include(engineer => engineer.JoinEntitiesLicensure)
                .Include(engineer => engineer.JoinEntitiesActiveRepairs)
                .ThenInclude(join => join.Machine)
                .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      #nullable enable
      Licensure? joinEntity = _db.Licensures.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
      #nullable disable
      if (joinEntity == null && machineId !=0)
      {
        _db.Licensures.Add(new Licensure() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }

    public ActionResult AddRepairs(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddRepairs(Engineer engineer, int machineId)
    {
      #nullable enable
      ActiveRepairs? joinEntity = _db.ActiveRepairs.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
      #nullable disable
      if (joinEntity == null && machineId !=0)
      {
        _db.ActiveRepairs.Add(new ActiveRepairs() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteLicensure(int joinId)
    {
      Licensure joinEntry = _db.Licensures.FirstOrDefault(entry => entry.LicensureId == joinId);
      _db.Licensures.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteActiveRepairs(int joinId)
    {
      ActiveRepairs joinEntry = _db.ActiveRepairs.FirstOrDefault(entry => entry.ActiveRepairsId == joinId);
      _db.ActiveRepairs.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}