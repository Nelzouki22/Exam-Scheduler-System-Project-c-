using System;
using System.Collections.Generic;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Students { get; set; }
}

public class Exam
{
    public Course Course { get; set; }
    public string Timeslot { get; set; }
}

public class ExamScheduler
{
    private List<Course> courses = new List<Course>();
    private List<Exam> exams = new List<Exam>();

    public void AddCourse(int id, string name, int students)
    {
        courses.Add(new Course { Id = id, Name = name, Students = students });
    }

    public void ScheduleExams()
    {
        string[] timeslots = { "9:00-11:00", "11:00-1:00", "2:00-4:00", "4:00-6:00" };
        for (int i = 0; i < courses.Count; i++)
        {
            exams.Add(new Exam { Course = courses[i], Timeslot = timeslots[i % timeslots.Length] });
        }
    }

    public void PrintSchedule()
    {
        Console.WriteLine("Exam Schedule:");
        foreach (var exam in exams)
        {
            Console.WriteLine($"Course ID: {exam.Course.Id}, Course Name: {exam.Course.Name}, Students: {exam.Course.Students}, Timeslot: {exam.Timeslot}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExamScheduler scheduler = new ExamScheduler();

        // Adding sample courses
        scheduler.AddCourse(1, "Math", 30);
        scheduler.AddCourse(2, "Physics", 25);
        scheduler.AddCourse(3, "Chemistry", 20);
        scheduler.AddCourse(4, "Biology", 15);

        // Schedule exams
        scheduler.ScheduleExams();

        // Print the exam schedule
        scheduler.PrintSchedule();
    }
}

