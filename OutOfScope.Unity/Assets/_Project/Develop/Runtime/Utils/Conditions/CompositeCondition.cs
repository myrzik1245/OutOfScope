using System;

namespace _Project.Develop.Runtime.Utils.Conditions
{
    public class CompositeCondition : ICondition
    {
        private readonly ICondition[] _conditions;
        private readonly Func<bool, bool, bool> _logicOperation;

        public CompositeCondition(params ICondition[] conditions) : this(LogicOperation.And, conditions)
        {
        }

        public CompositeCondition(Func<bool, bool, bool> logicOperation, params ICondition[] conditions)
        {
            _conditions = conditions;
            _logicOperation = logicOperation;
        }

        public bool IsCompleate()
        {
            bool result = _conditions[0].IsCompleate();

            for (int i = 1; i < _conditions.Length; i++)
                result = _logicOperation.Invoke(result, _conditions[i].IsCompleate());

            return result;
        }
    }
}