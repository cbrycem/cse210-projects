using System;
using System.Text;
using System.Linq;

class Assignment
{
    public Assignment(string studentName, string topic) {
        _studentName = studentName;
        _topic = topic;
    }
    private string _studentName;
    private string _topic;
    public string GetStudentName() {
        return _studentName;
    }
    public string GetSummary() {
        return _studentName + " - " + _topic;
    }
}