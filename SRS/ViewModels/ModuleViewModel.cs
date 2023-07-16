using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SRS.ViewModels
{
    public partial class ModuleViewModel : ObservableObject
    {
        public ModuleViewModel()
        {
            Load();
        }

        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public int credit;
        [ObservableProperty]
        public string? code;
        [ObservableProperty]
        public string? name;
        [ObservableProperty]
        ObservableCollection<Module> moduleList;

        public DatabaseContext context;


        [RelayCommand]
        private void DeleteModule(Module module)
        {
            moduleList.Remove(module);
            using (var context = new DatabaseContext())
            {
                context.Modules.Remove(module);
                context.SaveChanges();
            }
        }

        [RelayCommand]
        public void CreateModule()
        {

            Module temp = new Module();
            {
                temp.Name = name;
                temp.Code = code;
                temp.Credit = credit;
            };

            if (temp.Name != null && temp.Code != null && temp.Credit >= 0)
            {
                using (var context = new DatabaseContext())
                {
                    context.Modules.Add(temp);
                    context.SaveChanges();
                    moduleList.Add(temp);
                    Load();
                }

            }


        }

        public void Load()
        {
            context = new DatabaseContext();
            var list = context.Modules.ToList();
            moduleList = new ObservableCollection<Module>(list);
            OnPropertyChanged(nameof(moduleList));
        }

        [RelayCommand]
        private void UpdateModule(Module module)
        {
            if (name != null && code != null && credit >= 0)
            {
                module.Name = name;
                module.Code = code;
                module.Credit = credit;
                context.SaveChanges();
                Load();

            }
        }



    }
}

