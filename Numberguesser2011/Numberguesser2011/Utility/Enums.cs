using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    enum Rank { Ace=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

    enum Suit { Diamond, Club, Spade, Heart };

    [Flags]
    enum NegStatus { Poisoned = 1, Sleep = 2, Confused = 4, Slowed = 8, Enfeebled = 16, Stunned = 32, Fled = 64, Dead = 128};
    enum PosStatus { Overheal = 1, Hasted = 2, Regen = 4, Prepared = 8, Strengthened = 16, Hidden = 32, Invulnerable = 64, DeathProtection = 128};
}
