# Financial Forecasting - Analysis

## 1. Understand Recursive Algorithms

**What is Recursion?**
Recursion is a programming technique where a method calls *itself* to solve a smaller instance of the same problem. A recursive algorithm always has two main components:
1.  **Base Case**: The condition where the algorithm stops calling itself to prevent an infinite loop (e.g., when time periods hit 0).
2.  **Recursive Case**: The part of the algorithm that breaks the problem down and calls itself with modified parameters.

**How it simplifies problems:**
Recursion simplifies problems that have a naturally repetitive or hierarchical structure (like mathematical sequences, continuous growth models, or tree traversals). Instead of writing complex `for` or `while` loops with external tracking variables, recursion allows you to write clean, declarative code that mathematically defines the process.

## 4. Analysis & Optimization

**Time Complexity:**
The time complexity of the standard recursive financial forecasting algorithm is **O(n)**, where *n* is the number of periods (e.g., years). This is because the algorithm makes exactly one recursive call for each period until it reaches the base case of 0. 

**How to optimize recursive solutions:**
If a recursive algorithm branches heavily and calculates the same values multiple times (such as analyzing complex stock trees or a naive Fibonacci sequence which runs in $O(2^n)$), it leads to excessive computation and potential stack overflow errors. 

To optimize this, we use a technique called **Memoization**. 
Memoization involves storing the results of expensive function calls in a cache data structure (like a `HashMap` or an Array). Before the recursive method performs a calculation, it checks if the result for that specific state already exists in the cache. If it does, it returns the cached value instantly in **O(1)** time, completely avoiding redundant, overlapping computation.
