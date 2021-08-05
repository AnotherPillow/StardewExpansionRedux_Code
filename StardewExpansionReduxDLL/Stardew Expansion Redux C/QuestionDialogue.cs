﻿using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewExpansionReduxDLL
{
    //A class to handle the question dialogue more easily
    internal class QuestionDialogue
    {
        //List of answers
        List<QuestionAnswer> ltAnswers;
        //The message that should be displayed
        private string sMessage;
        //The actual list of responses the DialogueBox needs. Is being build automatically by this class
        List<Response> ltResponses;

        //Basic constructor. Just calling this makes the question dialogue pop up
        public QuestionDialogue(string sMessage, List<QuestionAnswer> ltAnswers, int iDelay = 100)
        {
            //Setup
            this.ltAnswers = ltAnswers;
            this.sMessage = sMessage;

            //Builds the responses for the dialogue
            ltResponses = new List<Response>();
            for (int iCounter = 0; iCounter < ltAnswers.Count; iCounter++)
            {
                //Responses are made up out of the string to be displayed and the string the after-dialogue function gets
                ltResponses.Add(new Response(iCounter.ToString(), ltAnswers[iCounter].sKey));
            }

            //After a set moment the question dialogue is being displayed
            DelayedAction.functionAfterDelay(DisplayDialogue, iDelay);
        }

        //The function that actually draws the dialogue
        public void DisplayDialogue()
        {
            //Parameters used here are as following:
            //the question to be displayed, the possible answers, the function that will be called once an answer is being selected
            Game1.player.currentLocation.createQuestionDialogue(sMessage, ltResponses.ToArray(), EvaluateAnswer);
        }

        //The function that is being called after the dialogue ends. Acts as a shell here to just call the function assigned to the answer in ltAnswers
        public void EvaluateAnswer(Farmer csFarmer, string sAnswer)
        {
            QuestionAnswer qa = ltAnswers[Convert.ToInt32(sAnswer)];
            if (qa.fuHandler != null)
            {
                qa.fuHandler();
            }
        }
    }
}
