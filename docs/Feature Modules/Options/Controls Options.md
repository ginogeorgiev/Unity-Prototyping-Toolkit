#### Input Rebind Data

Holds all the imported data related to input rebinds
-  events and current rebinding operation states

---
#### Advanced Input Rebind Popup

The Advanced Input Rebind Popup is a UI prefab that allows to give rebind feedback
Gives rebinding operations the options to either:
-  Cancel
-  Re-Capture 
-  or Accept 
the rebinding

Drag and drop **one** Prefab into your canvas, no need for a setup.
[[Controls Options#Input Rebind Element|Input Rebind Element]] will communicate changes and activate the Input Rebind Popup is needed.

---
#### Input Rebind Element

The Advanced Input Rebind Popup is a UI prefab that gives the option to rebind InputAction References.

Drag and drop the Prefab into your canvas (as many as you need) and set it up:
-  Set the corresponding Input Action
-  and the corresponding Binding
-  change the key-text to the actual key
which will be changed under the Settings section:

![[Pasted image 20230810172816.png]]

You need to have an InputAction Map with Actions and Bindings.