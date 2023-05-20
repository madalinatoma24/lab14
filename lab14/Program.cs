using System;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {

            var mada = new Angajat("mada", Guid.NewGuid(), 67_000, Departament.Development);
            var marian = new Angajat("Marian", Guid.NewGuid(), 50_000, Departament.Development);
            var ionel = new Angajat("Ionel", Guid.NewGuid(), 300, Departament.Logistics);
            var irine = new Angajat("Irine", Guid.NewGuid(), 100, Departament.Logistics);
            var miki = new Angajat("Miki", Guid.NewGuid(), 1500, Departament.Testing);
            var lucy = new Angajat("Lucy", Guid.NewGuid(), 2000, Departament.Testing);
            var eve = new Angajat("Eve", Guid.NewGuid(), 67_000, Departament.Development);

            var sistemGestiune = new SistemGestiune();
            sistemGestiune.AddEmployee(mada);
            sistemGestiune.AddEmployee(marian);
            sistemGestiune.AddEmployee(ionel);
            sistemGestiune.AddEmployee(irine);
            sistemGestiune.AddEmployee(miki);
            sistemGestiune.AddEmployee(lucy);
            sistemGestiune.AddEmployee(eve);


            Console.WriteLine($"Angajatii cu salarii peste 1222 din cadrul companiei: \n\t {string.Join("\n\t", sistemGestiune.GetNoOfWellPayedEmployees(1222))}");
            Console.WriteLine($"Angajatii din departamentul {Departament.Logistics}: \n\t {string.Join("\n\t", sistemGestiune.GetEmployeesByDepartment(Departament.Logistics))}");
            Console.WriteLine($"Cel mai mare salariu: \n\t {string.Join("\n\t", sistemGestiune.GetMaxSalary())}");
            Console.WriteLine($"Cel mai mare salariu din departamentul {Departament.Development}: \n\t {string.Join("\n\t", sistemGestiune.GetMaxSalary(Departament.Development))}");
            Console.WriteLine($"Suma tuturor salariilor: {sistemGestiune.GetTotalCost()}");
            Console.WriteLine($"Suma tuturor salariilor din departamentul {Departament.Testing}: {sistemGestiune.GetCostForDepartment(Departament.Testing)}");

            Console.WriteLine($"Marire salariu per departamanet:");
            Console.WriteLine($"\t inainte \n\t {string.Join("\n\t", sistemGestiune.GetEmployeesByDepartment(miki.Department))}");
            sistemGestiune.IncreaseSalary(20, miki.Department);
            Console.WriteLine($"\t dupa marire: \n\t {string.Join("\n\t", sistemGestiune.GetEmployeesByDepartment(miki.Department))}");

            Console.WriteLine($"Marire salariu angajat:");
            Console.WriteLine($"\t inainte {marian.Salary}"); 
            sistemGestiune.IncreaseSalary(marian.Id, 50);
            Console.WriteLine($"\t dupa marire: {marian.Salary}");

            sistemGestiune.RemoveEmployee(irine.Id);

        }
    }
}
