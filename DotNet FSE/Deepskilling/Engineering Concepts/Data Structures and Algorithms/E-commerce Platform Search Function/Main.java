import java.util.Arrays;

/**
 * Main execution class to demonstrate and test the E-commerce search functionality.
 */
public class Main {
    public static void main(String[] args) {
        System.out.println("==================================================");
        System.out.println("   E-Commerce Platform Search Algorithm Testing   ");
        System.out.println("==================================================\n");

        // 1. Initialize E-commerce Product Database (Array)
        Product[] inventory = {
            new Product(105, "Wireless Mouse", "Electronics"),
            new Product(101, "Mechanical Keyboard", "Electronics"),
            new Product(109, "Gaming Monitor", "Electronics"),
            new Product(102, "Office Chair", "Furniture"),
            new Product(107, "Desk Lamp", "Furniture")
        };

        int targetId = 107; 
        System.out.println("[TARGET] Searching for Product ID: " + targetId + "\n");

        // ---------------------------------------------------------
        // 2. Execute Linear Search
        // ---------------------------------------------------------
        System.out.println("--- Executing Linear Search ---");
        System.out.println(">> Time Complexity: O(n) | Space Complexity: O(1)");
        long linearStartTime = System.nanoTime();
        Product linearResult = SearchAlgorithms.linearSearch(inventory, targetId);
        long linearEndTime = System.nanoTime();
        
        if (linearResult != null) {
            System.out.println("SUCCESS: Found " + linearResult);
        } else {
            System.out.println("FAILED: Product not found.");
        }
        System.out.println("Time Elapsed: " + (linearEndTime - linearStartTime) + " ns\n");


        // ---------------------------------------------------------
        // 3. Execute Binary Search
        // ---------------------------------------------------------
        System.out.println("--- Executing Binary Search ---");
        System.out.println(">> Time Complexity: O(log n) | Space Complexity: O(1)");
        System.out.println("Sorting inventory array to prepare for Binary Search (Sort Time: O(n log n))...");
        Arrays.sort(inventory); 
        
        long binaryStartTime = System.nanoTime();
        Product binaryResult = SearchAlgorithms.binarySearch(inventory, targetId);
        long binaryEndTime = System.nanoTime();

        if (binaryResult != null) {
            System.out.println("SUCCESS: Found " + binaryResult);
        } else {
            System.out.println("FAILED: Product not found.");
        }
        System.out.println("Time Elapsed: " + (binaryEndTime - binaryStartTime) + " ns\n");
        
        System.out.println("==================================================");
        System.out.println("                 TESTING COMPLETE                 ");
        System.out.println("==================================================");
    }
}
