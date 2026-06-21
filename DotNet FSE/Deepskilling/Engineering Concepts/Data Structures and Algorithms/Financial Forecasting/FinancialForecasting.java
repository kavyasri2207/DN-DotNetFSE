public class FinancialForecasting {

    // 2. Setup & 3. Implementation: Recursive method to calculate future value
    public static double calculateFutureValue(double presentValue, double growthRate, int periods) {
        // Base Case: If no more periods are left, the future value is exactly the present value
        if (periods == 0) {
            return presentValue;
        }
        
        // Recursive Case: Calculate the value for the next period, and decrement the periods left
        // Formula: FV = PV * (1 + rate)
        double nextValue = presentValue * (1 + growthRate);
        return calculateFutureValue(nextValue, growthRate, periods - 1);
    }

    public static void main(String[] args) {
        System.out.println("--- Financial Forecasting Test ---\n");

        double initialInvestment = 1000.0; // $1,000 starting value
        double annualGrowthRate = 0.05;    // 5% growth rate
        int years = 10;                    // Predict for 10 years

        System.out.printf("Initial Value: $%.2f%n", initialInvestment);
        System.out.printf("Growth Rate: %.0f%%%n", annualGrowthRate * 100);
        System.out.printf("Time Periods: %d years%n%n", years);

        double futureValue = calculateFutureValue(initialInvestment, annualGrowthRate, years);

        System.out.printf("Predicted Future Value: $%.2f%n", futureValue);
        System.out.println("\nSUCCESS: Recursive forecasting algorithm executed perfectly.");
    }
}
