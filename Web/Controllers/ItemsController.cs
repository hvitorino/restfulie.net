﻿using System.Web.Mvc;
using Restfulie.Server;
using Restfulie.Server.Results;
using Web.Models;
using Web.Persistence;
using System.Linq;

namespace Web.Controllers
{
    [ActAsRestfulie]
    public class ItemsController : Controller
    {
        private MemoryDatabase database;

        public ItemsController()
        {
            
            database = new MemoryDatabase();
			database.Add(new Item());
        }

        public virtual ActionResult Index()
        {
            return new OK(database.List());
        }

        public virtual ActionResult Get(int id)
        {
            var item = database.List().Where(i => i.Id == id).SingleOrDefault();

            if (item == null) return new NotFound();
            return new OK(item);
        }

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create()
		{
			var item = new Item();
			database.Add(item);

			return new Created(item, "http://localhost:1198/Items/" + item.Id);
		}


        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Save(Item item)
        {
            database.Add(item);

            return new Created(item, "http://localhost:1198/Items/" + item.Id);
        }
    }
}
