import os

fp = open("C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/vsoutput.txt")
coverage = ".coverage"
for line in fp:
 if line.find(coverage) > -1:
  print line.strip()
  os.rename(line.strip(), "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage")


fp.close()
