
Those Scripts are here to help you faster create scripts/classes within Unity.

This also shows how they look and can be created on their own.

Adjust those Scripts to your liking and what works best for you.

![[Pasted image 20230628105158.png]]

UnityScripts
	- Behaviour
	- ScriptableObject
	- Controller
	- Manager
Class/Interface
	- Class
	- AbstractClass
	- Interface
Events
	- [[Create your own typed EmptyEvent]]
	- [[Create your own typed DataEvent]]


After creating one of those Scripts:
- adjust Namespace
- adjust menuName or fileName if its a ScriptableObject
- adjust fields
- remove unused methods

Example for ScriptableObject:

```csharp
using UnityEngine;  
  
namespace Logic  
{  
   [CreateAssetMenu(fileName = "newSomeData", menuName = "Features/FeatureA/SomeData")]  
   public class SomeData : ScriptableObject  
   {
      [Header("Data")]
      [SerializeField] private ScriptableObject data;
      
      public ScriptableObject Data => data;
      
      private void Awake()
      {     
      
      }  
      private void OnEnable()
      {
      
      }
      
      private void OnDisable()  
      {
      
      }  
   }
}
```