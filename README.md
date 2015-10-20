branch
===
[![Build status](https://img.shields.io/appveyor/ci/0xdeafcafe/branch.svg?style=flat-square&label=windows%20build)](https://ci.appveyor.com/project/0xdeafcafe/branch/branch/vnext) [![Github Issues](https://img.shields.io/github/issues/TheTree/branch.svg?style=flat-square)](https://github.com/TheTree/branch/issues) [![Github Forks](https://img.shields.io/github/forks/TheTree/branch.svg?style=flat-square)](https://github.com/TheTree/branch/network) [![Github Stars](https://img.shields.io/github/stars/TheTree/branch.svg?style=flat-square)](https://github.com/TheTree/branch/stargazers) [![Github License](https://img.shields.io/github/license/thetree/branch-vnext-auth.svg?style=flat-square)](https://github.com/thetree/branch/blob/vnext/LICENSE.md)


AspNet5 application for viewing Xbox Live, Halo: Reach, and Halo 4 stats. Expandable and service based for easy addition of new titles with minimal reworking.


### Getting Started

Pull the git repo to begin.
``` bash
> git clone git@github.com:TheTree/branch.git
> cd branch
> dnu restore
> cd src\Branch.Web
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
