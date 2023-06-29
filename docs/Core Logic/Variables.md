
-  Variables are atomic representations of either primitive or Unity types. 
-  They can be shared between features and help decoupling them

#### 1. Create a Variable in the Editor

![[Pasted image 20230629203006.png]]

#### 2. Adjust ts values in the Editor

![[Pasted image 20230629203630.png]]

-  the ``Start Value`` needs to be set in the inspector and will be copied to the current value at runtime
	- changing it at runtime has no effect
-  the ``Current Value`` will represent the actual value of the variable
	- it can be changed at runtime for testing purposes
-  the ``On Current Changed`` is optional and will be raised when the ``Current Value`` is changed 

#### 3. API

| Public Methods |  | Parameter |
| :------- | :------ | :------: |
| StartValue | getter/setter | - |
| OnCurrentChanged | getter/setter | - |
| Get | get the current value | - |
| Set | set the current value | T value, bool raiseChangedEvent = true |
| Restore | set the current value to the start value | bool raiseChangedEvent = false |
