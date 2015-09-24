using AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.EncryptMessageUsingCypher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnythingAndEverything.CustomDataAnnotations.SchoolProjects.Automata.EncryptionProject
{
    public class OnlyOneJorI : ValidationAttribute
    {
        public string StringToCheck { get; set; }
        public OnlyOneJorI()
        {
        }

        public override bool IsValid(object value)
        {
            StringToCheck = value as string;
            StringToCheck = StringToCheck.ToUpper();

            if(StringToCheck.Contains('J') && StringToCheck.Contains('I'))
            {
                return false;
            }

            return true;
        }
    }

    public class CheckForOnlyAtoZ : ValidationAttribute
    {
        public string StringToStrip { get; set; }

        public CheckForOnlyAtoZ()
        {
        }

        public override bool IsValid(object value)
        {
            StringToStrip = value as string;

            StringToStrip = StringToStrip.ToUpper();

            foreach (char letter in StringToStrip)
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    // Allow
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
    public class ConfirmStringUniqueCharacters : ValidationAttribute
    {
        public string KeyToValidate { get; set; }

        public ConfirmStringUniqueCharacters()
        {
        }

        public override bool IsValid(object value)
        {
            string stringToCheck = value as string;
            string stringToCompareToByRippingOutLetters = "";

            EncryptionSingleton encryptionService = EncryptionSingleton.GetInstance();

            stringToCheck = encryptionService.StipMessage(stringToCheck);

            bool isValid = true;

            if (stringToCheck != null)
            {
                foreach (char letter in stringToCheck)
                {
                    if (!stringToCompareToByRippingOutLetters.Contains(letter))
                    {
                        stringToCompareToByRippingOutLetters += letter;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }

    public class ConfirmStringOnlyHasAtoZCharacters : ValidationAttribute
    {
        public string KeyToValidate { get; set; }

        public ConfirmStringOnlyHasAtoZCharacters()
        {
        }

        public override bool IsValid(object value)
        {
            string stringToCheck = value as string;

            bool isValid = true;

            if (stringToCheck != null)
            {
                stringToCheck = stringToCheck.ToUpper();

                foreach (char letter in stringToCheck)
                {
                    if(letter < 'A' && letter > 'Z')
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }
    }
}