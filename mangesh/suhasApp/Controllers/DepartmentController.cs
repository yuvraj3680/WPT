using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using suhasApp.Models;

 using BOL;
 using DAL;
 using BLL;

namespace suhasApp.Controllers;

public class DepartmentController : Controller
{
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {        

        List<Department> list=HRManager.GetAllDepartmentsFromDAL();
        this.ViewData["departments"]=list;
        return View();
    }
    [HttpGet]
    public IActionResult Insert()
    {
        Department dobj=new Department();
        return View(dobj);
    }
    [HttpPost]
    public IActionResult Insert(int id,string name,string location)
    {
        // if(!ModelState.IsValid)
        // {
        //     return View();
        // }
        HRManager hobj=new HRManager();
        
        if(hobj.insert(id,name,location)){
        return RedirectToAction("Index");
        }
        return View();
    
    }
     public IActionResult Department()
    {
       
        return View();
    }


   
}
