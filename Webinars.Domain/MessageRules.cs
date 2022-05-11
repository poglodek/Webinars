using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.ValueObjects.Message;

namespace Webinars.Domain
{
    public class MessageRules
    {
        private readonly IList<IRejectWords> _wordsList;
        private readonly IList<ICurses> _cursesList;

        public MessageRules(IList<IRejectWords> wordsList, IList<ICurses> cursesList)
        {
            _wordsList = wordsList;
            _cursesList = cursesList;
        }

        public MessageScoreResult Evaluate(Message message)
        {
            if (HasAnyCurses(message))
                return new MessageScoreResult(true, "Message has curses!");
            else if (HasAnyRejectWords(message))
                return new MessageScoreResult(true, "Message has rejected words!");

            return new MessageScoreResult(false);
        }
        public bool HasAnyCurses(Message message)
        {
            ReadOnlySpan<string> words = message.Value
                .Replace('.', ' ')
                .Replace(',', ' ')
                .ToUpper()
                .Split(' ');

            foreach (var word in words)
            {
                if (_cursesList.Select(x=>x.Word.ToUpper()).Contains(word))
                    return false;
            }
            return true;
        }
        public bool HasAnyRejectWords(Message message)
        {
            ReadOnlySpan<string> words = message.Value
                .Replace('.', ' ')
                .Replace(',', ' ')
                .ToUpper()
                .Split(' ');

            foreach (var word in words)
            {
                if (_wordsList.Select(x => x.Word.ToUpper()).Contains(word))
                    return false;
            }
            return true;
        }

    }
}
