public class Main {
    public static void main(String[] args) {
        System.out.println("--- Factory Method Pattern Test ---\n");

        // 1. Create a Word Document using its Factory
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document wordDoc = wordFactory.createDocument();
        wordDoc.open();
        wordDoc.save();
        wordDoc.close();
        System.out.println();

        // 2. Create a PDF Document using its Factory
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdfDoc = pdfFactory.createDocument();
        pdfDoc.open();
        pdfDoc.save();
        pdfDoc.close();
        System.out.println();

        // 3. Create an Excel Document using its Factory
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excelDoc = excelFactory.createDocument();
        excelDoc.open();
        excelDoc.save();
        excelDoc.close();

        System.out.println("\nALL TESTS PASSED: Documents created successfully using Factory Method.");
    }
}
