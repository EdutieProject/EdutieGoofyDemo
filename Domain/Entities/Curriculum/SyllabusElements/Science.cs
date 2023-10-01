﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Curriculum.SyllabusElements;

public class Science
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    private readonly List<Course> courses = new();

    public Science(string name, string desc)
    { 
        Name = name;
        Description = desc;
    }

    public void AddNewCourse(Course course)
    {
        courses.Add(course);
    }

    public void RemoveCourse(Course course) 
    { 
        courses.Remove(course);
    }
}