using EventManager.bll.Model.Exception;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Entities;
using EventManager.Mapper;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers;

public class ThemeController(IThemeService themeService) : Controller
{
    private readonly IThemeService _themeService = themeService;

    public IActionResult AllTheme()
    {
        var theme = _themeService.GetAll()
                                                     .Select(t => t.toViewModel())
                                                     .ToList();
        return View(theme);
    }
    
    public IActionResult Detail(int id)
    {
        try
        {
            var result = _themeService.GetOneById(id).toViewModel();
            return View(result);
        }
        catch (NotFoundException ex)
        {
            TempData["ErrorMessage"] = "Theme not found";
            return RedirectToAction(nameof(Error));
        }
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] ThemeFormModel model)
    {
        if (ModelState.IsValid)
        {
            _themeService.Create(model.toEntity());
            return RedirectToAction(nameof(AllTheme));
        }

        return View(model);
    }
    
    public IActionResult Delete(int id)
    {
        try
        {
            Theme themeToDelete = _themeService.GetOneById(id);
            _themeService.Delete(themeToDelete);
            return RedirectToAction(nameof(AllTheme));
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Theme not found";
            return RedirectToAction(nameof(Error));
        }
    }

    public IActionResult Update(int id)
    {
        try
        {
            var item = _themeService.GetOneById(id).toFormModel();
        
            return View(item);
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = "Event not found";
            return RedirectToAction(nameof(Error));
        }
    }
    
    [HttpPost]
    public IActionResult Update(int id, [FromForm] ThemeFormModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var existingTheme = _themeService.GetOneById(id);
                model.Id = existingTheme.Id;
                
                _themeService.Update(model.toEntity());
                return RedirectToAction(nameof(AllTheme));
            }
            catch (NotFoundException)
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