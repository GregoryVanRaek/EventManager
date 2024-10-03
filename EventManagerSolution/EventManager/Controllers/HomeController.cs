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

    public HomeController(ILogger<HomeController> logger, IEventService eventService)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}