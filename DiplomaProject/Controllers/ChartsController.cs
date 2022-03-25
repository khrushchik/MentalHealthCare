using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ChartsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var moods = _context.Moods.Include(b => b.Notes).ToList();
            List<object> moodNotes = new List<object>();
            moodNotes.Add(new[] { "Настрій", "Кількість записів" });
            foreach (var c in moods)
            {
                moodNotes.Add(new object[] { c.moodName, c.Notes.Count() });
            }
            return new JsonResult(moodNotes);
        }

        [HttpGet("JsonData1")]
        public JsonResult JsonData1()
        {
            var activities = _context.Activities.Include(b=>b.Notes).ToList();
            List<object> activityNotes = new List<object>();
            activityNotes.Add(new[] { "Активності", "Кількість записів" });
            foreach (var c in activities)
            {
                activityNotes.Add(new object[] { c.activityName, c.Notes.Count()});
            }
            return new JsonResult(activityNotes);
        }
    }
}