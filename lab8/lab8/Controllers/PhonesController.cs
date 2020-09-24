using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab8.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab8.Controllers
{
    [Route("api/[controller]")]
    public class PhonesController : Controller
    {
        TelephoneBookContext context = new TelephoneBookContext();
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(context.PhoneBook);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return JsonConvert.SerializeObject(context.PhoneBook.Where(u=>u.Id.Equals(id)));
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]PhoneBook value)
        {
            PhoneBook phone = new PhoneBook();
            phone.Id = Guid.NewGuid();
            phone.Name = value.Name;
            phone.Phone = value.Phone;
            try
            {
               context.Add(phone);
               context.SaveChanges();
               return JsonConvert.SerializeObject("Контакт успешно добавлен");
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(ex.Message);
                }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public string Put(Guid id, [FromBody]PhoneBook value)
        {
            PhoneBook phone = context.PhoneBook.Where(u => u.Id.Equals(id)).First();// cinemaContext.FilmInfo.Where(u => u.Id.ToString().Equals(id)).First();
            phone.Name = value.Name;
            phone.Phone = value.Phone;
            try
            {
                context.Update(phone);
                context.SaveChanges();
                return JsonConvert.SerializeObject("Данные успешно изменены");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {
            PhoneBook phone = context.PhoneBook.FirstOrDefault(x => x.Id.Equals(id));
            if (phone == null)
            {
                return JsonConvert.SerializeObject("Фильм не найден!");
            }
            else
            {
                context.PhoneBook.Remove(phone);
                context.SaveChangesAsync();
                return JsonConvert.SerializeObject("Успешно удален!");
            }
        }
    }
}
