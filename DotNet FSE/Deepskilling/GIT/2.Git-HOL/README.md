# Hands-On Lab: Understanding `.gitignore`

## Objectives
* Explain what `git ignore` is.
* Explain how to ignore unwanted files using `.gitignore`.
* Implement the `.gitignore` command to ignore unwanted files and folders (.log files and log folders).

---

## 1. Explanation of Git Ignore

**What is `.gitignore`?**
A `.gitignore` file is a plain text file that contains a list of files, directories, or patterns that you want Git to intentionally ignore and *not* track in the version control system. 

**How to ignore unwanted files?**
To ignore files, you simply create a file named exactly `.gitignore` in the root of your repository (or any sub-folder) and write patterns inside it. 
* To ignore a specific file: `filename.txt`
* To ignore all files with a certain extension: `*.log`
* To ignore an entire folder and its contents: `folder_name/`

---

## 2. Implementation & Simulated Output

For this Hands-On Lab, we created dummy `.log` files and a `logs` folder to verify that Git ignores them.

### Step 1: Creating the Files
```bash
$ mkdir logs
$ echo "This is a debug log" > logs/debug.log
$ echo "This is a root log" > test.log
```

### Step 2: Checking Git Status (Before Ignore)
Before setting up the ignore rules, Git sees the files as "Untracked" and wants to add them:
```bash
$ git status
Untracked files:
  (use "git add <file>..." to include in what will be committed)
        logs/
        test.log
```

### Step 3: Updating `.gitignore`
We created a `.gitignore` file containing the following rules:
```text
*.log
logs/
```

### Step 4: Checking Git Status (After Ignore)
When we check the status again, the `.log` file and the `logs` folder completely disappear from the untracked list, proving that Git is now ignoring them! Only the `.gitignore` file itself is tracked:
```bash
$ git status
Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitignore
```

### Step 5: Committing the configuration
```bash
$ git add .gitignore
$ git commit -m "Added .gitignore configuration to ignore log files"
```

*The `test.log` and the `logs` folder will never be committed to the repository.*
