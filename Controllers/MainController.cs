using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using DojoInfoCenter.Models;

namespace DojoInfoCenter.Controllers
{
    public class MainController : Controller
{
    private DojoInfoCenterContext dbContext;

    // here we can "inject" our context service into the constructor
    public MainController(DojoInfoCenterContext context)
    {
        dbContext = context;
    }

//this is the login register page
    [HttpGet]
    [Route("Main")]
    public IActionResult Main()
    {

        return View();
    }

    [HttpGet]
    [Route("Latest")]
    public IActionResult Latest()
    {
        
        return View();
    }
}
}