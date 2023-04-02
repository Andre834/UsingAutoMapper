using AutoMapper;
using System;

namespace UsingAutoMapper
{
    /*
     *Como sabemos, se o nome da propriedade de dados for diferente para as classes de origem e destino,
     *o AutoMapper em C# não poderá mapear essas propriedades por padrão. No entanto, 
     *usando a opção ForMember, podemos mapear entre as propriedades de nomes diferentes.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>

             cfg.CreateMap<Student, StudentDT>()
               .ForMember(dest => dest.Fullname, act => act.MapFrom(src => src.Name))// permite mapear propriedades com nomes diferentes

            );

            Student stu = new Student

            {

                Name = "ShivamFullName",

                Age = 20,

                Address = "Bihar",

                Department = "IT"

            };


            //Using AutoMapper

            var mapper = new Mapper(config);

            var stuDT = mapper.Map<StudentDT>(stu);

            //OR another way of initializing AutoMapper.

            //var stuDT2 = mapper.Map<Student, StudentDT>(stu);

            //on running this , it will give us the output as expected

            Console.WriteLine("Name:" + stuDT.Fullname + ", Age:" + stuDT.Age + ", Address:" + stuDT.Address + ", Department:" + stuDT.Department);

            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
