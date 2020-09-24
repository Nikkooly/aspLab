using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace PhoneRepository.Models
{
    [Serializable]
    [DataContract]
    [XmlRoot(ElementName = "Contact", Namespace = "http://tempuri.org/")]
    public class Contact
    {

        [DataMember]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlElement(ElementName = "Id", Namespace = "http://tempuri.org/")]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [MaxLength(30)]
        [XmlElement(ElementName = "Surname", Namespace = "http://tempuri.org/")]
        public string Surname { get; set; }

        [DataMember]
        [Required]
        [MaxLength(15)]
        [XmlElement(ElementName = "Phone", Namespace = "http://tempuri.org/")]
        public string Phone { get; set; }
    }

    [XmlRoot(ElementName = "ArrayOfContact", Namespace = "http://tempuri.org/")]
    public class ArrayOfContact
    {
        [XmlElement(ElementName = "Contact", Namespace = "http://tempuri.org/")]
        public List<Contact> Contact { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}