using System;
using System.Text;
using System.Linq;

class Writing : Assignment
{
    public Writing(string studentName, string topic, string title) : base(studentName, topic) {
        _title = title;
    }
    private string _title;
    public string GetWritingInformation() {
        
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}