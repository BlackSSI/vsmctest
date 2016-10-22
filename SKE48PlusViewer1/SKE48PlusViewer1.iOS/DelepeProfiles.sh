#!/bin/sh

echo ----- ls 2
ls /Users/tfsbuild/Library/MobileDevice

echo ----- find
find /Users/tfsbuild -name iOSBuildTest1.* -print

exit

echo ----- ls 3
ls "/Users/tfsbuild/Library/MobileDevice/Provisioning Profiles"

rm /Users/tfsbuild/Library/MobileDevice/Provisioning Profiles/*
