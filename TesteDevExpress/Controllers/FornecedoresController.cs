using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TesteDevExpress.Models;

namespace TesteDevExpress.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FornecedoresController : Controller
    {
        private readonly AppDbContext _context;

        public FornecedoresController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions) {
            var fornecedores = _context.Fornecedores.Select(i => new {
                i.Id,
                i.Nome,
                i.Ativo
            });
            return Json(DataSourceLoader.Load(fornecedores, loadOptions));
        }

        [HttpPost]
        public IActionResult Post(string values) {
            var model = new Fornecedores();
            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Fornecedores.Add(model);
            _context.SaveChanges();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public IActionResult Put(int key, string values) {
            var model = _context.Fornecedores.FirstOrDefault(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Fornecedores not found");

            var _values = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, _values);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public void Delete(int key) {
            var model = _context.Fornecedores.FirstOrDefault(item => item.Id == key);

            _context.Fornecedores.Remove(model);
            _context.SaveChanges();
        }


        private void PopulateModel(Fornecedores model, IDictionary values) {
            string ID = nameof(Fornecedores.Id);
            string NOME = nameof(Fornecedores.Nome);
            string ATIVO = nameof(Fornecedores.Ativo);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NOME)) {
                model.Nome = Convert.ToString(values[NOME]);
            }

            if(values.Contains(ATIVO)) {
                model.Ativo = Convert.ToBoolean(values[ATIVO]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}