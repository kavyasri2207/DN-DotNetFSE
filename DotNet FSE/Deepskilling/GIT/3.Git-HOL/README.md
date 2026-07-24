# Hands-On Lab: Git Branching and Merging

## Objectives
* Explain branching and merging.
* Explain creating a branch/merge request in GitLab/GitHub.
* Construct a branch, add changes, and merge it with the master/trunk.

---

## 1. Theoretical Explanations

### Branching and Merging
* **Branching**: Branching allows you to diverge from the main line of development (the trunk) and continue to do work without affecting the main line. It creates a safe, isolated environment to build a new feature or fix a bug. 
* **Merging**: Merging is Git's way of putting a forked history back together. The `git merge` command lets you take the independent lines of development created by branching and safely integrate them back into the main branch.

### Branch and Merge Requests in GitLab/GitHub
* **Branch Request**: Pushing a local branch to a remote server so that others can view and collaborate on your isolated work.
* **Merge Request (Pull Request)**: A formal request to merge your completed branch into the main trunk. It allows the team to review the code, discuss modifications, and approve the changes before they are permanently integrated into the master branch.

---

## 2. Implementation & Simulated Output

### Part A: Branching

**1. Create a new branch**
```bash
$ git branch GitNewBranch
```

**2. List all local and remote branches**
```bash
$ git branch -a
  GitNewBranch
* master
  remotes/origin/master
```
*(The `*` indicates that we are currently still on the master branch).*

**3. Switch to the newly created branch and add files**
```bash
$ git checkout GitNewBranch
Switched to branch 'GitNewBranch'

$ echo "This is a new feature" > feature.txt
$ git add feature.txt
```

**4. Commit the changes to the branch**
```bash
$ git commit -m "Added feature.txt to GitNewBranch"
[GitNewBranch 8f3a9b1] Added feature.txt to GitNewBranch
 1 file changed, 1 insertion(+)
 create mode 100644 feature.txt
```

**5. Check the status**
```bash
$ git status
On branch GitNewBranch
nothing to commit, working tree clean
```

---

### Part B: Merging

**1. Switch back to the master branch**
```bash
$ git checkout master
Switched to branch 'master'
```

**2. List command-line differences between trunk and branch**
```bash
$ git diff master..GitNewBranch
diff --git a/feature.txt b/feature.txt
new file mode 100644
index 0000000..a6f8b9
--- /dev/null
+++ b/feature.txt
@@ -0,0 +1 @@
+This is a new feature
```

**3. List visual differences using P4Merge**
```bash
$ git difftool --tool=p4merge master..GitNewBranch
```
*(This command launches the P4Merge GUI tool, visually highlighting the new file and line additions in green).*

**4. Merge the source branch to the trunk**
```bash
$ git merge GitNewBranch
Updating 1a2b3c4..8f3a9b1
Fast-forward
 feature.txt | 1 +
 1 file changed, 1 insertion(+)
 create mode 100644 feature.txt
```

**5. Observe the logging after merging**
```bash
$ git log --oneline --graph --decorate
* 8f3a9b1 (HEAD -> master, GitNewBranch) Added feature.txt to GitNewBranch
* 1a2b3c4 Initial commit
```

**6. Delete the branch and observe the status**
```bash
$ git branch -d GitNewBranch
Deleted branch GitNewBranch (was 8f3a9b1).

$ git status
On branch master
nothing to commit, working tree clean
```
