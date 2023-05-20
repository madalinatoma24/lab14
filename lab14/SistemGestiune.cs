using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab14
{
   public class SistemGestiune
    {
        private List<Angajat> _angajati = new List<Angajat>();
        public void AddEmployee(Angajat angajat)
        {
            _angajati.Add(angajat);
        }

        public void RemoveEmployee(Guid Id)
        {
            _angajati.RemoveAll(p => p.Id == Id);
        }

        public List<Angajat> GetNoOfWellPayedEmployees(decimal minSalary)
        {
            return _angajati.Where(p => p.Salary > minSalary).ToList();
        }

        public List<Angajat> GetEmployeesByDepartment(  Departament departament)
        {
            return _angajati.Where(p => p.Department == departament).ToList();
        }

        public List<Angajat> GetMaxSalary()
        {
            var maxSalary = _angajati.Max(p => p.Salary);
            return _angajati.Where(p => p.Salary == maxSalary).ToList();
        }
        
        public List<Angajat> GetMaxSalary(Departament departament)
        {
            var angajatiiDepartamentului = _angajati.Where(d => d.Department == departament);
            var maxSalary = angajatiiDepartamentului.Max(p => p.Salary);
            return angajatiiDepartamentului.Where(p => p.Salary == maxSalary).ToList();
        }

        public decimal GetTotalCost()
        {
            return _angajati.Sum(p => p.Salary);
        }

        public decimal GetCostForDepartment(Departament departament)
        {
            return _angajati.Where(d => d.Department == departament).Sum(s => s.Salary);
        }

        public decimal IncreaseSalary(Guid id, decimal procent)
        {
            var angajat = _angajati.FirstOrDefault(a => a.Id == id);
            if (angajat == null)
                throw new InvalidOperationException($"Angajatul cu id-ul {id} nu exista in sistem!");
            angajat.IncreaseSalaryWithPercentage(procent);
            return angajat.Salary;
        }


        public void IncreaseSalary(decimal procent, Departament departament)
        {
            _angajati.Where(a => a.Department == departament)
                .ToList()
                .ForEach(a => a.IncreaseSalaryWithPercentage(procent));
        }
    }
}
