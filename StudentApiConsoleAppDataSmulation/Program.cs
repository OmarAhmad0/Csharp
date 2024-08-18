using System;
using System.Net.Http.Json;

class Program
{
    static readonly HttpClient httpClient = new HttpClient();
    static async Task Main(string[] args)
    {
        httpClient.BaseAddress = new Uri("http://localhost:5287/api/StudentApi");
        await GetAllStudent();
    }

    static async Task GetAllStudent()
    {
        try
        {
            Console.WriteLine("\n______________");
            Console.WriteLine("\nFetching all student data...\n");
            var student = await httpClient.GetFromJsonAsync<List<Student>>("StudentApi");
            if(student != null)
            {
                foreach (var st in student)
                {
                    Console.WriteLine($"ID: {st.Id}, Name: {st.Name}, Age: {st.Age}, Grade: {st.Grade} ");
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred {ex}");
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }
}