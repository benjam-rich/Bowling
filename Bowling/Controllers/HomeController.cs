using Bowling.Models;
using Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
        //Okay, so this Index Get Method does a LOT. It returns a view that gets the the items from the database from context and 
        //also gets the number of items so we can determine the length of the pages that should show up
        public IActionResult Index(long? teamid, string teamname, int pageNum = 0)
        {
            int pageSize = 5;


            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    //.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {teamid} OR {teamid} IS NULL")
                    .Where(m => m.TeamId == teamid || teamid == null)
                    .OrderBy(m => m.Team)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },
                TeamCategory = teamname

            });
                
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
