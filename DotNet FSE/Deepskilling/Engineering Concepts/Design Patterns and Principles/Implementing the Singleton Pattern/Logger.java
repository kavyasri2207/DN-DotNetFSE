import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Logger {
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
