branch
===
AspNet5 application for viewing Xbox Live, Halo: Reach, and Halo 4 stats. Expandable and service based for easy addition of new titles with minimal reworking.


### Getting Started

Pull the git repo to begin.
``` bash
> git clone git@github.com:TheTree/branch.git
> cd branch
> dnu restore
> dnu build
```


### Configuration

All configuration for services are stored inside the secrets json config. For more information, check the [docs](https://github.com/aspnet/UserSecrets). The secrets.json config looks like this:
``` json
{
	"Halo4": {
		"Authentication": {
			"MicrosoftAccount": "",
			"MicrosoftAccountPassword": "",
			"ApiEndpoint": ""
		},
		"DocumentDb": {
			"DatabaseId": "",
			"CollectionId": "",
			"AccessKey": "",
			"Endpoint": ""
		},
		"EntityFramework": {
			"ConnectionString": ""
		}
	},
	"XboxLive": {
		"Authentication": {
			"MicrosoftAccount": "",
			"MicrosoftAccountPassword": "",
			"ApiEndpoint": ""
		},
		"DocumentDb": {
			"DatabaseId": "",
			"CollectionId": "",
			"AccessKey": "",
			"Endpoint": ""
		},
		"EntityFramework": {
			"ConnectionString": ""
		}
	}
}
```

Populate these settings with the appropirate values. Where provided Microsoft Account's must have played the service they are inside.


### Migrations

I've written a migration manager located in `scripts/migrations.cmd`. This tool can be used to execute migrations on the various services. Sample usages are as so:

- Apply Migrations to all applicable projects:
``` bash
> ./migrations.cmd apply all
```

- Add Migration called `AddedXuidModel` to the `Branch.Service.XboxLive` project:
``` bash
> ./migrations.cmd add Branch.Service.XboxLive AddedXuidModel
```


### Contributing

If you want to contribute to this, great! Here is the rule-set:
- All spacing must be tabs. It's 2015, cmmon people.
- Write tests for your changes. I know I haven't, but that's because I fucking hate Moq and all that shit.
- If you're editing HTML/SCSS, provide before/after examples and explain your reasoning.
- Write nice code. This is `c# 6`, so we have all that cool shit to work with now.


### Note about reversing

Everything here was researched by myself, with no aid from SDK's or other peoples hard work.


### Thanks To

- Bungie
- 343 Industries
- Microsoft
- iBotPeaches
