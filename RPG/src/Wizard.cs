using System;
using System.Collections.Generic;
using System.Text;

public class Wizard : Character
{
    public float spellDamage;
    public Wizard(string mName)
    {
        name = mName;
        InitHP = 100;
        HP = InitHP;
        MP = 50;
        AP = 8;
        DP = 8;
        healAmount = 30;
        castAmount = 5;
        spellDamage = 20f;
        damageTaken = 1f;
    }
    public override void Action(Character target)
    {
        if (attackPriority == true && MP - castAmount < 0f)
        {
            BehaviorChange();
        }

        if (HP < InitHP * 0.25f && MP - castAmount >= 0f)
        {
            Healing();
        }
        else
        {
            Attack(target);
        }
    }
    public override void BehaviorChange()
    {
        attackPriority = !attackPriority;

        if (OnBehaviorChange != null)
            OnBehaviorChange(this);
    }
    public override void Healing()
    {
        HP += healAmount;
        MP -= 5;

        if (OnHealing != null)
            OnHealing(this);
    }
    public override void Attack(Character target)
    {
        int damage;
        Random rnd = new Random();

        if (attackPriority)
        {
            damage = (int)((spellDamage + rnd.Next(0, (int)(spellDamage*.5f))) * target.damageTaken);
            MP -= 5;
            if (OnSpell != null)
                OnSpell(this, target, damage);
        }
        else
        {
            damage = (int)((Math.Max((AP + rnd.Next((int)AP)) - (target.DP + rnd.Next((int)target.DP)), 0)) * target.damageTaken);
            if (OnAttack != null)
                OnAttack(this, target, damage);
        }

        target.HP -= damage;
       
    }
    public event EventHandler2 OnAttack;
    public event EventHandler2 OnSpell;
    public event EventHandler OnHealing;
    public event EventHandler OnBehaviorChange;
}