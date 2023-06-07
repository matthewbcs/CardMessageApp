using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMessageApp.Model.Dto
{
    public class CardMessageViewModel
    {
        public List<OccasionSelectItem> OccasionListing { get; set; }
        public List<RelationSelectItem> RelationListing { get; set; }
        public List<AttributeToggleItem> AtrributesListing { get; set; }
        public List<SelectItem> AgeListing { get; set; }
    }

    public class CardMessageRequestModel
    {
        public string Name { get; set; }
        public SelectItem Age { get; set; }
        public bool Poetic { get; set; }
        public RelationSelectItem Relation { get; set; }
        public OccasionSelectItem Occasion { get; set; }
        public List<AttributeToggleItem> AtrributesListing { get; set; }
    }

    public class SelectItem
    {
        public string Name { get; set; }
        
    }

    public class ToggleItem
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class OccasionSelectItem : SelectItem
    {
        public EOccasion Occasion { get; set; }
    }
    public class RelationSelectItem : SelectItem
    {
        public ERelation Relation { get; set; }
    }

    public class AttributeToggleItem : ToggleItem
    {

    }
}
