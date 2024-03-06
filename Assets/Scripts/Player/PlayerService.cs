using CosmicCuration.Bullets;
using System;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;
        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            bulletPool = new BulletPool(bulletPrefab, bulletScriptableObject);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPrefab, bulletScriptableObject, bulletPool);
        }

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();

        public void ReturnBulletToPool(BulletController bulletController)
        {
            bulletPool.ReturnToBulletPool(bulletController);
        }
    } 
}