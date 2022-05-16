using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class Group
    {
        public int Id { get; set; }
        public string? Number { get; set; } // номер группы
        public List<Student> Students { get; set; } = new();
        public List<Course> Courses { get; set; } = new();

    }
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }      // внешний ключ
        public Group? Group { get; set; }    // навигационное свойство  
    }
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Group> Groups { get; set; } = new();
    }
}

