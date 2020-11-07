using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudentView()
        {
            return View();
        }

        public ActionResult AddStudent(Student student)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44382/api/Student/AddStudent");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("AddStudent",student).Result;
            return RedirectToAction("Index","Student");
        }

        public ActionResult<List<Student>> GetStudents()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44382/api/Student/GetStudents");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("GetStudents").Result;
            List<Student> StudentList;
            StudentList = response.Content.ReadAsAsync<List<Student>>().Result;
            return View(StudentList);
        }

        public ActionResult EditView()
        {
            return View();
        }

        public ActionResult Edit(Student student)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44382/api/Student/Modify");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("Modify", student).Result;
            return RedirectToAction("Index", "Student");
        }

        public ActionResult DeleteView()
        {
            return View();
        }

        public ActionResult Delete(Student student)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44382/api/Student/Delete");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("Delete", student).Result;
            return RedirectToAction("Index", "Student");
        }
    }
}