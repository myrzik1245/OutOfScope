using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.AssetsManagment
{
    public class ResourcesAssetsLoader : IAssetsLoader
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}
