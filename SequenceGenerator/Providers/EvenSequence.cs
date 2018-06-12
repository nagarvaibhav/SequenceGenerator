using System.Collections;
using SequenceGenerator.Common;
using SequenceGenerator.Extensions;

namespace SequenceGenerator.Providers
{
    public class EvenSequence : ISequence
    {
        public SequenceType Name { get { return SequenceType.Even; } }
        private ArrayList _sequence;

        public EvenSequence()
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
                PopulateEvenSequence(iterator);
            }

            return _sequence;
        }

        private void PopulateEvenSequence(int value)
        {
            if (value.IsEven())
            {
                _sequence.Add(value);
            }
        }
    }
}