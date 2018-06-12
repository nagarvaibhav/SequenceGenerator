using System.Collections.Generic;
using SequenceGenerator.Common;
using SequenceGenerator.Helpers;
using SequenceGenerator.Providers;
using SequenceGenerator.Models;
using System.Linq;

namespace SequenceGenerator.Services
{
    public class IntegerSequencesService : ISequenceService
    {
        private readonly IEnumerable<ISequence> _sequences;

        public IntegerSequencesService(IEnumerable<ISequence> sequences)
        {
            _sequences = sequences;
        }

        public string GetAllSequence(int input, string seperator)
        {
           var provider = _sequences.Where(x => x.Name == SequenceType.All).First();
            if (provider != null)
            {
                return SequenceFormatHelper.Format(seperator, provider.GetSequence(input));
            }
            return string.Empty;
        }

        public string GetEvenSequence(int input, string seperator)
        {
            var provider = _sequences.Where(x => x.Name == SequenceType.Even).First();
            if (provider != null)
            {
                return SequenceFormatHelper.Format(seperator, provider.GetSequence(input));
            }
            return string.Empty;
        }

        public string GetMultiplesSequence(int input, string seperator)
        {
            var provider = _sequences.Where(x => x.Name == SequenceType.Multiples).First();
            if (provider != null)
            {
                return SequenceFormatHelper.Format(seperator, provider.GetSequence(input));
            }
            return string.Empty;
        }

        public string GetOddSequence(int input, string seperator)
        {
            var provider = _sequences.Where(x => x.Name == SequenceType.Odd).First();
            if (provider != null)
            {
                return SequenceFormatHelper.Format(seperator, provider.GetSequence(input));
            }
            return string.Empty;
        }

        public Sequences GetSequences(int input, string seperator)
        {
            var sequences = new Sequences();
            foreach (var sequence in _sequences)
            {
                switch (sequence.Name)
                {
                    case SequenceType.All:
                        sequences.AllSequence = SequenceFormatHelper.Format(seperator, sequence.GetSequence(input));
                        break;
                    case SequenceType.Even:
                        sequences.EvenSequence = SequenceFormatHelper.Format(seperator, sequence.GetSequence(input));
                        break;
                    case SequenceType.Odd:
                        sequences.OddSequence = SequenceFormatHelper.Format(seperator, sequence.GetSequence(input));
                        break;
                    case SequenceType.Multiples:
                        sequences.MultiplesSequence = SequenceFormatHelper.Format(seperator, sequence.GetSequence(input));
                        break;
                }
            }

            return sequences;
        }
    }
}