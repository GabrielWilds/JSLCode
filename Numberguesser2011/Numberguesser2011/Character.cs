using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arena;
using Utility;

namespace Numberguesser2011
{
    abstract class Character
    {

        //Str Attack damage, chance to stun on strong attack
        //Def Resistance to damage, chance to counter (a counter does half natural damage, possibility for status effect based on str/dex)
        //Dex Chance to hit, chance to ignore def on fast attack
        //Spd Chance to dodge, chance to resist fast attack, speed of AT gain
        //Sta Max HP, resistance to stun
        //Range 10 to 100, maybe? or some sort of exponential scale? Or higher base values and diminishing returns?
        //Dynamic. This will only run when the Character is initialized... think about it later
        protected int _AT = 0;              //increments by _speed value per tick in Fight (maybe adjusted, spd 1 guys having TEN TIMES less turns than spd 10 guys would be ridiculous. Ideally: Out of every 10 actions a 1 spd guy gets 1 extra one, 10 spd guy gets 10 extra actions), reduced by action costs, effects chance to flee, max value of 100;

        

        public Character(string name, int money, int level, int str, int def, int dex, int spd, int sta, int XP)
        {
            this.Name = name;
            this.Money = money;
            this.Level = level;
            this.Strength = str;
            this.Defense = def;
            this.Dexterity = dex;
            this.Speed = spd;
            this.Stamina = sta;
            this.MaxHP = sta * 4;
            this.XP = XP;
            this.HP = this.MaxHP;           
        }

        public int Level
        {
            get;
            protected set;
        }

        public String Name
        {
            get;
            protected set;
        }

        public int Money
        {
            get;
            protected set;
        }

        public int Strength
        {
            get;
            protected set;
        }

        public int Defense
        {
            get;
            protected set;
        }

        public int Dexterity
        {
            get;
            protected set;
        }

        public int Speed
        {
            get;
            protected set;
        }

        public int Stamina
        {
            get;
            protected set;
        }

        public Team Team
        {
            get;
            set;
        }

        public int MaxHP
        {
            get;
            protected set;
        }

        public int HP //no check for breaching max HP if healing/buffing. Maybe check that directly in the heal/buff effect, reduce value before calling Property
        {
            get;
            protected set;
        }

        public int AT
        {
            get { return _AT; }
            protected set { _AT = value; }
        }

        public int XP
        {
            get;
            set;
        }

        public bool IsDead
        {
            get;
            set;
        }

        public int IncrementAT()
        {
            this.AT = this.AT + this.Speed;
            if (this.AT > 100)
                this.AT = 100;
            return this.AT;
        }

        public void Heal(int healAmount)
        {
            if (healAmount > this.MaxHP - this.HP)
                this.HP = this.MaxHP;
            else
                this.HP = this.HP + healAmount;
        }


        public abstract void TakeTurn(FightState state);

        public void Attack(Character target, FightState status)
        {
            DamageInfo damage = new DamageInfo();

            _AT = _AT - 40;
            damage.Attacker = this;
            damage.Damage = (this.Strength * 5) + Randomizer.RandomNumber(10);

            Console.WriteLine();
            target.TakeDamage(this, damage);
        }


        public void TakeDamage(Character attacker, DamageInfo attack)
        {
            double dodgeChance = (this.Speed / (attacker.Dexterity / 1.5));
            if (dodgeChance < 1)
                dodgeChance = 1;
            if (Randomizer.RandomNumber(100) < dodgeChance * 5)
                Console.WriteLine(attacker.Name + "'s attack misses " + this.Name);
            else
            {
                attack.Damage = attack.Damage / this.Defense;
                Console.WriteLine(attacker.Name + " deals " + attack.Damage + " damage to " + this.Name);
                this.HP = this.HP - attack.Damage;
                Console.WriteLine(this.Name + " is at " + this.HP + " remaining health");
                if (this.HP < 1)
                    Console.WriteLine(this.Name + " dies!");
            }

        }


        public NewLinked<Team> GetTargets(FightState state)
        {
            NewLinked<Team> targets = new NewLinked<Team>();
            Team[] teams = state.GetTeams;

            for (int i = 0; i < teams.Length; i++)
                if (teams[i].TeamName != this.Team.TeamName && !teams[i].IsDead)
                    targets.Add(teams[i]);

            return targets;
        }

    }
}
