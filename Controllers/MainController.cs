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

//Main page 
    [HttpGet]
    [Route("Main")]
    public IActionResult Main()
    {
        if(HttpContext.Session.GetInt32("userid") == null) 
        {
            return RedirectToAction("Index", "LogReg");
        }
        ViewBag.LoggedInUserId = HttpContext.Session.GetInt32("userid");

        List<LocationObject> AllLocations = dbContext.Locations
        .ToList();
        ViewBag.AllLocations = AllLocations;
        
        List<MessageObject> LatestMessages = dbContext.Messages
        .Include(m => m.Creator)
        .Include(m => m.Location)
        .OrderByDescending(m => m.CreatedAt)
        .Take(3)
        .ToList();
        ViewBag.LatestMessages = LatestMessages;

        return View();
    }

//load latest messages partial
    [HttpGet]
    [Route("/latest")]
    public IActionResult Latest()
    {
        ViewBag.LoggedInUserId = HttpContext.Session.GetInt32("userid");
        List<MessageObject> LatestMessages = dbContext.Messages
        .Include(m => m.Creator)
        .Include(m => m.Location)
        .OrderByDescending(m => m.CreatedAt)
        .Take(3)
        .ToList();
        ViewBag.LatestMessages = LatestMessages;

        return PartialView("Latest");
    }

//----get messages for specific location and render PerLocation partial-----
    [HttpGet]
    [Route("/{name}")]
    public IActionResult PerLocation(string name)
    {

        LocationObject ThisLocation = dbContext.Locations
            .Where(l => l.LocationName == name)
            .FirstOrDefault();
        ViewBag.ThisLocation = ThisLocation;
        
        if(ThisLocation == null)
        {
            System.Console.WriteLine("**location not found**");
            return RedirectToAction("Main");
        }
        
        List<MessageObject> MsgsPerLocation = dbContext.Messages
        .Where(m => m.LocationId == ThisLocation.LocationId)
        .Include(m => m.Creator)
        .OrderByDescending(m => m.CreatedAt)
        .ToList();  
        ViewBag.MsgsPerLocation = MsgsPerLocation;

        ViewBag.LoggedInUserId = HttpContext.Session.GetInt32("userid");
        
        return PartialView("PerLocation");
    }


// ------------add a new message------------

    [HttpPost("/newMessage")]
    public IActionResult newMessage(MessageObject newMessage)
    {
        if(ModelState.IsValid)
        {
            {
                dbContext.Add(newMessage);
                dbContext.SaveChanges();

                MessageObject msgWlocation = dbContext.Messages
                .Where(m => m.MessageId == newMessage.MessageId)
                .Include(m => m.Location)
                .FirstOrDefault();

                string locationName = msgWlocation.Location.LocationName;

                return Json(locationName);
                // return RedirectToAction("PerLocation", new { name = msgWlocation.Location.LocationName });
            }
        }
        return RedirectToAction("Main");
    }

// ----------------delete a message--------------
        [HttpGet("/delete/{id}")]
        public IActionResult delete(int id)
        {
            System.Console.WriteLine("*******************");
            System.Console.WriteLine("delete route worked");
            if(HttpContext.Session.GetInt32("userid") == null) 
            {
                return RedirectToAction("Index", "LogReg");
            }
            

            MessageObject deletingMsg = dbContext.Messages
            .Where(m => m.MessageId == id)
            .FirstOrDefault();

            if(HttpContext.Session.GetInt32("userid") != deletingMsg.UserId) 
            {
                return RedirectToAction("Main");
            }

            dbContext.Messages.Remove(deletingMsg);
            dbContext.SaveChanges();

            return RedirectToAction("Main");
        }

// // ----------form to add new location----------
//     [HttpGet]
//     [Route("addLocation")]
//     public IActionResult addLocation()
//     {
//         if(HttpContext.Session.GetInt32("userid") == null) 
//         {
//             return RedirectToAction("Index", "LogReg");
//         }
                
//         ViewBag.LoggedInUserId =  HttpContext.Session.GetInt32("userid");
//         return View();
//     }

// // ------------add a new location------------

//     [HttpPost("/newLocation")]
//     public IActionResult newLocation(LocationObject newLocation)
//     {
//         if(ModelState.IsValid)
//         {
//             {
//                 dbContext.Add(newLocation);
//                 dbContext.SaveChanges();
            
//                 return RedirectToAction("Main");
//             }
//         }
//         System.Console.WriteLine("*************************");
//         System.Console.WriteLine("New location failed");
//         System.Console.WriteLine("*************************");

//         return RedirectToAction("Main");
//     }
}
}