using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();
        public EnemyPool(EnemyView enemyView, EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
            pooledEnemies = new List<PooledEnemy>();
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.Enemy;
                }

            }
            return CreateNewPooledEnemy();

        }

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.Enemy = new EnemyController(enemyView, enemyData);
            pooledEnemy.isUsed = true;
            pooledEnemies.Add(pooledEnemy);

            return pooledEnemy.Enemy;
        }

        public void ReturnToEnemyPool(EnemyController returnedEnemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.Enemy.Equals(returnedEnemy));
            if (pooledEnemy != null)
            {
                pooledEnemy.isUsed = false;
            }
        }
        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }
    }
}
