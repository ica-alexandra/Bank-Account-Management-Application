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
            mAccount.UserId = User.Identity.Name;
            mAccount.IBAN = "RO78INGB00009999" + GetCode() + GetCode();

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
            comp.Add(new Company(1,"Orange", "1234", "Orange", "ING"));
            comp.Add(new Company(2, "CEZ", "76543218910", "CEZOltenia", "ING"));
            //end temp

            string userCode = User.Identity.Name;
            List<MonetaryAccountModel> mList = appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList();
            PaymentViewModel pModel = new PaymentViewModel();
            pModel.CompanyList = new SelectList(comp, "Id", "CompanyName");
            pModel.CompanyIndex = Convert.ToInt32(pModel.CompanyList.First().Value);
            pModel.MonetaryAccounts = new SelectList(mList, "Id", "IBAN");
            pModel.MonetaryAccountIndex = Convert.ToInt32(pModel.MonetaryAccounts.FirstOrDefault().Value);
            //var str = pModel.CompanyList.ElementAt(pModel.CompanyIndex).Value;
            //pModel.MonetaryAccounts = new SelectList(appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList());
            
            ViewData["companies"] = comp;
            ViewData["accounts"] = mList;
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

        [HttpPost]
        public ActionResult GetCompanyData(string companyID)
        {
            //temp
            List<Company> cmpList = new List<Company>();
            cmpList.Add(new Company(1, "Orange", "12345678910", "Orange", "ING"));
            cmpList.Add(new Company(2, "CEZ", "76543218910", "CEZOltenia", "ING"));
            //end temp
            Company cmp = cmpList.First(c => c.Id == Convert.ToInt32(companyID));
            if (cmp != null)
            {
                return Json(new { success = true, companyName = cmp.CompanyName , iban = cmp.BeneficiaryIBAN});
            }
         return Json(new { success = false });

        }

        [HttpPost]
        public ActionResult GetAccountData(string accountId)
        {
            
            List<MonetaryAccountModel> accList = new List<MonetaryAccountModel>();
            accList = appDb.MonetaryAccount.Where(m => m.UserId == User.Identity.Name).ToList();

            MonetaryAccountModel acc = accList.First(m => m.Id == Convert.ToInt32(accountId));
            if (acc != null)
            {
                return Json(new { success = true, AccountIban = acc.IBAN });
            }
            return Json(new { success = false });

        }

        private int GetCode()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }
    }
}
