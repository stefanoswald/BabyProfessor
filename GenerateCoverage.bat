echo "Setting up environment variables"
call "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\Tools\VsDevCmd.bat"

echo "cleaning house"
rd TestResults /s /q
rd HtmlReport /s /q
rd tmp /s /q
mkdir tmp

echo "Copying dependencies";
copy "C:\BabyProfessor\NUnit 2.6.4\bin\framework\nunit.framework.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp"
copy "C:\Program Files (x86)\NUnit 2.6.4\bin\lib\nunit.core.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\BabyProfessor\NUnit 2.6.4\bin\lib\nunit.core.interfaces.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files (x86)\Mono\lib\mono\gac\Mono.Cecil\0.9.5.0__0738eb9f132ed756\Mono.Cecil.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files (x86)\Mono\lib\mono\gac\Mono.Cecil.Mdb\0.9.5.0__0738eb9f132ed756\Mono.Cecil.Mdb.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\Program Files\Unity\Editor\Data\PlaybackEngines\metrosupport\Players\Windows81\X86\release\UnityEngine.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
copy "C:\BabyProfessor\NSubstitute.1.8.1.0\lib\net45\NSubstitute.dll" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\"
echo "Generating DLL";
C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe @full.rsp

echo "Generating .coverage file";
"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" /UseVsixExtensions:true /Enablecodecoverage /InIsolation /Tests:SampleTests "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\full.dll" | "C:\Program Files (x86)\Jenkins\wtee.exe" "C:\Program Files (x86)\Jenkins\jobs\Baby Professor\workspace\CodeCoverage\tmp\vsoutput.txt"

echo "Converting .coverage file";
start "C:\Program Files (x86)\Python34\python.exe" C:\Users\Stefan\Desktop\BabyProfessor\findAndMoveCoverageFile.py

"C:\Users\Stefan\Documents\Visual Studio 2012\Projects\ConsoleApplication8\ConsoleApplication8\bin\Debug\ConsoleApplication8.exe" "C:\BabyProfessor\tmp\SYSTEM_BIGMAC 2015-03-30 10_20_55.coverage" "C:\BabyProfessor\tmp\full.dll" "C:\BabyProfessor\tmp\converted.coveragexml"

"C:\BabyProfessor\tmp\ReportGenerator_2.1.4.0\bin\ReportGenerator.exe" -reports:"C:\BabyProfessor\tmp\converted.coveragexml" -targetdir:"C:\BabyProfessor\tmp\HtmlReport"
