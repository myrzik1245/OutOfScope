using System;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.Conditions
{
    public class FuncCondition : ICondition
    {
        private readonly Func<bool> _condition;

        public FuncCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public bool IsCompleate()
        {
            return _condition.Invoke();
        }
    }

}