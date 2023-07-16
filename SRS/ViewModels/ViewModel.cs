using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using SRS.Pages;
using System.Windows.Controls;
using System.Xml.Linq;
using SRS.Views;

namespace SRS.ViewModels
{
    public partial class ViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<UserM> userMs = new ObservableCollection<UserM>();

        [ObservableProperty]
        ObservableCollection<StudentM> studentMs = new ObservableCollection<StudentM>();
        [ObservableProperty]
        ObservableCollection<StudentM> studentlist1;

        public DatabaseContext context;


        public UserM SelectedUser { get; set; }

        [ObservableProperty]
        public UserM userList;

        [ObservableProperty]
        public StudentM studentList;


        // Create data variables
        // Teachers
        [ObservableProperty] // It will create a new property. So we change the VM class - partial class 
        [NotifyPropertyChangedFor(nameof(Fullname))] // When we change the name, the fullname also change 
        public string? firstname;  // Nullable

        [ObservableProperty]
        public string? lastname;

        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public string? email;
        [ObservableProperty]
        public string? phonenumber;

        [ObservableProperty]
        public string? dateofbirth;
        [ObservableProperty]
        public string? password;


        [ObservableProperty]
        public string? address;

        [ObservableProperty]
        public string? gpa;




        [ObservableProperty]
        string day = GetGeneralTime(DateTime.Now);

        public static string GetGeneralTime(DateTime specificTime)
        {
            if (specificTime.Hour < 12)
            {
                return "Good Morning!";
            }
            if (specificTime.Hour < 17)
            {
                return "Good Afternoon!";
            }
            if (specificTime.Hour < 21)
            {
                return "Good Evening!";
            }
            else
            {
                return "Good Night!";
            }
        }


        public string Fullname
        { get { return $"{firstname} {lastname}"; } }

        //public string Fullname => $"{firstName} {lastName}";

        public ViewModel()
        {
           using (var context = new DatabaseContext())
           {

                var z = context.Users.ToList();
                foreach( var x in z )
                {
                    UserMs.Add(x);
                }

                var y = context.Students.ToList();
                foreach (var a in y)
                {
                    StudentMs.Add(a);
                }

           }

           Load();
        }


        [RelayCommand]
        public void CreateTheUser()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var uName = Username;
                var uPassword = Password;

