using AdminUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AdminUI.MvcApplication;
using System.Net.Http.Json;
using OfficeOpenXml;
using System.EnterpriseServices.Internal;

namespace AdminUI.Controllers
{
    public class PublishController : Controller
    {
        // GET: Publish
        public async Task<ActionResult> Index()
        {
            List<PublishBL> PublishInfo = new List<PublishBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Publish");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    PublishInfo = JsonConvert.DeserializeObject<List<PublishBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(PublishInfo);
            }
        }


        public async Task<ActionResult> Create()
        {
            PublishBL publish = new PublishBL();
            List<ProductBL> ProductInfo = new List<ProductBL>();
            List<CustomerBL> CustomerInfo = new List<CustomerBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Product");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProductInfo = JsonConvert.DeserializeObject<List<ProductBL>>(ProResponse);
                }
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res2 = await client.GetAsync("api/Customer");
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse2 = Res2.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    CustomerInfo = JsonConvert.DeserializeObject<List<CustomerBL>>(ProResponse2);
                }
                ViewBag.ProductId = new SelectList(ProductInfo, "ProductId", "ProductName");
                ViewBag.CustomerId = new SelectList(CustomerInfo, "CustomerId", "CustomerName");
            }

            return View(publish);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PublishBL publish)
        {
            publish.IsNeedsToDelete = false;

            PublishBLVM objPublishBLVM = new PublishBLVM();
            objPublishBLVM.ObjPublishBLList.Add(publish);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objPublishBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Publish", content);
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


        public async Task<ActionResult> Edit(int PublishId)
        {
            try
            {
                PublishBL publish = new PublishBL();
                List<ProductBL> ProductInfo = new List<ProductBL>();
                List<CustomerBL> CustomerInfo = new List<CustomerBL>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Publish/" + PublishId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        publish = JsonConvert.DeserializeObject<PublishBL>(ProResponse);
                    }
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res2 = await client.GetAsync("api/Product");
                    if (Res2.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse2 = Res2.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        ProductInfo = JsonConvert.DeserializeObject<List<ProductBL>>(ProResponse2);
                    }
                    ViewBag.ProductId = new SelectList(ProductInfo, "ProductId", "ProductName", publish.ProductId);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res3 = await client.GetAsync("api/Customer");
                    if (Res3.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse3 = Res3.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        CustomerInfo = JsonConvert.DeserializeObject<List<CustomerBL>>(ProResponse3);
                    }
                    ViewBag.CustomerId = new SelectList(CustomerInfo, "CustomerId", "CustomerName", publish.CustomerId);

                }

                return View(publish);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(PublishBL publish)
        {
            publish.IsNeedsToDelete = false;

            PublishBLVM objPublishBLVM = new PublishBLVM();
            objPublishBLVM.ObjPublishBLList.Add(publish);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objPublishBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/publish", content);
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



        public async Task<ActionResult> Details(int PublishId)
        {
            PublishBL publish = new PublishBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Publish/" + PublishId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    publish = JsonConvert.DeserializeObject<PublishBL>(ProResponse);
                }
            }
            return View(publish);
        }

        public async Task<ActionResult> Delete(int PublishId)
        {
            PublishBL publish = new PublishBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Publish/" + PublishId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    publish = JsonConvert.DeserializeObject<PublishBL>(ProResponse);
                }

            }
            return View(publish);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(PublishBL publish)
        {
            publish.IsNeedsToDelete = true;

            PublishBLVM objPublishBLVM = new PublishBLVM();
            objPublishBLVM.ObjPublishBLList.Add(publish);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objPublishBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Publish", content);
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
            PublishBLVM objPublishBLVM = new PublishBLVM();

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
                                var publishBL = new PublishBL();
                             

                                publishBL.ProductId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                publishBL.CustomerId = Convert.ToInt32(workSheet.Cells[rowIterator, 2].Value);
                                publishBL.ProductId = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value);
                                publishBL.MediaUrl = workSheet.Cells[rowIterator, 4].Value.ToString();

                                publishBL.PublishDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 5].Value);
                                publishBL.FrequencyInDays = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value);
                                publishBL.Status = Convert.ToBoolean(workSheet.Cells[rowIterator, 7].Value);
                                publishBL.CreatedDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 8].Value);
                                publishBL.UserId = workSheet.Cells[rowIterator, 9].Value.ToString();
                                publishBL.CustomerName = workSheet.Cells[rowIterator, 10].Value.ToString();

                                publishBL.ProductName = workSheet.Cells[rowIterator, 11].Value.ToString();


                                //productBL.ProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                //productBL.ProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objPublishBLVM.ObjPublishBLList.Add(publishBL);
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

                JsonContent content = JsonContent.Create(objPublishBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Publish", content);
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