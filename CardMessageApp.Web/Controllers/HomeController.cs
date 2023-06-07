using CardMessageApp.Model.Dto;
using CardMessageApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CardMessageApp.Model;
using CardMessageApp.Service.Card;

namespace CardMessageApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICardService _iCardService;

        public HomeController(ILogger<HomeController> logger, ICardService iCardService)
        {
            _logger = logger;
            _iCardService = iCardService;
        }

        public IActionResult Index()
        {
            // occasion
            CardMessageViewModel model = new CardMessageViewModel();
            List<OccasionSelectItem> Occasions = new List<OccasionSelectItem>();
            Occasions.Add(new OccasionSelectItem(){Name = "Birthday", Occasion = EOccasion.Birthday});
            Occasions.Add(new OccasionSelectItem(){Name = "Wedding Anniversary", Occasion = EOccasion.Anniversary});
            Occasions.Add(new OccasionSelectItem(){Name = "Graduation",Occasion = EOccasion.Graduation});
            // relations
            List<RelationSelectItem> relations = new List<RelationSelectItem>();
            relations.Add(new RelationSelectItem(){Name = ERelation.Wife.ToString(), Relation = ERelation.Wife});
            relations.Add(new RelationSelectItem(){Name = ERelation.Husband.ToString(), Relation = ERelation.Husband});
            relations.Add(new RelationSelectItem(){Name = ERelation.Boyfriend.ToString(), Relation = ERelation.Boyfriend});
            relations.Add(new RelationSelectItem(){Name = ERelation.Brother.ToString(), Relation = ERelation.Brother});
            // attributes
            List<AttributeToggleItem> atrToggleItems = new List<AttributeToggleItem>();
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "Funny"});
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "loyal"});
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "handsome"});
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "reliable"});
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "amazing"});
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "Patience" });
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "Integrity" });
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "Trustworthy" });
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "cute" });
            atrToggleItems.Add(new AttributeToggleItem(){IsChecked = false,Name = "attractive" });

            int max = 99;
            List<SelectItem> ages = new List<SelectItem>();
            for (int i = 0; i < max; i++)
            {
                ages.Add(new SelectItem(){Name = i.ToString()});
            }

            model.AtrributesListing = atrToggleItems;
            model.AgeListing = ages;
            model.RelationListing = relations;
            model.OccasionListing = Occasions;
            return View(model);
        }

        [HttpPost]
        public IActionResult GetMessage([FromBody] CardMessageRequestModel model)
        {
            ChatResponse response = _iCardService.GetCardMessage(model);
            return Json(response);
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
    }
}