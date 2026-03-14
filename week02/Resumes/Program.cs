using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2002;
        job1._endYear = 2024;
        

        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2028;

        Resume resume1 = new Resume();
        resume1._name = "Adrián San Miguel";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        
        // Console.WriteLine(resume1._jobs[0]._jobTitle);

        resume1.DisplayResumeInfo();
    }
}