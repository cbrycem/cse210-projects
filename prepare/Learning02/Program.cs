using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        Job job2 = new Job();

        job1._company = "Wagstaff";
        job1._jobTitle = "Shipping Team Member";
        job1._startYear = 2021;
        job1._endYear = 2022;

        job1.Display();


        job2._company = "Church";
        job2._jobTitle = "Missionary";
        job2._startYear = 2022;
        job2._endYear = 2024;

        job2.Display();

        Resume me = new Resume();

        me._name = "Chris";

        me._jobs.Add(job1);
        me._jobs.Add(job2);

        me.Display();

    }
}