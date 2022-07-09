using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public class Replay : ValueObject<Replay>
    {
        public Replay(Link? link)
        {
            Link = link;
        }

        public Link? Link { get; set; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Link;
        }

        public override string ToString()
        {
            return Link.ToString();
        }

        public bool HasReplay()
        {
            return Link != null;
        }
    }
}