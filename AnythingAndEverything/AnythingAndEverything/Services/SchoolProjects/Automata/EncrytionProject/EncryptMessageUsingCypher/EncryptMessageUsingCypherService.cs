using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.EncryptMessageUsingCypher
{
    public class EncryptMessageUsingCypherService : IEncryptMessageUsingCypher
    {
        private string EncodedMessage;
        private string InitialMessage;
        private char[,] letterPairs;
        private char[,] fiveByFiveCypherMatrix;

        public string UseCypherToEncodeNewString(char[,] _fiveByFiveCypherMatrix, string message)
        {
            fiveByFiveCypherMatrix = _fiveByFiveCypherMatrix;
            InitialMessage = message;
            ConvertMessageIntoLetterPairs();
            TurnCharArrayIntoMinimumRows();
            EncodeMessage();

            return EncodedMessage;
        }

        public string UserCypherToDecodeString(char[,] _fiveByFiveCypherMatrix, string message)
        {
            fiveByFiveCypherMatrix = _fiveByFiveCypherMatrix;
            InitialMessage = message;
            ConvertMessageIntoLetterPairs();
            TurnCharArrayIntoMinimumRows();
            DecodeMessage();

            return EncodedMessage;
        }

        private void EncodeMessage()
        {
            for(int row = 0; row < letterPairs.GetLength(0); row++)
            {
                int letterOneRowPosition = FindLetterRowPosition(letterPairs[row, 0]);
                int letterOneColPosition = FindLetterColPosition(letterPairs[row, 0]);

                int letterTwoRowPosition = FindLetterRowPosition(letterPairs[row, 1]);
                int letterTwoColPosition = FindLetterColPosition(letterPairs[row, 1]);

                if(letterOneRowPosition != letterTwoRowPosition && letterOneColPosition != letterTwoColPosition)
                {
                    this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterTwoColPosition];
                    this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterOneColPosition];
                }
                else if(letterOneColPosition == letterTwoColPosition && letterOneRowPosition == letterTwoRowPosition)
                {
                    throw new System.Exception("The letters were the same in the pair.  This cannot happen.");
                }
                else if(letterOneRowPosition == letterTwoRowPosition)
                {
                    letterOneColPosition++;
                    letterTwoColPosition++;

                    if(letterOneColPosition == 5)
                    {
                        letterOneColPosition = 0;
                    }
                    if(letterTwoColPosition == 5)
                    {
                        letterTwoColPosition = 0;
                    }

                    this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition];
                    this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition];
                }
                else if (letterOneColPosition == letterTwoColPosition)
                {
                    letterOneRowPosition++;
                    letterTwoRowPosition++;

                    if (letterOneRowPosition == 5)
                    {
                        letterOneRowPosition = 0;
                    }
                    if (letterTwoRowPosition == 5)
                    {
                        letterTwoRowPosition = 0;
                    }

                    this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition];
                    this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition];
                }
                else
                {
                    throw new System.Exception("Something strange went wrong.");
                }
            }
        }

        private void DecodeMessage()
        {
            for (int row = 0; row < letterPairs.GetLength(0); row++)
            {
                int letterOneRowPosition = FindLetterRowPosition(letterPairs[row, 0]);
                int letterOneColPosition = FindLetterColPosition(letterPairs[row, 0]);

                int letterTwoRowPosition = FindLetterRowPosition(letterPairs[row, 1]);
                int letterTwoColPosition = FindLetterColPosition(letterPairs[row, 1]);

                if (letterOneRowPosition != letterTwoRowPosition && letterOneColPosition != letterTwoColPosition)
                {
                    if (fiveByFiveCypherMatrix[letterOneRowPosition, letterTwoColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterTwoColPosition];
                    }

                    if (fiveByFiveCypherMatrix[letterTwoRowPosition, letterOneColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterOneColPosition];
                    }
                }
                else if (letterOneColPosition == letterTwoColPosition && letterOneRowPosition == letterTwoRowPosition)
                {
                    throw new System.Exception("The letters were the same in the pair.  This cannot happen.");
                }
                else if (letterOneRowPosition == letterTwoRowPosition)
                {
                    letterOneColPosition--;
                    letterTwoColPosition--;

                    if (letterOneColPosition == -1)
                    {
                        letterOneColPosition = 4;
                    }
                    if (letterTwoColPosition == -1)
                    {
                        letterTwoColPosition = 4;
                    }

                    if (fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition];
                    }

                    if (fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition];
                    }
                }
                else if (letterOneColPosition == letterTwoColPosition)
                {
                    letterOneRowPosition--;
                    letterTwoRowPosition--;

                    if (letterOneRowPosition == -1)
                    {
                        letterOneRowPosition = 4;
                    }
                    if (letterTwoRowPosition == -1)
                    {
                        letterTwoRowPosition = 4;
                    }

                    if (fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterOneRowPosition, letterOneColPosition];
                    }

                    if(fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition] == 'J')
                    {
                        this.EncodedMessage += 'I';
                    }
                    else
                    {
                        this.EncodedMessage += fiveByFiveCypherMatrix[letterTwoRowPosition, letterTwoColPosition];
                    }

                    
                    
                }
                else
                {
                    throw new System.Exception("Something strange went wrong.");
                }
            }
        }

        private int FindLetterRowPosition(char letter)
        {
            int rowToReturn = -1;

            for (int row = 0; row < fiveByFiveCypherMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fiveByFiveCypherMatrix.GetLength(1); col++)
                {
                    if(fiveByFiveCypherMatrix[row, col] == letter)
                    {
                        rowToReturn = row;
                    }
                    else if(letter == 'J')
                    {
                        if(fiveByFiveCypherMatrix[row, col] == 'I')
                        {
                            rowToReturn = row;
                        }
                    }
                    else if(letter == 'I')
                    {
                        if (fiveByFiveCypherMatrix[row, col] == 'J')
                        {
                            rowToReturn = row;
                        }
                    }
                }
            }

            return rowToReturn;
        }

        private int FindLetterColPosition(char letter)
        {
            int colToReturn = -1;

            for (int row = 0; row < fiveByFiveCypherMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fiveByFiveCypherMatrix.GetLength(1); col++)
                {
                    if (fiveByFiveCypherMatrix[row, col] == letter)
                    {
                        colToReturn = col;
                    }
                    else if (letter == 'J')
                    {
                        if (fiveByFiveCypherMatrix[row, col] == 'I')
                        {
                            colToReturn = col;
                        }
                    }
                    else if (letter == 'I')
                    {
                        if (fiveByFiveCypherMatrix[row, col] == 'J')
                        {
                            colToReturn = col;
                        }
                    }
                }
            }

            return colToReturn;
        }

        private void ConvertMessageIntoLetterPairs()
        {
            this.letterPairs = new char[InitialMessage.Length, 2];
            FillArrayWithEmptyValues();
            char[] CharacterArrayOfInitialMessage = InitialMessage.ToArray<char>();
            int positionInCharacterArrayToGrabNextValue = 0;
            bool hasNotFinishedGoingThroughMessage = true;
            int rowAtForLetterPairs = 0;

            char firstLetter = ' ';
            char secondLetter = ' ';

            while (hasNotFinishedGoingThroughMessage)
            {
                if(positionInCharacterArrayToGrabNextValue == CharacterArrayOfInitialMessage.Length - 1)
                {
                    firstLetter = CharacterArrayOfInitialMessage[positionInCharacterArrayToGrabNextValue];
                    firstLetter = ConvertJToI(firstLetter);

                    secondLetter = 'X';

                    positionInCharacterArrayToGrabNextValue++;
                }
                else
                {
                    firstLetter = CharacterArrayOfInitialMessage[positionInCharacterArrayToGrabNextValue];
                    firstLetter = ConvertJToI(firstLetter);

                    if (firstLetter == CharacterArrayOfInitialMessage[positionInCharacterArrayToGrabNextValue + 1])
                    {
                        secondLetter = 'X';
                    }
                    else
                    {
                        secondLetter = CharacterArrayOfInitialMessage[positionInCharacterArrayToGrabNextValue + 1];
                        secondLetter = ConvertJToI(secondLetter);
                        positionInCharacterArrayToGrabNextValue++;
                    }

                    positionInCharacterArrayToGrabNextValue++;
                }

                letterPairs[rowAtForLetterPairs, 0] = firstLetter;
                letterPairs[rowAtForLetterPairs, 1] = secondLetter;

                rowAtForLetterPairs++;

                if(positionInCharacterArrayToGrabNextValue >= CharacterArrayOfInitialMessage.Length)
                {
                    hasNotFinishedGoingThroughMessage = false;
                }
            }
        }

        public char ConvertJToI(char myChar)
        {
            if(myChar == 'J' || myChar == 'j')
            {
                myChar = 'I';
            }

            return myChar;
        }

        private void FillArrayWithEmptyValues()
        {
            for (int row = 0; row < letterPairs.GetLength(0); row++)
            {
                for (int col = 0; col < letterPairs.GetLength(1); col++)
                {
                    letterPairs[row, col] = '~';
                }
            }
        }

        private void TurnCharArrayIntoMinimumRows()
        {
            int realNumberOfRows = 0;

            for(int row = 0; row < letterPairs.GetLength(0); row++)
            {
                if(letterPairs[row, 0] == '~')
                {
                    break;
                }

                realNumberOfRows++;
            }

            char[,] tempCharArra = new char[realNumberOfRows, 2];

            for(int row = 0; row < tempCharArra.GetLength(0); row++)
            {
                tempCharArra[row, 0] = letterPairs[row, 0];
                tempCharArra[row, 1] = letterPairs[row, 1];
            }

            letterPairs = tempCharArra;

                /* GI
                 * Was?
                 * Make sure to have real data.
                 * Why show pictures?
                 * Make sure if you use pictures you use at max about two
                 * Does it work on the phone?
                 * If so, take a pic in class and show the admin side
                 * Have you met with mister paterson
                 * 
                 * GII
                 * What are the required sections
                 * Amazing project, presentation needs a LOT of work
                 * 
                 * GIV
                 * Larger font
                 * Are you really logged in?
                 * Tell the user to click there to show the tip 
                 */
        }
    }
}