using System;
using System.Collections.Generic;
using System.Linq;

// Khởi tạo class
public class Student
{
    public string Name { get; set; }
    public Score Score { get; set; }

    public double AvgScore => (Score.Math + Score.Physic + Score.Chemistry) / 3.0;

    public Student(string name, double math, double physic, double chemistry)
    {
        Name = name;
        Score = new Score { Math = math, Physic = physic, Chemistry = chemistry };
    }
}

public class Score
{
    public double Math { get; set; }
    public double Physic { get; set; }
    public double Chemistry { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo array
        var students = new List<Student>
        {
            new Student("Luu Van F", 4, 5, 3),
            new Student("Pham Thi B", 8, 8, 8),
            new Student("Nguyen Van A", 10, 9, 8),
            new Student("Pham Thi D", 9, 7, 8),
            new Student("Le Van C", 7, 9, 6),
            new Student("Hoang Van E", 6, 8, 7),
        };

        // Sắp xếp theo điểm trung bình giảm dần và name tăng dần (Bubble Sort)
        for (int i = 0; i < students.Count - 1; i++)
        {
            for (int j = 0; j < students.Count - i - 1; j++)
            {
                if (students[j].AvgScore < students[j + 1].AvgScore ||
                    (students[j].AvgScore == students[j + 1].AvgScore &&
                     string.Compare(students[j].Name, students[j + 1].Name) > 0))
                {
                    var temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Danh sách sau khi sắp xếp:");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Average: {student.AvgScore:F2}");
        }

        // Tìm object có điểm trung bình bằng 8
        Student result = null;
        foreach (var student in students)
        {
            if (Math.Abs(student.AvgScore - 8) < 0.0001)
            {
                result = student;
                break;
            }
        }

        if (result != null)
        {
            Console.WriteLine($"\nHọc sinh có điểm trung bình = 8: {result.Name} (TB: {result.AvgScore:F2})");
        }
        else
        {
            Console.WriteLine("\nKhông tìm thấy học sinh nào có điểm trung bình = 8");
        }
    }
}