using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using GradeBook.Enums;

namespace GradeBook
{
    /// <summary>
    /// The student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public StudentType Type { get; set; }
        /// <summary>
        /// Gets or sets the enrollment.
        /// </summary>
        public EnrollmentType Enrollment { get; set; }
        /// <summary>
        /// Gets or sets the grades.
        /// </summary>
        public List<double> Grades { get; set; }
        /// <summary>
        /// Gets the average grade.
        /// </summary>
        [JsonIgnore]
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }
        /// <summary>
        /// Gets or sets the letter grade.
        /// </summary>
        [JsonIgnore]
        public char LetterGrade { get; set; }
        /// <summary>
        /// Gets or sets the g p a.
        /// </summary>
        [JsonIgnore]
        public double GPA { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="studentType">The student type.</param>
        /// <param name="enrollment">The enrollment.</param>
        public Student(string name, StudentType studentType, EnrollmentType enrollment)
        {
            Name = name;
            Type = studentType;
            Enrollment = enrollment;
            Grades = new List<double>();
        }

        /// <summary>
        /// Adds the grade.
        /// </summary>
        /// <param name="grade">The grade.</param>
        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grades must be between 0 and 100.");
            Grades.Add(grade);
        }

        /// <summary>
        /// Removes the grade.
        /// </summary>
        /// <param name="grade">The grade.</param>
        public void RemoveGrade(double grade)
        {
            Grades.Remove(grade);
        }
    }
}
