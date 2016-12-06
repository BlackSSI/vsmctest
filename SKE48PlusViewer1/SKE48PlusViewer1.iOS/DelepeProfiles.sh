#!/bin/sh

echo ----- ls 2
ls /Users/vstsbuild/Library/MobileDevice

echo ----- find
find /Users/vstsbuild -name iOSBuildTest1.* -print

exit

echo ----- ls 3
ls "/Users/vstsbuild/Library/MobileDevice/Provisioning Profiles"

rm /Users/vstsbuild/Library/MobileDevice/Provisioning Profiles/*
