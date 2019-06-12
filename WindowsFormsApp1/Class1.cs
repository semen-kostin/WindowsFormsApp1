using System.Collections.Generic;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Данные о рабочих
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// Наименование
        /// </summary>
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
        public Category Category { get; set; }
        /// <summary>
        /// Рабочие
        /// </summary>
        public List<Workers> Workers { get; set; }
        /// <summary>
        /// Задачи
        /// </summary>
        public List<Tasks> Tasks { get; set; }
    }

    /// <summary>
    /// Категория
    /// </summary>
    public enum Category
    {
        ///  <summary>
        /// Металлургия
        /// </summary>
        Metallurgy,
        /// <summary>
        /// Администрация
        /// </summary>
        Administration,
        /// <summary>
        /// Инженерия
        /// </summary>
        Engineering,
        /// <summary>
        /// Ядерная область
        /// </summary>
        NuclearIndustry,
        /// <summary>
        /// Научная область
        /// </summary>
        ScientificActivity
    }

    /// <summary>
    /// Список рабочих
    /// </summary>
    public class Workers
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Стаж работы
        /// </summary>
        public int Experience { get; set; }
        public override string ToString()
        {
            return $"ФИО: {Name}, Должность: {Position}, Стаж работы: {Experience}";
        }
    }

    /// <summary>
    /// Задача
    /// </summary>
    public class Tasks
    {
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
}
