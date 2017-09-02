

namespace SnakeLadder.Rules
{
    public interface IRule
    {
        RuleType Type { get; }
        bool ValidateInitialize(string[] paramters);
        
    }
}
