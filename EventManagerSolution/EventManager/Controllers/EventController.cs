using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.Mapper;
using EventManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

namespace EventManager.Controllers;

public class EventController : Controller
{
    private readonly IEventService _eventService;
    private readonly IDaysService _daysService ;
    private readonly IThemeService _themeService;
    private readonly IParticipationService _participationService;
    private readonly IUserService _userService;
    
    public EventController(IEventService eventService, IDaysService daysService, IThemeService themeService,IParticipationService participationService, IUserService userService)
    {
        _eventService = eventService;
        _daysService = daysService;
        _themeService = themeService;
        _participationService = participationService;
        _userService = userService;
    }

    #region  Event
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
        catch (NotFoundException ex)
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
            catch (NotFoundException)
            {
                TempData["ErrorMessage"] = "Event not found";
                return RedirectToAction(nameof(Error));
            }
        }
        return View(model);
    }
    

    #endregion
    
    #region  Days
    [Authorize]
    public IActionResult DayCreate(int eventId)
    {
        ViewBag.EventId = eventId;

        ViewBag.Theme = _themeService.GetAll().Select(t => new { t.Id, t.Name }).ToList();
        
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult DayCreate([FromForm] DaysFormModel model)
    {
        if (ModelState.IsValid)
        {
            var newDay = model.toEntity();
            
            newDay.EventId = model.EventId;
            newDay.ThemeId = model.ThemeId;
            
            _daysService.Create(newDay);
            return RedirectToAction(nameof(AllEvent));
        }

        return View(model);
    }

    public IActionResult DayDelete(int id)
    {
        try
        {
            Days dayToDelete = _daysService.GetOneById(id);
            _daysService.Delete(dayToDelete);
            return RedirectToAction(nameof(AllEvent));
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Day not found";
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult DayUpdate(int id)
    {
        try
        {
            var item = _daysService.GetOneById(id).toFormModel();
            
            ViewBag.Theme = _themeService.GetAll().Select(t => new { t.Id, t.Name }).ToList();
            
            return View(item);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Day not found";
            return RedirectToAction(nameof(Error));
        }
    }
    
    [HttpPost]
    public IActionResult DayUpdate(int id, [FromForm] DaysFormModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var existingEvent = _daysService.GetOneById(id);
                model.Id = existingEvent.Id;
                
                _daysService.Update(model.toEntity());
                return RedirectToAction(nameof(AllEvent));
            }
            catch (NotFoundException)
            {
                TempData["ErrorMessage"] = "Event not found";
                return RedirectToAction(nameof(Error));
            }
        }
        return View(model);
    }

    #endregion

    #region Participation
    
    [Authorize]
    public IActionResult Participate(int id)
    {
        Days foundDay = _daysService.GetOneById(id);

        User? foundUser = _userService.GetByEmail(User.Identity.Name);
        
        ParticipationFormModel model = new ParticipationFormModel()
        {
            DaysId = id,
            State = ParticipationStateEnum.Pending,
            UserId = foundUser.Id,
        };
        
        return View(model);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Participate([FromForm] ParticipationFormModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var newParticipation = model.toEntity();
                
                _participationService.Create(newParticipation);
                return RedirectToAction(nameof(AllEvent));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error));
            }

        }

        return View(model);
    }

    [Authorize]
    public IActionResult MyEvents()
    {
        User? currentUser = _userService.GetByEmail(User.Identity.Name);
        
        var participations = _participationService.GetAll()
            .Where(e => e.UserId == currentUser.Id)
            .Select(e => e.toViewModel())
            .ToList();
        
        return View(participations);
    }
    
    #endregion
    
    
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