using System;
using System.Collections.Generic;
using System.IO;
class Filehandling {
      static void Main(string[] args)
    {
        InfoHandling inf = new InfoHandling();
        inf.DataStore();
        while (true)
        {
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1:
                    inf.AddInfo();
                    break;
                case 2:
                    inf.RemoveInfo();
                    break;
                case 3:
                    inf.Display();
                    break;
                default:
                    inf.EndFile();
                    return;
            }
        }
    }
}
class Info
{
    public string Name { get; set; }
    public string Surname { get; set; }

}
class InfoHandling {
    List<Info> infos;
    string path;
    public InfoHandling() {
        path = @"C:\Users\virst\Documents\data.txt";
        infos = new List<Info>();
    }
    public void DataStore()
    {
        StreamReader sr = new StreamReader(path);
        string? line = sr.ReadLine();
        while (line != null)
        {
            string[] SName = line.Split(' ');
            infos.Add(new Info { Name = SName[0], Surname = SName[1] });
            line = sr.ReadLine();
        }
        sr.Close();

    }
    public void EndFile() 
    { 
        StreamWriter sr1 = new StreamWriter(path);
        foreach (Info info in infos)
        {
            string s = string.Concat(info.Name, " " , info.Surname);
            sr1.WriteLine(s);
        }
        sr1.Close();
    }
    public void AddInfo()
    {
        Console.Write("Name:");
        string name = Console.ReadLine();
        Console.Write("Surname:");
        string surname = Console.ReadLine();
        infos.Add(new Info { Name = name, Surname = surname});
    }
    public void RemoveInfo()
    {
        Console.Write("Enter surname:");
        string surname = Console.ReadLine();
        infos.RemoveAll(info => info.Surname == surname);
    }
    public void Display()
    {
        foreach (Info info in infos)
        {
            Console.Write(info.Name + " ");
            Console.WriteLine(info.Surname);
        }
    }
}
