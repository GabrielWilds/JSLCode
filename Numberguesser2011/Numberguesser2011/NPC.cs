using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using System.Threading;

namespace Numberguesser2011
{
    class NPC : Character
    {
        public NPC(string name, int money, int level, int str, int def, int dex, int spd, int sta, int XP)
            : base(name, money, level, str, def, dex, spd, sta, XP)
        {
        }

        public override void TakeTurn(Arena.FightState state)
        {
            NewLinked<Team> enemyTeams = GetTargets(state);
            Team targetTeam = enemyTeams.Get(Randomizer.RandomNumber(enemyTeams.Length));
            Utility.NewLinked<Character> targets = new Utility.NewLinked<Character>();
            for (int i = 0; i < targetTeam.Members.Length; i++)
                if (!targetTeam.Members[i].IsDead)
                    targets.Add(targetTeam.Members[i]);
            Character target = targets.Get(Randomizer.RandomNumber(targets.Length));
            Attack(target, state);
            if (target is Player)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
