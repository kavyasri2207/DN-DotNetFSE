// Ensure the DOM is fully loaded before executing jQuery code
$(document).ready(function () {

    // ============================================
    // Exercise 1: jQuery Library Inclusion
    // ============================================
    // Bonus: Log the <p> element that says "Hello World!"
    const helloText = $('#hello').text();
    console.log("Exercise 1 Output:", helloText);

    // ============================================
    // Exercise 2: Selecting Elements
    // ============================================
    // Change the text of the <h1>
    $('#mainTitle').text("Updated Title using jQuery");

    // Hide one of the <p> elements when the button is clicked
    $('#hideParaBtn').click(function () {
        // Hiding the first paragraph specifically, leaving the second paragraph visible
        $('.ex2-para').first().hide();
    });

    // ============================================
    // Exercise 3: Use of Common Methods
    // ============================================
    $('#btnHide').click(function () {
        $('.box').hide();
    });

    $('#btnShow').click(function () {
        $('.box').show();
    });

    $('#btnFadeOut').click(function () {
        $('.box').fadeOut();
    });

    $('#btnFadeIn').click(function () {
        $('.box').fadeIn();
    });

    $('#btnToggle').click(function () {
        $('.box').toggle();
    });

    // Bonus: Chain methods like .slideUp().delay(1000).slideDown()
    $('#btnChain').click(function () {
        $('.box').slideUp(500).delay(1000).slideDown(500);
    });

    // ============================================
    // Exercise 4: DOM Manipulation
    // ============================================
    // Take the value from the input, create new <li>, append to <ul>
    $('#itemForm').submit(function (e) {
        e.preventDefault(); // Prevent page refresh
        
        const inputValue = $('#itemInput').val();
        if (inputValue.trim() !== "") {
            const newListItem = $('<li></li>').text(inputValue);
            $('#itemList').append(newListItem);
            $('#itemInput').val(""); // Clear input field
        }
    });

    // Add a "Remove All" button that empties the <ul>
    $('#removeAllBtn').click(function () {
        $('#itemList').empty();
    });

    // ============================================
    // Exercise 5: Handling User Interactions
    // ============================================
    // Change background to red on click, white on double-click
    $('#colorBtn').click(function () {
        $('#colorBox').css('background-color', 'red');
    });

    $('#colorBtn').dblclick(function () {
        $('#colorBox').css('background-color', 'white');
    });

    // ============================================
    // Exercise 6: Mouse and Keyboard Events
    // ============================================
    const $eventDiv = $('#eventDiv');
    const $eventStatus = $('#eventStatus');

    // .click()
    $eventDiv.click(function () {
        $eventStatus.text("Event: click triggered. Border changed.");
        $(this).css('border', '3px solid #f39c12');
    });

    // .dblclick()
    $eventDiv.dblclick(function () {
        $eventStatus.text("Event: dblclick triggered. Text size increased.");
        $(this).css('font-size', '1.5em');
    });

    // .mouseenter()
    $eventDiv.mouseenter(function () {
        $eventStatus.text("Event: mouseenter triggered. Background color changed.");
        $(this).css('background-color', '#dff9fb');
    });

    // .mouseleave()
    $eventDiv.mouseleave(function () {
        $eventStatus.text("Event: mouseleave triggered. Reverted styling.");
        $(this).css({
            'background-color': 'white',
            'border': '2px solid #bdc3c7',
            'font-size': '1em'
        });
    });

    // .keypress() on an input field
    $('#eventInput').keypress(function (e) {
        $eventStatus.text("Event: keypress triggered. Key code: " + e.which);
    });

});
