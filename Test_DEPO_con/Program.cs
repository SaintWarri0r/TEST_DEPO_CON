
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

        //Подключение к БД--------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------

        Console.WriteLine("\n\nWhat did you want to do?\n------------------------------------------------------\n" +
            "1 - Show list of companies\n" +
            "2 - Show list of Employee\n" +
            "3 - Add Company\n" +
            "4 - Add Employee");

        while (true)
        {
            string presed_key = Console.ReadLine();
            switch (presed_key)
            {
                case "1":
                    break;
                case "2":
                    break;
            }


        }
    }
}
