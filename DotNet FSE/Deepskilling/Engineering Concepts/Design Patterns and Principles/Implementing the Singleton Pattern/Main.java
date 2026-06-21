import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        boolean allPassed = true;

        System.out.println("--- Test 1: Same instance returned ---");
        Logger first = Logger.getInstance();
        Logger second = Logger.getInstance();
        boolean sameInstance = (first == second);
        System.out.println("first == second ? " + sameInstance);
        if (sameInstance) {
            System.out.println("PASS\n");
        } else {
            System.out.println("FAIL\n");
            allPassed = false;
        }

        System.out.println("--- Test 2: Shared state across references ---");
        int countBefore = first.getLogCount();
        first.log("Message written through reference A");
        second.log("Message written through reference B");
        int countAfter = first.getLogCount();
        System.out.println("Log count before: " + countBefore + ", after: " + countAfter);
        if (countAfter == countBefore + 2) {
            System.out.println("PASS\n");
        } else {
            System.out.println("FAIL\n");
            allPassed = false;
        }

        System.out.println("--- Test 3: Thread safety ---");
        int threadCount = 50;
        Logger[] threadLoggers = new Logger[threadCount];
        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++) {
            final int index = i;
            threads[i] = new Thread(() -> {
                threadLoggers[index] = Logger.getInstance();
            });
            threads[i].start();
        }

        for (int i = 0; i < threadCount; i++) {
            threads[i].join();
        }

        System.out.println(threadCount + " threads requested the instance concurrently.");
        boolean mismatch = false;
        Logger reference = threadLoggers[0];
        for (int i = 1; i < threadCount; i++) {
            if (threadLoggers[i] != reference) {
                mismatch = true;
                break;
            }
        }
        
        System.out.println("Mismatch detected? " + mismatch);
        if (!mismatch) {
            System.out.println("PASS\n");
        } else {
            System.out.println("FAIL\n");
            allPassed = false;
        }

        if (allPassed) {
            System.out.println("ALL TESTS PASSED: Logger is a correctly implemented Singleton.");
        } else {
            System.out.println("SOME TESTS FAILED.");
        }
    }
}

class Logger {
    private static volatile Logger instance;
    private List<String> logs;

    private Logger() {
        System.out.println("[Logger] Initializing the single Logger instance...");
        logs = new ArrayList<>();
    }

    public static Logger getInstance() {
        if (instance == null) {
            synchronized (Logger.class) {
                if (instance == null) {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }

    public void log(String message) {
        String entry = "[" + LocalDateTime.now().toString() + "] " + message;
        System.out.println(entry);
        logs.add(entry);
    }
    
    public int getLogCount() {
        return logs.size();
    }
}
