Tridion Context Engine Wrapper
====================

To do Mobile in SDL Tridion you can use this library along with the Context Engine Ambient Data Framework.

A C# and Java library to use with SDL's Tridion Context Engine Cartridge. Exposes claims as strongly-typed properties of Device, Browser and Operating System

Also has ASP.NET web controls that can display different markup for Device Families which are configurable in the Families XML file.

Important
=========

You must have a running SDL Tridion Content Delivery instance with a correctly configured Ambient Data Framework AND WITH the Context Engine Cartridge installed.
Contact SDL's customer support for a copy of the Context Engine Cartridge.

This library is basically a wrapper around the ADF claims, allowing you to use strongly-typed variables for the properties exposed by the cartridge

How to use
=====

**Using the cartridge directly**

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

**Using the ASP.NET Family control**
The Family control
```
<context:Family Name="smartphone">
   <img src="_images/blah_w220.jpg" srcset="/_images/blah_w440.jpg 2x" />
</context:Family>
<context:Family Name="desktop">
   <img src="_images/blah_w440.jpg" srcset="/_images/blah_w440.jpg 2x" />
</context:Family>
<context:Family Name="phone">
   <img src="_images/blah_w220.jpg" srcset="/_images/blah_w440.jpg 2x" />
</context:Family>
```

Configuring Device Family conditions
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <devicefamily name="featurephone">
    <condition uri="taf:claim:context:device:mobile" value="true" />
    <condition uri="taf:claim:context:device:tablet" value="false" />
    <condition uri="taf:claim:context:device:displayWidth" value="&lt;320" />
  </devicefamily>
  <devicefamily name="smartphone">
    <condition uri="taf:claim:context:device:mobile" value="true"/>
    <condition uri="taf:claim:context:device:tablet" value="false" />
    <condition uri="taf:claim:context:device:displayWidth" value="&gt;319" />
  </devicefamily>
  <devicefamily name="tablet">
    <condition uri="taf:claim:context:device:tablet" value="true" />
  </devicefamily>
  <devicefamily name="desktop">
    <condition uri="taf:claim:context:device:mobile" value="false"/>
    <condition uri="taf:claim:context:device:tablet" value="false" />
  </devicefamily>
 </configuration>
```
