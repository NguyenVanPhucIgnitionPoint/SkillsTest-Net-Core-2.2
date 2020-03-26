using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using SkillsTest.Models;
using SkillsTest.Models.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillsTest.Controllers
{
    public class SkillsTestsController : Controller
    {
        private readonly SkillsTestContext _context;

        public SkillsTestsController(SkillsTestContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(int CategoryId)
        {
            var category = new Category();
            var questios = _context.Questions.Where(q => q.CategoryId == CategoryId);

            foreach (var question in questios)
            {
                var answers = _context.Answers.Where(a => a.QuestionId == question.Id);
                foreach (var answer in answers)
                {
                    question.Answers.Add(answer);
                }
                category.Questions.Add(question);
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Results")] Result result)
        {
            _context.Add(result);
            await _context.SaveChangesAsync();

            var numberQuestion = 1;
            var totalQuestion = 2;
            return RedirectToAction(nameof(Index), new { numberQuestion = numberQuestion, totalQuestion = totalQuestion });
        }
    }
}
