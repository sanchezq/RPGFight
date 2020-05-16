using System;
using System.Collections.Generic;
using System.Text;

public class Warrior : Character
{
    public int potions;
    public Warrior(string mName)
    {
        name = mName;
        InitHP = 200;
        HP = InitHP;
        MP = 0;
        AP = 15;
        DP = 10;
        healAmount = 20;
        castAmount = 0;
        damageTaken = 1f;
        potions = 2;
    }

    public override void Action(Character target)
    { 
        if(HP < InitHP * 0.25f && potions > 0)
        {
            Healing();
        }

        if(attackPriority == true && HP < InitHP * 0.5f && target.MP - (float)target.castAmount >= 0f)
        {
            BehaviorChange();
        }
        else if(attackPriority == false && (HP >= InitHP * 0.5f || target.MP - (float)target.castAmount < 0f))
        {
            BehaviorChange();
        }

        Attack(target);
    }
    public override void BehaviorChange()
    {
        if(attackPriority)
        {
            damageTaken = .5f;
        }
        else
        {
            damageTaken = 1f;
        }
        attackPriority = !attackPriority;

        if (OnBehaviorChange != null)
            OnBehaviorChange(this);

    }
    public override void Healing()
    {
        potions--;
        HP += healAmount;

        if (OnHealing != null)
            OnHealing(this);
    }
    public override void Attack(Character target)
    {
        Random rnd = new Random();

        float attack = AP;

        if(!attackPriority)
        {
            attack *= .5f;
        }

        int damage = (int)((Math.Max((attack + rnd.Next((int)attack)) - (target.DP + rnd.Next((int)target.DP)), 0)) * target.damageTaken);
        target.HP -= damage;

        if (OnAttack != null)
            OnAttack(this, target, damage);
    }
    public event EventHandler2 OnAttack;
    public event EventHandler OnHealing;
    public event EventHandler OnBehaviorChange;
}