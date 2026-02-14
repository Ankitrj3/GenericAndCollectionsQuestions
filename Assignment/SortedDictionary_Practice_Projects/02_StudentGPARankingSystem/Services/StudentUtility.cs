using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class StudentUtility
    {
        private SortedDictionary<string, Student> _data
            = new SortedDictionary<string, Student>();

        public void AddStudent(string id, Student student)
        {
            // TODO: Validate entity
            if (_data.ContainsKey(id))
            {
                throw new CustomBaseException("DuplicateStudentException");
            }
            if(student.GPA < 0 || student.GPA > 10)
            {
                throw new CustomBaseException("InvalidGPAException (GPA must be 0–10)");
            }
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            _data.Add(id,student);
        }

        public void UpdateGPA(string id, double gpa)
        {
            // TODO: Update entity logic
            if (!_data.ContainsKey(id))
            {
                throw new CustomBaseException("StudentNotFoundException");
            }
            Student student = _data[id];
            student.GPA = gpa;
        }

        public SortedDictionary<double, List<Student>> DisplayRanking()
        {
            SortedDictionary<double, List<Student>> res = new SortedDictionary<double, List<Student>>();
            foreach(var i in _data)
            {
                var stu = i.Value;
                if (!res.ContainsKey(stu.GPA))
                {
                    res[stu.GPA] = new List<Student>();
                }
                res[stu.GPA].Add(stu);
            }
            return res;
        }
    }
}
