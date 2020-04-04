using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechieTree.Models;

namespace TechieTree.ViewModel
{
    public class Databaseoperations
    {
        /// <param name="trne"></param>
        public void TraineeSignUp(Trainee trne)
        {
            DataContext db = new DataContext();
            db.Trainee.Add(trne);
            
            db.SaveChanges();
        }

 /// <param name="inst"></param>
 public void TrainerSignUp(Trainer trnr)
        {
            DataContext db = new DataContext();
            db.Trainer.Add(trnr);
            db.SaveChanges();
        }

    }
    /// the function that gets the student's record from database when his/her profile is opened

  /*  public void PostMessage(Messages message)
    {
        using (var db = new DataContext())
            
     {
            if (message.MessageId == default(int))
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
        }
    }*/
}