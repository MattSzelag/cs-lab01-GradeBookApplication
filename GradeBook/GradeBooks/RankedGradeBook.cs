using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook.GradeBooks
{
    /// <summary>
    /// The ranked grade book.
    /// </summary>
    public class RankedGradeBook : BaseGradeBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RankedGradeBook"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="x">If true, x.</param>
        public RankedGradeBook(string name, bool x) : base(name, x)
        {
            Name = name;
            IsWeighted = x;
            Type = GradeBookType.Ranked;
        }

        /// <summary>
        /// Gets the letter grade.
        /// </summary>
        /// <param name="averageGrade">The average grade.</param>
        /// <returns>A char.</returns>
        public override char GetLetterGrade(double averageGrade)
        {
            List<double> srednie = new List<double>();
            foreach (Student student in Students)
            {
                srednie.Add(student.AverageGrade);
            }
            srednie.Sort();
            srednie.Reverse();
            int x = srednie.Count;
            if (x % 5 == 0)
            {
                if (averageGrade >= srednie[x / 5 - 1])
                    return 'A';
                else if (averageGrade < srednie[x / 5 - 1] && averageGrade >= srednie[2 * (x / 5) - 1])
                    return 'B';
                else if (averageGrade < srednie[2 * (x / 5) - 1] && averageGrade >= srednie[3 * (x / 5) - 1])
                    return 'C';
                else if (averageGrade < srednie[3 * (x / 5) - 1] && averageGrade >= srednie[4 * (x / 5) - 1])
                    return 'D';
                else
                    return 'F';
            }
            else
            {
                throw new InvalidOperationException("Error.");
            }
        }

        /// <summary>
        /// Calculates the statistics.
        /// </summary>
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        /// <summary>
        /// Calculates the student statistics.
        /// </summary>
        /// <param name="name">The name.</param>
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
