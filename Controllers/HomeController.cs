using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlanner.Models;
//added
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "This email is already in use!");
                    return View("Index");
                }

                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else 
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser loginUser)
        {
            if(ModelState.IsValid)
            {
                User getUser = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
                
                if(getUser == null){
                    ModelState.AddModelError("LoginEmail", "Email or Password is incorrect");
                    return View("Index");
                }

                PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(loginUser, getUser.Password, loginUser.LoginPassword);

                if(result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Email or Password is incorrect");
                    return View("Index");
                }

                if(HttpContext.Session.GetInt32("UserId")==null){
                    HttpContext.Session.SetInt32("UserId",getUser.UserId);
                    HttpContext.Session.SetString("FirstName",getUser.FirstName);
                    HttpContext.Session.SetString("LastName",getUser.LastName);
                }

                return RedirectToAction("Dashboard");
            } 
            else 
            {
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard(){
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                //HttpContext.Session.SetInt32("UserId",1);
                return RedirectToAction("Index");
            }
            ViewBag.AllWeddings = _context.Weddings.Include(w => w.Guests).ThenInclude(r => r.User);
            return View();
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View();
        }

        [HttpPost("wedding/add")]
        public IActionResult AddWedding(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewWedding");
            }
        }

        [HttpGet("wedding/{id}")]
        public IActionResult ViewWedding(int id)
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding wedding = _context.Weddings.Include(g => g.Guests).ThenInclude(r => r.User).FirstOrDefault(w => w.WeddingId == id);
            return View(wedding);
        }

        [HttpGet("wedding/rsvp/{id}")]
        public IActionResult RSVPWedding(int id)
        {
            RSVP newRSVP = new RSVP();
            newRSVP.UserId = (int)HttpContext.Session.GetInt32("UserId");
            newRSVP.WeddingId = id;
            _context.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/unrsvp/{id}")]
        public IActionResult unRSVPWedding(int id)
        {
            RSVP rsvp = _context.RSVPs.SingleOrDefault(r => r.WeddingId == id && r.UserId == HttpContext.Session.GetInt32("UserId"));
            _context.RSVPs.Remove(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/delete/{id}")]
        public IActionResult DeleteWedding(int id)
        {
            Wedding wedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
            _context.Weddings.Remove(wedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
