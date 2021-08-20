using System;
using System.Collections.Generic;
using System.IO;
namespace Teacher
{
    class TeacherRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Cls { get; set; }
        public char Sec { get; set; }

    }   


    class Assignment_1_Teacher_record
    {
        static public void add(TeacherRecord NewRecord, List<TeacherRecord> TeacherRecordList)
        {
            Console.WriteLine("Enter the number of Records you want to Enter");
            int record_count = int.Parse(Console.ReadLine());
            for (int i = 0; i < record_count; i++)
            {
                int id, cls; string name; char sec;
                Console.WriteLine("Enter the Teacher's ID: ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Teacher's Name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter the Teacher's Class: ");
                cls = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Teacher's Section: ");
                sec = Console.ReadLine()[0];

                NewRecord = new TeacherRecord
                {
                    ID = id,
                    Name = name,
                    Cls = cls,
                    Sec = sec
                };
                TeacherRecordList.Add(NewRecord);
            }

        }
        static public void Display(TeacherRecord NewRecord, List<TeacherRecord> TeacherRecordList)
        {
            if(TeacherRecordList.Count<1)
                Console.WriteLine("No Teacher's Data Found.....!!");
            for (int i=0;i<TeacherRecordList.Count;i++)
            {
                Console.WriteLine($"ID :{TeacherRecordList[i].ID}");
                Console.WriteLine($"Name :{TeacherRecordList[i].Name}");
                Console.WriteLine($"Class :{TeacherRecordList[i].Cls}");
                Console.WriteLine($"Section :{TeacherRecordList[i].Sec}");
            }
            
        }
        static public void DataIntoTextFile(TeacherRecord NewRecord,List<TeacherRecord> TeacherRecordList)
        {
            string fpath = @"e:\Teacher.txt"; string records = "";
            for (int i=0;i<TeacherRecordList.Count;i++)
            {
                records += TeacherRecordList[i].ID + " " + TeacherRecordList[i].Name + " " + TeacherRecordList[i].Cls + " " + TeacherRecordList[i].Sec + "\n";

            }
            File.WriteAllText(fpath, records);
            Console.WriteLine("Records are Dumped into the Text File Successfully");
        }
        static public void UpdateTeacherData(TeacherRecord NewRecord,List<TeacherRecord> TeacherRecordList)
        {
            Console.WriteLine("Enter Teacher's ID to Update the Data");
            int update_id = int.Parse(Console.ReadLine());
            int index = TeacherRecordList.FindIndex(x => x.ID == update_id);
            if (index>-1)
            {
                Console.WriteLine("Enter choice \n1. Name \n2. Class\n3. Section");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter new name..");
                        string nn = Console.ReadLine();
                        TeacherRecordList[index].Name = nn;
                        Console.WriteLine( "Name is updated successfully");
                        break;
                    case 2:
                        Console.WriteLine("Enter new class..");
                        int nc = int.Parse(Console.ReadLine());
                        TeacherRecordList[index].Cls = nc;
                        Console.WriteLine("Class is updated successfully");
                        break;
                    case 3:
                        char ns = Console.ReadLine()[0];
                        TeacherRecordList[index].Sec = ns;
                        Console.WriteLine("Section is updated successfully");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            else
                Console.WriteLine("ID is not found..");
        }
        static public void DeleteRecord(TeacherRecord NewRecord,List<TeacherRecord> TeacherRecordList)
        {
            Console.WriteLine("\nEnter the teacher's id to delete the record ..");
            int delete_id = int.Parse(Console.ReadLine());
            int index = TeacherRecordList.FindIndex(x => x.ID == delete_id);
            if(index>-1)
            {
                Console.WriteLine($"Teacher with Name :{TeacherRecordList[index].Name} , Class :{TeacherRecordList[index].Cls} , Section  :{TeacherRecordList[index].Sec}");
                Console.WriteLine("Will be Deleted");
                TeacherRecordList.RemoveAt(index);
            }
            else
                Console.WriteLine("ID is not found..");
        }
        static public void DataIntoList(TeacherRecord NewRecord,List<TeacherRecord> TeacherRecordList)
        {
            string fpath = @"e:\Teacher.txt";
            if(File.Exists(fpath))
            {
                string[] lines = File.ReadAllLines(fpath);
                string[] text_file_data;
                for(int i=0;i<lines.Length;i++)
                {
                    text_file_data = lines[i].Split(" ");
                    NewRecord = new TeacherRecord();
                    NewRecord.ID = int.Parse(text_file_data[0]);
                    NewRecord.Name = text_file_data[1];
                    NewRecord.Cls = int.Parse(text_file_data[2]);
                    NewRecord.Sec = text_file_data[3][0];
                    TeacherRecordList.Add(NewRecord);
                }
            }
            else
                Console.WriteLine("File not Found, New file has been Created..");
        }
        static void Main(string[] args)
        {
            List<TeacherRecord> TeacherRecordList = new List<TeacherRecord>();
            TeacherRecord NewRecord = null;
            int choice;

            DataIntoList(NewRecord, TeacherRecordList);
            
            while (true)
            {
                Console.WriteLine("Hello,\nChoose which operation you would like to do..\n1. for Adding \n2. For Displaying \n3. Dump Records Into The Text File \n4. For Update \n5. For Deleting \n6.Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        add(NewRecord, TeacherRecordList);
                        break;
                    case 2:
                        Display(NewRecord, TeacherRecordList);
                        break;
                    case 3:
                        DataIntoTextFile(NewRecord, TeacherRecordList);
                        break;
                    case 4:
                        UpdateTeacherData(NewRecord, TeacherRecordList);
                        break;
                    case 5:
                        DeleteRecord(NewRecord,TeacherRecordList);
                        break;
                    case 6:
                        break;
                }
                if (choice == 3 || choice == 6)
                    break;
            }

        }
    }
}

