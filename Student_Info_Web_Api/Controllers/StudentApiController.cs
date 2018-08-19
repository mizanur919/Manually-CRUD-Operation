using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Info_Web_Api.Model.Db;
using Student_Info_Web_Api.ViewModels;

namespace Student_Info_Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentApi")]
    public class StudentApiController : Controller
    {
        // Database Instance
        private readonly mystudentdbContext _context;

        public StudentApiController(mystudentdbContext context)
        {
            _context = context;
        }

        // GET: api/StudentApi
        public IQueryable<MyStudent> Getstudents()
        {
            IQueryable<MyStudent> a = from st in _context.Studentinfo
                                      select new MyStudent
                                      {
                                          Id = st.Id,
                                          Name = st.Name,
                                          Fathername = st.Fathername,
                                          Email = st.Email,
                                          Phone = st.Phone,
                                      };
            return a;
        }

        [HttpGet("{id}")]
        public IActionResult Getstudent(int id)
        {
            MyStudent item = (from st in _context.Studentinfo
                              where id == st.Id
                              select new MyStudent
                              {
                                  Id = st.Id,
                                  Name = st.Name,
                                  Fathername = st.Fathername,
                                  Email = st.Email,
                                  Phone = st.Phone
                              }).First();
            return Ok(item);
        }


        // POST: api/itemsApi
        [HttpPost]
        public IActionResult Post([FromBody] MyStudent st)
        {
            Studentinfo s = new Studentinfo();

            s.Id = st.Id;
            s.Name = st.Name;
            s.Fathername = st.Fathername;
            s.Email = st.Email;
            s.Phone = st.Phone;

            _context.Studentinfo.Add(s);
            _context.SaveChanges();
            return NoContent();
        }

        // PUT: api/StudentApi/5

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] MyStudent st)
        {
            var a = (from s in _context.Studentinfo
                     where id == s.Id
                     select s).First();
            a.Id = st.Id;
            a.Name = st.Name;
            a.Fathername = st.Fathername;
            a.Email = st.Email;
            a.Phone = st.Phone;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/StudentApi/5

        [HttpDelete("{id}")]
        public IActionResult Deleteitem(int id)
        {
            MyStudent s1 = (from st in _context.Studentinfo
                            where id == st.Id
                            select new MyStudent
                            {
                                Id = st.Id,
                                Name = st.Name,
                                Fathername = st.Fathername,
                                Email = st.Email,
                                Phone = st.Phone
                            }).First();
            Studentinfo s = new Studentinfo();

            s.Id = s1.Id;
            s.Name = s1.Name;
            s.Fathername = s1.Fathername;
            s.Email = s1.Email;
            s.Phone = s1.Phone;
            _context.Studentinfo.Attach(s);
            _context.Studentinfo.Remove(s);
            _context.SaveChanges();
            return Ok(s);
        }
    }
}