﻿using Academy.Lib.DAL;
using Academy.Lib.DAL.Repositories;
using Academy.Lib.Models;
using Academy.Lib.Repositories;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_New.DbContextFactory;

namespace WebApplication_New.Boot
{
    public class Bootstrapper
    {
        public IDependencyContainer Init()
        {
            var depCon = new SimpleDependencyContainer();

            RegisterRepositories(depCon);

            Entity.DepCon = depCon;

            return depCon;
        }

        public void RegisterRepositories(IDependencyContainer depCon)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new StudentsRepository(GetDbConstructor());
            });


            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Subject>(GetDbConstructor());
            });

            var examsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Exam>(GetDbConstructor());
            });

            //var studentSubjectRepoBuilder = new Func<object[], object>((parameters) =>
            //{
            //    return new EfCoreRepository<StudentSubject>(GetDbConstructor());
            //});

            //var studentsExamsRepoBuilder = new Func<object[], object>((parameters) =>
            //{
            //    return new EfCoreRepository<StudentExam>(GetDbConstructor());
            //});


            depCon.Register<IRepository<Student>, StudentsRepository>(studentRepoBuilder);
            depCon.Register<IStudentsRepository, StudentsRepository>((parameters) => new StudentsRepository(GetDbConstructor()));

            depCon.Register<IRepository<Subject>, EfCoreRepository<Subject>>(subjectsRepoBuilder);
            depCon.Register<IRepository<Exam>, EfCoreRepository<Exam>>(examsRepoBuilder);
            //depCon.Register<IRepository<StudentSubject>, EfCoreRepository<StudentSubject>>(studentSubjectRepoBuilder);
            //depCon.Register<IRepository<StudentExam>, EfCoreRepository<StudentExam>>(studentsExamsRepoBuilder);
        }

        private static AcademyDbContext GetDbConstructor()
        {
            var factory = new AcademyDbContextFactory();
            return factory.CreateDbContext(null);
        }
    }
}
