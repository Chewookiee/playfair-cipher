using AnythingAndEverything.CustomDataAnnotations.SchoolProjects.Automata.EncryptionProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnythingAndEverything.Models.SchoolProjects.Automata.EncryptionProject
{
    public class PlayFairModel
    {
        [Required(ErrorMessage = "Please enter a key.")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Key must be 25 or fewer characters.")]
        [ConfirmStringOnlyHasAtoZCharacters(ErrorMessage = "The key can only contain characters A to Z")]
        [ConfirmStringUniqueCharacters(ErrorMessage = "The key cannont contain the same letter twice.")]
        [CheckForOnlyAtoZ(ErrorMessage="The key can only contain characters 'A' to 'Z'")]
        [OnlyOneJorI(ErrorMessage="You can only have one J or I, but not both.")]
        [Display(Name = "Encryption Key")]
        public string EncryptionKey { get; set; }

        [Required(ErrorMessage = "Please enter a message to encrypt.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message to Encrypt")]
        public string MessageToEncrypt { get; set; }
    }

    public class PlayFairDecryptionModel
    {
        [Required(ErrorMessage = "Please enter a key.")]
        [DataType(DataType.Text)]
        [StringLength(26, ErrorMessage = "Key must be 26 or fewer characters.")]
        [ConfirmStringOnlyHasAtoZCharacters(ErrorMessage = "The key can only contain characters A to Z")]
        [ConfirmStringUniqueCharacters(ErrorMessage = "The key cannont contain the same letter twice.")]
        [CheckForOnlyAtoZ(ErrorMessage = "The key can only contain characters 'A' to 'Z'")]
        [OnlyOneJorI(ErrorMessage = "You can only have one J or I, but not both.")]
        [Display(Name="Encryption Key")]
        public string EncryptionKey { get; set; }

        [Required(ErrorMessage = "Please enter a message to decrypt.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Encrypted Message")]
        public string MessageToDecrypt { get; set; }
    }

    public class PlayFairEncryptedModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Encryption Key")]
        public string EncryptionKey { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Original Message")]
        public string MessageToEncrypt { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Encrypted Message")]
        public string EncryptedMessage { get; set; }
    }

    public class PlayFairDecryptedModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Encryption Key")]
        public string EncryptionKey { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Encrypted Message")]
        public string MessageToDecrypt { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Decrypted Message ")]
        public string DecryptedMessage { get; set; }
    }
}