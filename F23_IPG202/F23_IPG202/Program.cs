using System;
using System.IO;


internal class Program
{
    //create a filepath and put it into the project
    static public string fileName = "Students and Courses Registration System.txt";
    static public string projectPath = Directory.GetCurrentDirectory();
    static public string filePath = Path.Combine(projectPath, fileName);


    static public int ReadNumber(int from, int to)
    {
        do
        {
            if (int.TryParse(Console.ReadLine(), out int num))
            
            {
                if (num <= to && num >= from)
                {
                    return num;
                }

                Console.WriteLine($"enter a number between {from} and {to}");

            }


        } while (true);

    }
  
    static string ChooseProgram(int num)
    {
       
                if (num == 0 )
                {
                    return "BIT";
                }
                else if (num == 1)
                {
                    return "BAIT";
                }
                else
                {
                    return "TIC";

                }
    }

    static public void PrintMainScreen()
    {
        //the header of main screen
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        //the body of main screen
        Console.WriteLine(" Choose an Operation:");
        Console.WriteLine("1 : Registre Student and Courses");
        Console.WriteLine("2 : Edit Student and Courses");
        Console.WriteLine("3 : Print Student and Courses List");
        Console.WriteLine("4 : Print Student and Courses Orderd List");
        Console.WriteLine("5 : Student in Courses and Program");
        Console.WriteLine("6 : Print Global Summary");
        Console.WriteLine("7 : Exit");
    }

    static public void ChooesNumberBetween1To7()
    {
        bool x = true;
        try
        {
            int Number = int.Parse(Console.ReadLine());
            while (x)
            {
                //check for invalid number
                if (Number <= 0 || Number > 7)
                {
                    Console.WriteLine("Please Choose Number Between 1 and 7!");
                    Number = int.Parse(Console.ReadLine());
                }

                switch (Number)
                {
                    case 1:
                        if (Number == 1)
                        {
                            Console.Clear();
                            RegistreStudentandCourses();
                            x = false;

                        }
                        break;

                    case 2:
                        if (Number == 2)
                        {
                            Console.Clear();
                            EditStudentandCoursesRegistration();
                            x = false;
                        }
                        break;

                    case 3:
                        if (Number == 3)
                        {
                            Console.Clear();
                            ListofStudentsandCourses();
                            x = false;
                        }
                        break;

                    case 4:
                        if (Number == 4)
                        {
                            Console.Clear();
                            ListofStudentsandCoursesOrderd();
                            x = false;
                        }
                        break;

                    case 5:
                        if (Number == 5)
                        {
                            Console.Clear();
                            ListofStudentsinProgram();

                            x = false;
                        }
                        break;

                    case 6:
                        if (Number == 6)
                        {
                            Console.Clear();
                            GlobalSummary();
                            x = false;
                        }
                        break;
                    case 7:
                        if (Number == 7)
                        {
                            Console.Clear();
                            x = false;
                        }
                        break;

                }

            }
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("Make Sure The Input is a Int and Between 1 To 7");
            Console.WriteLine("Press Any Key To Contiune...");
            Console.ReadKey();
            Console.Clear();
            PrintMainScreen();
            ChooesNumberBetween1To7();
        }
       
       

    }

