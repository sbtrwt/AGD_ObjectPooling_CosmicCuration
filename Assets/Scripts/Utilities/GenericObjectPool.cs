using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        protected T GetItem()
        {
            if(pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if(item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }
            return CreateNewPooledItem();
        }

        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            //newItem.Item = CreateEnemy();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }
        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child Class do not have implemented yet");
        }
    }  public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }

        
}
