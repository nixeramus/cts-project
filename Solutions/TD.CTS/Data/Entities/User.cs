using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TD.CTS.Data.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "User", Namespace = "")]
    [XmlType("User")]
    public class User : Entity
    {
        public User()
        {
            Roles = new List<Role>();
        }
        [XmlAttribute(AttributeName = "SystemLogin")]
        [Required(ErrorMessage = "Логин не задан")]
        public string Login { get; set; }

     
        [Required(ErrorMessage = "Мед. учреждение не выбрано")]
        public int HospitalId { get; set; }

        [XmlAttribute(AttributeName = "UserFullName")]
        [Required(ErrorMessage = "Имя не задано")]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public bool NeedChangePassword { get; set; } 

        public List<Role> Roles { get; set; }
    }
}
