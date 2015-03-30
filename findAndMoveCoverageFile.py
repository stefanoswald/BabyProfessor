import os
fp = open("C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/vsoutput.txt")
coverage = ".coverage"
for line in fp:
 if line.find(coverage) > -1:
  source = line.strip()
  print source
  os.rename(source, "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage")

fp.close()
