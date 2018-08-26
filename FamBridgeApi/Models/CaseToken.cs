using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamBridgeApi.Models
{
    public class CaseToken
    {
        public long Id { get; set; }
        public long CaseId { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public string Token { get; set; }
    }
}
