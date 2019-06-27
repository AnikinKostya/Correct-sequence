using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введите последовательность скобок: ");
            var s = Console.ReadLine(); // добавляем ввод скобок с консоли
            var checker = new BracketsChecker(); // создаем и присваиваем нашу главную функцию

            foreach (var ch in s) // передаем каждый элемент введеного массива
                checker.Put(ch); // и добавляем в функцию
            
            Console.WriteLine(checker.Balanced);
            Console.ReadLine();
        }
            


         class BracketsChecker
        {
            private readonly string _opening = "([{";
            private readonly string _closing = ")]}";

            private bool _cantBeBalanced;

            private Stack<int> _opened = new Stack<int>();

            public bool Balanced => !_cantBeBalanced && !_opened.Any(); // баланс сохраняется, пока все элементы удовлетворяют условию 

            public void Put(char ch)
            {
                if (_cantBeBalanced) return;

                int index = _opening.IndexOf(ch); // ищем открывающие скобки

                if (index != -1) // если не находим
                {
                    _opened.Push(index); // Пушим их в начало
                    return;
                }

                index = _closing.IndexOf(ch); // тоже самое проделываем с закрывающими

                if (index != -1) // если не находим
                {
                    if (!_opened.Any() || _opened.Peek() != index) // проверяем наличие открывающих
                    {
                        _cantBeBalanced = true;
                        _opened.Clear();
                        _opened.TrimExcess();
                        return;
                    }

                    _opened.Pop();
                    return;
                }
            }
               
          }
    }
}
