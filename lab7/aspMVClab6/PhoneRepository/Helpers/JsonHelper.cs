using PhoneRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace mvcBuiko.Helpers
{
    public class JsonHelper
    {
        private string filePath;
        public JsonHelper(string filePath)
        {
            this.filePath = filePath;
        }

        public void updateFile(List<Contact> lsContacts)
        {
            var json = JsonSerializer.Serialize(lsContacts);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}