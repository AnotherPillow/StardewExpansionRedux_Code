using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewExpansionReduxDLL
{
    //One file for each class makes everything far more readable :D
    // + QuestionAnswer shouldnt be in the class ModEntry cuz then youd always have to call ModEntry.QuestionAnswer when you use it elsewhere (i think)
    internal class QuestionAnswer
    {
        // The answer key provided to the game.
        public string sKey { get; }

        // Handles the answer when the player chooses it.
        public Action fuHandler { get; }

        // Construct an instance.
        // "sKey" The answer key provided to the game.
        // "fuHandler" Handles the answer when the player chooses it.
        public QuestionAnswer(string sKey, Action fuHandler)
        {
            this.sKey = sKey;
            this.fuHandler = fuHandler;
        }
    }
}
