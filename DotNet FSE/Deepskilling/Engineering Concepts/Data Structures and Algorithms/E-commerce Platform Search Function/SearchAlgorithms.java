public class SearchAlgorithms {

    // Linear Search Implementation
    // Time Complexity: O(n)
    public static Product linearSearch(Product[] products, int targetId) {
        for (Product product : products) {
            if (product.getProductId() == targetId) {
                return product; // Product found
            }
        }
        return null; // Product not found
    }

    // Binary Search Implementation
    // Time Complexity: O(log n)
    // Note: The array 'products' MUST be sorted by productId before calling this method.
    public static Product binarySearch(Product[] products, int targetId) {
        int left = 0;
        int right = products.length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            int midId = products[mid].getProductId();

            if (midId == targetId) {
                return products[mid]; // Product found
            }
            if (midId < targetId) {
                left = mid + 1; // Target is in the right half
            } else {
                right = mid - 1; // Target is in the left half
            }
        }
        return null; // Product not found
    }
}
