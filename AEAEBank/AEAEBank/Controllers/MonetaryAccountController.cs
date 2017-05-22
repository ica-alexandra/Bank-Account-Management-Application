using AEAEBank.DAL;
using AEAEBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace AEAEBank.Controllers
{
    public class MonetaryAccountController : Controller
    {
        ApplicationDbContext appDb = new ApplicationDbContext();
        // GET: MonetaryAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            MonetaryAccountModel mAccount = appDb.MonetaryAccount.Find(id);
            return View(mAccount);
        }
        
        public ActionResult EditStatus(int? id, bool status)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            MonetaryAccountModel mAccount = appDb.MonetaryAccount.Find(id);
            //;appDb.MonetaryAccount.Remove(mAccount);
            mAccount.Blocked = status;
            appDb.Entry(mAccount).State = System.Data.Entity.EntityState.Modified;
            //appDb.MonetaryAccount.Add(mAccount);
            appDb.SaveChanges();
            return RedirectToAction("Details",mAccount);
        }
        // GET: MonetaryAccount/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: MonetaryAccount/Create
        [HttpPost]
        public ActionResult Create(MonetaryAccountModel mAccount)
        {
            mAccount.Amount = 0;
            mAccount.UserId = User.Identity.GetUserId();
            mAccount.IBAN = mAccount.UserId + "34";

            appDb.MonetaryAccount.Add(mAccount);
            appDb.SaveChanges();

            return RedirectToAction("Details","Account");
        }

        // GET: MonetaryAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            MonetaryAccountModel mAccount = appDb.MonetaryAccount.Find(id);

            return View(mAccount);
        }

        // POST: MonetaryAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(MonetaryAccountModel mAccount)
        {
            string userId = mAccount.UserId;
            MonetaryAccountModel model =  appDb.MonetaryAccount.Find(mAccount.Id);
            appDb.MonetaryAccount.Remove(model);
            appDb.SaveChanges();
            return RedirectToAction("Details", "Account", userId);
        }

        public ActionResult Payment()
        {
            //temp
            List<Company> comp = new List<Company>();
            comp.Add(new Company("Orange", "1234", "John", "IGN"));
            //end temp
            string userCode = User.Identity.Name;
            PaymentViewModel pModel = new PaymentViewModel();
            pModel.CompanyList = new SelectList(comp);
            pModel.MonetaryAccounts = new SelectList(appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList());
            return View(pModel);
        }

        [HttpPost]
        public ActionResult Payment(PaymentViewModel payment)
        {
            TransactionModel tModel = new TransactionModel();
            tModel.DestinationIBAN = payment.BeneficiaryIBAN;
            tModel.Amount = payment.Amount;
            tModel.SourceIBAN = payment.AccountIBAN;
            tModel.Status = TransactionStatus.Pending;
            tModel.TType = TransactionType.Withdrawal;
            tModel.TransactionDate = DateTime.Now;

            appDb.Transaction.Add(tModel);
            appDb.SaveChanges();

            return RedirectToAction("ViewTransaction");
        }

        public ActionResult Transfer()
        {
            TransferViewModel tModel = new TransferViewModel();
            string userCode = User.Identity.Name;
            tModel.MonetaryAccounts = new SelectList(appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList());

            return View(tModel);
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel transferModel)
        {
            TransactionModel tModel = new TransactionModel();
            tModel.Amount = transferModel.Amount;
            tModel.DestinationIBAN = transferModel.BeneficiaryIBAN;
            tModel.SourceIBAN = transferModel.AccountIBAN;
            tModel.Status = TransactionStatus.Pending;
            tModel.TransactionDate = DateTime.Now;
            tModel.TType = TransactionType.Withdrawal;

            appDb.Transaction.Add(tModel);
            appDb.SaveChanges();

            return RedirectToAction("ViewTransactions");
        }

        public ActionResult ViewTransactions()
        {
            TransactionReportViewModel TRModel = new TransactionReportViewModel();
            string userCode = User.Identity.Name;
            TRModel.MonetaryAccounts = new SelectList(appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList());

            return View(TRModel);
        }
    }
}
