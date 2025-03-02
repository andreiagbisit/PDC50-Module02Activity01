﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        //Role of ViewModel
        private Student _student;

        private string _fullName; //variable for data conversion

        public StudentViewModel()
        {
            //Initialize a sample student model. Coordination with Model
            _student = new Student { FirstName="John", LastName="Doe", Age=23};

            //UI Thread Management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            //Collections
            Students = new ObservableCollection<Student>()
            {
                new Student {FirstName="Jane", LastName="Smith", Age=23},
                new Student {FirstName="Juan", LastName="dela Cruz", Age=21},
                new Student {FirstName="Pedro", LastName="Penduko", Age=19}
            };
        }

        //Setting collections in public
        public ObservableCollection<Student> Students { get; set; }


        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI Thread Management
        public ICommand LoadStudentDataCommand { get; }

        //Two-way Data Binding and Data Conversion

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); // I/O Operation
            FullName = $"{_student.FirstName} {_student.LastName}"; //Data
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
