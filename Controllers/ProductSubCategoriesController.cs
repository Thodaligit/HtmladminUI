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
using System.Collections;
using OfficeOpenXml;

namespace AdminUI.Controllers
{
    public class ProductSubCategoriesController : Controller
    {
        // GET: ProductSubCategories
        public async Task<ActionResult> Index()
        {
            List<ProductSubcategoryBL> ProSubCategoryInfo = new List<ProductSubcategoryBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/ProductSubcategories");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProSubCategoryInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(ProSubCategoryInfo);
            }
        }

        public async Task<ActionResult> Create()
        {
            ProductSubcategoryBL ProSubCategory = new ProductSubcategoryBL();
            List<ProductCategoryBL> productCategories = new List<ProductCategoryBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/ProductCategories");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    productCategories = JsonConvert.DeserializeObject<List<ProductCategoryBL>>(ProResponse);
                }
            }
            ViewBag.ProductCategoryId = new SelectList(productCategories, "ProductCategoryId", "ProductCategoryName");
            return View(ProSubCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductSubcategoryBL ProSubCategory)
        {
            ProductSubcategoryBLVM objProductCategoryBLVM = new ProductSubcategoryBLVM();
            objProductCategoryBLVM.ProductSubcategories.Add(ProSubCategory);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductSubcategories", content);
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

        public async Task<ActionResult> Edit(int ProductSubcategoryId)
        {
            try
            {
                ProductSubcategoryBL ProSubCategory = new ProductSubcategoryBL();
                List<ProductCategoryBL> productCategories = new List<ProductCategoryBL>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/ProductSubcategories/" + ProductSubcategoryId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        ProSubCategory = JsonConvert.DeserializeObject<ProductSubcategoryBL>(ProResponse);
                    }
                    HttpResponseMessage Res2 = await client.GetAsync("api/ProductCategories");
                    if (Res2.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse2 = Res2.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        productCategories = JsonConvert.DeserializeObject<List<ProductCategoryBL>>(ProResponse2);
                    }
                    ViewBag.ProductCategoryId = new SelectList(productCategories, "ProductCategoryId", "ProductCategoryName", ProSubCategory.ProductCategoryId);
                }
                return View(ProSubCategory);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductSubcategoryBL ProSubCategory)
        {
            ProSubCategory.IsNeedsToDelete = false;

            ProductSubcategoryBLVM objProductCategoryBLVM = new ProductSubcategoryBLVM();
            objProductCategoryBLVM.ProductSubcategories.Add(ProSubCategory);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductSubcategories", content);
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


        public async Task<ActionResult> Details(int ProductSubcategoryId)
        {
            ProductSubcategoryBL ProSubCategory = new ProductSubcategoryBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/ProductSubcategories/" + ProductSubcategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProSubCategory = JsonConvert.DeserializeObject<ProductSubcategoryBL>(ProResponse);
                }
            }
            return View(ProSubCategory);
        }
     
        public async Task<ActionResult> Delete(int ProductSubcategoryId)
        {
            ProductSubcategoryBL ProSubCategory = new ProductSubcategoryBL();
            List<ProductCategoryBL> productCategories = new List<ProductCategoryBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/ProductSubcategories/" + ProductSubcategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProSubCategory = JsonConvert.DeserializeObject<ProductSubcategoryBL>(ProResponse);
                }
                HttpResponseMessage Res2 = await client.GetAsync("api/ProductCategories");
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse2 = Res2.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    productCategories = JsonConvert.DeserializeObject<List<ProductCategoryBL>>(ProResponse2);
                }
                ViewBag.ProductCategoryId = new SelectList(productCategories, "ProductCategoryId", "ProductCategoryName", ProSubCategory.ProductCategoryId);
            }
            return View(ProSubCategory);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(ProductSubcategoryBL ProSubCategory)
        {
            ProSubCategory.IsNeedsToDelete = true;

            ProductSubcategoryBLVM objProductCategoryBLVM = new ProductSubcategoryBLVM();
            objProductCategoryBLVM.ProductSubcategories.Add(ProSubCategory);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductSubcategories", content);
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
            ProductSubcategoryBLVM objSubProductCategoryBLVM = new ProductSubcategoryBLVM();

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
                                var productSubCategoryBL = new ProductSubcategoryBL();
                                productSubCategoryBL.ProductSubcategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                productSubCategoryBL.ProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                productSubCategoryBL.ProductSubcategoryName = workSheet.Cells[rowIterator, 3].Value.ToString();
                                productSubCategoryBL.ProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value);
                                productSubCategoryBL.Description = workSheet.Cells[rowIterator, 5].Value.ToString();
                                objSubProductCategoryBLVM.ProductSubcategories.Add(productSubCategoryBL);
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

                JsonContent content = JsonContent.Create(objSubProductCategoryBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/ProductSubcategories", content);
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