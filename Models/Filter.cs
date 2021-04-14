using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Filter
    {
        public Filter(string filterString)
        {
            FilterString = filterString ?? "all-all-all-all-all-all-all";
            string[] filters = FilterString.Split("-");
            Location = filters[3];
            HairColor = filters[1];
            AgeGroup = filters[0];
            Preservation = filters[2];
            Researcher = filters[4];
            Depth = filters[5];
            HeadDirection = filters[6];

        }

        public string FilterString { get; }
        public string Location { get; }
        public string HairColor { get; }
        public string AgeGroup { get; }
        public string Preservation { get; }
        public string Researcher { get; }
        public string Depth { get; }
        public string HeadDirection { get; }

        public bool HasLocation => Location.ToLower() != "all";
        public bool HasHairColor => HairColor.ToLower() != "all";
        public bool HasAgeGroup => AgeGroup.ToLower() != "all";
        public bool HasPreservation => Preservation.ToLower() != "all";
        public bool HasResearcher => Researcher.ToLower() != "all";
        public bool HasDepth => Depth.ToLower() != "all";
        public bool HasHeadDirection => HeadDirection.ToLower() != "all";

    }
}
