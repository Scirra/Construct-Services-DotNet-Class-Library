## Cloud Save Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

```C#
var service = new CloudSaveService(
	"c59fca77-46f0-4069-9af2-8b40008906c0", 
	"your-secret-api-key"
);
```