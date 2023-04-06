using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    /// <summary>
    /// The standard grade book.
    /// </summary>
    public class StandardGradeBook : BaseGradeBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardGradeBook"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="x">If true, x.</param>
        public StandardGradeBook(string name, bool x) : base(name, x)
        {
            Name = name;
            IsWeighted = x;
            Type = GradeBookType.Standard;
        }
    }
}
