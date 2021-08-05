using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using PyTK.Extensions;
using PyTK.Types;
using Microsoft.Xna.Framework;

namespace StardewExpansionReduxDLL
{
    public class ModEntry : Mod
    {
        //This is what the ModEntry is for, to be the entry to your mod ^^
        //So here should be (only) the entry method and events you add in the entry method
        public override void Entry(IModHelper helper)
        {
            new TileAction("TSVFixMinecart1", FixMinecart.FixMinecart1).register();
        
        }
    }
    class FixMinecart
    {

        internal static void TSVFixMinecart1()
        {
            if (Game1.player.hasOrWillReceiveMail("8968.Minecart1"))
            {
                Game1.drawObjectDialogue("You already fixed this minecart");
            }
            else if (Game1.player.Money < 10000)
            {
                Game1.drawObjectDialogue("Not enough gold.");
            }
            else
            {
                Game1.player.Money -= 10000;
                Game1.player.mailReceived.Add("8968.Minecart1");
                Game1.drawObjectDialogue("Minecart is being fixed, please return soon.");
            }
        }

        internal static bool FixMinecart1(string arg1, GameLocation arg2, Vector2 arg3, string arg4)
        {
            //Creating the list of possible answers with the functions that should be called when the answer left of them is being selected
            List<QuestionAnswer> ltAnswers = new List<QuestionAnswer>()
            {
                new QuestionAnswer("Fix minecart Number 1 for 10000G", TSVFixMinecart1),
                new QuestionAnswer("Don't fix minecart", null)
            };

            // Calls the QuestionDialogue and thus displays the question dialogue, with the given answers
            new QuestionDialogue("This minecart seems broken, would you like to fix it for 10000G?", ltAnswers);

            //why just return true? If its not needed delete the line and change the bool into void :D
            return true;
        }
    }
}
