using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpExercises
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("      C# and ADO.NET Exercises         ");
            Console.WriteLine("=======================================\n");

            Ex1_Setup();
            Ex2_ValueVsReference();
            Ex3_PrimaryConstructors();
            Ex4_TypeInference();
            Ex5_GradeCalculation(85);
            Ex6_Loops();
            Ex7_MethodOverloading();
            Ex8_RefOutIn();
            Ex9_LocalFunctions();
            Ex10_Constructors();
            Ex11_AccessModifiers();
            Ex12_Properties();
            Ex13_Records();
            Ex14_Inheritance();
            Ex15_AbstractVsInterface();
            Ex16_NullReferences();
            Ex17_ContactApp();
            Ex18_RequiredModifier();
            Ex19_ListsAndDictionaries();
            Ex20_LINQ();
            Ex21_PatternMatching(new Person("Alice", 30));
            Ex22_Tuples();
            await Ex23_AsyncUpload();
            Ex24_Json();
            Ex25_Streams();
            Ex26_RaceConditions();
            Ex27_Deadlocks();
            Ex28_TraceLogging();
            Ex29_SanitizeInput("<script>alert('XSS!')</script>");
            Ex30_ADONET();
            
            Console.WriteLine("\nAll exercises executed successfully!");
        }

        // --- Ex 1: Set Up the Development Environment ---
        static void Ex1_Setup() {
            Console.WriteLine("--- Ex 1 ---");
            Console.WriteLine("Hello World from C# Console App!");
        }

        // --- Ex 2: Explore Value vs Reference Types ---
        class MyClass { public int Value; }
        static void Ex2_ValueVsReference() {
            Console.WriteLine("\n--- Ex 2 ---");
            int val = 10;
            MyClass refObj = new MyClass { Value = 10 };
            Console.WriteLine($"Before Method: val={val}, refObj={refObj.Value}");
            
            // Value types pass a copy, Reference types pass a pointer to the heap object
            Modify(val, refObj);
            
            Console.WriteLine($"After Method: val={val}, refObj={refObj.Value}");
        }
        static void Modify(int v, MyClass r) { v = 20; r.Value = 20; }

        // --- Ex 3: Primary Constructors (C# 12) ---
        public class Person(string name, int age) {
            public string Name { get; } = name;
            public int Age { get; } = age;
            public void Display() => Console.WriteLine($"Person details: {Name}, Age {Age}");
        }
        static void Ex3_PrimaryConstructors() {
            Console.WriteLine("\n--- Ex 3 ---");
            Person p = new Person("John Doe", 25);
            p.Display();
        }

        // --- Ex 4: Type Inference with var and new() ---
        static void Ex4_TypeInference() {
            Console.WriteLine("\n--- Ex 4 ---");
            var number = 42; 
            var text = "Hello Inference";
            Person p = new("Bob", 40); // Target-typed new expression

            Console.WriteLine($"Type of var number: {number.GetType()}, Value: {number}");
            Console.WriteLine($"Type of var text: {text.GetType()}, Value: {text}");
            Console.WriteLine($"Type of target-typed new(): {p.GetType()}, Value: {p.Name}");
            // Discussion: var is great for clean code when the right-hand side is obvious (var dict = new Dictionary<int, string>()), but affects readability if the returning type of a method is obscure.
        }

        // --- Ex 5: Conditional Logic for Grade Calculation ---
        static void Ex5_GradeCalculation(int score) {
            Console.WriteLine("\n--- Ex 5 ---");
            // Pattern matching with switch expression
            string grade = score switch {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
            Console.WriteLine($"Score: {score} -> Grade: {grade}");
        }

        // --- Ex 6: Loop Through an Array ---
        static void Ex6_Loops() {
            Console.WriteLine("\n--- Ex 6 ---");
            int[] arr = { 1, 2, 3, 4, 5 };
            
            Console.Write("For loop (skip 3): ");
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == 3) continue;
                Console.Write(arr[i] + " ");
            }
            
            Console.Write("\nForeach loop (stop at 4): ");
            foreach (var num in arr) {
                if (num == 4) break;
                Console.Write(num + " ");
            }
            
            Console.Write("\nWhile loop: ");
            int j = 0;
            while (j < arr.Length) { Console.Write(arr[j++] + " "); }
            
            Console.Write("\nDo-While loop: ");
            int k = 0;
            do { Console.Write(arr[k++] + " "); } while (k < arr.Length);
            Console.WriteLine();
        }

        // --- Ex 7: Method Overloading ---
        static void Ex7_MethodOverloading() {
            Console.WriteLine("\n--- Ex 7 ---");
            Console.WriteLine($"Int Overload (5+10): {CalculateTotal(5, 10)}");
            Console.WriteLine($"Double Overload (1.5+2.5+3.5): {CalculateTotal(1.5, 2.5, 3.5)}");
        }
        static int CalculateTotal(int a, int b) => a + b;
        static double CalculateTotal(double a, double b, double c) => a + b + c;

        // --- Ex 8: Use ref, out, and in Parameters ---
        static void Ex8_RefOutIn() {
            Console.WriteLine("\n--- Ex 8 ---");
            int r = 5; 
            Console.WriteLine($"Before ref: {r}");
            ModifyRef(ref r);
            Console.WriteLine($"After ref: {r}");

            ModifyOut(out int o);
            Console.WriteLine($"Out value set: {o}");

            ModifyIn(in r); // Passes by read-only reference
        }
        static void ModifyRef(ref int x) => x += 5;
        static void ModifyOut(out int x) => x = 100;
        static void ModifyIn(in int x) => Console.WriteLine($"In value passed: {x}");

        // --- Ex 9: Local Functions ---
        static void Ex9_LocalFunctions() {
            Console.WriteLine("\n--- Ex 9 ---");
            Console.WriteLine($"Factorial of 5 using Local Function: {CalculateFactorial(5)}");
            
            int CalculateFactorial(int n) {
                int Fact(int num) => num <= 1 ? 1 : num * Fact(num - 1);
                return Fact(n);
            }
        }

        // --- Ex 10: OOP Basics with Constructors ---
        class Car {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            
            // Default
            public Car() { Make = "Unknown"; Model = "Unknown"; Year = 1900; }
            
            // Parameterized
            public Car(string make, string model, int year) { Make = make; Model = model; Year = year; }
        }
        static void Ex10_Constructors() {
            Console.WriteLine("\n--- Ex 10 ---");
            Car c1 = new Car();
            Car c2 = new Car("Tesla", "Model 3", 2024);
            Console.WriteLine($"Default Constructor: {c1.Make} {c1.Model} ({c1.Year})");
            Console.WriteLine($"Parameterized Constructor: {c2.Make} {c2.Model} ({c2.Year})");
        }

        // --- Ex 11: Access Modifiers ---
        class BaseClass {
            public string Pub = "Public Member";
            private string Priv = "Private Member";
            protected string Prot = "Protected Member";
            
            public string GetPrivate() => Priv; // Accessed inside the class
        }
        class DerivedClass : BaseClass {
            public string GetProtected() => Prot; // Accessed by derived
        }
        static void Ex11_AccessModifiers() {
            Console.WriteLine("\n--- Ex 11 ---");
            DerivedClass d = new DerivedClass();
            Console.WriteLine(d.Pub);
            Console.WriteLine(d.GetProtected());
            Console.WriteLine(d.GetPrivate());
        }

        // --- Ex 12: Auto-Properties and Backing Fields ---
        class Product {
            public string Name { get; set; } = string.Empty;
            
            private decimal _price;
            public decimal Price { 
                get => _price; 
                set {
                    if (value >= 0) _price = value;
                    else Console.WriteLine("Validation Error: Price cannot be negative!");
                }
            }
        }
        static void Ex12_Properties() {
            Console.WriteLine("\n--- Ex 12 ---");
            Product p = new Product { Name = "Keyboard" };
            p.Price = -50;  // Will trigger validation
            p.Price = 120; // Valid
            Console.WriteLine($"Product: {p.Name}, Price: {p.Price}");
        }

        // --- Ex 13: Records with init Properties ---
        public record Employee {
            public string Name { get; init; } = string.Empty;
            public int ID { get; init; }
        }
        static void Ex13_Records() {
            Console.WriteLine("\n--- Ex 13 ---");
            Employee e1 = new Employee { Name = "Alice", ID = 101 };
            // e1.Name = "Bob"; // Compiler Error: Init-only property cannot be set
            Employee e2 = e1 with { Name = "Bob" }; // Non-destructive mutation
            
            Console.WriteLine($"Original Record: {e1.Name} ({e1.ID})");
            Console.WriteLine($"Modified Copy Record: {e2.Name} ({e2.ID})");
        }

        // --- Ex 14: Inheritance and Method Overriding ---
        abstract class Shape { public virtual void Draw() => Console.WriteLine("Drawing a Generic Shape"); }
        class Circle : Shape { public override void Draw() => Console.WriteLine("Drawing a Circle"); }
        class Rectangle : Shape { public override void Draw() => Console.WriteLine("Drawing a Rectangle"); }
        
        static void Ex14_Inheritance() {
            Console.WriteLine("\n--- Ex 14 ---");
            Shape s1 = new Circle();
            Shape s2 = new Rectangle();
            s1.Draw();
            s2.Draw();
        }

        // --- Ex 15: Abstract Classes and Interfaces ---
        abstract class Vehicle { public abstract void Drive(); }
        interface IDrivable { void Start(); }
        class AutoCar : Vehicle, IDrivable {
            public override void Drive() => Console.WriteLine("Vehicle is Driving");
            public void Start() => Console.WriteLine("Engine Started");
        }
        static void Ex15_AbstractVsInterface() {
            Console.WriteLine("\n--- Ex 15 ---");
            AutoCar myCar = new AutoCar();
            myCar.Start();
            myCar.Drive();
        }

        // --- Ex 16: Handle Null References Safely ---
        class NullablePerson { public string? Name { get; set; } }
        static void Ex16_NullReferences() {
            Console.WriteLine("\n--- Ex 16 ---");
            NullablePerson? p = null;
            
            // Null-conditional (?.) and null-coalescing (??)
            string name = p?.Name ?? "Default Anonymous User";
            Console.WriteLine($"Safely handled null: {name}");
        }

        // --- Ex 17: Null-Conditional Chaining in a Contact App ---
        class Contact { public string? Name { get; set; } public string? PhoneNumber { get; set; } }
        static void Ex17_ContactApp() {
            Console.WriteLine("\n--- Ex 17 ---");
            Contact? c = new Contact { Name = "Charlie", PhoneNumber = "555-1234" };
            Contact? emptyContact = null;
            
            Console.WriteLine($"Contact 1 Name: {c?.Name}");
            Console.WriteLine($"Contact 2 Name: {emptyContact?.Name ?? "No Contact Found"}");
        }

        // --- Ex 18: Use the required Modifier ---
        class Student { public required string Name { get; set; } }
        static void Ex18_RequiredModifier() {
            Console.WriteLine("\n--- Ex 18 ---");
            // Student s = new Student(); // Compile error: required property not set
            Student s = new Student { Name = "Dave" };
            Console.WriteLine($"Student initialized with required modifier: {s.Name}");
        }

        // --- Ex 19: Lists and Dictionaries ---
        static void Ex19_ListsAndDictionaries() {
            Console.WriteLine("\n--- Ex 19 ---");
            List<string> list = new List<string> { "Apple", "Banana" };
            list.Add("Cherry");
            list.Remove("Banana");
            
            Console.Write("List Elements: ");
            foreach(var item in list) Console.Write(item + " ");

            Dictionary<int, string> dict = new Dictionary<int, string> { { 1, "One" }, { 2, "Two" } };
            dict.Add(3, "Three");
            
            Console.Write("\nDict Elements: ");
            foreach(var kv in dict) Console.Write($"[{kv.Key}:{kv.Value}] ");
            Console.WriteLine();
        }

        // --- Ex 20: LINQ for Filtering and Projection ---
        class Order { public int OrderId; public string CustomerName=""; public decimal TotalAmount; }
        static void Ex20_LINQ() {
            Console.WriteLine("\n--- Ex 20 ---");
            var orders = new List<Order> {
                new Order { OrderId=1, CustomerName="X", TotalAmount=50 },
                new Order { OrderId=2, CustomerName="Y", TotalAmount=150 },
                new Order { OrderId=3, CustomerName="Z", TotalAmount=200 }
            };
            
            // Filter and project to anonymous type
            var bigOrders = orders
                .Where(o => o.TotalAmount > 100)
                .Select(o => new { o.CustomerName, o.TotalAmount });
                
            foreach(var o in bigOrders) {
                Console.WriteLine($"Big Order: {o.CustomerName} spent {o.TotalAmount}");
            }
        }

        // --- Ex 21: Pattern Matching ---
        static void Ex21_PatternMatching(object obj) {
            Console.WriteLine("\n--- Ex 21 ---");
            if (obj is Person p) {
                Console.WriteLine($"Object is Person. Name is {p.Name}");
            }
            
            string result = obj switch {
                Person _ => "Matched Person type via switch",
                string _ => "Matched String type via switch",
                _ => "Unknown type"
            };
            Console.WriteLine(result);
        }

        // --- Ex 22: Create and Deconstruct Tuples ---
        static void Ex22_Tuples() {
            Console.WriteLine("\n--- Ex 22 ---");
            var (id, desc) = GetTuple(); // Deconstruction
            Console.WriteLine($"Deconstructed Tuple: ID={id}, Desc={desc}");
        }
        static (int, string) GetTuple() => (99, "A valid tuple return");

        // --- Ex 23: Async File Upload ---
        static async Task Ex23_AsyncUpload() {
            Console.WriteLine("\n--- Ex 23 ---");
            try {
                Console.WriteLine("Simulating Async Upload (waiting 3 seconds)...");
                await Task.Delay(3000); // Wait 3 seconds
                Console.WriteLine("Upload Successful!");
            } catch (Exception ex) { 
                Console.WriteLine($"Upload Failed: {ex.Message}"); 
            }
        }

        // --- Ex 24: JSON Serialize / Deserialize ---
        class User { public string Name { get; set; }="" ; public int Age { get; set; } }
        static void Ex24_Json() {
            Console.WriteLine("\n--- Ex 24 ---");
            User u = new User { Name = "Eve", Age = 28 };
            
            // Serialize
            string json = JsonSerializer.Serialize(u);
            Console.WriteLine($"Serialized JSON: {json}");
            
            // Deserialize
            User? des = JsonSerializer.Deserialize<User>(json);
            Console.WriteLine($"Deserialized Object Name: {des?.Name}");
        }

        // --- Ex 25: FileStream and MemoryStream ---
        static void Ex25_Streams() {
            Console.WriteLine("\n--- Ex 25 ---");
            
            // FileStream
            File.WriteAllText("test.txt", "Stream Data Content");
            using (FileStream fs = new FileStream("test.txt", FileMode.Open))
            using (StreamReader sr = new StreamReader(fs)) {
                Console.WriteLine($"FileStream Read: {sr.ReadToEnd()}");
            }
            
            // MemoryStream
            using (MemoryStream ms = new MemoryStream()) {
                byte[] data = System.Text.Encoding.UTF8.GetBytes("Memory String");
                ms.Write(data, 0, data.Length);
                Console.WriteLine($"MemoryStream Bytes Written: {ms.Length}");
            }
        }

        // --- Ex 26: Race Conditions with Multi-threading ---
        static int counter = 0; 
        static readonly object lockObj = new object();
        static void Ex26_RaceConditions() {
            Console.WriteLine("\n--- Ex 26 ---");
            Task[] tasks = new Task[20];
            for (int i = 0; i < 20; i++) {
                tasks[i] = Task.Run(() => {
                    lock (lockObj) { counter++; } // Safely incrementing
                });
            }
            Task.WaitAll(tasks);
            Console.WriteLine($"All threads complete safely using lock. Shared Counter: {counter}");
        }

        // --- Ex 27: Deadlocks ---
        static readonly object lock1 = new object(); 
        static readonly object lock2 = new object();
        static void Ex27_Deadlocks() {
            Console.WriteLine("\n--- Ex 27 ---");
            Task t1 = Task.Run(() => {
                lock(lock1) {
                    Thread.Sleep(50);
                    if (Monitor.TryEnter(lock2, 100)) {
                        try { Console.WriteLine("T1 acquired both locks"); }
                        finally { Monitor.Exit(lock2); }
                    } else { Console.WriteLine("T1 avoided deadlock by timing out via Monitor.TryEnter"); }
                }
            });
            Task t2 = Task.Run(() => {
                lock(lock2) {
                    Thread.Sleep(50);
                    if (Monitor.TryEnter(lock1, 100)) {
                        try { Console.WriteLine("T2 acquired both locks"); }
                        finally { Monitor.Exit(lock1); }
                    } else { Console.WriteLine("T2 avoided deadlock by timing out via Monitor.TryEnter"); }
                }
            });
            Task.WaitAll(t1, t2);
        }

        // --- Ex 28: Log with Trace ---
        static void Ex28_TraceLogging() {
            Console.WriteLine("\n--- Ex 28 ---");
            using TextWriterTraceListener listener = new TextWriterTraceListener("trace.log");
            Trace.Listeners.Add(listener);
            Trace.WriteLine("This is an automated trace log generated by Ex 28.");
            Trace.Flush();
            Trace.Listeners.Remove(listener);
            Console.WriteLine("Message successfully logged to local 'trace.log' file.");
        }

        // --- Ex 29: Sanitize Input for XSS ---
        static void Ex29_SanitizeInput(string input) {
            Console.WriteLine("\n--- Ex 29 ---");
            Console.WriteLine($"Malicious Input: {input}");
            string safeHtml = HtmlEncoder.Default.Encode(input);
            Console.WriteLine($"Sanitized HTML Safe Output: {safeHtml}");
        }

        // --- Ex 30: Perform CRUD Operations using ADO.NET ---
        static void Ex30_ADONET() {
            Console.WriteLine("\n--- Ex 30 ---");
            Console.WriteLine("Executing ADO.NET Logic (will safely catch exceptions if no local SQL DB exists)");
            
            try {
                // Connect to a local SQL Server instance
                string connStr = "Server=localhost;Database=TestDB;Trusted_Connection=True;";
                using SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                // Create Command (C)
                using SqlCommand insertCmd = new SqlCommand("INSERT INTO Employees (Name) VALUES ('Jane Doe')", conn);
                insertCmd.ExecuteNonQuery();

                // Read Command (R)
                using SqlCommand readCmd = new SqlCommand("SELECT * FROM Employees", conn);
                using SqlDataReader reader = readCmd.ExecuteReader();
                while(reader.Read()) { 
                    Console.WriteLine($"Read Record: {reader["Name"]}"); 
                }
                reader.Close();

                // Update Command (U)
                using SqlCommand updateCmd = new SqlCommand("UPDATE Employees SET Name='Jane Smith' WHERE Name='Jane Doe'", conn);
                updateCmd.ExecuteNonQuery();

                // Delete Command (D)
                using SqlCommand deleteCmd = new SqlCommand("DELETE FROM Employees WHERE Name='Jane Smith'", conn);
                deleteCmd.ExecuteNonQuery();
                
                // DataAdapter Demonstration
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", conn);
                Console.WriteLine("ADO.NET Commands Executed Successfully!");

            } catch (Exception ex) {
                // Safe Exception Handling to prevent crashing if user doesn't have a DB setup.
                Console.WriteLine($"ADO.NET execution caught gracefully without crashing. Expected Error: {ex.Message}");
            }
        }
    }
}
