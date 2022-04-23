using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public class Replay : ValueObject<Replay>
    {
        public Link? Link { get; set; }

        public Replay(Link? link)
        {
            Link = link;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Link;
        }

        public override string ToString()
        {
            return Link.ToString();
        }

        public bool HasReplay()
            => Link != null;
    }
}
