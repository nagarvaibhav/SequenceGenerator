using System.Collections;
using SequenceGenerator.Common;
using SequenceGenerator.Extensions;

namespace SequenceGenerator.Providers
{
    public class OddSequence : ISequence
    {
        public SequenceType Name { get { return SequenceType.Odd; } }
        private ArrayList _sequence;

        public OddSequence()
        {
            _sequence = new ArrayList();
        }

        public ArrayList GetSequence(int value)
        {
            if (value == 0)
            {
                _sequence.Add("No Sequence Found!");
                return _sequence;
            }

            for (int iterator = 0; iterator <= value; iterator++)
            {
                PopulateOddSequence(iterator);
            }

            return _sequence;
        }

        private void PopulateOddSequence(int value)
        {
            if (value.IsOdd())
            {
                _sequence.Add(value);
            }
        }
    }
}