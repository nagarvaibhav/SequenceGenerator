namespace SequenceGenerator.Models
{
    public class MultipleRuleModel
    {
        public int Priority { get; set; }

        public string Rule { get; set; }

        public bool IsRulePassed { get; set; }
    }
}