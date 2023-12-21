using System.Data.SqlClient;




public class Company
{
    public string Company_Name { get; set; }
    public string Company_INN { get; set; }
    public string Company_Legal_Address { get; set; }
    public string Company_Actual_Address { get; set; }
}
public class Employee
{
    public string Employee_Surname { get; set; }
    public string Employee_Name { get; set; }
    public string? Employee_Patronymic { get; set; }
    public string Employee_Date_Of_Birth { get; set; }
    public string Employee_Passport_Series { get; set; }
    public string Employee_Passport_Number { get; set; }
}

class Con_Test_DEPO
{
    
    public static void Main()
    {


        Console.SetCursorPosition((Console.WindowWidth - 7) / 2, Console.CursorTop);
        Console.WriteLine("TEST DB\n");

        //Проверка подключения к БД--------------------------------------------------------------------------------------------
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Test_DEPO_DB;Trusted_Connection=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Подключение открыто");
        // Вывод информации о подключении
        Console.WriteLine("Свойства подключения:");
        Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
        Console.WriteLine($"\tБаза данных: {connection.Database}");
        Console.WriteLine($"\tСервер: {connection.DataSource}");
        Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
        Console.WriteLine($"\tСостояние: {connection.State}");
        Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
        connection.Close();
        //-------------------------------------------------------------------------------------------------------------

        Console.WriteLine("\n\nWhat did you want to do?\n------------------------------------------------------\n" +
            "1 - Show list of companies\n" +
            "2 - Show list of Employee\n" +
            "3 - Add Company\n" +
            "4 - Add Employee");

        while (true)
        {
            
            switch (Console.ReadLine())
            {
                case "1":// Вывод списка компаний
                    connection.Open();
                    string Show_Company_List = "SELECT Company_Name FROM Company";
                    SqlCommand Show_Company_command = new SqlCommand(Show_Company_List,connection);
                    SqlDataReader Show_Company_reader = Show_Company_command.ExecuteReader();
                    foreach (var row in Show_Company_reader)
                    {
                        string Company_NAME = Show_Company_reader.GetValue(0).ToString();
                        Console.WriteLine(Company_NAME);
                    }
                    connection.Close();
                    Console.WriteLine("\n\nWhat did you want to do?\n------------------------------------------------------\n" +
                    "1 - Show list of companies\n" +
                    "2 - Show list of Employee\n" +
                    "3 - Add Company\n" +
                    "4 - Add Employee");
                    break;

                case "2":// Вывод списка сотрудников
                    connection.Open();
                    string Show_Employee_List = "SELECT * FROM Employee";
                    SqlCommand Show_Employee_command = new SqlCommand(Show_Employee_List, connection);
                    SqlDataReader Show_Employee_reader = Show_Employee_command.ExecuteReader();
                    foreach (var row in Show_Employee_reader)
                    {
                        string Employee_Surname = Show_Employee_reader.GetValue(2).ToString();
                        string Employee_Name = Show_Employee_reader.GetValue(3).ToString();
                        string Employee_Patronymic = Show_Employee_reader.GetValue(4).ToString();
                        Console.WriteLine($"{Employee_Surname} {Employee_Name} {Employee_Patronymic}");

                    }
                    connection.Close();
                    Console.WriteLine("\n\nWhat did you want to do?\n------------------------------------------------------\n" +
                    "1 - Show list of companies\n" +
                    "2 - Show list of Employee\n" +
                    "3 - Add Company\n" +
                    "4 - Add Employee");
                    break;

                case "3":// Добавление новой компании

                    Company new_company = new Company();
                    bool stopper = false;
                    while (stopper == false)
                    {
                        Console.WriteLine("Введите название компании: ");
                        string temp_name = Console.ReadLine();
                        if (temp_name == "")
                        {
                            Console.WriteLine("ОШИБКА!");
                        }
                        else
                        {
                            new_company.Company_Name = temp_name;
                            stopper = true;
                        }
                    }
                    stopper = false;

                    while (stopper == false)
                    {
                        Console.WriteLine("Введите ИНН компании: ");
                        string temp_name = Console.ReadLine();
                        if (temp_name == "" || temp_name.Length < 10)
                        {
                            Console.WriteLine("ОШИБКА!");
                        }
                        else
                        {
                            new_company.Company_INN = temp_name;
                            stopper = true;
                        }
                    }
                    stopper = false;

                    while (stopper == false)
                    {
                        Console.WriteLine("Введите юр.адрес компании: ");
                        string temp_name = Console.ReadLine();
                        if (temp_name == "")
                        {
                            Console.WriteLine("ОШИБКА!");
                        }
                        else
                        {
                            new_company.Company_Legal_Address = temp_name;
                            stopper = true;
                        }
                    }
                    stopper = false;

                    while (stopper == false)
                    {
                        Console.WriteLine("Введите факт.адрес компании: ");
                        string temp_name = Console.ReadLine();
                        if (temp_name == "")
                        {
                            Console.WriteLine("ОШИБКА!");
                        }
                        else
                        {
                            new_company.Company_Actual_Address = temp_name;
                            stopper = true;
                        }
                    }
                    stopper = false;

                    connection.Open();
                    string Add_Company = "INSERT INTO Company " +
                        "(" +
                        "Company_Name," +
                        "Company_INN," +
                        "Company_Legal_Address," +
                        "Company_Actual_Address" +
                        ") VALUES" +
                        "(" +
                        $"N\'{new_company.Company_Name}\'," +
                        $"N\'{new_company.Company_INN}\'," +
                        $"N\'{new_company.Company_Legal_Address}\'," +
                        $"N\'{new_company.Company_Actual_Address}\'" +
                        ");";
                    SqlCommand ADD_Company_command = new SqlCommand(Add_Company, connection);
                    SqlDataReader ADD_Company_reader = ADD_Company_command.ExecuteReader();
                    connection.Close();
                    Console.WriteLine("\nA new company added sucesfull");
                    Console.WriteLine("\n\nWhat did you want to do?\n------------------------------------------------------\n" +
                    "1 - Show list of companies\n" +
                    "2 - Show list of Employee\n" +
                    "3 - Add Company\n" +
                    "4 - Add Employee");
                    break;

                case "4":

                    break;
            }


        }
    }
}
