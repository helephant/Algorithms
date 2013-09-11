using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpacedRepetitionAlgorithm
{
    [TestFixture]
    public class SpacedRepetitionTest
    {
        [Test]
        public void WhenCardIsCorrectSpacingIncreases()
        {
            var session = new SpacedRepetitionSession();
            var now = DateTime.Now;
            session.Add(new Fact("neko", "cat", now.AddHours(-1), now));

            var fact = session.Next();
            fact.Answer(Answer.Correct);

            Assert.That(fact.NextReview, Is.EqualTo(now.AddHours(2)));
        }
    }

    public enum Answer
    {
        Correct, 
        Incorrect
    }

    public class SpacedRepetitionSession 
    {
        readonly List<Fact> _facts = new List<Fact>();

        public void Add(Fact newFact)
        {
            _facts.Add(newFact);
        }

        public Fact Next()
        {
            return _facts[0];
        }
    }

    public class Fact
    {
        public Fact(string expression, string meaning, DateTime lastReview, DateTime nextReview)
        {
            Expression = expression;
            Meaning = meaning;
            LastReview = lastReview;
            NextReview = nextReview;
        }

        public void GiveAnswer(Answer answer)
        {
            if (answer == Answer.Correct)
            {
                NextReview = DateTime.Now.Add(LastReview - DateTime.Now);
                LastReview = DateTime.Now;
            }
        }

        public string Expression { get; private set; }
        public string Meaning { get; private set; }

        public DateTime NextReview { get; private set; }
        public DateTime LastReview { get; private set; }
    }
}
