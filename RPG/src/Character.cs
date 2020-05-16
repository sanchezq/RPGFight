using System;
using System.Collections.Generic;
using System.Text;

public abstract class Character
{
    public string name;
    public int InitHP;
    public int HP;
    public int MP;
    public int AP;
    public int DP;
    public int healAmount;
    public int castAmount;
    public float damageTaken;
    public bool attackPriority = true;

    public abstract void Action(Character target);
    public abstract void Attack(Character target);
    public abstract void BehaviorChange();
    public abstract void Healing();

    public delegate void EventHandler(Character mChar);
    public delegate void EventHandler2(Character src, Character target, int damage);
}
