﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        public int GameScore { get; set; }

        public int Pins { get; set; }


        public Game()
        {
            GameScore = 0;
        }

        public int Score()
        {
            return GameScore;
        }

        public int Throw(int rolledPins)
        {
            Pins = rolledPins;
            GameScore += Pins;

            return Pins;
        }

        int[] ListWithNumberOfRolledPinsInThrowWithIndex;

        public int ManyThrows(int numberOfThrows, int numberOfRolledPinsPerThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            int rolledPins = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(numberOfRolledPinsPerThrow);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                if (i > 1 && (ListWithNumberOfRolledPinsInThrowWithIndex[i - 2] + ListWithNumberOfRolledPinsInThrowWithIndex[i - 1]) == 10)
                {
                    GameScore += rolledPins;
                }
            }

            return GameScore;
        }


        int[] ListOfThrowsWithPunctation;

        public int ManyThrows(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            ListOfThrowsWithPunctation = new int[numberOfThrows];

            int rolledPins = 0;
            //Boolean didLastThrowGiveStrike = false;
            //Boolean thisThrowGiveStrike = false;
            //Boolean nextThrowIsInNewFrame = false;
            int frameThrowsCounter = 1;

            for (int i = 0; i < numberOfThrows; i++)
            {
                rolledPins = Throw(listOfRolledPinsInEveryThrow[i]);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                /*                if (lastThrowGaveStrike == true)
                                {
                                    nextThrowIsInNewFrame = true;
                                }*/

                // SPARE
                //if (i > 1 && ((ListOfThrowsWithRolledPins[i - 2] + ListOfThrowsWithRolledPins[i - 1]) == 10) && nextThrowIsInNewFrame)
                //if (frameThrowsCounter == 2 && nextThrowIsInNewFrame == true && ((ListOfThrowsWithRolledPins[i - 2] + ListOfThrowsWithRolledPins[i - 1]) == 10))
                if (frameThrowsCounter == 1 && i > 0 && ((ListWithNumberOfRolledPinsInThrowWithIndex[i - 1] + ListWithNumberOfRolledPinsInThrowWithIndex[i]) == 10))
                {
                    GameScore += rolledPins;
                }

                // STRIKE
                //if (i > 1 && RolledPinsInEveryThrow[i-2] == 10)
                if (frameThrowsCounter == 1 && ListWithNumberOfRolledPinsInThrowWithIndex[i] == 10)
                {
                    //thisThrowGiveStrike = true;
                    //didLastThrowGiveStrike = true;
                    //nextThrowIsInNewFrame = true;
                    GameScore += (listOfRolledPinsInEveryThrow[i - 1] + listOfRolledPinsInEveryThrow[i]);
                    frameThrowsCounter = 2;
                }

                ListOfThrowsWithPunctation[i] = GameScore;
                //nextThrowIsInNewFrame = false;

                if (frameThrowsCounter == 2)
                {
                    frameThrowsCounter = 1;
                }
                else
                {
                    frameThrowsCounter++;
                }
            }

            return GameScore;
        }

        // pointing the index of frame
        public int FrameCounter {get; set;}

        public int ManyThrowsSecond(int numberOfThrows, int[] listOfRolledPinsInEveryThrow)
        {
            ListWithNumberOfRolledPinsInThrowWithIndex = new int[numberOfThrows];
            int rolledPins = 0;
            // iteration variable for countering throws in current frame
            int frameThrowsCounter = 1;
            // pointing the index of frame
            int frameCounter = 0;
            Boolean lastFrameUnlockedSpare = false;
            Boolean lastFrameUnlockedStrike = false;
            // iteration variable for countering of usage of Strike bonuses
            int usedStrikeBonuseCounter = 0;

            for (int i = 0; i < numberOfThrows; i++)
            {
                if (frameThrowsCounter > 2)
                {
                    frameThrowsCounter = 1;
                }

                rolledPins = Throw(listOfRolledPinsInEveryThrow[i]);

                ListWithNumberOfRolledPinsInThrowWithIndex[i] = rolledPins;

                // SPARE sprawdzamy czy ostatnia ramka dała nam bonus 
                //if (lastFrameUnlockedSpare == true)
                //if (lastFrameUnlockedSpare == true && frameThrowsCounter == 1)
                //if (lastFrameUnlockedSpare == true && (i <= numberOfThrows - 1) && frameThrowsCounter == 1)
                //if (lastFrameUnlockedSpare == true && ((i + 1) <= numberOfThrows))
                if (i == numberOfThrows - 1)
                {
                    lastFrameUnlockedSpare = false;
                }
                if (lastFrameUnlockedSpare == true)
                {
                    GameScore += rolledPins;
                    lastFrameUnlockedSpare = false;
                } 

                // SPARE sprawdzamy czy po drugim rzucie odblokowujemy bonus
                if (frameThrowsCounter == 2 && i > 0 && ((ListWithNumberOfRolledPinsInThrowWithIndex[i - 1] + ListWithNumberOfRolledPinsInThrowWithIndex[i]) == 10))
                {
                        lastFrameUnlockedSpare = true;
                }

                // STRIKE sprawdzamy czy ostatnia ramka dała nam bonus jeśli tak to go liczymy
                if (lastFrameUnlockedStrike == true && usedStrikeBonuseCounter <= 2)
                {
                    //GameScore += (listOfRolledPinsInEveryThrow[i - 1] + listOfRolledPinsInEveryThrow[i]);
                    GameScore += listOfRolledPinsInEveryThrow[i];
                    usedStrikeBonuseCounter++;
                }
                else
                {
                    usedStrikeBonuseCounter = 0;
                }

                // STRIKE sprawdzamy czy aktualny rzut dał nam bonus
                if (frameThrowsCounter == 1 && rolledPins == 10)
                {
                    lastFrameUnlockedStrike = true;
                    frameThrowsCounter = 3;
                    usedStrikeBonuseCounter = 0;
                }
                else
                {
                    frameThrowsCounter++;
                }

                if (frameThrowsCounter >= 3)
                {
                    frameCounter++;
                }
                //if (frameThrowsCounter == 2)
                //{
                //    frameThrowsCounter = 1;
                //}
                //else
                //{
                //    frameThrowsCounter++;
                //}
            }

            FrameCounter = frameCounter;

            return GameScore;
        }

    }

}
