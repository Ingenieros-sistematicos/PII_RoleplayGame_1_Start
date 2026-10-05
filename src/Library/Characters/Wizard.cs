using System;
using System.Collections.Generic;
using Library.Characters;

namespace Library
{
    public class Wizard: Hero
    {
        public SpellBook Spellbook { get; set; }
        public Wizard(string name) : base(name)
        {
            Spellbook = new SpellBook(0, 0, new List<Spell>());
        }
    }
}