//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using Library;
using Library.Characters;

namespace Ucu.Poo.RolePlayGame
{
    public static class Program
    {
        public static void Main()
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
            Check("Curarse", 90, knight.Health);

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

            knight.AddVP(5);

            Check("Agregar VP", 6, knight.Vp);
            // El enemigo ataca primero por 10 y el héroe lo derrota con un ataque de 100.
            Knight encounterKnight = new Knight("Caballero del encuentro");
            encounterKnight.AddItem(new Staff(100, 0));

            BadBoys enemy = new BadBoys("Enemigo del encuentro");
            enemy.Items.Add(new Staff(10, 0));
            enemy.SetVP(5);

            List<Hero> heroes = new List<Hero> { encounterKnight };
            List<BadBoys> enemies = new List<BadBoys> { enemy };
            encounterKnight.DoEncounter(heroes, enemies);

            Check("Vida del héroe después del encuentro", 100, encounterKnight.Health);
            Check("Enemigo derrotado", 0, enemy.Health);
            Check("Héroes restantes", 1, heroes.Count);
            Check("Enemigos restantes", 0, enemies.Count);
            Check("VP por derrotar al enemigo", 6, encounterKnight.Vp);
            // Un héroe derrotado no debe contraatacar ni provocar una división por cero.
            Knight defeatedKnight = new Knight("Héroe derrotado");
            defeatedKnight.AddItem(new Staff(100, 0));
            BadBoys strongEnemy = new BadBoys("Enemigo fuerte");
            strongEnemy.Items.Add(new Staff(100, 0));
            List<Hero> defeatedHeroes = new List<Hero> { defeatedKnight };
            List<BadBoys> winningEnemies = new List<BadBoys> { strongEnemy };
            defeatedKnight.DoEncounter(defeatedHeroes, winningEnemies);
            Check("Héroe derrotado eliminado", 0, defeatedHeroes.Count);
            Check("El héroe derrotado no contraataca", 100, strongEnemy.Health);

            // Eliminar un enemigo no debe saltarse al siguiente ni confundir sus VP.
            Knight victoriousKnight = new Knight("Héroe victorioso");
            victoriousKnight.AddItem(new Staff(100, 0));
            BadBoys firstEnemy = new BadBoys("Primer enemigo");
            firstEnemy.SetVP(5);
            BadBoys secondEnemy = new BadBoys("Segundo enemigo");
            secondEnemy.SetVP(7);
            List<Hero> winningHeroes = new List<Hero> { victoriousKnight };
            List<BadBoys> multipleEnemies = new List<BadBoys> { firstEnemy, secondEnemy };
            victoriousKnight.DoEncounter(winningHeroes, multipleEnemies);
            Check("Todos los enemigos eliminados", 0, multipleEnemies.Count);
            Check("VP de ambos enemigos", 13, victoriousKnight.Vp);

            // Un encuentro con un equipo vacío termina sin atacar.
            victoriousKnight.DoEncounter(new List<Hero>(), winningEnemies);
            victoriousKnight.DoEncounter(winningHeroes, new List<BadBoys>());
            Check("Equipo vacío: enemigo sin daño", 100, strongEnemy.Health);
            Check("Equipo vacío: héroe sin daño", 100, victoriousKnight.Health);

            // Si nadie puede causar daño, el encuentro termina sin cambiar la vida.
            Knight unarmedKnight = new Knight("Héroe sin armas");
            BadBoys unarmedEnemy = new BadBoys("Enemigo sin armas");
            unarmedKnight.DoEncounter(
                new List<Hero> { unarmedKnight }, new List<BadBoys> { unarmedEnemy });
            Check("Sin daño: vida del héroe", 100, unarmedKnight.Health);
            Check("Sin daño: vida del enemigo", 100, unarmedEnemy.Health);
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