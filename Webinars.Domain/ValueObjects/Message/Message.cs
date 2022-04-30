using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Message
{
    public class Message : ValueObject<Message>
    {
        public string Value { get; init; }
        public bool IsVisible { get; init; }
        public CreatedTime CreatedTime { get; init; }
        public Curses Curses { get; init; }

        public Message(string value, CreatedTime createdTime, Curses curses)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Message cannot be empty");
            Value = value;
            CreatedTime = createdTime;
            Curses = curses;
            IsVisible = HasAnyCurses() && HasAnyBadWords();
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Value;
            yield return CreatedTime;
        }

        public bool HasAnyCurses()
        {
            ReadOnlySpan<string> words = Value
                .Replace('.', ' ')
                .Replace(',', ' ')
                .ToUpper()
                .Split(' ');

            foreach (var word in words)
            {
                if (Curses.Words.Contains(word))
                    return false;
            }
            return true;
        }

        public bool HasAnyBadWords()
        {
            return false;
        }

        public override string ToString()
        {
            return $"{Value} - {CreatedTime.CreatedDateTime}";
        }
    }
}
