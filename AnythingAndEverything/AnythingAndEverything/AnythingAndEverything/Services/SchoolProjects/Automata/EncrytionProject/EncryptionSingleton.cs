using AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.BuildMatrixForWordAssociation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.EncryptMessageUsingCypher
{
    public class EncryptionSingleton
    {
        private static EncryptionSingleton instance;
        private IBuildMatrixForWordAssociation buildMatrixForWordAssociation;
        private IEncryptMessageUsingCypher encryptMessageUsingCypher;

        public string EncryptedMessage;
        public string DecryptedMessage;
        public string MessageBeforeEncryption;
        public string KeyForEncryptingMessage;

        private EncryptionSingleton()
        {
        }

        public static EncryptionSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new EncryptionSingleton();
            }

            return instance;
        }

        
        public string EncryptMessageWithPlayFair(string key, string message)
        {
            message = StipMessage(message.ToUpper());

            buildMatrixForWordAssociation = new BuildMatrixForWordAssociationService(StipMessage(key.ToUpper()));
            encryptMessageUsingCypher = new EncryptMessageUsingCypherService();

            string encryptedMessage = encryptMessageUsingCypher.UseCypherToEncodeNewString(buildMatrixForWordAssociation.MatrixForLetterSwapFiveByFive(), message);

            return encryptedMessage;
        }

        public string DecryptMessageWithPlayFair(string key, string message)
        {
            message = StipMessage(message.ToUpper());

            buildMatrixForWordAssociation = new BuildMatrixForWordAssociationService(StipMessage(key.ToUpper()));
            encryptMessageUsingCypher = new EncryptMessageUsingCypherService();

            string decryptedMessage = encryptMessageUsingCypher.UserCypherToDecodeString(buildMatrixForWordAssociation.MatrixForLetterSwapFiveByFive(), message);

            return decryptedMessage;
        }

        public string ChangeJToI(string stringToRemoveJFrom)
        {
            stringToRemoveJFrom = stringToRemoveJFrom.ToUpper();
            string stringToReturn = "";

            if(stringToRemoveJFrom.Contains('J'))
            {
                char[] stringToCharArray = stringToRemoveJFrom.ToCharArray();

                foreach(char item in stringToCharArray)
                {
                    char itemToAdd = item;

                    if (itemToAdd == 'J')
                    {
                        itemToAdd = 'I';
                    }

                    stringToReturn += item;
                }
            }

            return stringToReturn;
        }

        public string StipMessage(string stringToStrip)
        {
            stringToStrip = stringToStrip.ToUpper();

            StringBuilder sb = new StringBuilder(stringToStrip);

            foreach(char letter in stringToStrip)
            {
                if(letter >= 'A' && letter <= 'Z')
                {
                    // Keep letter
                }
                else
                {
                    sb.Replace(letter.ToString(), "");
                }
            }

            stringToStrip = sb.ToString();

            return stringToStrip;
        }
    }
}