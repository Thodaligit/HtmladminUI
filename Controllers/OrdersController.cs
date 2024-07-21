using AdminUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static AdminUI.MvcApplication;
using AdminUI.Models.Orders;
using System.Threading.Tasks;
using System.Net.Http.Json;
using OfficeOpenXml;

namespace AdminUI.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public async Task<ActionResult> Index()
        {
            List<OrderBL> OrderInfo = new List<OrderBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Orders");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    OrderInfo = JsonConvert.DeserializeObject<List<OrderBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(OrderInfo);
            }
        }


        public async Task<ActionResult> Create()
        {
            OrderBL ObjOrderBL = new OrderBL();

            return View(ObjOrderBL);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderBL objOrderBL)
        {
            OrderBLVM objOrderBLVM = new OrderBLVM();
            objOrderBLVM.ObjOrderBLList.Add(objOrderBL);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objOrderBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Orders", content);
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

        public async Task<ActionResult> Edit(int OrderId)
        {
            try
            {
                OrderBL objOrder = new OrderBL();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/Orders/" + OrderId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        objOrder = JsonConvert.DeserializeObject<OrderBL>(ProResponse);
                    }

                }
                return View(objOrder);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(OrderBL objOrderBL)
        {
            objOrderBL.IsNeedsToDelete = false;

            OrderBLVM objOrderBLVM = new OrderBLVM();
            objOrderBLVM.ObjOrderBLList.Add(objOrderBL);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objOrderBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Orders", content);
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



        public async Task<ActionResult> Details(int OrderId)
        {
            OrderBL orderBL = new OrderBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Orders/" + OrderId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    orderBL = JsonConvert.DeserializeObject<OrderBL>(ProResponse);
                }
            }
            return View(orderBL);
        }

        public async Task<ActionResult> Delete(int OrderId)
        {
            OrderBL ObjOrderBL = new OrderBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Orders/" + OrderId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ObjOrderBL = JsonConvert.DeserializeObject<OrderBL>(ProResponse);
                }

            }
            return View(ObjOrderBL);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(OrderBL objOrderBL)
        {
            objOrderBL.IsNeedsToDelete = true;

            OrderBLVM objOrderBLVM = new OrderBLVM();
            objOrderBLVM.ObjOrderBLList.Add(objOrderBL);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objOrderBLVM);
                HttpResponseMessage Res = await client.PostAsync("api/Orders", content);
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
            OrderBLVM objOrderBLVM = new OrderBLVM();

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
                                var orderBL = new OrderBL();
                                orderBL.OrderId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                orderBL.OrderDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 2].Value);
                                orderBL.Username = workSheet.Cells[rowIterator, 3].Value.ToString();
                                orderBL.FirstName = workSheet.Cells[rowIterator, 4].Value.ToString();
                                orderBL.LastName = workSheet.Cells[rowIterator, 5].Value.ToString();
                                orderBL.Address = workSheet.Cells[rowIterator, 6].Value.ToString();
                                orderBL.City = workSheet.Cells[rowIterator, 7].Value.ToString();
                                orderBL.State = workSheet.Cells[rowIterator, 8].Value.ToString();
                                orderBL.PostalCode = workSheet.Cells[rowIterator, 9].Value.ToString();
                                orderBL.Country = workSheet.Cells[rowIterator, 10].Value.ToString();
                                orderBL.Phone = workSheet.Cells[rowIterator, 11].Value.ToString();
                                orderBL.Email = workSheet.Cells[rowIterator, 12].Value.ToString();
                                orderBL.Total = Convert.ToDecimal(workSheet.Cells[rowIterator, 13].Value);
                                objOrderBLVM.ObjOrderBLList.Add(orderBL);
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

                JsonContent content = JsonContent.Create(objOrderBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/Orders", content);
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