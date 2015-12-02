using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.ViewModels.HSE.DialogueSecuriteViewModels
{
    public class DialogueSecuriteViewModel
    {
        private AntelopeEntities db = new AntelopeEntities();

        public DialogueSecurite DialogueSecurite;
        public List<Site> AllSite;

        public DialogueSecuriteViewModel(DialogueSecurite dialogueSecurite)
        {
            this.DialogueSecurite = dialogueSecurite; 
            this.AllSite = db.Sites.ToList();
        }

    }
}