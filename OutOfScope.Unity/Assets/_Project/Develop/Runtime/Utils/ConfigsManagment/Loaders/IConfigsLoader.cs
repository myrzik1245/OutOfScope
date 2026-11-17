using System;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment.Loaders
{
    public interface IConfigsLoader
    {
        public void Load(Action<Type, object> onLoad);
    }
}
