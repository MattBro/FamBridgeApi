using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamBridgeApi.Models
{
    public class CaseRelationship
    {
        public long Id { get; set; }
        public long caseId { get; set; }
        public long userId { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
