using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            //This allows the teamName to be highlighted
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));

        }
    }
}
