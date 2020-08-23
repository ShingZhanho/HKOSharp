## SeaTemp Constructors

### SeaTemp(JObject)

Instantizes a new instance of the SeaTemp object to the specified JSON object.

```c#
internal SeaTemp(JObject jObject);
```

#### Parameters

`jObject` JObject

A JObject that contains deserialized JSON.

#### Remarks

SeaTemp can only be instantized within the assembly. 



### SeaTemp()

Instantizes a new instance of the SeaTemp object that contains nothing.

```c#
protected SeaTemp();
```

#### Remarks

This constructor is for its child class [SoilTemp](SoilTemp).