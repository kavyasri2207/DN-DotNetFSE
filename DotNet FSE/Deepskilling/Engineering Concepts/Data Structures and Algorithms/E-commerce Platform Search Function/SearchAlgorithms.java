/**
 * Utility class containing search algorithms optimized for the E-commerce platform.
 */
public class SearchAlgorithms {

    /**
     * Performs a Linear Search to find a product by its ID.
     * 
     * Time Complexity: 
     *  - Best Case: O(1) (Target is the first element)
     *  - Average Case: O(n)
     *  - Worst Case: O(n) (Target is at the end or not present)
     * Space Complexity: O(1) (No additional memory used)
     * 
     * @param products Array of products (unsorted or sorted).
     * @param targetId The Product ID to search for.
     * @return The Product if found, otherwise null.
     */
    public static Product linearSearch(Product[] products, int targetId) {
        if (products == null) return null;
        
        for (Product product : products) {
            if (product.getProductId() == targetId) {
                return product; 
            }
        }
        return null; 
    }

    /**
     * Performs a Binary Search to find a product by its ID.
     * IMPORTANT: The provided array MUST be sorted by Product ID prior to invocation.
     * 
     * Time Complexity:
     *  - Best Case: O(1) (Target is exactly in the middle)
     *  - Average Case: O(log n)
     *  - Worst Case: O(log n)
     * Space Complexity: O(1) (Iterative approach uses constant memory overhead)
     * 
     * @param products A SORTED array of products.
     * @param targetId The Product ID to search for.
     * @return The Product if found, otherwise null.
     */
    public static Product binarySearch(Product[] products, int targetId) {
        if (products == null) return null;

        int left = 0;
        int right = products.length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            int midId = products[mid].getProductId();

            if (midId == targetId) {
                return products[mid]; 
            }
            if (midId < targetId) {
                left = mid + 1; 
            } else {
                right = mid - 1; 
            }
        }
        return null; 
    }
}
