# Hands-On Lab: Git Configuration & Version Control

## Objectives
* Familiarize with Git commands: `git init`, `git status`, `git add`, `git commit`, `git push`, and `git pull`.
* Setup local machine with Git global configuration.
* Integrate Notepad++ to Git and make it the default editor.
* Add a file to a source code repository and track it.

---

## Step 1: Setup Machine with Git Configuration

To begin, we verify the Git installation and configure our global user identity.

### 1. Verify Git Installation
```bash
$ git version
git version 2.21.0.windows.1
```
*The output confirms that the Git Client is installed properly on the machine.*

### 2. Configure User Credentials
```bash
$ git config --global user.name "username"
$ git config --global user.email "username@cognizant.com"
```

### 3. Verify Global Configuration
```bash
$ git config --global --list
user.name=username
user.email=username@cognizant.com
```

---

## Step 2: Integrate Notepad++ to Git as Default Editor

By default, Git uses Vim. In this step, we map Notepad++ to our bash environment and configure Git to use it.

### 1. Environment Variable Setup
If typing `notepad++` in Git Bash returns `command not found`, it means the executable is not in the system path. 
* **Action taken**: Navigated to Control Panel -> System -> Advanced System Settings -> Environment Variables, and appended the path to `notepad++.exe` (e.g., `C:\Program Files (x86)\Notepad++`) into the `Path` variable.

### 2. Create Bash Alias for Notepad++
```bash
$ notepad++.exe bash -profile
```
Inside the generated profile file in Notepad++, we added the following alias so the terminal recognizes `npp`:
```bash
alias npp='notepad++.exe -multiInst -nosession'
```

### 3. Configure Git Global Editor
```bash
$ git config --global core.editor "notepad++.exe -multiInst -nosession"
```

### 4. Verify Default Editor
```bash
$ git config --global -e
hint: Waiting for your editor to close the file...
```
*Executing this command successfully opens Notepad++ displaying the global `.gitconfig` file.*

---

## Step 3: Add a File to Source Code Repository

With configuration complete, we initialize a repository and track our first file.

### 1. Initialize Repository
```bash
$ git init GitDemo
Initialized empty Git repository in D:/Development_Avecto/GitDemo/.git/
```

### 2. Verify Hidden `.git` Directory
```bash
$ ls -al
total 8
drwxr-xr-x 1 1049089 0 Jan 13 11:54 ./
drwxr-xr-x 1 1049089 0 Jan 13 11:54 ../
drwxr-xr-x 1 1049089 0 Jan 13 11:54 .git/
```

### 3. Create File and Verify Content
```bash
$ echo "Welcome to the version control" >> welcome.txt

$ ls -al
total 9
drwxr-xr-x 1 494096 1049089 0 Jan 13 12:02 ./
drwxr-xr-x 1 494096 1049089 0 Jan 13 11:54 ../
drwxr-xr-x 1 494096 1049089 0 Jan 13 12:01 .git/
-rw-r--r-- 1 494096 1049089 31 Jan 13 12:02 welcome.txt

$ cat welcome.txt
Welcome to the version control
```

### 4. Check Repository Status
```bash
$ git status
On branch master
No commits yet
Untracked files:
  (use "git add <file>..." to include in what will be committed)
        welcome.txt
```

### 5. Track the File (Staging)
```bash
$ git add welcome.txt
warning: LF will be replaced by CRLF in welcome.txt.
The file will have its original line endings in your working directory
```

### 6. Commit the File
We execute the commit command, which automatically opens our newly configured default editor (Notepad++) to write the multi-line commit message.
```bash
$ git commit
```

### 7. Final Status Check
```bash
$ git status
On branch master
nothing to commit, working tree clean
```
*The file `welcome.txt` has been successfully added to the local repository.*

---

## Remote Repository Operations (GitLab/GitHub)
To sync this local repository with a remote server:
1. Created a remote repository named `GitDemo`.
2. Pulled any existing remote changes (if applicable):
   `git pull origin master`
3. Pushed the local commits to the remote repository:
   `git push origin master`
