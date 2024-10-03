using System.Diagnostics;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.Mapper;
using Microsoft.AspNetCore.Mvc;
using EventManager.Models;

namespace EventManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEventService _eventService;

    public HomeController(ILogger<HomeController> logger, IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    public IActionResult Index()
    {
        List<EventViewModel> events = _eventService.GetAll()
                                          .Select(e => e.toViewModel())
                                          .ToList();
        
        return View(events);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}