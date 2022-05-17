using System.Collections.Generic;
using System.Text;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public class Link : ValueObject<Link>
    {
        public string Youtube { get; set; }
        public string Website { get; set; }

        public Link(string youtube, string website)
        {
            Youtube = youtube;
            Website = website;
        }

        public bool HasStream()
        {
            return !string.IsNullOrWhiteSpace(Youtube) || !string.IsNullOrWhiteSpace(Website);
        }

        public List<string> GetAllLink()
        {
            var list = new List<string>();
            foreach (var link in GetAttributesToEqualityCheck())
            {
                if (string.IsNullOrWhiteSpace(link))
                    continue;

                list.Add(link);
            }
            return list;
        }
        protected override IEnumerable<string> GetAttributesToEqualityCheck()
        {
            yield return Youtube;
            yield return Website;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var link in GetAllLink())
            {
                sb.Append(link + "\n");
            }

            return sb.ToString();
        }
    }
}
