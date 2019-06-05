using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {

            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }


            int numOfStudentsPerGrade = (int)Math.Ceiling(Students.Count * .20);

            List<Student> orderedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();

            if(orderedStudents[numOfStudentsPerGrade -1].AverageGrade <= averageGrade )
            {
                return 'A';
            }
            else if(orderedStudents[(numOfStudentsPerGrade-1) + numOfStudentsPerGrade].AverageGrade <= averageGrade){
                return 'B';
            }
            else if (orderedStudents[(numOfStudentsPerGrade - 1) + numOfStudentsPerGrade*2].AverageGrade <= averageGrade)
            {
                return 'C';
            }
            else if (orderedStudents[(numOfStudentsPerGrade - 1) + numOfStudentsPerGrade * 3].AverageGrade <= averageGrade)
            {
                return 'D';
            }
            else
            {
                


                return 'F';
            }
            //List<Student> receiveA = orderedStudents.GetRange(0, numOfStudentsPerGrade);

            //List<Student> receiveB = orderedStudents.GetRange(receiveA.Count, numOfStudentsPerGrade);

            //List<Student> receiveC = orderedStudents.GetRange(receiveB.Count, numOfStudentsPerGrade);

            //List<Student> receiveD = orderedStudents.GetRange(receiveC.Count, numOfStudentsPerGrade);

            
        }

       
    }
}
