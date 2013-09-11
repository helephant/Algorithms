using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SpacedRepetitionAlgorithm
{
    [TestFixture]
    public class SpacedRepetitionTest
    {
        [Test]
        public void WhenCardIsCorrectSpacingIncreases()
        {
            var now = DateTime.Now;
            var fact = new Fact("neko", "cat", now, now);
            fact.GiveAnswer(Answer.Correct);

            Assert.That(fact.NextReview, Is.EqualTo(now.AddHours(1)));
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
        private ReviewTime _reviewTime;

        public Fact(string expression, string meaning, DateTime lastReview, DateTime nextReview) :
            this(expression, meaning, new ReviewTime(nextReview, lastReview))
        {
        }

        internal Fact(string expression, string meaning, ReviewTime reviewTime)
        {
            _reviewTime = reviewTime;
            Expression = expression;
            Meaning = meaning;
            _reviewTime = reviewTime;
        }

        public void GiveAnswer(Answer answer)
        {
            if (answer == Answer.Correct)
            {
//                NextReview = DateTime.Now.Add(DateTime.Now - LastReview);
//                LastReview = DateTime.Now;
                _reviewTime = _reviewTime.CalculateNextReview();
            }
        }

        public string Expression { get; private set; }
        public string Meaning { get; private set; }

        public DateTime NextReview { get { return _reviewTime.NextReview; } }
        public DateTime LastReview { get { return _reviewTime.LastReview; } }
    }

    internal class ReviewTime
    {
        public DateTime LastReview { get; private set; }
        public DateTime NextReview { get; private set; }

        internal ReviewTime(DateTime lastReview, DateTime nextReview)
        {
            LastReview = lastReview;
            NextReview = nextReview;
        }

        public ReviewTime CalculateNextReview()
        {
            return null;
        }
    }
}
