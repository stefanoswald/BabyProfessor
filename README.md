# BabyProfessor
An infinite scrolling game where Baby Professor must shoot enemies, get power-ups, and jump over spikes to stay alive as long as possible.

To perform code coverage testing using Jenkins:

Required Software:
Windows 7*
Visual Studio 2012 Premium**
Python
Unity with Unit Testing Plugin Installed
ReportGenerator.exe
WTee
NunitAdapter (version 1.0.0.0)

1) Follow the instructions found here: http://codingdebauchery.blogspot.com/2014/03/code-coverage-for-unityc.html
(Don't worry, we will set your computer up on Monday to run these tests)


Throw this in your Jenkins as an exectue batch command: 

:: path corrector because bug: https://issues.jenkins-ci.org/browse/JENKINS-3425
set PATH=%PATH:"=%
generateCoverage.bat
