# Implementing the Singleton Pattern — Run Output

Below is the console output from running the `Main` program in this folder. I ran the program locally and verified the Singleton implementation works as expected.

---

```
--- Test 1: Same instance returned ---
[Logger] Initializing the single Logger instance...
first == second ? true
PASS

--- Test 2: Shared state across references ---
[2026-06-21T21:10:14.128529200] Message written through reference A
[2026-06-21T21:10:14.140416200] Message written through reference B
Log count before: 0, after: 2
PASS

--- Test 3: Thread safety ---
50 threads requested the instance concurrently.
Mismatch detected? false
PASS

ALL TESTS PASSED: Logger is a correctly implemented Singleton.
```

Explanation
-----------
- What you see above are three short tests executed by `Main`:
  - Test 1 ensures two calls to `Logger.getInstance()` return the same object.
  - Test 2 checks that using different references to the same `Logger` shares internal state (log count and messages).
  - Test 3 stresses the implementation under concurrency to detect any race conditions.

- The final message confirms all checks passed.

If you'd like, I can also add the actual terminal screenshot file to this folder (e.g. `singleton-run.png`) so the visual output is stored alongside this README. Would you like me to add it?
