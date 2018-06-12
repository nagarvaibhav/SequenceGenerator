using System.Collections;
using SequenceGenerator.Common;

namespace SequenceGenerator.Providers
{
    public interface ISequence
    {
        SequenceType Name { get; }
        ArrayList GetSequence(int value);
    }
}
