using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebApplication.Models
{
    namespace DataAccessPostgreSqlProvider
    {
        // >dotnet ef migration add testMigration in AspNet5MultipleProject
        public class WorkListDbContext : DbContext
        {
            public WorkListDbContext()
            {

                Database.EnsureCreated();
            }

            public WorkListDbContext(DbContextOptions<WorkListDbContext> options) : base(options)
            {
            }

            public DbSet<DbWorkList> WorkLists { get; set; }

            public static string ConnectionString { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(WorkListDbContext.ConnectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }

        public class DbWorkList
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string NameOfCompany { get; set; }
            /// <summary>
            /// Адрес
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// Численность сотрудников
            /// </summary>
            public int Number { get; set; }
            /// <summary>
            /// Категория
            /// </summary>
            public WindowsFormsApp1.Category Category { get; set; }
            /// <summary>
            /// Рабочие
            /// </summary>
            public Collection<DbWorkers> Workers { get; set; }
            /// <summary>
            /// Задачи
            /// </summary>
            public Collection<DbTasks> Tasks { get; set; }
        }

        public class DbTasks
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int WorkListId { get; set; }
            [ForeignKey("WorkListId")]

            public virtual DbWorkList WorkList { get; set; }
            /// <summary>
            /// Наименование задачи
            /// </summary>
            public string NameOfTask { get; set; }
            /// <summary>
            /// Краткие пояснения
            /// </summary>
            public string Explanations { get; set; }
            public override string ToString()
            {
                return $"Наименование задачи: {NameOfTask}, Краткие пояснения: {Explanations}";
            }
        }

        public class DbWorkers
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public int WorkListId { get; set; }
            [ForeignKey("WorkListId")]

            public virtual DbWorkList WorkList { get; set; }
            /// <summary>
            /// Имя
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Должность
            /// </summary>
            public string Position { get; set; }
            /// <summary>
            /// Стаж
            /// </summary>
            public int Experience { get; set; }

            public override string ToString()
            {
                return $"Имя: {Name}, Должность: {Position}, Стаж: {Experience}";
            }
        }
    }
}
