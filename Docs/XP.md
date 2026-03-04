## XP Requests

To make requests against this service, you need to first create the relevant service object.  These are cheap objects, you can create them as and when you require them.  Service objects do not need disposing.

There are two ways to construct a service object:

### For requests where authentication is not required
Some requests do not require a secret key or a players session key.  For these requests you can simply pass your games ID to the constructor as follows:
```C#
var service = new XPService(
	"c59fca77-46f0-4069-9af2-8b40008906c0"
);
```

### For requests using your secret key
If you are making requests that require use of your games secret key, pass in the game ID and a new SecretAPIKey object as follows:
```C#
var service = new XPService(
	"c59fca77-46f0-4069-9af2-8b40008906c0",
	new SecretAPIKey("your-secret-key")
);
```
Services constructed with a secret key will also work for requests that don't require a secret key.