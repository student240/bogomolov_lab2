using System;
using System.Collections.Generic;

namespace StudentGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем список студентов
            List<Student> students = new List<Student>();

            // Ввод количества студентов в группе
            Console.Write("Введите количество студентов в группе: ");
            int n = int.Parse(Console.ReadLine());

            // Ввод информации о каждом студенте
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nСтудент №" + (i + 1));
                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.Write("Имя: ");
                string firstName = Console.ReadLine();
                Console.Write("Отчество: ");
                string patronymic = Console.ReadLine();
                Console.Write("Год рождения: ");
                int birthYear = int.Parse(Console.ReadLine());
                Console.Write("Месяц рождения: ");
                int birthMonth = int.Parse(Console.ReadLine());
                Console.Write("День рождения: ");
                int birthDay = int.Parse(Console.ReadLine());

                List<Exam> exams = new List<Exam>();
                Console.Write("Количество экзаменов: ");
                int m = int.Parse(Console.ReadLine());

                // Ввод информации об экзаменах
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("\nЭкзамен №" + (j + 1));
                    Console.Write("Предмет: ");
                    string subject = Console.ReadLine();
                    Console.Write("День экзамена: ");
                    int examDay = int.Parse(Console.ReadLine());
                    Console.Write("Месяц экзамена: ");
                    int examMonth = int.Parse(Console.ReadLine());
                    Console.Write("Год экзамена: ");
                    int examYear = int.Parse(Console.ReadLine());
                    Console.Write("Преподаватель: ");
                    string teacher = Console.ReadLine();
                    Console.Write("Оценка: ");
                    int grade = int.Parse(Console.ReadLine());

                    exams.Add(new Exam(subject, new DateTime(examYear, examMonth, examDay), teacher, grade));
                }

                students.Add(new Student(lastName, firstName, patronymic, new DateTime(birthYear, birthMonth, birthDay), exams));
            }

            // Вывод информации о студентах
            Console.WriteLine("\nСписок студентов:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            // Вывод информации о студенте с худшей успеваемостью
            Student worstStudent = students[0];
            foreach (Student student in students)
            {
                if (student.GetAverageGrade() < worstStudent.GetAverageGrade())
                {
                    worstStudent = student;
                }
            }

            Console.WriteLine("\nСтудент с худшей успеваемостью:");
            Console.WriteLine(worstStudent.GetWorstExamInfo());
        }
    }

    class Student
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private DateTime birthDate;
        private List<Exam> exams;

        public Student(string lastName, string firstName, string patronymic, DateTime birthDate, List<Exam> exams)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.birthDate = birthDate;
            this.exams = exams;
        }

        // Возвращает фамилию, имя и отчество студента
        public string GetFullName()
        {
            return string.Format("{0} {1} {2}", lastName, firstName, patronymic);
        }

        // Возвращает средний балл студента
        public double GetAverageGrade()
        {
            double sum = 0;
            foreach (Exam exam in exams)
            {
                sum += exam.Grade;
            }

            return sum / exams.Count;
        }

        // Возвращает информацию об экзамене с худшей оценкой у студента
        public string GetWorstExamInfo()
        {
            Exam worstExam = exams[0];
            foreach (Exam exam in exams)
            {
                if (exam.Grade < worstExam.Grade)
                {
                    worstExam = exam;
                }
            }

            return string.Format("{0}: {1} ({2}), Оценка: {3}", GetFullName(), worstExam.Subject, worstExam.ExamDate.ToShortDateString(), worstExam.Grade);
        }

        // Переопределение метода ToString для удобного вывода информации о студенте
        public override string ToString()
        {
            string result = string.Format("{0}, Дата рождения: {1},\nЭкзамены:", GetFullName(), birthDate.ToShortDateString());
            foreach (Exam exam in exams)
            {
                result += string.Format("\n{0} ({1}): {2}", exam.Subject, exam.ExamDate.ToShortDateString(), exam.Grade);
            }

            return result + string.Format("\nСредний балл: {0:F2}", GetAverageGrade());
        }
    }

    class Exam
    {
        public string Subject { get; set; }
        public DateTime ExamDate { get; set; }
        public string Teacher { get; set; }
        public int Grade { get; set; }

        public Exam(string subject, DateTime examDate, string teacher, int grade)
        {
            Subject = subject;
            ExamDate = examDate;
            Teacher = teacher;
            Grade = grade;
        }
    }
}