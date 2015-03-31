import os
fp = open("C:/Users/JaggerMcClaw/Desktop/PythonTest/PullFile.txt")
coverage = ".txt"
dest = "C:/Users/JaggerMcClaw/Desktop/PythonTest/2/vsoutput.txt"
for line in fp:
    if coverage in line:
        s = line.strip()
        s = s.replace('\\','/')
        print(s)
        print(dest)
        os.rename(s, dest)


fp.close()
