using UnityEngine;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.AssetsManagment
{
    public class ResourcesAssetsLoader : IAssetsLoader
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}
