using BuinessLogic_Library;
using FirstWebAppMVC.Models;
using HelperLibery;
using Microsoft.AspNetCore.Mvc;


namespace FirstWebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerHelper helper= new CustomerHelper();
        public IActionResult NewCustomer()
        { 
           
            return View();
        }
        [HttpPost]
        public IActionResult NewCustomer(CustomerViewModel model)
        {
            CustomerBAL bal = new CustomerBAL();
            bal.CustomerId =model.CustomerId;
            bal.CustName = model.CustName;
            helper.insertCustomer(bal);
         
           return RedirectToAction("Index");   
             //return Content(" Record  added successfulll"); 
            //to return  string on action
        }
        public IActionResult Index()
        {
           List<CustomerBAL> custlist = helper.GetCustomers();
            // show all list of customer
           List<CustomerViewModel> modellist = new List<CustomerViewModel>();
            foreach (var item in custlist)
            {
                CustomerViewModel model = new CustomerViewModel();
                model.CustomerId = item.CustomerId;
                model.CustName=item.CustName;
                modellist.Add(model);
            }
            return View(modellist);
        }
        public IActionResult DeleteCustomer(int id)
        {
            CustomerBAL bal = helper.FindCustomer(id);
            CustomerViewModel model = new CustomerViewModel();
            model.CustomerId = bal.CustomerId;
            model.CustName = bal.CustName;
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteCustomer(int id,CustomerViewModel model)
        {
            helper.deleteCustomer(id);
            
            return RedirectToAction("Index");
            // return Content(" Record deletead successfulll");
        }
        public IActionResult EditCustomer(int id)
        {
            CustomerBAL bal = helper.FindCustomer(id);
            CustomerViewModel model = new CustomerViewModel(); 
            model.CustomerId = bal.CustomerId;
            model.CustName = bal.CustName;
            return View(model);

        }
            [HttpPost]
        public IActionResult EditCustomer( int id,CustomerViewModel model)
        { 
           CustomerBAL bal=new CustomerBAL();
            bal.CustomerId=model.CustomerId;
            bal.CustName=model.CustName;
            helper.UpdateCustomer(id, bal);
            return RedirectToAction("Index");
        }
        public IActionResult FindCustomer(int id)
        {
            CustomerBAL bal = helper.FindCustomer(id);
            CustomerViewModel model=new CustomerViewModel();
            model.CustomerId=bal.CustomerId;
            model.CustName=bal.CustName;
            return View(model);
        }
    }
}
