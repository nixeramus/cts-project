using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TD.CTS.Data.Entities
{
    [Serializable]
    [XmlRoot(ElementName = "Role", Namespace = "")]
    [XmlType("Role")]
    public class Role : Entity
    {
        [XmlAttribute(AttributeName = "SystemRoleCode")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "SystemRoleName")]
        public string Name { get; set; }
    }
}
