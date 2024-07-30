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
using AdminUI.Model;

namespace AdminUI.Controllers
{
    public class DayBookController : Controller
    {
        // GET: Customers
        public async Task<ActionResult> Index()
        {
            List<DayBookBL> DayBookInfo = new List<DayBookBL>();
            using (var client = new HttpClient())
            {
                ////Passing service base url
                //client.BaseAddress = new Uri(GlobalValues.Baseurl);
                //client.DefaultRequestHeaders.Clear();
                ////Define request data format
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ////Sending request to find web api REST service resource GetAllEmployees using HttpClient
                //HttpResponseMessage Res = await client.GetAsync("api/Daybook");
                ////Checking the response is successful or not which is sent using HttpClient
                //if (Res.IsSuccessStatusCode)
                //{
                //    //Storing the response details recieved from web api
                //    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                //    //Deserializing the response recieved from web api and storing into the Employee list
                //    DayBookInfo = JsonConvert.DeserializeObject<List<DayBookBL>>(ProResponse);
                //}
                ////returning the employee list to view
                ///
                //1
                DayBookInfo.Add(new DayBookBL
                {
                    AccountNo = 001,
                    Date = "28-07-2024",
                    AccountName = "Test",
                    AccountDescription = "Paid",
                    AccountAmount = "1000"
                });

                //2
                DayBookInfo.Add(new DayBookBL
                {
                    AccountNo = 002,
                    Date = "28-07-2024",
                    AccountName = "Test001",
                    AccountDescription = "Paid",
                    AccountAmount = "1500"

                });
                return View(DayBookInfo);
            }
        }
        public async Task<ActionResult> Create()
        {
            DayBookBL daybook = new DayBookBL();

            return View(daybook);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DayBookBL daybook)
        {
            daybook.IsNeedsToDelete = false;

            DayBookBLVM objDayBookBLVM = new DayBookBLVM();
            objDayBookBLVM.ObjDayBookBLList.Add(daybook);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objDayBookBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Daybook", content);
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
        public async Task<ActionResult> Edit(int AccountNo)
        {
            try
            {
                DayBookBL daybook = new DayBookBL();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Daybook/" + AccountNo);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        daybook = JsonConvert.DeserializeObject<DayBookBL>(ProResponse);
                    }

                }

                return View(daybook);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(DayBookBL daybook)
        {
            daybook.IsNeedsToDelete = false;

            DayBookBLVM objDayBookBLVM = new DayBookBLVM();
            objDayBookBLVM.ObjDayBookBLList.Add(daybook);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objDayBookBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Daybook", content);
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
        public async Task<ActionResult> Details(int AccountNo)
        {
            DayBookBL daybook = new DayBookBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Daybook/" + AccountNo);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    daybook = JsonConvert.DeserializeObject<DayBookBL>(ProResponse);
                }
            }
            return View(daybook);
        }

        public async Task<ActionResult> Delete(int AccountNo)
        {
            DayBookBL daybook = new DayBookBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Daybook/" + AccountNo);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    daybook = JsonConvert.DeserializeObject<DayBookBL>(ProResponse);
                }

            }
            return View(daybook);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(DayBookBL daybook)
        {
            daybook.IsNeedsToDelete = true;

            DayBookBLVM objDayBookBLVM = new DayBookBLVM();
            objDayBookBLVM.ObjDayBookBLList.Add(daybook);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objDayBookBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Daybook", content);
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
            DayBookBLVM objDayBookBLVM = new DayBookBLVM();

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
                                var daybookBL = new DayBookBL();
                                daybookBL.AccountNo = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);                              
                                daybookBL.Date = workSheet.Cells[rowIterator, 2].Value.ToString();
                                daybookBL.AccountName = workSheet.Cells[rowIterator, 3].Value.ToString();                               
                                daybookBL.AccountDescription = workSheet.Cells[rowIterator, 4].Value.ToString();
                                daybookBL.AccountAmount = workSheet.Cells[rowIterator, 5].Value.ToString();                              

                                //productBL.ProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                //productBL.ProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objDayBookBLVM.ObjDayBookBLList.Add(daybookBL);
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

                JsonContent content = JsonContent.Create(objDayBookBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Product", content);
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