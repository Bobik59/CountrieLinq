using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrieLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Task1 = new Menu("Task 1", new List<IMenuItem>
            {
                new Subtask1(),
                new Subtask2()
            });

            var Task2 = new Menu("Task 2", new List<IMenuItem>
            {
                new Task2.Subtask1(),
                new Task2.Subtask2(),
                new Task2.Subtask3(),
                new Task2.Subtask4(),
                new Task2.Subtask5(),
                new Task2.Subtask6(),
                new Task2.Subtask7(),
            });

            var Task3 = new Menu("Task 3", new List<IMenuItem>
            {
                new Task3.Subtask1(),
                new Task3.Subtask2(),
                new Task3.Subtask3(),
                new Task3.Subtask4(),
            });

            var Task4 = new Menu("Task 4", new List<IMenuItem>
            {
                new Task4.Subtask1(),
                new Task4.Subtask2(),
                new Task4.Subtask3(),
                new Task4.Subtask4(),
                new Task4.Subtask5(),
                new Task4.Subtask6(),
                new Task4.Subtask7(),
                new Task4.Subtask8(),
                new Task4.Subtask9(),
                new Task4.Subtask10(),
            });

            var mainMenu = new Menu("Task", new List<IMenuItem>
            {
                Task1,
                Task2,
                Task3,
                Task4
            });
            mainMenu.Execute();
        }
    }
}
