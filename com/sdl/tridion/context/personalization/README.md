SetClaimsAsCharacteristics
==========================

This is a Tridion Ambient Framework cartridge that will:
 - Find your visitor's WAI ID
 - Load all context claims as WAI CustomerCharacteristics


USAGE
=====

Get the code (.java) and the .xml packaged into a jar file somehow (choose your poison) and add it to the classpath of your web application (/WEB-INF/lib or /bin/lib).
Add the following to your cd_ambient_conf.xml:
&lt;Cartridge File="c2c.xml" /&gt;
Enjoy.

The cartridge will remain the URIs as follows:
taf:claim:context:device:mobile -> device.mobile
taf:claim:context:browser:cssVersion -> browser.cssVersion
etc.
