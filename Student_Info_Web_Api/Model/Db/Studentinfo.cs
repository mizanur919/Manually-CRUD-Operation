using System;
using System.Collections.Generic;

namespace Student_Info_Web_Api.Model.Db
{
    public partial class Studentinfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fathername { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
