using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.BuildMatrixForWordAssociation
{
    public class BuildMatrixForWordAssociationService : IBuildMatrixForWordAssociation
    {
        private char[,] FiveByFiveCypherMatrix;
        private string key;

        public BuildMatrixForWordAssociationService(string key)
        {
            this.FiveByFiveCypherMatrix = new char[5, 5];
            this.key = key;
        }

        public char[,] MatrixForLetterSwapFiveByFive()
        {
            CheckStringToMakeSureOnlyOneInstanceOfLetterExists();
            ConstructFiveByFiveCypherFromKey();

            return FiveByFiveCypherMatrix;
        }

        private void CheckStringToMakeSureOnlyOneInstanceOfLetterExists()
        {
            string ContainerForEachLetterChecked = string.Empty;

            foreach(char letterFromKey in key)
            {
                if (ContainerForEachLetterChecked.Contains(letterFromKey))
                {
                    throw new System.Exception("Key contains multiple instances of the same letter.");
                }

                ContainerForEachLetterChecked += letterFromKey;
            }
        }

        private void ConstructFiveByFiveCypherFromKey()
        {
            int nextPositionInString = 0;
            int lengthOfKey = key.Length;
            string keyWithNewValuesAddedAfterTheInitialKeyIsSet;

            keyWithNewValuesAddedAfterTheInitialKeyIsSet = string.Empty;

            for(int row = 0; row < FiveByFiveCypherMatrix.GetLength(0); row++)
            {
                for(int col = 0; col < FiveByFiveCypherMatrix.GetLength(1); col++)
                {
                    if (lengthOfKey > nextPositionInString)
                    {
                        char NextCharInKey = key.ElementAt(nextPositionInString);

                        FiveByFiveCypherMatrix[row, col] = NextCharInKey;
                        keyWithNewValuesAddedAfterTheInitialKeyIsSet += NextCharInKey;
                    }
                    else
                    {
                        char NextLetterToAddThatIsNotInTheKey = findNextLetterThatIsNotInTheKey(keyWithNewValuesAddedAfterTheInitialKeyIsSet);

                        FiveByFiveCypherMatrix[row, col] = NextLetterToAddThatIsNotInTheKey;
                        keyWithNewValuesAddedAfterTheInitialKeyIsSet += NextLetterToAddThatIsNotInTheKey;
                    }

                    nextPositionInString++;
                }
            }
        }

        private char findNextLetterThatIsNotInTheKey(string keyWithNewValuesAddedAfterTheInitialKeyIsSet)
        {
            char nextChracterToCheck = 'A';
            char characterThatHasNotBeenUsedInCypher = ' ';

            bool haveNotFoundTheNextLetterToAddToCypher = true;

            while(haveNotFoundTheNextLetterToAddToCypher)
            {
                if (keyWithNewValuesAddedAfterTheInitialKeyIsSet.Contains(nextChracterToCheck) || 
                    (nextChracterToCheck == 'J' && keyWithNewValuesAddedAfterTheInitialKeyIsSet.Contains('I')) || 
                    (nextChracterToCheck == 'I' && keyWithNewValuesAddedAfterTheInitialKeyIsSet.Contains('J')))
                {
                    nextChracterToCheck++;
                }
                else
                {
                    characterThatHasNotBeenUsedInCypher = nextChracterToCheck;
                    haveNotFoundTheNextLetterToAddToCypher = false;
                }
            }
            
            return characterThatHasNotBeenUsedInCypher;
        }
    }
}