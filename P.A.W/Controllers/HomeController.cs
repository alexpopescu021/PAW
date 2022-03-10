using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P.A.W.Models;
using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using PAW.Model;
using System.Net.Mail;
using Newtonsoft.Json;

namespace P.A.W.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View();
        }

        [HttpGet]
        public ActionResult UploadAudio()
        {
            List<Song> audiolist = new List<Song>();
            /*
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllAudioFile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AudioFile audio = new AudioFile();
                    audio.ID = Convert.ToInt32(rdr["ID"]);
                    audio.Name = rdr["Name"].ToString();
                    audio.FileSize = Convert.ToInt32(rdr["FileSize"]);
                    audio.FilePath = rdr["FilePath"].ToString();

                    audiolist.Add(audio);
                }
            }*/
            return View(audiolist);
        }


    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(IFormCollection fc)
        {
            MailMessage mail = new MailMessage(fc["email"].ToString(), "pepalon426@vapaka.com",
                fc["subject"].ToString(), fc["message"].ToString());
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            var json = System.IO.File.ReadAllText("wwwroot/tsconfig1.json");
            var credentials = JsonConvert.DeserializeObject<Account>(json);
            client.Credentials = new System.Net.NetworkCredential(credentials.Email, credentials.Pass);
            client.EnableSsl = true;
            client.Send(mail);
            return RedirectToAction("Index");
        }

    }

    
}
