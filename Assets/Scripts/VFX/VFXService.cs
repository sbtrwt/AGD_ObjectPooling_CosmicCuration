using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vfxPool;
        public VFXService(VFXView viewPrefab, VFXScriptableObject vfxSO) {
            vfxData = vfxSO.vfxData;
            this.vfxPool = new VFXPool(viewPrefab);
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            //VFXController vfxToPlay = new VFXController(prefabToSpawn);
            this.vfxPool = new VFXPool(prefabToSpawn);
            VFXController vfxToPlay = vfxPool.GetVFX();
           
            vfxToPlay.Configure(spawnPosition);
        }
    } 
}