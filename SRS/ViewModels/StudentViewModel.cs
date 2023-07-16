using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRS.Models;
using SRS.Pages;
using SRS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRS.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {


        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public string? password;


        public StudentM CurrStudent { get; set; }
        public StudentViewModel(int studentId)
        {

            using (DatabaseContext context = new DatabaseContext())
            {
                CurrStudent = context.Students.FirstOrDefault(s => s.Id == studentId);
            }
        }



        [RelayCommand]
        private void UpdateStudent()
        {

            using (DatabaseContext context = new DatabaseContext())
            {
                StudentM student = new StudentM();
                student = context.Students.FirstOrDefault(s => s.Id == CurrStudent.Id);
                student.FirstName = CurrStudent.FirstName;
                student.LastName = CurrStudent.LastName;
                student.Username = CurrStudent.Username;
                context.SaveChanges();

            }

        }


        //[RelayCommand]
        //public void ResultsDetails()
        //{
        //    var vm = new ResultsDetailsVM(CurrStudent.Id);
        //    var win = new ResultsDetails(vm);
        //    win.Show();
        //}



    }

}

