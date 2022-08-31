using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Newtonsoft.Json.Linq;


using kanbanBoard_aspdotnetmvc.Models.Classes;
using Newtonsoft.Json;

namespace kanbanBoard_aspdotnetmvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        Context c = new Context();

        [HttpGet]
        public JsonResult KendoCard()
            
        {

             var cards = from p in c.Cards
                         join c in c.Columns on p.ColumnId equals c.ID
                         select new
                         {
                             id = p.ID,
                             Title=p.CardTitle,
                             Order=p.Order,
                             Description=p.Description,
                             Category=p.Category,
                             Status=c.Status,
                             image=p.Image,
                         };

            var cardsList= cards.ToList();
           

            return Json(cardsList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult UpdateCard(string updatedItem, int id, string updatedDescID, string updatedCategoryID, string updatedStatusID,String updatedOrderID)
        {
            var col = c.Columns.Where(x => x.Status == updatedStatusID).FirstOrDefault();
            
            var y = c.Cards.Find(id);
            y.CardTitle = updatedItem;
            y.Description = updatedDescID ;
            y.Category = updatedCategoryID;
            y.Order = updatedOrderID;
            y.ColumnId = col.ID;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DestroyCard(int id)
        {
            var deleted = c.Cards.Find(id);
            c.Cards.Remove(deleted);
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }
        [HttpPost]
        public ActionResult NewCard(string id,string titleID,string descriptionID,string categoryID, string statusID)
        {
            Card card = new Card();
            var col = c.Columns.Where(x => x.Status== statusID).FirstOrDefault();
            //var length = col.Cards.Count();
            card.CardTitle = titleID;
            card.Description = descriptionID;
            card.Category = categoryID;

            card.ColumnId = col.ID;
            int y = col.Cards.Count() + 1;
            card.Order = y.ToString();

            c.Cards.Add(card);
            col.Cards.Add(card);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult KendoTable()
        {

            var tablolar = c.Columns.ToList();
            return Json(tablolar, JsonRequestBehavior.AllowGet);

        }


        [HttpPost,HttpGet]
        public ActionResult NewTable(string id)
        {
            Column column = new Column();
            column.Text = id;
            column.Status = id;
            column.Order = c.Columns.ToArray().Length+1;


            c.Columns.Add(column);
            c.SaveChanges();


            
            return RedirectToAction("Index");
        }
        [HttpPost]
     
        public ActionResult DestroyTable(int id)
        {
            var deleted=c.Columns.Find(id);
            c.Columns.Remove(deleted);
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public ActionResult UpdateTable(string updatedItem, int id)
        {
             var y=c.Columns.Find(id);
             y.Text = updatedItem;
             y.Status = updatedItem;
             y.Order = c.Columns.ToArray().Length + 1;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}