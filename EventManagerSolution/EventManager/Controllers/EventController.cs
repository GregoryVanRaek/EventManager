using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.Mapper;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers;

public class EventController : Controller
{
    private readonly IEventService _eventService;
    
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    public IActionResult AllEvent()
    {
        var events = _eventService.GetAll()
            .Select(e => e.toViewModel())
            .ToList();
        
        return View(events);
    }

    public IActionResult Detail(int id)
    {
        try
        {
            var result = _eventService.GetOneById(id).toViewModel();
            return View(result);
        }
        catch (EventNotFoundException ex)
        {
            TempData["ErrorMessage"] = "Event not found";
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] EventFormModel model)
    {
        if (ModelState.IsValid)
        {
            _eventService.Create(model.toEntity());
            return RedirectToAction(nameof(AllEvent));
        }

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            Event eventToDelete = _eventService.GetOneById(id);
            _eventService.Delete(eventToDelete);
            return RedirectToAction(nameof(AllEvent));
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Event not found";
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Update(int id)
    {
        try
        {
            var item = _eventService.GetOneById(id).toFormModel();
        
            return View(item);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Event not found";
            return RedirectToAction(nameof(Error));
        }
    }
    
    [HttpPost]
    public IActionResult Update(int id, [FromForm] EventFormModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var existingEvent = _eventService.GetOneById(id);
                model.Id = existingEvent.Id;
                
                _eventService.Update(model.toEntity());
                return RedirectToAction(nameof(AllEvent));
            }
            catch (EventNotFoundException)
            {
                TempData["ErrorMessage"] = "Event not found";
                return RedirectToAction(nameof(Error));
            }
        }
        return View(model);
    }
    
    public IActionResult Error()
    {
        string errorMessage = TempData["ErrorMessage"]?.ToString() ?? string.Empty;
    
        var errorViewModel = new ErrorViewModel
        {
            ErrorMessage = errorMessage,
        };
    
        return View(errorViewModel);
    }
    
}