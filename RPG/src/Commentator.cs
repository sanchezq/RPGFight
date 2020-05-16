using System;
using System.Collections.Generic;
using System.Text;

class Commentator
{
    public void Link(Warrior warrior)
    {
        warrior.OnAttack += AttackWarrior;
        warrior.OnBehaviorChange += BehaviorChangeWarrior;
        warrior.OnHealing += HealingWarrior;
    }
    public void Link(Wizard wizard)
    {
        wizard.OnAttack += AttackWizard;
        wizard.OnSpell += SpellWizard;
        wizard.OnBehaviorChange += BehaviorChangeWizard;
        wizard.OnHealing += HealingWizard;
    }

    private void AttackWarrior(Character src, Character target, int damage)
    {
        if (src.attackPriority)
        {
            Console.Write(src.name + " slices " + target.name + " with his sword.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[-" + damage + "HP]\n");
        }
        else
        {
            Console.Write(src.name + " throws his shield at " + target.name + ".");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[-" + damage + "HP]\n");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    private void BehaviorChangeWarrior(Character src)
    {
        if (src.attackPriority)
        {
            Console.WriteLine(src.name + " gets his sword back.");
        }
        else
        {
            Console.WriteLine(src.name + " hides behind his shield.");
        }
    }
    private void HealingWarrior(Character src)
    {
        Console.Write(src.name + " drinks a potion.");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("[+" + src.healAmount + "HP]\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private void AttackWizard(Character src, Character target, int damage)
    {
        Console.Write(src.name + " cuts " + target.name + " in half.");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("[-" + damage + "HP]\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    private void SpellWizard(Character src, Character target, int damage)
    {
        Console.Write(src.name + " casts a fireball and burns " + target.name + ".");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("[-" + damage + "HP]");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("[-" + src.castAmount + "MP]\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    private void BehaviorChangeWizard(Character src)
    {
        Console.WriteLine(src.name + " cannot use spells anymore.");
    }
    private void HealingWizard(Character src)
    {
        Console.Write(src.name + " heals himself.");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("[+" + src.healAmount + "HP]");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("[-" + src.castAmount + "MP]\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

}
