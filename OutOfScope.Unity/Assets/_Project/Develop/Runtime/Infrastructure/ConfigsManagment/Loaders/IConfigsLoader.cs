using System;

namespace _Project.Develop.Runtime.Infrastructure.ConfigsManagment.Loaders
{
    public interface IConfigsLoader
    {
        public void Load(Action<Type, object> onLoad);
    }
}
