using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudentsCRUD.Data;
using StudentsCRUD.Models;

namespace StudentsCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext db;
        public StudentsController(StudentContext studentContext)
        {
            db = studentContext;
        }
        public async Task<ActionResult> Index()
        {
            try
            {
                var result = await db.Students.ToListAsync();
                return View(result);
            }
            catch
            {
                ViewData["Index_ERR"] = "Something Went Worng !!";
                return View();
            }

        }

        public async Task<ActionResult> CreateStudent(Students o)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await db.Students.AddAsync(o);
                    await db.SaveChangesAsync();
                    TempData["Stu_Create"] = "Student Created Successfully !!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                ViewData["Index_ERR"] = "Something Went Worng !!";
                return View();
            }

        }

        [HttpGet]
        public async Task<ActionResult> UpdateStudent(int Id)
        {
            var result = await db.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateStudent(Students o)
        {
            try
            {
                var result = await db.Students.Where(x => x.Id == o.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = o.Name;
                    result.Phone = o.Phone;
                    result.Email = o.Email;
                    result.Pincode = o.Pincode;
                    result.Address = o.Address;
                    await db.SaveChangesAsync();
                    TempData["Stu_Update"] = "Student Updated Successfully !!";
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                ViewData["Update_ERR"] = "Something Went Worng !!";
                return View();
            }

        }
        public async Task<ActionResult> DeleteStudent(int Id)
        {

            try
            {
                var result = await db.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    db.Students.Remove(result);
                    await db.SaveChangesAsync();
                    TempData["Stu_Delete"] = "Student Deleted Successfully !!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                TempData["Delete_ERR"] = "Something Went Worng !!";
                return RedirectToAction("Index");
            }
        }
    }
}
