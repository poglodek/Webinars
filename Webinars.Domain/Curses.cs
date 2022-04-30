using System.Collections.Generic;

namespace Webinars.Domain
{
    public class Curses
    {
        public List<string> Words { get; init; }

        public Curses(List<string> words)
        {
            Words = words;
        }

        public override string ToString()
        {
            var message = string.Empty;
            Words.ForEach(x => message += x + "\n");
            return message;
        }
    }
}
