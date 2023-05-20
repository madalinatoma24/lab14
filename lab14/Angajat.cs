using System;
using System.Collections.Generic;
using System.Text;

namespace lab14
{
    public class Angajat
    {
        public string Nume { get; private set; }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Salary { get; private set; }
        public Departament Department { get; private set; }
        public override string ToString() => $"Id {Id}, Nume: {Nume}, Salary {Salary}, Departament {Department}";

        public Angajat(string nume, Guid id, decimal salary, Departament department)
        {
            Nume = nume ?? throw new ArgumentNullException(nameof(nume));
            Id = id;
            Salary = salary;
            Department = department;
        }

        public void IncreaseSalaryWithPercentage(decimal percentage) 
            => Salary *= (1 + percentage / 100);
    }
}