                if (uName != null && uPassword != null)
                {
                    context.Users.Add(new UserM() { Username = uName, Password = uPassword });
                    context.SaveChanges();
                    MessageBox.Show("User create successful", "Confirmation");
                }
                else
                {
                    MessageBox.Show("User create unsuccessful", "Confirmation");
                }

            }

        }

        [RelayCommand]
        public void ReadTheUser()
        {
            List<UserM> DatabaseUsers = new List<UserM>();
            userMs.Clear();
            using (DatabaseContext datacontext = new DatabaseContext())
            {
                DatabaseUsers = datacontext.Users.ToList();
                //UsersDataGridView.Itemsource = DatabaseUsers;

                foreach (var x in DatabaseUsers)
                {
                    userMs.Add(x);
                }

            }
        }


        //[RelayCommand]
        //public void UpdateTheUser()
        //{
        //    using (DatabaseContext context = new DatabaseContext())
        //    {
        //        var uName = Username;
        //        var uPassword = Password;

        //        if (uName != null && uPassword != null)
        //        {
        //            //var x = new Sucessmsg();
        //            //x.Show();
        //            var selecteduser = context.Users.Find(UserList.UserId);
        //            selecteduser.Username = uName;
        //            selecteduser.Password = uPassword;
        //            context.SaveChanges();
        //            foreach (var i in UserMs)
        //            {
        //                if (i.Username == selecteduser.Username && i.Password == selecteduser.Password)
        //                {
        //                    i.Username = uName;
        //                    i.Password = uPassword;

        //                }
        //            }

        //            MessageBox.Show("User update successful", "Confirmation");

        //        }
        //        else
        //        {
        //            MessageBox.Show("User update unsuccessful", "Confirmation");
        //        }


        //    }
        //}

        [RelayCommand]
        public void UpdateTheUser()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var uName = Username;
                var uPassword = Password;

                if (uName != null && uPassword != null)
                {
                    var selectedUser = context.Users.Find(SelectedUser.UserId);
                    selectedUser.Username = uName;
                    selectedUser.Password = uPassword;
                    context.SaveChanges();

                    // Find the index of the selected user in the collection
                    int selectedIndex = UserMs.IndexOf(SelectedUser);

                    // Create a copy of the selected user with the updated values
                    var updatedUser = new UserM
                    {
                        UserId = selectedUser.UserId,
                        Username = uName,
                        Password = uPassword
                    };

                    // Replace the selected user in the collection with the updated copy
                    UserMs[selectedIndex] = updatedUser;

                    MessageBox.Show("User update successful", "Confirmation");
                }
                else
                {
                    MessageBox.Show("User update unsuccessful", "Confirmation");
                }
            }
        }



        [RelayCommand]
        public void DeleteTheUser()
        {

            using (DatabaseContext context = new DatabaseContext())
            {

                UserM selectedUser = UserList as UserM;

                if (selectedUser != null)
                {
                    UserM user = context.Users.Single(x => x.UserId == selectedUser.UserId);

                    context.Remove(user);
                    context.SaveChanges();
                    MessageBox.Show("User create successful", "Confirmation");
                }
                else
                {
                    MessageBox.Show("User create unsuccessful", "Confirmation");
                }
            }

        }

        /// <summary>
        /// STUDENT  ////////////////////////////////////////////////////////////////////////////   
        /// </summary>
        [RelayCommand]
        public void StudentLogin()
        {

            using (DatabaseContext context = new DatabaseContext())
            {
                var currstudent = context.Students.FirstOrDefault(St => St.Username == Username && St.Password == Password);
                if (currstudent != null)
                {
                    var studentMainViewModel = new StudentViewModel(currstudent.Id);
                    var SRVM = new StudentResultsViewModel(currstudent);
                    var studentMainW = new StudentWindowView(studentMainViewModel, SRVM);
                    studentMainW.Show();
                }

            }

        }


        [RelayCommand]
        private void DeleteTheStudent(StudentM student)
        {
            studentlist1.Remove(student);
            using (var context = new DatabaseContext())
            {
                context.Students.Remove(student);
                context.SaveChanges();
                MessageBox.Show("Student deleted successful", "Confirmation");
            }
        }


        [RelayCommand]
        public void AddTheStudent()
        {

            StudentM tempStudent = new StudentM()
            {
                Username = Username,
                Password = Password,


            };

            if (tempStudent.Username != null && tempStudent.Password != null)
            {
                using (var context = new DatabaseContext())
                {
                    context.Students.Add(tempStudent);
                    context.SaveChanges();
                    studentlist1.Add(tempStudent);
                    Load();
                }

            }


        }

        public void Load()
        {
            context = new DatabaseContext();
            var sList = context.Students.ToList();
            studentlist1 = new ObservableCollection<StudentM>(sList);
            OnPropertyChanged(nameof(studentlist1));


        }

        [RelayCommand]
        private void UpdateTheStudent(StudentM student)
        {
            if (Firstname != null && Lastname != null && Password != null)
            {
                student.FirstName = Firstname;
                student.LastName = Lastname;
                student.Password = Password;
                context.SaveChanges();
                Load();

            }
        }




        [RelayCommand]
        public void UserStudentLogin()
        {
            /*
            using (var dbContext = new DatabaseContext())
            {
                var users = dbContext.Users.ToList();
                var students = dbContext.Students.ToList();

                bool userFound = false;
                bool studentFound = false;

                foreach (var user in users)
                {
                    if (user.Username == Username && user.Password == Password)
                    {
                        var uDW = new UserDetailsWindow();
                        uDW.Show();
                        //uDW.textUsername.Text = user.Username;
                        //this.Close();
                        userFound = true;
                        break; // Exit the loop after successful user login

                    }
                }

                if (!userFound)
                {
                    foreach (var student in students)
                    {
                        if (student.StudentName == Username && student.StudentPassword == Password)
                        {
                            var sWV = new StudentWindowView();
                            sWV.Show();
                            //uDW.textUsername.Text = user.Username;
                            //this.Close();
                            studentFound = true;
                            return; // Exit the method after successful student login
                        }
                    }
                }
                if (!userFound && !studentFound)
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
            }
            */
        }
    }
}