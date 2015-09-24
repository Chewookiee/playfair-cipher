using AnythingAndEverything.Models.SchoolProjects.Automata.EncryptionProject;
using AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.EncryptMessageUsingCypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnythingAndEverything.Controllers.SchoolProjects.Automata.EncryptionProject
{
    public class CMPS479Controller : Controller
    {
        // GET: CMPS479
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EncryptionUsingPlayFair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EncryptionUsingPlayFair(PlayFairModel model)
        {
            EncryptionSingleton encryptionService = EncryptionSingleton.GetInstance();

            model.EncryptionKey = encryptionService.StipMessage(model.EncryptionKey);

            if(ModelState.IsValid)
            {
                encryptionService.EncryptedMessage = encryptionService.EncryptMessageWithPlayFair(model.EncryptionKey, model.MessageToEncrypt);
                encryptionService.MessageBeforeEncryption = model.MessageToEncrypt;
                encryptionService.KeyForEncryptingMessage = model.EncryptionKey;

                return RedirectToAction("DisplayEncryptedMessage");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult DisplayEncryptedMessage()
        {
            EncryptionSingleton encryptionService = EncryptionSingleton.GetInstance();

            PlayFairEncryptedModel playFairEncryptedModel = new PlayFairEncryptedModel();

            playFairEncryptedModel.EncryptionKey = encryptionService.KeyForEncryptingMessage;
            playFairEncryptedModel.MessageToEncrypt = encryptionService.MessageBeforeEncryption;
            playFairEncryptedModel.EncryptedMessage = encryptionService.EncryptedMessage;

            return View(playFairEncryptedModel);
        }

        [HttpGet]
        public ActionResult DecryptionUsingPlayFair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DecryptionUsingPlayFair(PlayFairDecryptionModel model)
        {
            EncryptionSingleton encryptionService = EncryptionSingleton.GetInstance();

            model.EncryptionKey = encryptionService.StipMessage(model.EncryptionKey);

            if (ModelState.IsValid)
            {
                encryptionService.DecryptedMessage = encryptionService.DecryptMessageWithPlayFair(model.EncryptionKey, model.MessageToDecrypt);
                encryptionService.MessageBeforeEncryption = model.MessageToDecrypt;
                encryptionService.KeyForEncryptingMessage = model.EncryptionKey;

                return RedirectToAction("DisplayDecryptedMessage");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult DisplayDecryptedMessage()
        {
            EncryptionSingleton encryptionService = EncryptionSingleton.GetInstance();

            PlayFairDecryptedModel playFairDecryptedModel = new PlayFairDecryptedModel();

            playFairDecryptedModel.EncryptionKey = encryptionService.KeyForEncryptingMessage;
            playFairDecryptedModel.MessageToDecrypt = encryptionService.MessageBeforeEncryption;
            playFairDecryptedModel.DecryptedMessage = encryptionService.DecryptedMessage;

            return View(playFairDecryptedModel);
        }
    }
}