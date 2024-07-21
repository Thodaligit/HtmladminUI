using AdminUI.Models;
using Newtonsoft.Json;
using OfficeOpenXml;
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

namespace AdminUI.Controllers
{
    public class MasterProductCategoriesController : Controller
    {
        // GET: MasterProductCategories
        public async Task<ActionResult> Index()
        {
            List<MasterProductCategoryBL> ProMasterCategoryInfo = new List<MasterProductCategoryBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/MasterProductCategories");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProMasterCategoryInfo = JsonConvert.DeserializeObject<List<MasterProductCategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(ProMasterCategoryInfo);
            }
        }


        public async Task<ActionResult> Create()
        {
            MasterProductCategoryBL ProMasterCategory = new MasterProductCategoryBL();

            return View(ProMasterCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MasterProductCategoryBL ProMasterCategory)
        {
            MasterProductCategoryBLVM objMasterProductCategoryBLVM = new MasterProductCategoryBLVM();
            objMasterProductCategoryBLVM.MasterProductCategories.Add(ProMasterCategory);

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objMasterProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/MasterProductCategories", content);
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

        public async Task<ActionResult> Edit(int MasterProductCategoryId)
        {
            try
            {
                MasterProductCategoryBL ProMasterCategory = new MasterProductCategoryBL();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/MasterProductCategories/" + MasterProductCategoryId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        ProMasterCategory = JsonConvert.DeserializeObject<MasterProductCategoryBL>(ProResponse);
                    }

                }
                return View(ProMasterCategory);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(MasterProductCategoryBL ProMasterCategory)
        {
            MasterProductCategoryBLVM objMasterProductCategoryBLVM = new MasterProductCategoryBLVM();
            objMasterProductCategoryBLVM.MasterProductCategories.Add(ProMasterCategory);
            using (var client = new HttpClient())
            {
                ProMasterCategory.IsNeedsToDelete = false;
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objMasterProductCategoryBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/MasterProductCategories", content);
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


        public async Task<ActionResult> Details(int MasterProductCategoryId)
        {
            MasterProductCategoryBL ProMasterCategory = new MasterProductCategoryBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MasterProductCategories/" + MasterProductCategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProMasterCategory = JsonConvert.DeserializeObject<MasterProductCategoryBL>(ProResponse);
                }
            }
            return View(ProMasterCategory);
        }

        public async Task<ActionResult> Delete(int MasterProductCategoryId)
        {
            MasterProductCategoryBL ProMasterCategory = new MasterProductCategoryBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MasterProductCategories/" + MasterProductCategoryId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProMasterCategory = JsonConvert.DeserializeObject<MasterProductCategoryBL>(ProResponse);
                }

            }
            return View(ProMasterCategory);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(MasterProductCategoryBL ProMasterCategory)
        {
            MasterProductCategoryBLVM objMasterProductCategoryBLVM = new MasterProductCategoryBLVM();
            objMasterProductCategoryBLVM.MasterProductCategories.Add(ProMasterCategory);

            using (var client = new HttpClient())
            {
                ProMasterCategory.IsNeedsToDelete = true;
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objMasterProductCategoryBLVM);
                HttpResponseMessage Res = await client.PostAsync("api/MasterProductCategories", content);
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
            MasterProductCategoryBLVM objMasterProductCategoryBLVM = new MasterProductCategoryBLVM();

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
                                var masterProductCategoryBL = new MasterProductCategoryBL();
                                masterProductCategoryBL.MasterProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                masterProductCategoryBL.MasterProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objMasterProductCategoryBLVM.MasterProductCategories.Add(masterProductCategoryBL);
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

                JsonContent content = JsonContent.Create(objMasterProductCategoryBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("api/MasterProductCategories", content);
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