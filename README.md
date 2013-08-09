TridionContextEngine
====================

A library to use with SDL's Tridion Context Engine Cartridge. Exposes claims as strongly-typed properties of Device, Browser and Os

IMPORTANT
=========

You must have a running SDL Tridion Content Delivery instance with a correctly configured Ambient Data Framework AND WITH the Context Engine Cartridge installed.
Contact SDL's customer support for a copy of the Context Engine Cartridge.

This library is basically a wrapper around the ADF claims, allowing you to use strongly-typed variables for the properties exposed by the cartridge

USAGE
=====

In a code-behind block (or razor view or whatever):

using Sdl.Tridion.Context;

[...]

ContextEngine context = new ContextEngine();
if(context.Browser.DisplayWidth < 320)
   // show small navigation (for instance)

or 
if(context.Device.PixelRatio == 2)
  // Show a retina-display ready image
  
  
or
if(context.Device.IsTablet)
or
if(context.Device.IsMobile)
etc

Have fun
