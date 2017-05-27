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
            string userCode = User.Identity.Name;
            List<MonetaryAccountModel> mList = appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList();
            List<Company> comp = appDb.Companies.ToList();
            PaymentViewModel pModel = new PaymentViewModel();
            pModel.CompanyList = new SelectList(comp, "Id", "CompanyName");
            pModel.CompanyIndex = Convert.ToInt32(pModel.CompanyList.FirstOrDefault().Value);
            pModel.MonetaryAccounts = new SelectList(mList, "Id", "IBAN");
            pModel.MonetaryAccountIndex = Convert.ToInt32(pModel.MonetaryAccounts.FirstOrDefault().Value);
            
            return View(pModel);
        }

        [HttpPost]
        public ActionResult Payment(PaymentViewModel payment)
        {

            if (ModelState.IsValid)
            {
                TransactionModel tModel = new TransactionModel();
                tModel.DestinationIBAN = payment.BeneficiaryIBAN;
                tModel.Amount = payment.Amount;
                tModel.SourceIBAN = payment.AccountIBAN;
                tModel.TType = TransactionType.Withdrawal;
                tModel.TransactionDate = DateTime.Now;
                MonetaryAccountModel source = appDb.MonetaryAccount.First(m => m.IBAN == payment.AccountIBAN);
                MonetaryAccountModel destination = appDb.MonetaryAccount.First(m => m.IBAN == payment.BeneficiaryIBAN);

                source.Amount -= payment.Amount;
                destination.Amount += payment.Amount;
                appDb.Transaction.Add(tModel);
                appDb.SaveChanges();

                return RedirectToAction("ViewTransactions", new { selectedAccountId = source.Id });
            }
            List<MonetaryAccountModel> mList = appDb.MonetaryAccount.Where(m => m.UserId == User.Identity.Name).ToList();
            List<Company> comp = appDb.Companies.ToList();
            payment.CompanyList = new SelectList(comp, "Id", "CompanyName");
            payment.MonetaryAccounts = new SelectList(mList, "Id", "IBAN");
            return View(payment);
        }

        public ActionResult Transfer()
        {
            TransferViewModel tModel = new TransferViewModel();
            string userCode = User.Identity.Name;
            tModel.MonetaryAccounts = new SelectList(appDb.MonetaryAccount.Where(m => m.UserId == userCode).ToList(), "Id", "IBAN");
            tModel.SelectedValue = Convert.ToInt32(tModel.MonetaryAccounts.FirstOrDefault().Value);

            return View(tModel);
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel transferModel)
        {
            if (ModelState.IsValid)
            {
                if (!appDb.MonetaryAccount.Any(m => m.IBAN == transferModel.BeneficiaryIBAN))
                {
                    return HttpNotFound();
                }
                MonetaryAccountModel source = appDb.MonetaryAccount.First(m => m.IBAN == transferModel.AccountIBAN);
                MonetaryAccountModel destination = appDb.MonetaryAccount.First(m => m.IBAN == transferModel.BeneficiaryIBAN);
                
                source.Amount -= transferModel.Amount;
                destination.Amount += transferModel.Amount;

                TransactionModel tModelSource = new TransactionModel();
                TransactionModel tModelDest = new TransactionModel();
                tModelSource.Amount = transferModel.Amount;
                tModelSource.DestinationIBAN = transferModel.BeneficiaryIBAN;
                tModelSource.SourceIBAN = transferModel.AccountIBAN;
                tModelSource.TransactionDate = DateTime.Now;
                tModelSource.TType = TransactionType.Withdrawal;

                tModelDest.Amount = transferModel.Amount;
                tModelDest.DestinationIBAN = transferModel.AccountIBAN;
                tModelDest.SourceIBAN = transferModel.BeneficiaryIBAN;
                tModelDest.TransactionDate = DateTime.Now;
                tModelDest.TType = TransactionType.Deposit;

                

                appDb.Transaction.Add(tModelDest);
                appDb.Transaction.Add(tModelSource);
                appDb.SaveChanges();

                return RedirectToAction("ViewTransactions", new { selectedAccountId = source.Id});
            }
            List<MonetaryAccountModel> mList = appDb.MonetaryAccount.Where(m => m.UserId == User.Identity.Name).ToList();
            transferModel.MonetaryAccounts = new SelectList(mList, "Id", "IBAN");
            return View(transferModel);
        }

        public ActionResult ViewTransactions(int? selectedAccountId)
        {
            if (selectedAccountId == 0)
            {
                return HttpNotFound();
            }
            MonetaryAccountModel mAcc = appDb.MonetaryAccount.First(acc => acc.Id == selectedAccountId);
            
            List<TransactionModel> transactions = appDb.Transaction.Where(t => t.SourceIBAN == mAcc.IBAN).ToList();
            return View(transactions);
        }

        public ActionResult SelectAccount()
        {

            var dbEntries = appDb.MonetaryAccount.Where(m => m.UserId == User.Identity.Name).ToList();
            if (dbEntries.Count == 0)
            {
                return View("Error");
            }
            var vm = new TransactionReportViewModel();
            vm.MonetaryAccounts = new SelectList(dbEntries, "Id", "IBAN");
            vm.SelectedValue = Convert.ToInt32(vm.MonetaryAccounts.FirstOrDefault().Value);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SelectAccount(TransactionReportViewModel selectedAccount)
        {
            return RedirectToAction("ViewTransactions", new { selectedAccountId = selectedAccount.SelectedValue });
        }

        [HttpPost]
        public ActionResult GetCompanyData(string companyID)
        {
            List<Company> cmpList = new List<Company>();
            cmpList = appDb.Companies.ToList();
            Company cmp = cmpList.First(c => c.Id == Convert.ToInt32(companyID));
            if (cmp != null)
            {
                return Json(new { success = true, companyName = cmp.CompanyName , iban = cmp.BeneficiaryIBAN, bankName = cmp.BeneficiaryBankName});
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
                return Json(new { success = true, AccountIban = acc.IBAN, amount = acc.Amount });
            }
            return Json(new { success = false });

        }

        public ActionResult GetTransactionHistory(string accountId, TransactionReportViewModel transactionModel)
        {
            List<MonetaryAccountModel> accList = new List<MonetaryAccountModel>();
            accList = appDb.MonetaryAccount.Where(m => m.UserId == User.Identity.Name).ToList();

            MonetaryAccountModel acc = accList.First(m => m.Id == Convert.ToInt32(accountId));
            List<TransactionModel> tList = new List<TransactionModel>();
            tList = appDb.Transaction.Where(t => t.SourceIBAN == acc.IBAN).ToList();
            transactionModel.Transactions = tList;
            if (acc != null)
            {
                return Json(new { success = true, tranModel = transactionModel});
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
