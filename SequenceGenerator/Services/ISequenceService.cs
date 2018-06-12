using SequenceGenerator.Models;

namespace SequenceGenerator.Services
{
    public interface ISequenceService
    {
        Sequences GetSequences(int input, string seperator);

        string GetOddSequence(int input, string seperator);

        string GetEvenSequence(int input, string seperator);

        string GetMultiplesSequence(int input, string seperator);

        string GetAllSequence(int input, string seperator);
    }
}
