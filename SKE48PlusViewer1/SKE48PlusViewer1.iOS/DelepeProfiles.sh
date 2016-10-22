#!/bin/sh

echo ----- ls 2
ls /Users/tfsbuild/Library/MobileDevice

echo ----- ls 3
ls "/Users/tfsbuild/Library/MobileDevice/Provisioning Profiles"

rm /Users/tfsbuild/Library/MobileDevice/Provisioning Profiles/*
