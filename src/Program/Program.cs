//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Library;

namespace Ucu.Poo.RolePlayGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Knight knight = new Knight("Arturo");

            // Staff sí implementa IItems en tu proyecto.
            Staff staff = new Staff(20, 10);
            knight.AddItem(staff);

            Check("Equipar un item", 1, knight.Items.Count);

            // Ataque 30 - defensa 10 = daño 20.
            knight.ReceiveAttack(30);
            Check("Recibir daño", 80, knight.Health);

            // La defensa supera al ataque: no pierde vida.
            knight.ReceiveAttack(5);
            Check("Bloquear un ataque", 80, knight.Health);

            knight.Cure();
            Check("Curarse", 100, knight.Health);

            knight.ReceiveAttack(500);
            Check("La vida no baja de cero", 0, knight.Health);

            List<Spell> spells = new List<Spell>();
            spells.Add(new Spell(20, 5));

            SpellBook book = new SpellBook(0, 0, spells);

            // Esta prueba detecta un error en SpellBook.
            Check("Ataque del libro", 20, book.AttackValue);
            Check("Defensa del libro", 5, book.DefenseValue);

            book.AddSpell(new Spell(10, 3));

            // Estas pruebas detectan que no se recalculan los totales.
            Check("Ataque al agregar hechizo", 30, book.AttackValue);
            Check("Defensa al agregar hechizo", 8, book.DefenseValue);
        }

        private static void Check(
            string name, int expected, int actual)
        {
            string result = expected == actual ? "OK" : "ERROR";

            Console.WriteLine(
                $"{result}: {name}. Esperado: {expected}; obtenido: {actual}");
        }
    }
}