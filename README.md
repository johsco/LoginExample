# LoginExample
<p>
Here is the code test. I timebox myself to 1 hour..... But i did go over by 30 mins because I "Got in the zone" lol. Currently there is no validation as I ran out of time. So if the login fails, it just redirects you back to the username page. If successful, you will got the Home/Index with a basic welcome message. The login info is UN: TestUser, Password: Password123
</p>


# Setup
<p>
	You will have to change appsettings.ConnectionStrings.LoginExample. The part that would need to change would be AttachDbFilename string to match your file structure.
	
</p>

```json
	"ConnectionStrings": {
		"LoginExample": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\git\\LoginExample\\LoginExample.Ui\\LoginExample.mdf;Integrated Security=True"
	} 
```

