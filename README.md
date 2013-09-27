TridionContextEngine
====================

A C# and Java library to use with SDL's Tridion Context Engine Cartridge. Exposes claims as strongly-typed properties of Device, Browser and Os

Also has a ASP.NET web control that can display different markup for Device Families

IMPORTANT
=========

You must have a running SDL Tridion Content Delivery instance with a correctly configured Ambient Data Framework AND WITH the Context Engine Cartridge installed.
Contact SDL's customer support for a copy of the Context Engine Cartridge.

This library is basically a wrapper around the ADF claims, allowing you to use strongly-typed variables for the properties exposed by the cartridge

USAGE
=====

In a code-behind block (or Razor view or whatever):

```
using Sdl.Tridion.Context;

[...]

ContextEngine context = new ContextEngine();
if(context.Browser.DisplayWidth < 320)
   // show small navigation (for instance)
```

or 

```
if(context.Device.PixelRatio == 2)
  // Show a retina-display ready image
```  
or
```
if(context.Device.IsTablet)
```
or
```
if(context.Device.IsMobile)
```

Have fun
