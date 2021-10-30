using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Predictive_Solutions
{
    class CreatingUser
    {
        public User Create(string line, int index)
        {
            var userName = GetName(line);
            ValidationName(userName);

            var phone = GetPhoneNumber(line);
            phone = ValidationPhone(phone);
            return new User(index, userName[0], userName[1], userName[2], phone);
        }

        private List<string> GetName(string line)
        {
            return Regex.Matches(line, @"[А-Яа-яёЁ]+").Select(x => x.Value).ToList();     
        }
        
        private string GetPhoneNumber(string line)
        {
            return Regex.Replace(line, @"[^\d]", "");
        }

        private void ValidationName(List<string> lName)
        {
            foreach(var name in lName)
                if(name.Length<2 || name.Length>50)
                    throw new Exception("При распозновании ФИО произошла ошибка \"имя не может быть короче 2 и больше 50 символов\"");
            if (lName.Count < 2)
                throw new Exception("При распозновании ФИО произошла ошибка \"не удаловсь найти фамилию\"");
            else if (lName.Count < 3)
                lName.Add("");
        }

        private string ValidationPhone(string phone)
        {
            if (phone.Length == 11)
                if (phone[0] == '8')
                {
                    StringBuilder StrB = new StringBuilder(phone);
                    StrB[0] = '7';
                    phone = StrB.ToString();
                }
                else if (phone[0] == '7') { }
                else
                {
                    throw new Exception("При распозновании номера произошла ошибка \"номер должен начинаться с 7 или 8 или же без первой цифры\"");
                }
            else if (phone.Length == 10)
                phone.Append('7');
            else
                throw new Exception("При распозновании номера произошла ошибка \"номер должен состоять из 10-11 цифр\"");
            return phone;
        }
    }
}
