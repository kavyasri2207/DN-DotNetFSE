# Hands-On Lab: Git Cleanup and Remote Push

## Objectives
* Explain how to clean up a local repository.
* Explain how to synchronize local changes by pushing them back to a remote Git repository.

---

## 1. Theoretical Explanation
After resolving conflicts and merging branches (such as in the previous Hands-On Lab), it is crucial to synchronize your local repository with your remote repository (e.g., GitHub or GitLab).
* **Cleanup**: This involves ensuring the working directory is clean, untracked/backup files (like `.orig`) are ignored or removed, and old merged branches are deleted so the repository remains organized.
* **Pulling (`git pull`)**: Fetches the latest changes from the remote server and merges them into the local repository. This ensures your local codebase is completely up-to-date before you attempt to push.
* **Pushing (`git push`)**: Uploads all of your newly committed local changes and merged histories up to the remote repository so the rest of the team can access them.

---

## 2. Implementation & Simulated Output

### Step 1: Verify Master is in a Clean State
We check the status to ensure there are no uncommitted changes left over from the previous conflict resolution lab.
```bash
$ git status
On branch master
Your branch is ahead of 'origin/master' by 3 commits.
  (use "git push" to publish your local commits)

nothing to commit, working tree clean
```

### Step 2: List All Available Branches
We list the branches to verify that our cleanup in the previous lab (deleting the temporary `GitWork` branch) was completely successful.
```bash
$ git branch -a
* master
  remotes/origin/master
```

### Step 3: Pull Remote Repository to Master
Before pushing our changes, it is best practice to pull any potential updates from the remote server to avoid conflicts or rejected pushes.
```bash
$ git pull origin master
From https://github.com/username/GitDemo
 * branch            master     -> FETCH_HEAD
Already up to date.
```

### Step 4: Push Pending Changes to Remote
We push the conflict resolution commits from the previous hands-on lab to the remote repository.
```bash
$ git push origin master
Enumerating objects: 11, done.
Counting objects: 100% (11/11), done.
Delta compression using up to 8 threads
Compressing objects: 100% (6/6), done.
Writing objects: 100% (7/7), 724 bytes | 724.00 KiB/s, done.
Total 7 (delta 2), reused 0 (delta 0), pack-reused 0
To https://github.com/username/GitDemo.git
   1a2b3c4..7b8c9d0  master -> master
```

### Step 5: Observe Changes in Remote Repository
* **Action**: Navigated to the GitHub/GitLab web interface for the remote repository. 
* **Observation**: The commit history online now accurately reflects the merged branches, and the `hello.xml` file is visible in the master branch containing the successfully resolved 3-way merge.
