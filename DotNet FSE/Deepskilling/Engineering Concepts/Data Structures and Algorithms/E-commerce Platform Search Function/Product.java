/**
 * Represents a product in the E-commerce platform.
 * Implements Comparable to allow sorting by Product ID, which is a prerequisite for Binary Search.
 */
public class Product implements Comparable<Product> {
    private final int productId;
    private final String productName;
    private final String category;

    public Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    public int getProductId() { return productId; }
    public String getProductName() { return productName; }
    public String getCategory() { return category; }

    @Override
    public int compareTo(Product other) {
        // Essential for Arrays.sort() to arrange products by ID in ascending order
        return Integer.compare(this.productId, other.productId);
    }

    @Override
    public String toString() {
        return String.format("Product [ID=%d, Name='%s', Category='%s']", productId, productName, category);
    }
}
