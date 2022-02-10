using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            //Задаем переменные
            string userName1, userName2, corUserName, difficulte, pcGamer;
            int maxThrow, maxScore, difLvl;
            int corScore, inputTrow;
            int moveNumber;
            bool checkHardLvl, checkInputTrow, addPcGamer;
            Random Score = new Random();
            Random Throw = new Random();

            maxScore = 1; // задаем параметр максимального кол-ва очков, после выбора сложности подставится небходимое значение
            maxThrow = 1; // задаем параметр максимальной ставки, после выбора сложности подставится небходимое значение
            moveNumber = 1; // указываем что нумерация ходов начинается с 1го
            corUserName = null;
            userName2 = null;
            addPcGamer = false;
            inputTrow = 0;

            //Запрос выриантов игры с человеком или компьютером
            Console.WriteLine("Вы будите играть один или с другом?");
            Console.WriteLine("Выбереите (1) если будете играть с Компьютером или (2) если с другом.");
            pcGamer = Console.ReadLine();
            checkHardLvl = (pcGamer == "1" || pcGamer == "2") ? true : false;

            while (!checkHardLvl)
            {
                Console.WriteLine("Вы ввели не верное значение, пожалуйста выберите (1) если будете играть с Компьютером или (2) если с другом.");
                pcGamer = Console.ReadLine();
                checkHardLvl = (pcGamer == "1" || pcGamer == "2") ? true : false;
            }

            switch (pcGamer)
            {
                case "1":
                    {
                        addPcGamer = true;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Вы выбрали игру с компьютером");
                        Console.ResetColor();
                        break;
                    }
                case "2":
                    {
                        addPcGamer = false;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Вы выбрали игру с другом");
                        Console.ResetColor();
                        break;
                    }
            }


            //Запрос имен игроков
            Console.WriteLine("Введите имя первого игрока");
            userName1 = Console.ReadLine();
            
            // проверяем кто 2й игрок: человек или компьютер
            if (addPcGamer == true)
            {
                userName2 = "Компьютер";
            }
            if (addPcGamer == false)
            {
                Console.WriteLine("Введите имя второго игрока");
                userName2 = Console.ReadLine();
            }

            //Выводим имена игроков
            Console.WriteLine($"Игроки {userName1} и {userName2} готовы");

            // Запрос уровня сложности
            Console.WriteLine("Выберите сложность: (0) для легкого режима (1) для обычной сложности или (2) для сложного режима");
            Console.WriteLine("(0) Легкий режим - максимальй пул 50, бросок от 1 до 3х");
            Console.WriteLine("(1) Средний режим - максимальй пул 90, бросок от 1 до 4х");
            Console.WriteLine("(2) Сложный режим - максимальй пул 120, бросок от 1 до 5и");
            difficulte = Console.ReadLine();

            // Проверка того что введены нужные значения, т.е. от 0 до 2 (включительно). Цыкл будет повторяться пока не будут нужные значения
            checkHardLvl = (difficulte == "0" || difficulte == "1" || difficulte == "2") ? true : false; // Если введено от 0 до 2х то истина, если что то другое, то лож.
            while (!checkHardLvl)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Печать следующей строки красным цветом
                Console.WriteLine("Выбран не верный уровень сложности");
                Console.ResetColor(); // Сброс параметров печати строк
                Console.WriteLine("Выберите сложность: (0) для легкого режима (1) для обычной сложности или (2) для сложного режима");
                Console.WriteLine("(0) Легкий режим - максимальй пул 50, бросок от 1 до 3х");
                Console.WriteLine("(1) Нормальный режим - максимальй пул 90, бросок от 1 до 4х");
                Console.WriteLine("(2) Сложный режим - максимальй пул 120, бросок от 1 до 5и");
                difficulte = Console.ReadLine();
                checkHardLvl = (difficulte == "0" || difficulte == "1" || difficulte == "2") ? true : false;
            }

            // Выставление игровых параметров по заданой игровой сложности
            difLvl = Convert.ToInt32(difficulte);
            switch (difLvl)
            {
                case 0:
                    maxScore = 51;
                    maxThrow = 3;
                    Console.WriteLine($"Выбрана легкая сложность. Максимальный бросок {maxThrow} и Максимальное значение {maxScore - 1}.");
                    break;
                case 1:
                    maxScore = 91;
                    maxThrow = 4;
                    Console.WriteLine($"Выбрана нормальная сложность. Максимальный бросок {maxThrow} и Максимальное значение {maxScore - 1}.");
                    break;
                case 2:
                    maxScore = 121;
                    maxThrow = 5;
                    Console.WriteLine($"Выбрана максимальная сложность. Максимальный бросок {maxThrow} и Максимальное значение {maxScore - 1}.");
                    break;
            }

            //генерация псевдослучайного числа от 12 до Максимального (зависит от уовня сложности)
            corScore = Score.Next(12, maxScore);
            // Начинается игра до 0
            for (; corScore > 0;)
            {
                // Опеределяется очередность ходов, игрок 2 ходит четным
                if (moveNumber % 2 == 0 && corScore > 0)
                {
                    // если играете с компом то далее все автоматичемки
                    if (addPcGamer == true)
                    {
                        Console.WriteLine($"Текущий счет  - {corScore}"); // озвучиваем текущий счет
                        corUserName = "Компьютер"; // переопеределем текущего игрока
                        Console.ForegroundColor = ConsoleColor.Green ; Console.WriteLine($"Ходит игрок  - {corUserName}"); Console.ResetColor();
                        inputTrow = Throw.Next(1, maxThrow + 1);
                    }
                    // если играете с 2м игроком, то необходимо проверить вводимые данные
                    if (addPcGamer == false)
                    {
                        Console.WriteLine($"Текущий счет  - {corScore}"); // озвучиваем текущий счет
                        corUserName = userName2; // переопеределем текущего игрока
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"Ходит игрок  - {corUserName}"); Console.ResetColor();
                        Console.WriteLine($"Какой ваш ход (от 1 до {maxThrow})");
                        inputTrow = Console.ReadKey(true).KeyChar - 48; // опрелеляем какая клавиша нажата

                        // сравниаем попадает ли нажатая клавиша в доступный диапозон значений по уровню сложности игры
                        checkInputTrow = (inputTrow < 1 || inputTrow > maxThrow) ? false : true; 
                        while (!checkInputTrow)
                        {
                            Console.WriteLine($"Вы вели не корректное значение");
                            inputTrow = Console.ReadKey(true).KeyChar - 48;
                            checkInputTrow = (inputTrow < 1 || inputTrow > maxThrow) ? false : true;
                        }
                    }

                    // выводим значение броска игрока
                    Console.WriteLine($"Игрок {corUserName} ввел значение {inputTrow}");
                    //изменяем значение текущего счет на зачение броска игрока
                    corScore -= inputTrow;
                    //увеличиваем номер хода на 1, тем самым передавая ход другому игроку.
                    moveNumber++;
                }
                // Опеределяется очередность ходов, игрок 1 ходит по нечетным ходам: на первой, третий, пятый и тд. ход
                if (moveNumber % 2 == 1 && corScore > 0)
                {
                    Console.WriteLine($"Текущий счет  - {corScore}"); // озвучиваем текущий счет
                    corUserName = userName1; // переопеределем текущего игрока
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"Ходит игрок  - {corUserName}"); Console.ResetColor();
                    Console.WriteLine($"Какой ваш ход (от 1 до {maxThrow})");
                    inputTrow = Console.ReadKey(true).KeyChar - 48; // опрелеляем какая клавиша нажата

                    // сравниаем попадает ли нажатая клавиша в доступный диапозон значений по уровню сложности игры
                    checkInputTrow = (inputTrow < 1 || inputTrow >  maxThrow) ? false : true;
                    while (!checkInputTrow)
                    {
                        Console.WriteLine($"Вы вели не корректное значение");
                        inputTrow = Console.ReadKey(true).KeyChar - 48;
                        checkInputTrow = (inputTrow < 1 || inputTrow > maxThrow) ? false : true;
                    }

                    // выводим значение броска игрока
                    Console.WriteLine($"Игрок {corUserName} ввел значение {inputTrow}");
                    //изменяем значение текущего счет на зачение броска игрока
                    corScore -= inputTrow;
                    //увеличиваем номер хода на 1, тем самым передавая ход другому игроку.
                    moveNumber++;

                }
            }
              // как только Значение очков перестало быть положительным, победителем объявляется последний игрок
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Выиграл игрок  - {corUserName}"); Console.ResetColor();
            Console.ReadKey();
               
        }
    }
}
