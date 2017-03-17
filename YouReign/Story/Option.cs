using System.Collections.Generic;

namespace YouReign.Story
{
    public class Option
    {
        public string Message { get; }
        public string Background { get; }
        public List<Message> Messages { get; }
        public List<Option> NextOptions { get; }

        private int _index = 0;

        public Option(string message, string background, List<Message> messages, List<Option> nextOptions = new List<Option>())
        {
            Message = message;
            Background = background;
            Messages = messages;
            NextOptions = nextOptions;
        }

        public bool ShouldGetNextMessage()
        {
            return _index < Messages.Count;
        }

        public Message GetNextMessage()
        {
            var message = Messages[_index];
            _index++;
            return message;
        }

        public bool DidTheKingDie()
        {
            return NextOptions.Count == 0;
        }
    }
}
