using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.AssetsManagment
{
    public interface IAssetsLoader
    {
        public T Load<T>(string path) where T : Object;
    }
}
