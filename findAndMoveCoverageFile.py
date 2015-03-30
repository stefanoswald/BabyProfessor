import os
fp = open("C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/vsoutput.txt")
coverage = ".coverage"
dest = "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage"
for line in fp:
<<<<<<< HEAD
    if coverage in line:
        s = line.strip()
        print(s)
        print(dest)
        #loop through s, replace \ with / character
        os.rename(s, dest)

=======
 if line.find(coverage) > -1:
  source = line.strip()
  print source
  os.rename(source, "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage")
>>>>>>> origin/master

fp.close()
