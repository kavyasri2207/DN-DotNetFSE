public class Main {
    public static void main(String[] args) {
        // 4. Test the Singleton Implementation
        System.out.println("--- Testing the Singleton Pattern ---");
        
        // Attempt to retrieve two instances of the Logger
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        // Use the logger functionality
        logger1.log("This is the first log message.");
        logger2.log("This is the second log message.");

        // Verify that only one instance of Logger is created across the application
        if (logger1 == logger2) {
            System.out.println("\nSUCCESS: Singleton Pattern is working correctly!");
            System.out.println("Both 'logger1' and 'logger2' point to the exact same instance in memory.");
        } else {
            System.out.println("\nFAILURE: Singleton Pattern failed. Different instances exist.");
        }
    }
}
