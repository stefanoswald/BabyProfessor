echo "Setting up environment variables"
call VsDevCmd.bat

echo "cleaning house"
rd TestResults /s /q
rd HtmlReport /s /q
rd tmp /s /q
mkdir tmp

echo "Copying dependencies";
copy c:\Path\To\nunit.framework.dll c:\jenkins\workspace\CodeCoverage\tmp\ 
copy c:\Path\To\nunit.core.dll c:\jenkins\workspace\CodeCoverage\tmp\
copy c:\Path\To\nunit.core.interfaces.dll c:\jenkins\workspace\CodeCoverage\tmp\
copy c:\Path\To\Mono.Cecil.dll c:\jenkins\workspace\CodeCoverage\tmp\
copy c:\Path\To\Mono.Cecil.Mdb.dll c:\jenkins\workspace\CodeCoverage\tmp\
copy "C:\Path\To\UnityEngine.dll" c:\jenkins\workspace\CodeCoverage\tmp\
copy "C:\Path\To\PlayMaker\PlayMaker.dll" c:\jenkins\workspace\CodeCoverage\tmp\
copy "C:\Path\To\HOTween.dll" c:\jenkins\workspace\CodeCoverage\tmp\
copy "C:\Path\To\NSubstitute.dll" c:\jenkins\workspace\CodeCoverage\tmp\

echo "Generating DLL";
csc.exe @full.rsp

echo "Generating .coverage file";
vstest.console.exe /UseVsixExtensions:true /Enablecodecoverage /InIsolation C:\Jenkins\workspace\CodeCoverage\tmp\full.dll | wtee tmp\vsoutput.txt

echo "Converting .coverage file";
findAndMoveCoverageFile.py

CoverageConverter\CodeCoverageConverter.exe tmp\raw.coverage tmp\full.dll tmp\converted.coveragexml

ReportGen\ReportGenerator.exe -reports:tmp\converted.coveragexml -targetdir:HtmlReport