    static public void RegistreStudentandCourses()
    {
        int Count = 0;
        //the header of Registre screen
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        //the body of Registre screen
        Console.WriteLine(" Registre Student and Courses:");

        Console.WriteLine(" Student Name: ");
        string StudentName = Console.ReadLine();
        string formattedName = StudentName.Substring(0, Math.Min(StudentName.Length, 10)).PadRight(10);
        string College;

        Console.WriteLine(" Choose Program (0=>BIT, 1=>BAIT, 2=>TIC): ");
         College = ChooseProgram( ReadNumber(0,2));

        
        Console.WriteLine(" Registre IPG101 (yes,no): ");
        string IPG101 = Console.ReadLine();
        if (IPG101.ToLower() == "y" || IPG101.ToLower() == "yes") { Count++; IPG101 = "X"; } else { IPG101 = "."; };

        Console.WriteLine(" Registre IPG201 (yes,no): ");
        string IPG201 = Console.ReadLine();
        if (IPG201.ToLower() == "y" || IPG201.ToLower() == "yes") { Count++; IPG201 = "X"; } else { IPG201 = "."; };

        Console.WriteLine(" Registre IPG202 (yes,no): ");
        string IPG202 = Console.ReadLine();
        if (IPG202.ToLower() == "y" || IPG202.ToLower() == "yes") { Count++; IPG202 = "X"; } else { IPG202 = "."; };

        Console.WriteLine(" Registre IPG203 (yes,no): ");
        string IPG203 = Console.ReadLine();
        if (IPG203.ToLower() == "y" || IPG203.ToLower() == "yes") { Count++; IPG203 = "X"; } else { IPG203 = "."; };

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{formattedName} {new string(' ', 10)} {College.Substring(0, Math.Min(College.Length, 4)).PadRight(4)} {new string(' ', 10)} {IPG101} {new string(' ', 10)} {IPG201} {new string(' ', 10)} {IPG202} {new string(' ', 10)} {IPG203} {new string(' ', 10)} {Count}");
        }
        Console.WriteLine(" \nStudent Registered Successfully, register another (yes,no): ");
        string answer = Console.ReadLine();
        if (answer == "yes" || answer == "y")
        {
            Console.Clear();
            RegistreStudentandCourses();
        }
        else
        {
            Console.WriteLine("Back To Main Screen");
            Console.ReadKey();
            StartProgram();
        }

    }

    static public void EditStudentandCoursesRegistration()
    {
        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);
        int Count = 0;

        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        Console.WriteLine(" Edit Student and Courses Registration:");
        Console.WriteLine(" Student Name: ");
        string StudentName = Console.ReadLine();

        //Make a loop on file to search of StudentName if found edit it
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(' ');


            if (parts[0] == StudentName)
            {
                //Make the Name Has 10 Chars if less replace the rest with space
                string formattedName = StudentName.Substring(0, Math.Min(StudentName.Length, 10)).PadRight(10);
                string College;
                Console.WriteLine(" Choose Program (0=>BIT, 1=>BAIT, 2=>TIC): ");
                College = ChooseProgram(ReadNumber(0,2));

                Console.WriteLine(" Registre IPG101 (yes,no): ");
                string IPG101 = Console.ReadLine();
                if (IPG101.ToLower() == "y" || IPG101.ToLower() == "yes") { Count++; IPG101 = "X"; } else { IPG101 = " "; };

                Console.WriteLine(" Registre IPG201 (yes,no): ");
                string IPG201 = Console.ReadLine();
                if (IPG201.ToLower() == "y" || IPG201.ToLower() == "yes") { Count++; IPG201 = "X"; } else { IPG201 = " "; };

                Console.WriteLine(" Registre IPG202 (yes,no): ");
                string IPG202 = Console.ReadLine();
                if (IPG202.ToLower() == "y" || IPG202.ToLower() == "yes") { Count++; IPG202 = "X"; } else { IPG202 = " "; };

                Console.WriteLine(" Registre IPG203 (yes,no): ");
                string IPG203 = Console.ReadLine();
                if (IPG203.ToLower() == "y" || IPG203.ToLower() == "yes") { Count++; IPG203 = "X"; } else { IPG203 = " "; };

                parts[1] = College;
                parts[2] = IPG101;
                parts[3] = IPG201;
                parts[4] = IPG202;
                parts[5] = IPG203;

                string updatedLine = string.Format($"{formattedName} {new string(' ', 10)} {College} {new string(' ', 10)} {IPG101} {new string(' ', 10)} {IPG201} {new string(' ', 10)} {IPG202} {new string(' ', 10)} {IPG203} {new string(' ', 10)} {Count}");

                lines[i] = updatedLine;

                //Save into file
                File.WriteAllLines(filePath, lines);


                Console.WriteLine("Data for {0} successfully updated!", StudentName);
                break;
            }
            if (i == lines.Length - 1)
            {
                Console.WriteLine("{0} is not in the system yet", StudentName);
            }

        }

        Console.WriteLine("Use Again? y/n");
        string ans = Console.ReadLine().ToLower();
        if (ans == "y" || ans == "yes")
        {
            Console.Clear();
            EditStudentandCoursesRegistration();
        }
        else
        {
            StartProgram();

        }



    }
    
    static public void ListofStudentsandCourses()
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        Console.WriteLine(" List of Students and Courses\n");

        Console.WriteLine($"Name {new string(' ', 14)}   Program {new string(' ', 5)} IPG101 {new string(' ', 5)}  IPG201 {new string(' ', 5)} IPG202 {new string(' ', 5)} IPG203 {new string(' ', 5)} Count\n");
        Console.WriteLine($"{new string('-', 93)}");

        string[] lines = File.ReadAllLines(filePath);
        string[] Parts;
        for (int i = 0; i < lines.Length; i++)
        {
            Parts = lines[i].Split(new char[' '], StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < lines[i].Length; j++)
            {
                
                if (lines[i][j] != '.')
                {
                    Console.Write($"{lines[i][j]}");
                }
                else
                {
                    Console.Write($" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{new string('-',93)}");

        }
       
        Console.ReadKey();
        StartProgram();
    }
    
    static public void ListofStudentsandCoursesOrderd()
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        Console.WriteLine(" List of Students and Courses ordered\n");



        Console.WriteLine($"Name {new string(' ', 14)}   Program {new string(' ', 5)} IPG101 {new string(' ', 5)}  IPG201 {new string(' ', 5)} IPG202 {new string(' ', 5)} IPG203 {new string(' ', 5)} Count\n");
        Console.WriteLine($"{new string('-', 93)}");

        string[] lines = File.ReadAllLines(filePath);
        string[] Parts;
        string[] ReversedLines = new string[lines.Length ];

        for (int i = 0; i <= lines.Length - 1; i++)
        {
            ReversedLines[i] = "";
            for (int j = lines[i].Length - 1; j >= 0  ; j--)
            {
                ReversedLines[i] += lines[i][j];
            }
        }
        Array.Sort(ReversedLines);
        Array.Reverse(ReversedLines);

        for (int i = 0; i <= ReversedLines.Length - 1; i++)
        {
            lines[i] = "";

            for (int j = ReversedLines[i].Length - 1; j >= 0; j--)
            {
                lines[i] += ReversedLines[i][j];

            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
            Parts = lines[i].Split(new char[' '], StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < lines[i].Length; j++)
            {

                if (lines[i][j] != '.')
                {
                    Console.Write($"{lines[i][j]}");
                }
                else
                {
                    Console.Write($" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{new string('-', 93)}");

        }
        Console.ReadKey();
        StartProgram();
    }

    static public void ListofStudentsinProgram()
    {
         Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");

        Console.WriteLine("List of Students and Courses");
        Console.WriteLine("Program (0=>BIT, 1=>BAIT, 2=>TIC)");
        string College; 
        College = ChooseProgram(ReadNumber(0, 2));

        string[] Lines = File.ReadAllLines(filePath);
        string[] Parts;
        string[] students = new string[Lines.Length];
        int j = 0;
        int Count = 0;
        for (int i = 0; i < Lines.Length; i++)
        {
            
            Parts = Lines[i].Split(new char[] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
            if (College == Parts[1])
            {
                students[j] = Parts[0];
                j++;
                Count++;
            } 

        }
        Array.Resize(ref students, Count);
        foreach (string student in students)
        {
            Console.WriteLine(student);
            Console.WriteLine(new string('-', 10));
        }
        Console.Write("Press any key to go back to main screen");
        Console.ReadKey();
        StartProgram();
    }

    static public void GlobalSummary()
    {
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tSVU - Students and Courses Registration System");
        Console.WriteLine("-----------------------------------------------------------------");
        Console.WriteLine("\tGlobal summary");
        int BaitIpg101 = 0, BaitIpg201 = 0, BaitIpg202 = 0, BaitIpg203 = 0;
        int TicIpg101 = 0, TicIpg201 = 0, TicIpg202 = 0, TicIpg203 = 0;
        int BitIpg101 = 0, BitIpg201 = 0, BitIpg202 = 0, BitIpg203 = 0;

        string[] Lines = File.ReadAllLines(filePath);
        string[] Parts;
        for (int i = 0; i < Lines.Length; i++)
        {
            Parts = Lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Parts[1] == "BAIT" && Parts[2] == "X")
            {
                BaitIpg101++;
            }
            if (Parts[1] == "BAIT" && Parts[3] == "X")
            {
                BaitIpg201++;
            }
            if (Parts[1] == "BAIT" && Parts[4] == "X")
            {
                BaitIpg201++;
            }
            if (Parts[1] == "BAIT" && Parts[5] == "X")
            {
                BaitIpg202++;
            }

            if (Parts[1] == "TIC" && Parts[2] == "X")
            {
                TicIpg101++;
            }
            if (Parts[1] == "TIC" && Parts[3] == "X")
            {
                TicIpg201++;
            }
            if (Parts[1] == "TIC" && Parts[4] == "X")
            {
                TicIpg202++;
            }
            if (Parts[1] == "TIC" && Parts[5] == "X")
            {
                TicIpg203++;
            }


            if (Parts[1] == "BIT" && Parts[2] == "X")
            {
                BitIpg101++;
            }
            if (Parts[1] == "BIT" && Parts[3] == "X")
            {
                BitIpg201++;
            }
            if (Parts[1] == "BIT" && Parts[4] == "X")
            {
                BitIpg202++;
            }
            if (Parts[1] == "BIT" && Parts[5] == "X")
            {
                BitIpg203++;
            }

        }
        Console.WriteLine("\nCourse \tBAIT\t\tBIT\t\tTIC\n");
        Console.WriteLine($"IPG101 \t{BaitIpg101}\t\t{BitIpg101}\t\t{TicIpg101}");
        Console.WriteLine($"{new string('-',50)}");
        Console.WriteLine($"IPG201 \t{BaitIpg201}\t\t{BitIpg201}\t\t{TicIpg201}");
        Console.WriteLine($"{new string('-', 50)}");
        Console.WriteLine($"IPG202 \t{BaitIpg202}\t\t{BitIpg202}\t\t{TicIpg202}");
        Console.WriteLine($"{new string('-', 50)}");
        Console.WriteLine($"IPG203 \t{BaitIpg203}\t\t{BitIpg203}\t\t{TicIpg203}");
        Console.WriteLine($"{new string('-', 50)}");

        Console.ReadKey();
        StartProgram();
    }

    static public void StartProgram()
    {
        Console.Clear();
        //check if file dose not exist 
        if (!File.Exists(filePath))
        {
            File.CreateText(filePath);
        }
        PrintMainScreen();
        ChooesNumberBetween1To7();
    }


    static void Main(string[] args)
    {
        StartProgram();

        Console.ReadLine();
    }
}

