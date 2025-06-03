using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using student2.Data;
using student2.Models;
using student2.Models.Entities;

namespace student2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)  
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentWithParentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Student.Name,
                Email = viewModel.Student.Email,
                Phone = viewModel.Student.Phone,
                Subscribed = viewModel.Student.Subscribed,

            };
             await dbContext.Students.AddAsync(student);
             await dbContext.SaveChangesAsync();

            var parent = new Parent
            {
                Name = viewModel.Parent.Name,
                Address = viewModel.Parent.Address,
                StudentID = student.ID
            };
            await dbContext.Parents.AddAsync(parent);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Students"); 
            

        }
        
       public async Task<IActionResult> List()
        {
           var students =  await dbContext.Students.ToListAsync();
           // var parents = await dbContext.Parents.ToListAsync();

            return View(students);
           // return View(parents);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students
                .Include(s => s.Parents)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.ID);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();


                return RedirectToAction("List", "Students");
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await dbContext.Students.AsNoTracking() .FirstOrDefaultAsync(x => x.ID ==id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        //public IActionResult AddToParent(Guid id)
        //{
        //    return PartialView("_AddToParent",id);

        //}

        //[HttpPost]

        //public async Task<IActionResult> AddToParent(ParentViewModel viewModel,Guid id)
        //{
        //    var parent = new Parent
        //    {
        //        Name = viewModel.Name,
        //        Address = viewModel.Address,
        //        ParentID = id




        //    };
        //    await dbContext.AddAsync(parent);
        //    await dbContext.SaveChangesAsync();
        //    return RedirectToAction(nameof(List));
        //}
        public IActionResult AddToParent(Guid id)
        {
            var viewModel = new ParentViewModel
            {
                StudentID = id,
            };
            return PartialView("_AddToParent", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToParent(ParentViewModel viewModel)
        {
            var parent = new Parent
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                StudentID = viewModel.StudentID,
            };

            await dbContext.Parents.AddAsync(parent);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List");
        }


         

    }

}
