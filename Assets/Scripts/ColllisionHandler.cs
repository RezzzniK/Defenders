using UnityEngine;

public class ColllisionHandler : MonoBehaviour
{
   [SerializeField] GameObject exp;
   /// <summary>
   /// OnTriggerEnter is called when the Collider other enters the trigger.
   /// </summary>
   /// <param name="other">The other Collider involved in this collision.</param>
   void OnTriggerEnter(Collider other)
   {
      
      Instantiate(exp.gameObject, transform.position, Quaternion.identity);
      // Debug.Log("You Collided with:"+other.gameObject.tag+" aka :"+other.gameObject.name);
      Debug.LogWarning($"You Collided with:{other.name}");
      Destroy(this.gameObject);
      
   }
}
