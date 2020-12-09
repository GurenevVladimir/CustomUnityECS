using System.Collections.Generic;

namespace TestProject.DevOOP.GamePool
{
    internal abstract class BaseGamePoolList<T> : BaseGamePool<T>
    {
        private IList<T> _poolList;


        protected override void CreateGamePool()
        {
            _poolList = new List<T>();
        }

        public override void Add(T poolObject)
        {
            if (!_poolList.Contains(poolObject))
            {
                _poolList.Add(poolObject);
            }
        }


        public override T Get(object prototype)
        {
            T result = default;
            if (!ContainsOf(prototype))
            {
                result = (T)CreatePoolObjectByObject(prototype);
            }
            else
            {
                result = GetObjectInPool(prototype, _poolList);
            }
            return result;
        }

        public override void Remove(T poolObject)
        {
            if (_poolList.Contains(poolObject))
            {
                _poolList.Remove(poolObject);
            }
        }

        protected abstract T GetObjectInPool(object prototype, IList<T> list);

        protected virtual bool ContainsOf(object checkObject)
        {
            bool result = false;
            for(int i = 0; i < _poolList.Count; ++i)
            {
                if(_poolList[i].GetType() == checkObject.GetType())
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}