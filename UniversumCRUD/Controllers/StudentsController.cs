using UniversumCRUD.Models;
using UniversumCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using UniversumCRUD.Data;
using Microsoft.EntityFrameworkCore;


namespace UniversumCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCUniversumDbContext mvcUniversumDbContext;

        public StudentsController(MVCUniversumDbContext mvcUniversumDbContext)
        {
            this.mvcUniversumDbContext = mvcUniversumDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var students = await mvcUniversumDbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                PhoneNumber = addStudentRequest.PhoneNumber,
                Department = addStudentRequest.Department,
                DateOfBirth = addStudentRequest.DateOfBirth,
            };

            await mvcUniversumDbContext.Students.AddAsync(student);
            await mvcUniversumDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var student = await mvcUniversumDbContext.Students.FirstOrDefaultAsync(x => x.Id == Id);

            if (student != null)
            {
                var viewModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    Department = student.Department,
                    DateOfBirth = student.DateOfBirth,
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentViewModel model)
        {
            var student = await mvcUniversumDbContext.Students.FindAsync(model.Id);

            if (student != null)
            {
                student.Name = model.Name;
                student.Email = model.Email;
                student.PhoneNumber = model.PhoneNumber;
                student.Department = model.Department;
                student.DateOfBirth = model.DateOfBirth;

                await mvcUniversumDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            var student = await mvcUniversumDbContext.Students.FindAsync(model.Id);

            if (student != null)
            {
                mvcUniversumDbContext.Students.Remove(student);
                await mvcUniversumDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}