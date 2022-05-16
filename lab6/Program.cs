using lab6;

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("Добавление");
    Group group1 = new Group { Number = "3333" };
    Group group2 = new Group { Number = "4444" };
    Student student1 = new Student { Name = "Костя", Group = group1 };
    Student student2 = new Student { Name = "Слава", Group = group2 };
    Student student3 = new Student { Name = "Лера", Group = group2 };
    Course math = new Course { Name = "Вышмат" };
    Course phyz = new Course { Name = "Физика" };

    db.Groups.AddRange(group1, group2);  // добавление групп
    db.Students.AddRange(student1, student2, student3);     // добавление студентов
    db.Courses.AddRange(math, phyz); // добавление курсов

    db.SaveChanges();

    // добавление группам курсов
    group1.Courses.Add(math);
    group1.Courses.Add(phyz);
    group2.Courses.Add(math);


    foreach (var student in db.Students.ToList())
    {
        Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
        Console.WriteLine($"Группа изучает:");
        foreach (var course in student.Group?.Courses)
        {
            Console.WriteLine(course.Name);
        }
    }
    // удаление первого студента
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Удаление");
    Student? st = db.Students.FirstOrDefault();
    if (st != null)
    {
        db.Students.Remove(st);
        db.SaveChanges();
        foreach (var student in db.Students.ToList())
        {
            Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
            Console.WriteLine($"Группа изучает:");
            foreach (var course in student.Group?.Courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
    Console.WriteLine("------------------------------------------");
    Console.WriteLine("Редактирование");
    st = db.Students.FirstOrDefault();
    if (st != null)
    {
        st.Name = "Пётр";
        db.SaveChanges();
        foreach (var student in db.Students.ToList())
        {
            Console.WriteLine($"{student.Name} принадлежит группе {student.Group?.Number}");
            Console.WriteLine($"Группа изучает:");
            foreach (var course in student.Group?.Courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}

   