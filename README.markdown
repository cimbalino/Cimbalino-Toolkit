# Cimbalino Toolkit

![Cimbalino Toolkit][3]

### [Official Site][1] - [@CimbalinoWP][2]

Cimbalino Toolkit is a set of useful and powerful tools that will help you build your Windows Platform applications.

The toolkit is fully compatible with:

* Windows Phone Silverlight 8.0 and 8.1 apps (WP8)
* Windows Phone 8.1 apps (WPA81)
* Windows Store 8.1 apps (Win81)

## NuGet packages

* [Cimbalino.Toolkit.Core](https://www.nuget.org/packages/Cimbalino.Toolkit.Core) - The PCL portion of the toolkit (compatible with background agents)
* [Cimbalino.Toolkit](https://www.nuget.org/packages/Cimbalino.Toolkit) - The main component of the toolkit

## FAQ

### Why do I keep getting NotImplementedExceptions when calling methods from the PCL library?

The toolkit uses the ["Bait and Switch PCL trick"](http://log.paulbetts.org/the-bait-and-switch-pcl-trick/) from Paul Betts to properly support platform implementations, so please **use NuGet to add the packages to ALL your projects and don't add assemblies manually!**

### What about Windows Phone 7.x support?

The Cimbalino Toolkit does not support Windows Phone 7.x, but you can still use the [Cimbalino Windows Phone Toolkit](https://github.com/Cimbalino/Cimbalino-Phone-Toolkit) for that!

### Are there any plans to support other platforms?

Yes, there are some plans in the making, but that will still take some time... :) 

## License

See the [LICENSE.txt][4] file for details.

## Acknowledgments

* [Paulo Morgado](https://twitter.com/PauloMorgado)
* [Scott Lovegrove](https://twitter.com/scottisafool)
* [Sara Silva](https://twitter.com/saramgsilva)
* [Jeff Wilcox](https://twitter.com/jeffwilcox)
* All developers that use this toolkit in their apps! :)

## Sponsors

* [JetBrains ReSharper][5] - The best C# & VB.NET refactoring plugin for Visual Studio!

[1]: http://cimbalino.org
[2]: http://twitter.com/CimbalinoWP
[3]: https://github.com/Cimbalino/Cimbalino-Toolkit/raw/master/Cimbalino.Toolkit.png "Cimbalino Toolkit"
[4]: https://github.com/Cimbalino/Cimbalino-Toolkit/raw/master/LICENSE.txt "Cimbalino Toolkit License"
[5]: http://www.jetbrains.com/resharper