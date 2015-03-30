import os
fp = open("C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/vsoutput.txt")
coverage = ".coverage"
dest = "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage"
for line in fp:
    if coverage in line:
        s = line.strip()
        print(s)
        print(dest)
        #loop through s, replace \ with / character
        os.rename(s, dest)


fp.close()
