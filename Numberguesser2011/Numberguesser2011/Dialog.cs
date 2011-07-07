using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Numberguesser2011
{
    class Dialog
    {

        public void Mingle()
        {
            String[] charNouns = { "Gambler", "Waitress", "Old Man", "Old Lady", "Little Kid", "Stranger", "Mutoid scavenger", "Talking Dog" };
            String[] charAdjectives = { "Strange", "Wizened", "Hyperactive", "Menacing", "Lucky", "Filthy", "Ugly", "Far out" };
            String[] talkVerbs = { "shouted", "spoke", "whispered", "hollered", "screamed", "joked", "informed", "said" };
            String[] talkAdjectives = { "excitedly", "softly", "bravely", "menacingly", "interestingly", "quietly", "loudly", "stupidly" };
            String[] statements = { "Try the Black Jack! If you're good you can make a lot of money!", "The big guys are weaker to fast attacks, they aren't very quick to respond.", "The little guys are fast, but stunned they're extremely weak.", "You can buy new equipment or train at the Store.", "Boy, I miss the internet. Don't you?", "We've yet to master the technology of word wrap.", "Ain't got nothing to say to the likes of you.", "Lol, butts." };
            Console.WriteLine("A " + charAdjectives[Randomizer.RandomNumber(charAdjectives.Length)] + " " + charNouns[Randomizer.RandomNumber(charNouns.Length)] + " " + talkAdjectives[Randomizer.RandomNumber(talkAdjectives.Length)] + " " + talkVerbs[Randomizer.RandomNumber(talkVerbs.Length)] + " to you: " + statements[Randomizer.RandomNumber(statements.Length)]);
            Console.ReadKey();
        }

    }
}
