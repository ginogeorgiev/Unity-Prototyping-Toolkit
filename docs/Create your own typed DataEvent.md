### Create your own typed [[DataEvent]]

##### See also: [[Create your own typed EmptyEvent]]

-  This is mandatory if you want to send you own data with Events
-  This can either be useful to have separate Eventgroups or even a single Type for every Event in you game to distinguish them and make them easier to find debug and maintain.

#### 1. Create a new DataEvent Script

- Right-click in the Project hierarchy and choose Create/Create/C# Script/DataEvent

![[Pasted_image_20230623200649.png]]

#### 2. Adjust the namespace, menu- and filename as well as the type

```csharp
using UnityEngine;  
using PrototypingToolkit.Core.Logic.Event;  
  
namespace Logic
{  
   [CreateAssetMenu(
   fileName = "SomeDataEvent",
   menuName = "FEATURENAME/SomeDataEvent")]
   public class SomeEvent : DataEvent<SomeData> { }  
}
```

#### 3. Create the asset for the Event if needed

![[Pasted_image_20230624101456.png]]

