

namespace SnakeLadder.Rules
{
    public interface IRule
    {
        RuleType Type { get; }
        bool ValidateInitialize(string[] paramters);
        bool TryApplyOnBoard(Board board); 
    }
}
