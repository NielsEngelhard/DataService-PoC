using System;
using System.Collections.Generic;
using System.Linq;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly List<Data> _data = new List<Data>();

        public DataController()
        {
            /*Add example data for retrieving (Code used for a Proof of Concept not production) */
            _data.Add(new Data()
            {
                Id = 100001,
                Name = "Example B.V. order for new monitors.",
                Description = "2 Dell monitors | 3 Apple monitors",
                Price = 5000.0f
            });

            _data.Add(new Data()
            {
                Id = 100002,
                Name = "Another B.V. order for used keyboards.",
                Description = "200 Razer keyboards",
                Price = 1999.99f
            });
        }

        [HttpGet]
        public ActionResult<List<Data>> Index()
        {
            return _data; // Get only returns the data. No active data source is attached, because this API is part of a PoC.
        }

        [HttpGet("{id}")]
        public ActionResult<Data> GetById(int id)
        {
            return Ok(_data.FirstOrDefault(dataset => dataset.Id == id));
        }

        [HttpPost]
        public ActionResult<Data> Insert([FromBody] Data data)
        {
            _data.Add(data);
            return data;
        }

    }
}

