using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRS.Models;
using SRS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS.ViewModels
{
    public partial class StudentResultsViewModel : ObservableObject
    {
        [ObservableProperty]
        public double gpa;
        public StudentM? SelectedStudent { get; set; }
        public List<Module> ModuleList { get; set; }


        public StudentResultsViewModel(StudentM student)
        {
            SelectedStudent = student;
            gpa = SelectedStudent.GPA;


            using (DatabaseContext context = new DatabaseContext())
            {
                ModuleList = context.Modules.ToList();

            }
        }

        [RelayCommand]

        public void CalculateTheGPA()
        {
            using (DatabaseContext context = new DatabaseContext())
            {

                SelectedStudent = context.Students.FirstOrDefault(s => s.Id == SelectedStudent.Id);

                if (SelectedStudent != null)
                {
                    var selectedModules = ModuleList.Where(m => m.IsSelected).ToList();
                    SelectedStudent.SelModules = selectedModules;
                    context.SaveChanges();
                }
            }
            double totalCredit = 0;
            double totalPoints = 0;

            foreach (var module in SelectedStudent.SelModules)
            {
                double Points = 0;
                double Credit = module.Credit;
                switch (module.Result)
                {

                    case "A+":
                    case "A":
                        Points = 4.0; break;
                    case "A-":
                        Points = 3.7; break;
                    case "B+":
                        Points = 3.4; break;
                    case "B":
                        Points = 3.0; break;
                    case "B-":
                        Points = 2.7; break;
                    case "C+":
                        Points = 2.4; break;
                    case "C":
                        Points = 2.0; break;
                    case "C-":
                        Points = 1.7; break;
                    default:
                        Points = 0; break;
                }
                totalPoints += (Points * Credit);
                totalCredit += Credit;
            }
            double GPA = totalPoints / totalCredit;
            SelectedStudent.GPA = GPA;
            gpa = SelectedStudent.GPA;
            using (DatabaseContext context = new DatabaseContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Id == SelectedStudent.Id);
                if (student != null)
                {
                    student.GPA = GPA;
                    context.SaveChanges();
                }
            }

        }
    }
}
