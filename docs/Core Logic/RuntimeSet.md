#### 1. Create your own RuntimeSet

![[Pasted image 20230701120142.png]]

#### 2. Adjust the namespace, menu- and filename as well as the type

```csharp
using UnityEngine;  
using PrototypingToolkit.Core.Logic.RuntimeSet; 
  
namespace Logic
{  
   [CreateAssetMenu(
   fileName = "SomerunetimeSet",
   menuName = "FEATURENAME/SomerunetimeSet")]
   public class SomeRunetimeSet : RuntimeSet<SomeType> { }
}
```

#### 3. Create your RuntimeSet through the Create Asset Menu


#### 4. How to use the RuntimeSet

-  Reference the RuntimeSet 
-  Let Items add themselves OnEnable
-  Let Items remove themselves OnDisable or OnDestroy based on your needs

```csharp
public class SomeType
{
	[SerializeField] private SomeRuntimeSet someRuntimeSet;  
	  
	private void OnEnable()
	{  
	   someRuntimeSet.Add(this);  
	} 
	
	private void OnDisable()
	{  
	   someRuntimeSet.Remove(this);
	} 
	  
	private void OnDestroy()
	{  
	   someRuntimeSet.Remove(this);
	}
}
```

#### 5. Do something with the RuntimeSet Items

-  Reference the RuntimeSet 
-  Do something with these Items

```csharp
[SerializeField] private SomeRuntimeSet someRuntimeSet;

private void DoSomething()
{
	foreach (SomeType item in someRuntimeSet.GetItems())
	{
	   // Add Logic here
	}
}
```