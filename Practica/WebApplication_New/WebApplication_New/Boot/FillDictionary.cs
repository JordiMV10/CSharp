﻿using Academy.Lib.Models;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_New.Boot
{
    public class FillDictionary
    {
        public FillDictionary()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            ////var count = repo.QueryAll().ToList().Count();
            var count = 0;
            if (count < 3)
            {
                Student newStudent = new Student { Name = "Eugene", Dni = "123", ChairNumber = 5, Email = "eugene" };
                newStudent.Save();
            //    Subject newStudent2 = new Subject { Name = "Fisica", Teacher = "Marta" };
            //    newStudent2.Save();
            //    Subject newStudent3 = new Subject { Name = "Music", Teacher = "Marta" };
            //    newStudent3.Save();
            }

            //var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
            ////var count = repo.QueryAll().ToList().Count();
            //var count = 0;
            //if (count < 3)
            //{
            //    Subject newStudent = new Subject { Name = "Maths", Teacher = "Marta" };
            //    newStudent.Save();
            //    Subject newStudent2 = new Subject { Name = "Fisica", Teacher = "Marta" };
            //    newStudent2.Save();
            //    Subject newStudent3 = new Subject { Name = "Music", Teacher = "Marta" };
            //    newStudent3.Save();
            //}
            //if (count > 3)
            //{
            //    var students = repo.QueryAll().ToList();
            //    for (var i=3; i<students.Count(); i++)
            //    {
            //        students[i].Delete();
            //    }
            //}
        }

    }
}
