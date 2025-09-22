using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Jerboa
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int countOfTouches {
            get => _countOfTouches;
            set
            {
                if (value >= 0) 
                    _countOfTouches = value;
            }
        }
        public int countOfFeedings {
            get => _countOfFeedings;
            set
            {
                if (value >= 0) // Защита от отрицательных значений
                    _countOfFeedings = value;
            }
        }
        public int Id { get; set; }
        
        //уникальное айди для каждого, по нему происходит обращение
        private static int _nextId = 1;
        // защищенное колво троганий
        private int _countOfTouches = 0;
        private int _countOfFeedings = 0;

        private static List<Jerboa> _desert = new List<Jerboa> { };

        //создание
        public static Jerboa Make_Jerboa(string name, string color)
        {
            var jerboa = new Jerboa
            {
                
                Name = name,
                Color = color,
                countOfTouches = 0,
                countOfFeedings = 0,
                Id = _nextId++
            };

            _desert.Add(jerboa); 
            return jerboa;

        }

        //показать всех. получение оригинальной пустыни
        public static List<Jerboa> GetDesert() => _desert;

        public static Jerboa GetJerboaById(int id)
        {
            return _desert.FirstOrDefault(j => j.Id == id);
        }

        //удаление
        public static bool Remove_Jerboa(int id)
        {
            var jr = _desert.FirstOrDefault(j => j.Id == id);
            if (jr != null)
            {
                _desert.Remove(jr);
                return true;
            }
            return false;
        }

        //гладить
        public static bool Pet(int id)
        {
            Jerboa jr = GetJerboaById(id);
            if (jr != null) 
            {
                jr.countOfTouches++;
                return true;
            }
            return false;
        }

        //кормить
        public bool Feed(int id)
        {
            Jerboa jr = GetJerboaById(id);
            if (jr != null)
            {
                jr.countOfFeedings++;
                return true;
            }
            return false;
        }
    }
}
