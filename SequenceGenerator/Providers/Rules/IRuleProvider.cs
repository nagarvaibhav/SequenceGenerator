using System.Collections.Generic;

namespace SequenceGenerator.Providers.Rules
{
    public interface IRuleProvider
    {
        Dictionary<string, string> GetRules();
    }
}