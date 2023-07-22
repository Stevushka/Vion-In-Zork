using System;
using System.Collections.Generic;
using System.Linq;

namespace Vion
{
    public class Command
    {
        public string Name { get; set; }

        public string[] Verbs { get; set; }

        public Action<Game> Action { get; set; }

        public Action<Game, List<string>> ComplexAction { get; set; }

        public string HelpText { get; set; }

        public Command(string name, IEnumerable<string> verbs, string helpText, Action<Game> action)
        {
            Assert.IsNotNull(name);
            Assert.IsNotNull(verbs);
            Assert.IsNotNull(action);
            Assert.IsNotNull(helpText);

            Name = name;
            Verbs = verbs.ToArray();
            HelpText = helpText;
            Action = action;
        }

        public Command(string name, IEnumerable<string> verbs, string helpText, Action<Game, List<string>> action)
        {
            Assert.IsNotNull(name);
            Assert.IsNotNull(verbs);
            Assert.IsNotNull(action);
            Assert.IsNotNull(helpText);

            Name = name;
            Verbs = verbs.ToArray();
            HelpText = helpText;
            ComplexAction = action;
        }

        public override string ToString() => Name;
    }
}