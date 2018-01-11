using System;
using System.Collections.Generic;
using System.Text;

namespace HittaLekparker
{

    public class RootobjectDetailedInfo
    {
        public Attribute[] Attributes { get; set; }
        public Geographicalarea[] GeographicalAreas { get; set; }
        public Geographicalposition GeographicalPosition { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public object[] RelatedServiceUnits { get; set; }
        public Serviceunittype[] ServiceUnitTypes { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }


    public class Attribute
    {
        public string Description { get; set; }
        public string Group { get; set; }
        public object GroupDescription { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public object[] Values { get; set; }
        public Serviceunittypeinfo ServiceUnitTypeInfo { get; set; }
    }

    public class Serviceunittypeinfo
    {
        public string Id { get; set; }
        public string SingularName { get; set; }
    }

    public class Geographicalarea
    {
        public string FriendlyId { get; set; }
        public int Id { get; set; }
        public bool IsCityArea { get; set; }
        public string Name { get; set; }
    }

    public class Serviceunittype
    {
        public string DefinitiveName { get; set; }
        public string Id { get; set; }
        public string PluralName { get; set; }
        public Serviceunittypegroupinfo ServiceUnitTypeGroupInfo { get; set; }
        public string SingularName { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }

    public class Serviceunittypegroupinfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
