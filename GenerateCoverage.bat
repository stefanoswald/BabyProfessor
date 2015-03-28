echo "Setting up environment variables"
call VsDevCmd.bat

echo "cleaning house"
rd TestResults /s /q
rd HtmlReport /s /q
rd tmp /s /q
mkdir tmp

echo "Copying dependencies";
copy "C:\Program Files (x86)\NUnit 2.6.4\bin\framework\nunit.framework.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp"
copy "C:\Program Files (x86)\NUnit 2.6.4\bin\lib\nunit.core.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files (x86)\NUnit 2.6.4\bin\lib\nunit.core.interfaces.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files (x86)\Mono\lib\mono\gac\Mono.Cecil\0.9.5.0__0738eb9f132ed756\Mono.Cecil.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files (x86)\Mono\lib\mono\gac\Mono.Cecil.Mdb\0.9.5.0__0738eb9f132ed756\Mono.Cecil.Mdb.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files\Unity\Editor\Data\PlaybackEngines\metrosupport\Players\Windows81\X86\release\UnityEngine.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
echo "Generating DLL";
C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe @full.rsp

echo "Generating .coverage file";
vstest.console.exe /UseVsixExtensions:true /Enablecodecoverage /InIsolation C:\Jenkins\workspace\CodeCoverage\tmp\full.dll | wtee tmp\vsoutput.txt

echo "Converting .coverage file";
findAndMoveCoverageFile.py

CoverageConverter\CodeCoverageConverter.exe tmp\raw.coverage tmp\full.dll tmp\converted.coveragexml

ReportGen\ReportGenerator.exe -reports:tmp\converted.coveragexml -targetdir:HtmlReport
