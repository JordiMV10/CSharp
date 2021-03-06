﻿using Academy.Lib.Context;
using Academy.Lib.Infrastructure;
using Academy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static string CurrentOption { get; set; }

        public static StudentRepository StudentRepository { get; set; }

        public static SubjectRepository SubjectRepository { get; set; }

        static void Main(string[] args)
        {
            //ExampleDelegates();
            Console.WriteLine("Bienvenidos al programa de gestión de clase");
            ShowMainMenu();

            StudentRepository = new StudentRepository();

            while (true)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == 'm')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "m")
                    {
                        Console.WriteLine();
                        ShowMainMenu();
                    }
                }
                else if (option == 'a')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "a")
                    {
                        Console.WriteLine();
                        ShowHandleStudentsMenu();
                    }
                }
                else if (option == 's')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "s")
                    {
                        Console.WriteLine();
                        ShowHandleSubjectsMenu();
                    }
                }
                else if( option == 'n')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "n")
                    {
                        Console.WriteLine();
                        ShowAddNotesMenu();
                    }
                }
                else if(option == 'c')
                {
                    ClearCurrentConsoleLine();
                    if (CurrentOption != "c")
                    {
                        Console.WriteLine();
                        ShowStatisticsMenu();
                    }
                }
            }
        }
                
        static void ShowMainMenu()
        {
            CurrentOption = "m";
            Console.WriteLine("Menu de opciones principal");

            Console.WriteLine("Opciones: m - para volver a este menu");
            Console.WriteLine("Opciones: a - gestionar alumnos");
            Console.WriteLine("Opciones: s - gestionar sujetos");
            Console.WriteLine("Opciones: n - añadir notas de alumnos");
            Console.WriteLine("Opciones: c - Estadísticas");
        }

        static void ShowHandleStudentsMenu()
        {
            CurrentOption = "a";
            Console.WriteLine("Menu de gestionar alumnos.");
            Console.WriteLine("Opciones: a - para añadir un nuevo almuno");
            Console.WriteLine("Opciones: e + dni - para editar un alumno existente");
            Console.WriteLine("Opciones: n - ver información del alumno");
            Console.WriteLine("Opciones: n/e - ver exámenes de alumno");
            Console.WriteLine("Opciones: n/e - ver asignaturas de alumno");
            Console.WriteLine("Presione m para acabar y volver al menú principal");

            while (true)
            {
                var option = Console.ReadLine();

                if (option == "m")
                {
                    break;
                }
                else if (option == "a")
                {
                    Console.WriteLine("Para volver sin guardar alumno escriba  *.");
                    Console.WriteLine("escriba el dni:");

                    #region read dni
                    var dni = Console.ReadLine();

                    if (dni == "*")
                        break;

                    ValidationResult<string> vrDni; 
                    while (!(vrDni = Student.ValidateDni(dni)).IsSuccess)
                    {
                        Console.WriteLine(vrDni.AllErrors);
                        dni = Console.ReadLine();
                    }
                    
                    if (dni == "*")
                        break;

                    #endregion

                    #region read name
                    Console.WriteLine("escriba el nombre y apellidos:");
                    var name = Console.ReadLine();

                    if (name == "*")
                        break;

                    ValidationResult<string> vrName;
                    while (!(vrName = Student.ValidateName(name)).IsSuccess)
                    {
                        Console.WriteLine(vrName.AllErrors);
                        name = Console.ReadLine();
                    }

                    #endregion

                    #region read chair number
                    Console.WriteLine("escriba el número de silla:");
                    var chairNumberText = Console.ReadLine();

                    if (chairNumberText == "*")
                        break;

                    ValidationResult<int> vrChair;
                    while (!(vrChair = Student.ValidateChairNumber(chairNumberText)).IsSuccess)
                    {
                        Console.WriteLine(vrChair.AllErrors);
                        chairNumberText = Console.ReadLine();
                    }

                    #endregion

                    if (vrDni.IsSuccess && vrName.IsSuccess && vrChair.IsSuccess)
                    {
                        var student = new Student
                        {
                            Dni = vrDni.ValidatedResult,
                            Name = vrName.ValidatedResult,
                            ChairNumber = vrChair.ValidatedResult
                        };
                        
                        var sr = student.Save();
                        var sr2 = StudentRepository.Add(student);
                        if (sr.IsSuccess && sr2.IsSuccess)
                        {
                            Console.WriteLine($"alumno guardado correctamente");
                        }
                        else
                        {
                            Console.WriteLine($"uno o más errores han ocurrido y el almuno no se guardado correctamente: {sr.AllErrors} {sr2.AllErrors}");
                        }
                    }
                }
                else if (option == "e")
                {
                    Console.WriteLine("escriba el dni del alumno para editar:");
                    var dni = Console.ReadLine();
                    var result = StudentRepository.GetStudentByDni(dni);
                    if (result != null)
                    {
                        #region read name
                        Console.WriteLine("escriba el nombre y apellidos:");
                        var name = Console.ReadLine();

                        if (name == "*")
                            break;

                        ValidationResult<string> vrName;
                        while (!(vrName = Student.ValidateName(name)).IsSuccess)
                        {
                            Console.WriteLine(vrName.AllErrors);
                            name = Console.ReadLine();
                        }
                        #endregion

                        #region read chair number
                        Console.WriteLine("escriba el número de silla:");
                        var chairNumberText = Console.ReadLine();

                        if (chairNumberText == "*")
                            break;

                        ValidationResult<int> vrChair;
                        while (!(vrChair = Student.ValidateChairNumber(chairNumberText)).IsSuccess)
                        {
                            Console.WriteLine(vrChair.AllErrors);
                            chairNumberText = Console.ReadLine();
                        }
                        #endregion
                        if (vrName.IsSuccess && vrChair.IsSuccess)
                        {
                            Student newStudent = new Student
                            {
                                Id = result.Id,
                                Dni = result.Dni,
                                Name = vrName.ValidatedResult,
                                ChairNumber = vrChair.ValidatedResult
                            };
                            StudentRepository.Update(newStudent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay el alumno con este dni!");
                    }
                }
                else if (option == "n")
                {
                    Console.WriteLine("escriba el dni del alumno para ver informacio / * - ver la lista de los todos alumnos:");
                    var dni = Console.ReadLine();
                    if (dni == "*")
                        foreach (KeyValuePair<string, Student> kvp in StudentRepository.GetAllStudents())
                            Console.WriteLine("Dni = {0}, Name = {1}, ChairNumber = {2}", kvp.Key, kvp.Value.Name, kvp.Value.ChairNumber);
                    else
                    {
                        var result = StudentRepository.GetStudentByDni(dni);
                        if (result != null)
                            Console.WriteLine("Dni = {0}, Name = {1}, ChairNumber = {2}", result.Dni, result.Name, result.ChairNumber);

                    }
                }
            }

            ClearCurrentConsoleLine();
            Console.WriteLine();
            ShowMainMenu();
        }

        static void ShowHandleSubjectsMenu()
        {
            CurrentOption = "s";
            Console.WriteLine("Menu de gestionar asignaturas.");
            Console.WriteLine("Opciones: a - para añadir una nueva asignatura");
            Console.WriteLine("Opciones: s - para ver alumnos por asignatura");
            Console.WriteLine("Opciones: e - para ver exámenes de asignatura");
            Console.WriteLine("Presione m para acabar y volver al menú principal");

            while (true)
            {
                var option = Console.ReadLine();

                if (option == "m")
                {
                    break;
                }
                else if (option == "a")
                {
                    Console.WriteLine("Para volver sin guardar asignatura escriba  *.");
                    Console.WriteLine("escriba el nombre:");

                    #region read dni
                    var name = Console.ReadLine();

                    if (name == "*")
                        break;

                    var subject = new Subject
                    {
                        Name = name
                    };

                    while (!subject.Validate().IsSuccess)
                    {
                        Console.WriteLine("el nombre está en formato incorrecto, vuelva a escribirlo");
                        name = Console.ReadLine();
                        if (name == "*")
                            break;
                        subject = new Subject
                        {
                            Name = name
                        };
                    }

                    if (name == "*")
                        break;

                    #endregion             

                    if (subject.Save().IsSuccess)
                    {
                        Console.WriteLine($"asignatura guardada correctamente");
                    }
                    else
                    {
                        Console.WriteLine($"uno o más errores han ocurrido y la asignatura no se ha guardado correctamente");
                    }

                }
                else if (option == "s")
                {
                    Console.WriteLine("escriba el name del subject para ver informacio / * - ver la lista de los todos subjects:");
                    var name = Console.ReadLine();
                    if (name == "*")
                        foreach (KeyValuePair<string, Subject> kvp in SubjectRepository.GetAllSubjects())
                            Console.WriteLine("Dni = {0}, Name = {1}", kvp.Key, kvp.Value.Name);
                    else
                    {
                        var result = SubjectRepository.GetSubjectByName(name);
                        if (result != null)
                            Console.WriteLine("GUID = {0}, Name = {1}", result.Guid, result.Name);

                    }
                }
            }

            ClearCurrentConsoleLine();
            Console.WriteLine();
            ShowMainMenu();
        }
        
        static void ShowAddNotesMenu()
        {
            /*CurrentOption = "n";
            Console.WriteLine("Menu de añadir notas. Añada notas [dni*nombre*nota] y presione al enter");
            Console.WriteLine("Presione m para acabar y volver al menú principal");

            while (true)
            {
                var notaText = Console.ReadLine();

                if (notaText == "m")
                {
                    break;
                }
                else                
                {
                    char[] c1 = { '*' };
                    var spaso = notaText.Split(c1);

                    var dni = spaso[0];
                    var name = spaso[1];
                    var markText = spaso[2].Replace(".", ",");

                    #region Nota
                    //double nota;
                    //if (double.TryParse(markText, out nota))
                    //{
                    //    if (!Marks.ContainsKey(dni))
                    //        Marks.Add(dni, new List<double>());

                    //    Marks[dni].Add(nota);
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"valor introducidio [{notaText}] no válido");
                    //}
                    #endregion

                    #region Name

                    //if (!Students.ContainsKey(dni))
                    //    Students.Add(dni, name);
                    //else if(!string.IsNullOrEmpty(name))
                    ////else if (name != "" && name != null)
                    //    Students[dni] = name;

                    #endregion

                }
            }

            ClearCurrentConsoleLine();
            Console.WriteLine();
            ShowMainMenu();*/
        }

        static void ShowStatisticsMenu()
        {
            /*CurrentOption = "c";

            Console.WriteLine("Opción de Estadísticas");
            Console.WriteLine("Presione m para acabar y volver al menú principal");
            Console.WriteLine("Opciones: avg - obtener la media de las notas de los alumnos");
            Console.WriteLine("Opciones: max - obtener la máxima nota de los alumnos");
            Console.WriteLine("Opciones: max - obtener la mínima nota de los alumnos");

            while (true)
            {
                var optionText = Console.ReadLine();

                if (optionText == "m")
                {
                    break;
                }
                else if (optionText == "avg")
                {
                    ShowAverage();
                }
            }

            ClearCurrentConsoleLine();
            Console.WriteLine();
            ShowMainMenu();*/
        }

        static void ShowAverage()
        {
            //var avg =  Marks.Values
            //                .SelectMany(x => x)
            //                .Where(x => x > 3)
            //                .Average();

            var avg = 0.0;
            Console.WriteLine($"La media actual es: {avg}");
            Console.WriteLine();
        }

        static void ShowMinimum()
        {
            Console.WriteLine("La nota más baja es: ");
            Console.WriteLine();
        }

        static void ShowMaximum()
        {
            Console.WriteLine("La nota más alta es: ");
            Console.WriteLine();
        }     

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        #region Formulas

        public static double GetAverage()
        {
            var sum = 0.0;

            //for (var i = 0; i < Marks.Count; i++)
            //{
            //    sum += Marks[i];
            //}

            //return sum / Marks.Count;
            return sum;
        }


        #endregion
    }
}
