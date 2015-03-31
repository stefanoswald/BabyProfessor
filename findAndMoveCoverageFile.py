import os

fp = open("C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/vsoutput.txt")
coverage = ".coverage"
dest = "C:/Program Files (x86)/Jenkins/jobs/Baby Professor/workspace/CodeCoverage/tmp/raw.coverage"
for line in fp:
    if coverage in line:
        s = line.strip()#remove spaces before file path
        s = s.replace('\\','/')#switch \ for /
        os.rename(s, dest)#send to dest directory and rename file to end of dest


fp.close()
