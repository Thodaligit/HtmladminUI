using AdminUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AdminUI.MvcApplication;
using OfficeOpenXml;

namespace AdminUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public async Task<ActionResult> Index()
        {
            List<CustomerBL> CustomerInfo = new List<CustomerBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Customer");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    CustomerInfo = JsonConvert.DeserializeObject<List<CustomerBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(CustomerInfo);
            }
        }

        public async Task<ActionResult> Create()
        {
            CustomerBL customer = new CustomerBL();        

            return View(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerBL customer)
        {
            customer.IsNeedsToDelete = false;

            CustomerBLVM objCustomerBLVM = new CustomerBLVM();
            objCustomerBLVM.ObjCustomerBLList.Add(customer);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objCustomerBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Customer", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }
        }


        public async Task<ActionResult> Edit(int CustomerId)
        {
            try
            {
                CustomerBL customer = new CustomerBL();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Customer/" + CustomerId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        customer = JsonConvert.DeserializeObject<CustomerBL>(ProResponse);
                    }

                }

                return View(customer);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(CustomerBL customer)
        {
            customer.IsNeedsToDelete = false;

            CustomerBLVM objCustomerBLVM = new CustomerBLVM();
            objCustomerBLVM.ObjCustomerBLList.Add(customer);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objCustomerBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Customer", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }

        }


        public async Task<ActionResult> Details(int CustomerId)
        {
            CustomerBL customer = new CustomerBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Customer/" + CustomerId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    customer = JsonConvert.DeserializeObject<CustomerBL>(ProResponse);
                }
            }
            return View(customer);
        }

        public async Task<ActionResult> Delete(int CustomerId)
        {
            CustomerBL customer = new CustomerBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Customer/" + CustomerId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    customer = JsonConvert.DeserializeObject<CustomerBL>(ProResponse);
                }

            }
            return View(customer);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(CustomerBL customer)
        {
            customer.IsNeedsToDelete = true;

            CustomerBLVM objCustomerBLVM = new CustomerBLVM();
            objCustomerBLVM.ObjCustomerBLList.Add(customer);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objCustomerBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Customer", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }
        }



        public async Task<ActionResult> UploadAsync(FormCollection formCollection)
        {
            CustomerBLVM objCustomerBLVM = new CustomerBLVM();

            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {
                                var customerBL = new CustomerBL();
                                customerBL.CustomerId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                customerBL.CustomerName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                customerBL.ContactNumber = workSheet.Cells[rowIterator, 3].Value.ToString();
                                customerBL.Address = workSheet.Cells[rowIterator, 4].Value.ToString();

                                customerBL.B2B = workSheet.Cells[rowIterator, 5].Value.ToString();
                                customerBL.IsActive = Convert.ToBoolean(workSheet.Cells[rowIterator, 6].Value);
                                customerBL.CreatedDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 7].Value);
                              
                                objCustomerBLVM.ObjCustomerBLList.Add(customerBL);
                            }
                        }
                    }
                }
            }

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonContent content = JsonContent.Create(objCustomerBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Customer", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
            }
            return RedirectToAction("Index");
        }


    }
}