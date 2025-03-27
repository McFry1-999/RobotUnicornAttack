using Unity.Mathematics;
using UnityEngine;

public class InstanciateObject : MonoBehaviour
{
   [SerializeField]
   private GameObject _objectToInstantiate;

   public void InstanciateObjectatPosition(Transform asset)
   {
    Instantiate(_objectToInstantiate, asset.position, Quaternion.identity);
   }
}
