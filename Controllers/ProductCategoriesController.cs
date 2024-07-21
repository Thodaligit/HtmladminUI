using Newtonsoft.Json;
using AdminUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using static AdminUI.MvcApplication;
using System.Net.Http.Json;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;

namespace AdminUI.Controllers
{
    public class ProductCategoriesController : Controller
    {
        // GET: ProductCategories
        public async Task<ActionResult> Index()
        {
            List<ProductCategoryBL> ProCategoryInfo = new List<ProductCategoryBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/ProductCategories");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProCategoryInfo = JsonConvert.DeserializeObject<List<ProductCategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(ProCategoryInfo);
            }
        }


        public async Task<ActionResult> Create()
        {

            ProductCategoryBL ProCategory = new ProductCategoryBL();
            List<MasterProductCategoryBL> masterProductCategories = new List<MasterProductCategoryBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MasterProductCategories");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    masterProductCategories = JsonConvert.DeserializeObject<List<MasterProductCategoryBL>>(ProResponse);
                }
            }
            ViewBag.MasterProductCategoryId = new SelectList(masterProductCategories, "MasterProductCategoryId", "MasterProductCategoryName");

            return View(ProCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductCategoryBL ProCategory)
        {
            ProductCategoryBLVM objProductCategoryBLVM = new ProductCategoryBLVM();
            objProductCategoryBLVM.ProductCategories.Add(ProCategory);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductCategories", content);
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

        public async Task<ActionResult> Edit(int ProductCategoryId)
        {
            try
            {
                ProductCategoryBL ProCategory = new ProductCategoryBL();
                List<MasterProductCategoryBL> masterProductCategories = new List<MasterProductCategoryBL>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/ProductCategories/" + ProductCategoryId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        ProCategory = JsonConvert.DeserializeObject<ProductCategoryBL>(ProResponse);
                    }
                    HttpResponseMessage Res2 = await client.GetAsync("api/MasterProductCategories");
                    if (Res2.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse2 = Res2.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        masterProductCategories = JsonConvert.DeserializeObject<List<MasterProductCategoryBL>>(ProResponse2);
                    }
                    ViewBag.MasterProductCategoryId = new SelectList(masterProductCategories, "MasterProductCategoryId", "MasterProductCategoryName", ProCategory.MasterProductCategoryId);
                }
                return View(ProCategory);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductCategoryBL ProCategory)
        {
            ProductCategoryBLVM objProductCategoryBLVM = new ProductCategoryBLVM();
            objProductCategoryBLVM.ProductCategories.Add(ProCategory);
            using (var client = new HttpClient())
            {
                ProCategory.IsNeedsToDelete = false;
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductCategories", content);
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


        public async Task<ActionResult> Details(int ProductCategoryId)
        {
            ProductCategoryBL ProCategory = new ProductCategoryBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/ProductCategories/" + ProductCategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProCategory = JsonConvert.DeserializeObject<ProductCategoryBL>(ProResponse);
                }
            }
            return View(ProCategory);
        }

        public async Task<ActionResult> Delete(int ProductCategoryId)
        {
            ProductCategoryBL ProCategory = new ProductCategoryBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/ProductCategories/" + ProductCategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProCategory = JsonConvert.DeserializeObject<ProductCategoryBL>(ProResponse);
                }

            }
            return View(ProCategory);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(ProductCategoryBL ProCategory)
        {
            ProductCategoryBLVM objProductCategoryBLVM = new ProductCategoryBLVM();
            objProductCategoryBLVM.ProductCategories.Add(ProCategory);

            using (var client = new HttpClient())
            {
                ProCategory.IsNeedsToDelete = true;
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                HttpResponseMessage Res = await client.PostAsync("api/ProductCategories", content);
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
            ProductCategoryBLVM objProductCategoryBLVM = new ProductCategoryBLVM();

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
                                var productCategoryBL = new ProductCategoryBL();
                                productCategoryBL.ProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                productCategoryBL.ProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objProductCategoryBLVM.ProductCategories.Add(productCategoryBL);
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

                JsonContent content = JsonContent.Create(objProductCategoryBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductCategories", content);
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