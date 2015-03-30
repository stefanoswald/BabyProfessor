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
"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" /UseVsixExtensions:true /Enablecodecoverage /InIsolation "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\full.dll" | "C:\Program Files (x86)\Jenkins\wtee.exe" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\vsoutput.txt"

echo "Converting .coverage file";
findAndMoveCoverageFile.py

"C:\Users\Stefan\Documents\Visual Studio 2012\Projects\ConsoleApplication6\ConsoleApplication6\bin\Debug\ConsoleApplication6.exe" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\raw.coverage" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\full.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\converted.coveragexml"

ReportGen\ReportGenerator.exe -reports:"C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\converted.coveragexml" -targetdir:HtmlReport
