using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models.DataAccessPostgreSqlProvider;
using WindowsFormsApp1;

namespace WebApplication.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(Class1));
                var list = (Class1)xs.Deserialize(stream);


                using (var db = new WorkListDbContext())
                {
                    var dbs = new DbWorkList()
                    {
                        NameOfCompany = list.NameOfCompany,
                        Address = list.Address,
                        Number = list.Number,
                        Category = list.Category,
                    };
                    dbs.Tasks = new Collection<DbTasks>();
                    foreach (var task in list.Tasks)
                    {
                        dbs.Tasks.Add(new DbTasks()
                        {
                            NameOfTask = task.NameOfTask,
                            Explanations = task.Explanations,
                        });
                    }
                    dbs.Workers = new Collection<DbWorkers>();
                    foreach (var worker in list.Workers)
                    {
                        dbs.Workers.Add(new DbWorkers()
                        {
                            Name = worker.Name,
                            Position = worker.Position,
                            Experience = worker.Experience,
                        });
                    }
                    db.WorkLists.Add(dbs);
                    db.SaveChanges();
                }

                return View(list);
            }
        }



        public ActionResult List()
        {
            List<DbWorkList> list;
            using (var db = new WorkListDbContext())
            {
                list = db.WorkLists.Include(s => s.Workers).ToList();
                list = db.WorkLists.Include(s => s.Tasks).ToList();
            }

            return View(list);
        }

    }
}