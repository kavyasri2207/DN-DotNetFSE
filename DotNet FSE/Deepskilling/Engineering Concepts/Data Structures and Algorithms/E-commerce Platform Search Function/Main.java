import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        System.out.println("--- E-commerce Search Functionality Test ---\n");

        // 1. Setup: Store products in an array
        Product[] products = {
            new Product(105, "Wireless Mouse", "Electronics"),
            new Product(101, "Mechanical Keyboard", "Electronics"),
            new Product(109, "Gaming Monitor", "Electronics"),
            new Product(102, "Office Chair", "Furniture"),
            new Product(107, "Desk Lamp", "Furniture")
        };

        int targetId = 107; // Searching for "Desk Lamp"

        // 2. Linear Search Test (Works on unsorted array)
        System.out.println("Starting Linear Search for Product ID: " + targetId);
        Product linearResult = SearchAlgorithms.linearSearch(products, targetId);
        if (linearResult != null) {
            System.out.println("Found via Linear Search: " + linearResult);
        } else {
            System.out.println("Product not found via Linear Search.");
        }

        System.out.println("\n------------------------------------------------\n");

        // 3. Binary Search Test (REQUIRES sorted array)
        System.out.println("Sorting array for Binary Search...");
        Arrays.sort(products); // Sorts based on the compareTo method in Product class (by productId)
        
        System.out.println("Starting Binary Search for Product ID: " + targetId);
        Product binaryResult = SearchAlgorithms.binarySearch(products, targetId);
        if (binaryResult != null) {
            System.out.println("Found via Binary Search: " + binaryResult);
        } else {
            System.out.println("Product not found via Binary Search.");
        }
    }
}
