# Hands-On Lab: Git Conflict Resolution

## Objectives
* Explain how to resolve a conflict during a merge.
* Implement conflict resolution using 3-way merge tools (P4Merge) when trunk and branch modifications collide.

---

## 1. Theoretical Explanation: Conflict Resolution
A **Merge Conflict** occurs when Git is unable to automatically resolve differences in code between two commits. This usually happens when the exact same line of a file is modified differently in both the `master` trunk and a secondary branch. 

When a conflict happens, Git pauses the merge process and marks the conflicting areas inside the file using Git mark-up markers (`<<<<<<<`, `=======`, `>>>>>>>`). The developer must manually review the file, choose which changes to keep, and save it. Tools like **P4Merge** provide a 3-way visual interface (Base, Local, Remote) to make resolving these conflicts significantly easier.

---

## 2. Implementation & Simulated Output

### Step 1-4: Branch Creation & Modification
```bash
$ git status
On branch master
nothing to commit, working tree clean

$ git checkout -b GitWork
Switched to a new branch 'GitWork'

$ echo "<greeting>Hello from GitWork Branch!</greeting>" > hello.xml
$ git status
Untracked files:
        hello.xml

$ git add hello.xml
$ git commit -m "Added hello.xml in GitWork branch"
[GitWork 5a2b3c1] Added hello.xml in GitWork branch
```

### Step 5-7: Master Trunk Modification (Creating the Conflict)
```bash
$ git checkout master
Switched to branch 'master'

$ echo "<greeting>Hello from Master Trunk!</greeting>" > hello.xml
$ git add hello.xml
$ git commit -m "Added hello.xml in Master trunk"
[master 8d4e5f2] Added hello.xml in Master trunk
```

### Step 8-10: Observing the Differences
```bash
$ git log --oneline --graph --decorate --all
* 8d4e5f2 (HEAD -> master) Added hello.xml in Master trunk
| * 5a2b3c1 (GitWork) Added hello.xml in GitWork branch
|/
* 1a2b3c4 Initial commit

$ git diff master..GitWork
diff --git a/hello.xml b/hello.xml
--- a/hello.xml
+++ b/hello.xml
@@ -1 +1 @@
-<greeting>Hello from Master Trunk!</greeting>
+<greeting>Hello from GitWork Branch!</greeting>

$ git difftool --tool=p4merge master..GitWork
```
*(P4Merge UI launches, visually highlighting the differences between the two hello.xml versions).*

### Step 11-12: Triggering the Merge Conflict
```bash
$ git merge GitWork
Auto-merging hello.xml
CONFLICT (add/add): Merge conflict in hello.xml
Automatic merge failed; fix conflicts and then commit the result.

$ cat hello.xml
<<<<<<< HEAD
<greeting>Hello from Master Trunk!</greeting>
=======
<greeting>Hello from GitWork Branch!</greeting>
>>>>>>> GitWork
```

### Step 13-14: Resolving the Conflict
```bash
$ git mergetool --tool=p4merge
```
*(P4Merge 3-way merge tool launches. The conflict is manually resolved to include both greetings, and saved).*
```bash
$ git commit -m "Merge branch 'GitWork' into master, resolved hello.xml conflict"
[master 3f4a5b6] Merge branch 'GitWork' into master, resolved hello.xml conflict
```

### Step 15-16: Handling Backup Files
```bash
$ git status
Untracked files:
        hello.xml.orig

$ echo "*.orig" > .gitignore
$ git add .gitignore
$ git commit -m "Added *.orig backup files to gitignore"
[master 7b8c9d0] Added *.orig backup files to gitignore
```

### Step 17-19: Cleanup and Final Log
```bash
$ git branch -a
  GitWork
* master

$ git branch -d GitWork
Deleted branch GitWork (was 5a2b3c1).

$ git log --oneline --graph --decorate
* 7b8c9d0 (HEAD -> master) Added *.orig backup files to gitignore
*   3f4a5b6 Merge branch 'GitWork' into master, resolved hello.xml conflict
|\
| * 5a2b3c1 Added hello.xml in GitWork branch
* | 8d4e5f2 Added hello.xml in Master trunk
|/
* 1a2b3c4 Initial commit
```
