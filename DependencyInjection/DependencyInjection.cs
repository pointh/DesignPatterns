﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Validators;

namespace DependencyInjection
{
    // Client class
    class Osoba
    {
        IIntValidator vekValidator;
        IStringValidator surnameValidator;
        public string Jmeno { get; set; }
        public int Vek { get; set; }

        // Osoba je závislá na validátorech
        // závislost je injektovaná v konstruktoru
        public Osoba(IIntValidator iv, IStringValidator sv)
        {
            vekValidator = iv; surnameValidator = sv;
        }

        public Osoba() { vekValidator = null; surnameValidator = null; }

        public void ConsoleInput()
        {
            Osoba o = new Osoba();

            bool nameOK = false;
            bool vekOK = false;
            int vek;

            do
            {
                Console.Write("Příjmení: ");
                string s = Console.ReadLine();
                if (s == string.Empty) return;
                if (nameOK = surnameValidator.IsValid(s))
                {
                    this.Jmeno = s;
                }
            }
            while (nameOK == false);

            do
            {
                Console.Write("Věk: ");
                string s = Console.ReadLine();
                if (s == string.Empty) return;
                if(vekOK = vekValidator.IsValid(s, out vek))
                {
                    this.Vek = vek;
                }
            } while (vekOK == false);
        }

        public override string ToString()
        {
            return $"{Jmeno}:{Vek}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // všechny osoby mimo Japonců
            // závislosti injektované v konstruktoru
            Osoba o = new Osoba(new AgeValidator(), new SurnameValidator());
            o.ConsoleInput();

            // Japonci to mají jinak
            // závislosti injektované v konstruktoru
            Osoba j = new Osoba(new JapanAgeValidator(), new JapanSurnameValidator());
            j.ConsoleInput();

            Console.WriteLine("========================================");

            Console.WriteLine(o);
            Console.WriteLine(j);

            Console.ReadLine();
        }
    }
}
