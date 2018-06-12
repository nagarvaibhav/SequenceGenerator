using System.Collections;
using SequenceGenerator.Common;

namespace SequenceGenerator.Providers
{
    public class AllSequence : ISequence
    {
        public SequenceType Name { get { return SequenceType.All; } }
        private ArrayList _sequence;

        public AllSequence()
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
                _sequence.Add(iterator);
            }

            return _sequence;
        }
    }
}